// QCovid® Calculation Engine is Copyright © 2020 Oxford University Innovation Limited.
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
// 
// PLEASE NOTE:
// In its compiled form, QCovid@ Calculation Engine is a Class I Medical Device and
// is covered by the Medical Device Regulations 2002 (as amended).
// 
// Modification of the source code and subsequently placing that modified code on the market
// may make that person/entity a legal manufacturer of a medical device and so
// subject to the requirements listed in Medical Device Regulations 2002 (as amended).
// 
// Failure to comply with these regulations (for example, failure to comply with the relevant
// registration requirements or failure to meet the relevant essential requirements)
// may result in prosecution and a penalty of an unlimited fine and/or 6 months’ imprisonment.
// 
// This source code version of QCovid® Calculation Engine is provided as is, and
// has not been certified for clinical use, and must not be used for supporting or informing clinical decision-making.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using QCovid.RiskCalculator.Exceptions;

namespace QCovid.RiskCalculator.CodeMapping.Internal
{
    internal class MedicalCodeRepo : IMedicalCodeRepo, IDisposable
    {
        private readonly DbConnection _dbConnection;
        private readonly bool _ownsConnection;

        private readonly QCovidErrorCode? _overrideErrorCode;

        public MedicalCodeRepo(Func<DbConnection> newConnectionFactory)
        {
            _dbConnection = newConnectionFactory();

            _ownsConnection = true;
            try
            {
                _dbConnection.Open();
                _overrideErrorCode = ValidateDatabase() ? null : QCovidErrorCode.IncorrectMedicalCodeDatabaseVersion;
            }
            catch
            {
                _overrideErrorCode = QCovidErrorCode.CouldNotConnectToMedicalCodeDatabase;
            }
        }

        public MedicalCodeRepo(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;

            _ownsConnection = false;

            _overrideErrorCode = ValidateDatabase() ? null : QCovidErrorCode.IncorrectMedicalCodeDatabaseVersion;
        }

        public void Dispose()
        {
            if (_ownsConnection)
            {
                _dbConnection.Dispose();
            }
        }

        public MedicalCodeToCodeGroupMappingResult GetCodeGroupIdsFromMedicalCodes(IEnumerable<MedicalCodeInstance> medicalCodes)
        {
            if (_overrideErrorCode != null)
            {
                return new MedicalCodeToCodeGroupMappingResult(_overrideErrorCode);
            }

            try
            {
                var results = new List<CodeGroupInstance>();
                var notFound = new List<MedicalCodeInstance>();

                var byType = medicalCodes.GroupBy(c => c.CodeType);

                foreach (IGrouping<CodeType, MedicalCodeInstance> grouping in byType)
                {
                    var lookup = GetCodeGroupIdsFromInputCodes(grouping.Key, grouping.Select(c => c.Code));

                    foreach (MedicalCodeInstance inputCode in grouping)
                    {
                        if (lookup.Contains(inputCode.Code))
                        {
                            results.AddRange(lookup[inputCode.Code].Select(id => new CodeGroupInstance(inputCode.Date, id, inputCode.Code, inputCode.CodeType)));
                        }
                        else
                        {
                            notFound.Add(inputCode);
                        }
                    }
                }

                return new MedicalCodeToCodeGroupMappingResult(results, notFound);
            }
            catch
            {
                return new MedicalCodeToCodeGroupMappingResult(QCovidErrorCode.CouldNotQueryMedicalCodeDatabase);
            }
        }

        private ILookup<string, int> GetCodeGroupIdsFromInputCodes(CodeType codeType, IEnumerable<string> codes)
        {
            // we don't know the db implementation - 500 is below all limits I'm aware of
            // though what individual has so many snomed codes anyway?
            const int subsetSize = 500;

            var results = new Dictionary<string, List<int>>();

            DbCommand getByCode = _dbConnection.CreateCommand();
            var parameters = new List<string>();
            var i = 0;
            foreach (var code in codes)
            {
                DbParameter codeParam = getByCode.CreateParameter();
                codeParam.ParameterName = $"@A{i}";
                codeParam.Value = code.ToUpperInvariant();
                codeParam.DbType = DbType.String;

                getByCode.Parameters.Add(codeParam);
                parameters.Add(codeParam.ParameterName);

                i++;
                if (i > subsetSize)
                {
                    RunGetCommand(getByCode, codeType, parameters, results);

                    getByCode = _dbConnection.CreateCommand();
                    parameters = new List<string>();
                    i = 0;
                }
            }

            RunGetCommand(getByCode, codeType, parameters, results);

            return results
                .SelectMany(kvp => kvp.Value.Select(id => new {Code = kvp.Key, CodeGroupId = id}))
                .ToLookup(x => x.Code, x => x.CodeGroupId, StringComparer.InvariantCultureIgnoreCase);
        }

        private bool ValidateDatabase()
        {
            try
            {
                DbCommand getCount = _dbConnection.CreateCommand();

                // check that the table and columns exist
                getCount.CommandText =
                    $"SELECT Overall, InputsSpecification, CodesDatabase FROM {MedicalCodeDbConstants.MedicalCodesVersionTable}";

                var foundVersion = "";
                var foundSpecVersion = -1;
                var foundSourceVersion = -1;

                using var readAll = getCount.ExecuteReader();
                while (readAll.Read())
                {
                    foundVersion = readAll.GetString(0);
                    foundSpecVersion = readAll.GetInt32(1);
                    foundSourceVersion = readAll.GetInt32(2);
                }

                return foundVersion == MedicalCodeDbConstants.MedicalCodesOutputVersion &&
                       foundSpecVersion == MedicalCodeDbConstants.MedicalCodesSpecVersion && 
                       foundSourceVersion == MedicalCodeDbConstants.MedicalCodesSourceVersion;
            }
            catch
            {
                return false;
            }
        }

        private void RunGetCommand(DbCommand command, CodeType codeType, IEnumerable<string> parameterNames,
            Dictionary<string, List<int>> resultDict)
        {
            var paramString = string.Join(", ", parameterNames);

            if (string.IsNullOrEmpty(paramString))
            {
                return;
            }

            DbParameter typeParam = command.CreateParameter();
            typeParam.ParameterName = "@CodeType";
            typeParam.Value = codeType.Value;
            typeParam.DbType = DbType.Int32;
            command.Parameters.Add(typeParam);

            command.CommandText =
                $"SELECT Code, CodeGroup_Id FROM {MedicalCodeDbConstants.MedicalCodesMainTable} WHERE CodeType_Id = @CodeType AND Code IN ({paramString})";

            using DbDataReader readAll = command.ExecuteReader();
            while (readAll.Read())
            {
                var code = readAll.GetString(0);
                var codeTypeId = readAll.GetInt32(1);

                if (!resultDict.ContainsKey(code))
                {
                    resultDict[code] = new List<int>();
                }

                resultDict[code].Add(codeTypeId);
            }
        }
    }
}
