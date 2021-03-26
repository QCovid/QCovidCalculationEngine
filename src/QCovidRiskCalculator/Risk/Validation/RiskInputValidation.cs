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
using System.Linq;
using CRStandardDefinitions;
using QCovid.RiskCalculator.Exceptions;
using QCovid.RiskCalculator.Risk.Input;

namespace QCovid.RiskCalculator.Risk.Validation
{
    /// <inheritdoc/>
    public class RiskInputValidation : IRiskInputValidation
    {
        // no provided constants for age
        private static readonly ValidationRange<int> ValidAgeRange = new ValidationRange<int>(19, 100);

        /// <inheritdoc/>
        public ValidationRange<int> GetValidAgeRangeYears()
        {
            return ValidAgeRange;
        }

        /// <inheritdoc/>
        public ValidationRange<Date> GetValidDateOfBirthRange(Date now)
        {
            DateTime dateTime = now.Value;

            var latest = new Date(dateTime.AddYears(-ValidAgeRange.MinimumInclusive));
            var earliest = new Date(dateTime.AddYears(-ValidAgeRange.MaximumInclusive - 1).AddDays(1));

            return new ValidationRange<Date>(earliest, latest);
        }

        private static readonly ValidationRange<double> ValidBmiRange = new ValidationRange<double>(Constants.minBmi, Constants.maxBmi);

        /// <inheritdoc/>
        public ValidationRange<double> GetValidBmiRange()
        {
            return ValidBmiRange;
        }

        /// <inheritdoc/>
        public IReadOnlyList<QCovidErrorCode> ValidateInputs(RiskInput input)
        {
            if (FindAnyNull(input))
            {
                return new[] { QCovidErrorCode.NullInput };
            }

            var list = new List<QCovidErrorCode>();

            var ageRange = GetValidAgeRangeYears();

            if (input.Age.Years < ageRange.MinimumInclusive)
            {
                list.Add(QCovidErrorCode.AgeBelowMinimumValue);
            }
            else if (input.Age.Years > ageRange.MaximumInclusive)
            {
                list.Add(QCovidErrorCode.AgeAboveMaximumValue);
            }

            if (input.Bmi.ErrorCode != null)
            {
                list.Add(input.Bmi.ErrorCode);
            }

            var bmiRange = GetValidBmiRange();
            
            if (input.Bmi.BodyMassIndex < bmiRange.MinimumInclusive)
            {
                list.Add(QCovidErrorCode.BmiBelowMinimumValue);
            }
            else if (input.Bmi.BodyMassIndex > bmiRange.MaximumInclusive)
            {
                list.Add(QCovidErrorCode.BmiAboveMaximumValue);
            }

            if (input.EncryptedTownsendScore.ErrorCode != null)
            {
                list.Add(input.EncryptedTownsendScore.ErrorCode);
            }

            return list;
        }

        private bool FindAnyNull(RiskInput? input)
        {
            // doing this via reflection would be nice
            // but c# does not expose nullable reference types in a nice way at compile time

            // ReSharper disable ConstantConditionalAccessQualifier only true if people are sensible
            var inputs = new object?[]
            {
                // only need to check endmost properties
                // input,
                input?.Age,
                input?.Bmi,
                input?.Sex,
                input?.EncryptedTownsendScore,
                input?.HousingCategory,
                input?.Ethnicity,
                //input?.ClinicalInformation,
                input?.ClinicalInformation?.Diabetes,
                input?.ClinicalInformation?.ChronicKidneyDisease,
                input?.ClinicalInformation?.SickleCellOrSevereCombinedImmunodeficiencySyndrome,
                input?.ClinicalInformation?.LearningDisabilityOrDownsSyndrome,
                //input?.ClinicalInformation?.CancerTreatmentsAndImmunoSuppressants,
                input?.ClinicalInformation?.CancerTreatmentsAndImmunoSuppressants?.ChemotherapyGroup,
                input?.ClinicalInformation?.RespiratoryProblems,
                input?.ClinicalInformation?.HeartOrCirculationProblems,
                input?.ClinicalInformation?.NeurologicalProblems,
                input?.ClinicalInformation?.OtherConditions
            };
            // ReSharper restore ConstantConditionalAccessQualifier

            return inputs.Contains(null);
        }
    }
}
