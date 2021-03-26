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
using System.Data.Common;
using System.Linq;
using QCovid.RiskCalculator.BodyMassIndex;
using QCovid.RiskCalculator.CodeMapping.Internal;
using QCovid.RiskCalculator.Exceptions;
using QCovid.RiskCalculator.Risk.Input;
using QCovid.RiskCalculator.Townsend;

namespace QCovid.RiskCalculator.CodeMapping
{
    /// <summary>
    /// Implements <see cref="IMedicalCodesToRiskInputConverter"/> by checking the provided codes against the medical codes sql database
    /// and performing additional logic to determine which codes are in date and have priority
    /// </summary>
    public class MedicalCodesToRiskInputConverter : IMedicalCodesToRiskInputConverter, IDisposable
    {
        private readonly MedicalCodeRepo _repo;
        private readonly CodeGroupMapper _codeMapper = new CodeGroupMapper();

        /// <summary>
        /// Construct a CodesToInputConverter with a function to create a new database connection.
        /// Will close created db connection on dispose.
        /// </summary>
        /// <param name="licenceKey"></param>
        /// <param name="newConnectionFactory"></param>
        /// <exception cref="LicenceKeyException"></exception>
        public MedicalCodesToRiskInputConverter(string licenceKey, Func<DbConnection> newConnectionFactory)
        {
            LicenceKeyException.ValidateLicenceKeyOrThrow(licenceKey);
            _repo = new MedicalCodeRepo(newConnectionFactory);
        }

        /// <summary>
        /// Construct a CodesToInputConverter with a pre-existing database connection.
        /// Will not close db connection on dispose.
        /// </summary>
        /// <param name="licenceKey"></param>
        /// <param name="dbConnection"></param>
        /// <exception cref="LicenceKeyException"></exception>
        public MedicalCodesToRiskInputConverter(string licenceKey, DbConnection dbConnection)
        {
            LicenceKeyException.ValidateLicenceKeyOrThrow(licenceKey);
            _repo = new MedicalCodeRepo(dbConnection);
        }

        /// <inheritdoc />
        public MedicalCodeMappingResult CreateRiskInputFromMedicalCodes(Date processingReferenceDate, IEnumerable<MedicalCodeInstance> codes,
            Age age, Sex sex, EncryptedTownsendScore townsendScore, Bmi bmi)
        {
            // ReSharper disable once ConstantConditionalAccessQualifier can't assume users are sensible
            var enumeratedCodes = codes?.ToArray();

            if (AreAnyNull(processingReferenceDate, enumeratedCodes, age, sex, townsendScore, bmi))
            {
                // some of these may be null, but risk inputs own validation will catch them
                return new MedicalCodeMappingResult(RiskInput.CreateInitialRiskInput(age, sex, bmi, townsendScore), new [] {QCovidErrorCode.NullInput});
            }

            var errors = new List<QCovidErrorCode>();

            MedicalCodeToCodeGroupMappingResult medicalCodeToCodeGroup = _repo.GetCodeGroupIdsFromMedicalCodes(enumeratedCodes!);

            if (medicalCodeToCodeGroup.ErrorCode != null)
            {
                errors.Add(medicalCodeToCodeGroup.ErrorCode);
            }

            CodeGroupMapperResult codeGroupToRiskInput = _codeMapper.Process(medicalCodeToCodeGroup.CodeGroups, age,
                sex, bmi, townsendScore, processingReferenceDate);
            
            if (errors.Any(e => e.IsFatal))
            {
                return new MedicalCodeMappingResult(codeGroupToRiskInput.RiskInput, errors);
            }
            else
            {
                var recognisedInputCodes = codeGroupToRiskInput.RecognisedCodeGroupInstances.Cast<MedicalCodeInstance>();

                var unrecognisedInputCodes = medicalCodeToCodeGroup.NotFoundMedicalCodes.Concat(
                    medicalCodeToCodeGroup.CodeGroups
                        .Where(cg => !codeGroupToRiskInput.RecognisedCodeGroupInstances.Contains(cg))
                );

                return new MedicalCodeMappingResult(codeGroupToRiskInput.RiskInput, recognisedInputCodes, unrecognisedInputCodes, errors);
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _repo.Dispose();
        }

        private bool AreAnyNull(Date? processingReferenceDate, IEnumerable<MedicalCodeInstance?>? codes, Age? age, Sex? sex, EncryptedTownsendScore? townsendScore, Bmi? bmi)
        {
            return processingReferenceDate == null ||
                   codes == null ||
                   // ReSharper disable ConditionIsAlwaysTrueOrFalse can't assume users are sensible
                   codes.Any(c => c?.Date == null || c.Code == null || c.CodeType == null) ||
                   // ReSharper restore ConditionIsAlwaysTrueOrFalse
                   age == null ||
                   sex == null ||
                   townsendScore == null ||
                   bmi == null;
        }
    }
}
