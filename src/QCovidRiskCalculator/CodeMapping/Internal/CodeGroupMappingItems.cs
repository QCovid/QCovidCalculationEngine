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

using QCovid.RiskCalculator.CodeMapping.Internal.CodeGroupMappings;
using QCovid.RiskCalculator.Risk.Input;

namespace QCovid.RiskCalculator.CodeMapping.Internal
{
    // <summary>
    // The list of code group => action mappings, e.g. "if code group 24 is found, then AtrialFibrillation should be set to true"
    // </summary>
    internal class CodeGroupMappingItems
    {
        // <summary>
        // Used as a compile-time check that we have the correct number of items
        // </summary>
        private const int ItemCount = 36 /*items in inputs spec spreadsheet between Age and Postcode */ - 1 /*BMI*/;

        // ReSharper disable once RedundantExplicitArraySize constant is used as a check
        public static CodeGroupMapping[] Items = new CodeGroupMapping[ItemCount]
        {
            new NInstancesInPeriodBoolMapping<CancerTreatmentsAndImmunoSuppressants>(new [] { 938, 939, 940, 941 }, 4, 6, ci => ci.CancerTreatmentsAndImmunoSuppressants, p => p.PrescribedImmunoSuppressants),
            new NInstancesInPeriodBoolMapping<RespiratoryProblems>(new [] { 1657, 7573 }, 4, 6, ci => ci.RespiratoryProblems, p => p.TakingAntiLeukotrieneOrLaba),
            new NInstancesInPeriodBoolMapping<CancerTreatmentsAndImmunoSuppressants>(new [] { 7588 }, 4, 6, ci => ci.CancerTreatmentsAndImmunoSuppressants, p => p.PrescribedOralSteroids),
            new SimpleBoolMapping<HeartOrCirculationProblems>(new[] { 24, 11204 }, ci => ci.HeartOrCirculationProblems, p => p.AtrialFibrillation),
            new SimpleBoolMapping<HeartOrCirculationProblems>(new[] { 25, 1936 }, ci => ci.HeartOrCirculationProblems, p => p.HeartFailure),
            new SimpleBoolMapping<RespiratoryProblems>(new [] { 7557, 1926 }, ci => ci.RespiratoryProblems, p => p.Asthma),
            new SimpleBoolMapping<CancerTreatmentsAndImmunoSuppressants>(new [] { 58, 2004 }, ci => ci.CancerTreatmentsAndImmunoSuppressants, p => p.CancerOfBloodOrBoneMarrow),
            new SimpleBoolMapping<NeurologicalProblems>(new [] { 7579, 11212 }, ci => ci.NeurologicalProblems, p => p.CerebralPalsy),
            new SimpleBoolMapping<HeartOrCirculationProblems>(new[] { 19, 1928 }, ci => ci.HeartOrCirculationProblems, p => p.CoronaryHeartDisease),
            new SimpleBoolMapping<OtherConditions>(new [] { 7792, 11210 }, ci => ci.OtherConditions, p => p.LiverCirrhosis),
            new SimpleBoolMapping<HeartOrCirculationProblems>(new[] { 7549, 7603, 7561 }, ci => ci.HeartOrCirculationProblems, p => p.CongenitalHeartProblem),
            new SimpleBoolMapping<RespiratoryProblems>(new [] { 29, 1937 }, ci => ci.RespiratoryProblems, p => p.Copd),
            new SimpleBoolMapping<NeurologicalProblems>(new [] { 35, 1932 }, ci => ci.NeurologicalProblems, p => p.Dementia),
            new SimpleBoolMapping<NeurologicalProblems>(new [] { 30, 1966 }, ci => ci.NeurologicalProblems, p => p.Epilepsy),
            new SimpleBoolMapping<OtherConditions>(new [] { 2075, 2735 }, ci => ci.OtherConditions, p => p.PriorFractureOfHipWristSpineHumerus),
            new SimpleBoolMapping<NeurologicalProblems>(new [] { 3224, 1822, 2984, 38, 3225, 11193, 11208, 11194 }, ci => ci.NeurologicalProblems, p => p.MotorNeuroneDiseaseOrMultipleSclerosisOrMyaestheniaOrHuntingtonsChorea),
            new SimpleBoolMapping<NeurologicalProblems>(new [] { 37, 11199 }, ci => ci.NeurologicalProblems, p => p.ParkinsonsDisease),
            new SimpleBoolMapping<RespiratoryProblems>(new [] { 6502, 7608, 11211, /* does not match spec! I think spec has a typo */ 11197 }, ci => ci.RespiratoryProblems, p => p.PulmonaryHypertensionOrFibrosis),
            new SimpleBoolMapping<RespiratoryProblems>(new [] { 303, 1829, 6503, 11198, 11196, 11195 }, ci => ci.RespiratoryProblems, p => p.CysticFibrosisBronchiectasisAlveolitis),
            new SimpleBoolMapping<HeartOrCirculationProblems>(new[] { 27, 3860 }, ci => ci.HeartOrCirculationProblems, p => p.PeripheralVascularDisease),
            new SimpleBoolMapping<OtherConditions>(new [] { 2218, 11209 }, ci => ci.OtherConditions, p => p.RheumatoidArthritisOrSle),
            new SimpleBoolMapping<RespiratoryProblems>(new [] { 51, 222, 2021, 2023 }, ci => ci.RespiratoryProblems, p => p.LungOrOralCancer),
            new SimpleBoolMapping<OtherConditions>(new [] { 3187, 2453 }, ci => ci.OtherConditions, p => p.SevereMentalIllness),
            new SimpleBoolMapping<ClinicalInformation>(new[] { 7594, 7729, 11205 }, ci => ci, p => p.SickleCellOrSevereCombinedImmunodeficiencySyndromeViaBool),
            new SimpleBoolMapping<HeartOrCirculationProblems>(new[] { 26, 7941 }, ci => ci.HeartOrCirculationProblems, p => p.StrokeOrTia),

            new DiabetesMapping(new [] 
            { 
                (new [] { 1913, 1940 }, Diabetes.Type1),
                (new [] { 2411, 1931 }, Diabetes.Type2)
            }, p => p.Diabetes),

            new SimpleBoolMapping<HeartOrCirculationProblems>(new [] { 368, 1935 }, ci => ci.HeartOrCirculationProblems, p => p.ThrombosisOrPulmonaryEmbolus),
            //Skipped BMI, which will be handled explicitly
            new ChemotherapyGroupMapping(p => p.ChemotherapyGroup),
            new EthnicityMapping(ri => ri.Ethnicity),

            new MostRecentInstanceEnumMapping<RiskInput, HousingCategory>(new []
            {
                (new [] { 395 }, HousingCategory.NursingOrCareHome),
                (new [] { 7577 }, HousingCategory.Homeless),
            }, ri => ri, p => p.HousingCategory),

            new LearningDisabilityOrDownsSyndromeMapping(new []
            {
                (new [] { 7931, 11207 }, LearningDisabilityOrDownsSyndrome.LearningDisabilityExcludingDowns),
                (new [] { 65, 11200 }, LearningDisabilityOrDownsSyndrome.DownsSyndrome),
            }, p => p.LearningDisabilityOrDownsSyndrome),

            new NInstancesInPeriodBoolMapping<CancerTreatmentsAndImmunoSuppressants>(new [] { 7568 }, 1, 6, ci => ci.CancerTreatmentsAndImmunoSuppressants, p => p.BoneMarrowTransplantInLast6Months),
            new NInstancesInPeriodBoolMapping<CancerTreatmentsAndImmunoSuppressants>(new [] { 2916 }, 1, 6, ci => ci.CancerTreatmentsAndImmunoSuppressants, p => p.RadioTherapyInLast6Months),
            new SimpleBoolMapping<CancerTreatmentsAndImmunoSuppressants>(new [] { 7571 }, ci => ci.CancerTreatmentsAndImmunoSuppressants, p => p.SolidOrganTransplant),
            
            new ChronicKidneyDiseaseMapping(new []
            {
                (new [] { 3082, 11201 }, ChronicKidneyDisease.Ckd3),
                (new [] { 3083, 11202 }, ChronicKidneyDisease.Ckd4),
                (new [] { 3084, 11203 }, ChronicKidneyDisease.Ckd5WithNeitherDialysisNorTransplant),
                (new [] { 2776 }, ChronicKidneyDisease.Ckd5WithDialysis),
                (new [] { 2774 }, ChronicKidneyDisease.Ckd5WithTransplant)
            }, p => p.ChronicKidneyDisease)
        };
    }
}
