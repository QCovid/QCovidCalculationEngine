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

namespace QCovid.RiskCalculator.CodeMapping
{
    /// <summary>
    /// The output of <see cref="IMedicalCodesToRiskInputConverter"/>
    /// </summary>
    public class MedicalCodeMappingResult
    {
        /// <summary>
        /// The Risk Input resulting from the provided medical codes
        /// </summary>
        public RiskInput RiskInput { get; }

        /// <summary>
        /// The list of the medical code instances which were understood by the mapper.
        /// This includes medical codes that were outdated, or overridden by others
        /// </summary>
        public IReadOnlyList<MedicalCodeInstance> RecognisedMedicalCodes { get; }

        /// <summary>
        /// The list of medical code instances which were not understood by the mapper.
        /// This includes both medical codes which were malformed and medical codes which were irrelevant
        /// </summary>
        public IReadOnlyList<MedicalCodeInstance> UnrecognisedMedicalCodes { get; }

        /// <summary>
        /// A list of errors associated with this result.
        /// </summary>
        public IReadOnlyList<QCovidErrorCode> ErrorCodes { get; }

        internal MedicalCodeMappingResult(RiskInput riskInput, IEnumerable<MedicalCodeInstance> recognisedInputCodes, IEnumerable<MedicalCodeInstance> unrecognisedInputCodes, IEnumerable<QCovidErrorCode> errorCodes)
        {
            RiskInput = riskInput;
            RecognisedMedicalCodes = recognisedInputCodes.ToArray();
            UnrecognisedMedicalCodes = unrecognisedInputCodes.ToArray();
            ErrorCodes = errorCodes.ToArray();
        }

        internal MedicalCodeMappingResult(RiskInput riskInput, IEnumerable<QCovidErrorCode> errorCodes)
        {
            RiskInput = riskInput;
            RecognisedMedicalCodes = new MedicalCodeInstance[0];
            UnrecognisedMedicalCodes = new MedicalCodeInstance[0];
            ErrorCodes = errorCodes.ToArray();
        }
    }
}
