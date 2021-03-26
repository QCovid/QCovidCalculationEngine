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

using System.Linq;
using QCovid.RiskCalculator.Exceptions;
using QCovid.RiskCalculator.Risk.Input;
using QCovid.RiskCalculator.Risk.Result;
using QCovid.RiskCalculator.Risk.Validation;
using QCovid.RiskCalculator.Townsend.Internal;

namespace QCovid.RiskCalculator.Risk
{
    /// <summary>
    /// Calculates the QCovid risk report for the patient
    /// </summary>
    public class QCovidRiskCalculator : IQCovidRiskCalculator
    {
        private readonly IRiskInputValidation _validator = new RiskInputValidation();

        /// <summary>
        /// Construct a QCovidRiskCalculator with a provided licence key.
        /// </summary>
        /// <param name="licenceKey"></param>
        /// <exception cref="LicenceKeyException"></exception>
        public QCovidRiskCalculator(string licenceKey)
        {
            LicenceKeyException.ValidateLicenceKeyOrThrow(licenceKey);
        }

        /// <summary>
        /// Create a risk report for the given input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IRiskResult Calculate(RiskInput input)
        {
            try
            {
                var errors = _validator.ValidateInputs(input)
                    .ToList();

                if (errors.Any(e => e.IsFatal))
                {
                    return new RiskResult(input, errors);
                }
                else
                {
                    Ox.QCovid.QCovid core = new Ox.QCovid.QCovid();

                    TownsendScore townsendScore = new TownsendScore(input.EncryptedTownsendScore);

                    Ox.QCovid.QCovid.Result coreResult = core.calculate(
                        input.Sex.CoreValue,
                        input.Age.Years,
                        input.ClinicalInformation.CancerTreatmentsAndImmunoSuppressants.PrescribedImmunoSuppressants,
                        input.ClinicalInformation.RespiratoryProblems.TakingAntiLeukotrieneOrLaba,
                        input.ClinicalInformation.CancerTreatmentsAndImmunoSuppressants.PrescribedOralSteroids,
                        input.ClinicalInformation.HeartOrCirculationProblems.AtrialFibrillation,
                        input.ClinicalInformation.HeartOrCirculationProblems.HeartFailure,
                        input.ClinicalInformation.RespiratoryProblems.Asthma,
                        input.ClinicalInformation.CancerTreatmentsAndImmunoSuppressants.CancerOfBloodOrBoneMarrow,
                        input.ClinicalInformation.NeurologicalProblems.CerebralPalsy,
                        input.ClinicalInformation.HeartOrCirculationProblems.CoronaryHeartDisease,
                        input.ClinicalInformation.OtherConditions.LiverCirrhosis,
                        input.ClinicalInformation.HeartOrCirculationProblems.CongenitalHeartProblem,
                        input.ClinicalInformation.RespiratoryProblems.Copd,
                        input.ClinicalInformation.NeurologicalProblems.Dementia,
                        input.ClinicalInformation.NeurologicalProblems.Epilepsy,
                        input.ClinicalInformation.OtherConditions.PriorFractureOfHipWristSpineHumerus,
                        input.ClinicalInformation.NeurologicalProblems
                            .MotorNeuroneDiseaseOrMultipleSclerosisOrMyaestheniaOrHuntingtonsChorea,
                        input.ClinicalInformation.NeurologicalProblems.ParkinsonsDisease,
                        input.ClinicalInformation.RespiratoryProblems.PulmonaryHypertensionOrFibrosis,
                        input.ClinicalInformation.RespiratoryProblems.CysticFibrosisBronchiectasisAlveolitis,
                        input.ClinicalInformation.HeartOrCirculationProblems.PeripheralVascularDisease,
                        input.ClinicalInformation.OtherConditions.RheumatoidArthritisOrSle,
                        input.ClinicalInformation.RespiratoryProblems.LungOrOralCancer,
                        input.ClinicalInformation.OtherConditions.SevereMentalIllness,
                        input.ClinicalInformation.SickleCellOrSevereCombinedImmunodeficiencySyndrome.CoreValue,
                        input.ClinicalInformation.HeartOrCirculationProblems.StrokeOrTia,
                        input.ClinicalInformation.Diabetes.CoreValue,
                        input.ClinicalInformation.HeartOrCirculationProblems.ThrombosisOrPulmonaryEmbolus,
                        input.Bmi.BodyMassIndex,
                        input.ClinicalInformation.CancerTreatmentsAndImmunoSuppressants.ChemotherapyGroup.CoreValue,
                        input.Ethnicity.CoreValue,
                        input.HousingCategory.CoreValue,
                        input.ClinicalInformation.LearningDisabilityOrDownsSyndrome.CoreValue,
                        input.ClinicalInformation.CancerTreatmentsAndImmunoSuppressants.BoneMarrowTransplantInLast6Months,
                        input.ClinicalInformation.CancerTreatmentsAndImmunoSuppressants.RadioTherapyInLast6Months,
                        input.ClinicalInformation.CancerTreatmentsAndImmunoSuppressants.SolidOrganTransplant,
                        input.ClinicalInformation.ChronicKidneyDisease.CoreValue,
                        townsendScore.Score
                    );

                    // see status3_male or status3_female for status string source
                    if (coreResult.status.StartsWith("estimate:"))
                    {
                        if (!errors.Any())
                        {
                            // an input was out of range and we did not catch it ourselves
                            return new RiskResult(input, new[] { QCovidErrorCode.UnhandledException });
                        }
                    } 
                    else if (coreResult.status != "ok")
                    {
                        // something went wrong
                        errors.Add(QCovidErrorCode.UnhandledException);
                        return new RiskResult(input, errors);
                    }

                    return new RiskResult(input, coreResult, errors);
                }
            }
            catch
            {
                return new RiskResult(input, new[] {QCovidErrorCode.UnhandledException});
            }
        }
    }
}
