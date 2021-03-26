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

using System.Collections.Generic;
using System.Linq;
using QCovid.RiskCalculator.Exceptions;
using QCovid.RiskCalculator.Risk.Input;

namespace QCovid.RiskCalculator.Risk.Result
{
    /// <inheritdoc />
    public class RiskResult : IRiskResult
    {
        /// <summary>
        /// The inputs supplied to the calculation method
        /// </summary>
        public RiskInput Input { get; }

        /// <summary>
        /// Results for the patient
        /// </summary>
        public RiskResultForSubjectType ResultForPatient { get; }

        /// <summary>
        /// Results for the a person with the same age and sex and the patient but without the risk factors
        /// </summary>
        public RiskResultForSubjectType ResultForTypicalPersonSameAgeSex { get; }

        /// <summary>
        /// A list of error codes associated with this result.
        /// </summary>
        public IReadOnlyList<QCovidErrorCode> ErrorCodes { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="resultForPatient"></param>
        /// <param name="resultForTypicalPersonSameAgeSex"></param>
        /// <param name="errorCodes"></param>
        public RiskResult(RiskInput input, RiskResultForSubjectType resultForPatient, RiskResultForSubjectType resultForTypicalPersonSameAgeSex, IEnumerable<QCovidErrorCode>? errorCodes = null)
        {
            Input = input;
            ResultForPatient = resultForPatient;
            ResultForTypicalPersonSameAgeSex = resultForTypicalPersonSameAgeSex;
            ErrorCodes = errorCodes?.ToArray() ?? new QCovidErrorCode[0];
        }

        internal RiskResult(RiskInput input, Ox.QCovid.QCovid.Result coreResult, IEnumerable<QCovidErrorCode> errorCodes)
        {
            Input = input;
            ResultForPatient = new RiskResultForSubjectType(
                RiskResultForOutcomeType.CreateOrReturnNull(coreResult.death_patient_score, coreResult.death_patient_centile),
                RiskResultForOutcomeType.CreateOrReturnNull(coreResult.hospital_patient_score, coreResult.hospital_patient_centile)
            );

            ResultForTypicalPersonSameAgeSex = new RiskResultForSubjectType(
                RiskResultForOutcomeType.CreateOrReturnNull(coreResult.death_typical_score, coreResult.death_typical_centile),
                RiskResultForOutcomeType.CreateOrReturnNull(coreResult.hospital_typical_score, coreResult.hospital_typical_centile)
            );
            ErrorCodes = errorCodes.ToArray();
        }

        internal RiskResult(RiskInput input, IEnumerable<QCovidErrorCode> errorCodes)
        {
            Input = input;
            ResultForPatient = new RiskResultForSubjectType(null, null);
            ResultForTypicalPersonSameAgeSex = new RiskResultForSubjectType(null, null);
            ErrorCodes = errorCodes.ToArray();
        }
    }
}
