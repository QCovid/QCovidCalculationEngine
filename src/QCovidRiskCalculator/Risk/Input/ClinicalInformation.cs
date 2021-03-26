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

namespace QCovid.RiskCalculator.Risk.Input
{
    /// <summary>
    /// A collection on inputs about various relevant diseases, conditions and treatments
    /// </summary>
    public class ClinicalInformation
    {
        /// <summary>
        /// Do you have diabetes?
        /// </summary>
        public Diabetes Diabetes { get; internal set; }

        /// <summary>
        /// Do you have kidney disease?
        /// </summary>
        public ChronicKidneyDisease ChronicKidneyDisease { get; internal set; }

        /// <summary>
        /// Do you have sickle cell disease or severe combined immune deficiency syndromes?
        /// </summary>
        public SickleCellOrSevereCombinedImmunodeficiencySyndrome SickleCellOrSevereCombinedImmunodeficiencySyndrome { get; internal set; }

        /// <summary>
        /// This is a convenience that can be used in place of SickleCellOrSevereCombinedImmunodeficiencySyndrome since there are only two options for that
        /// </summary>
        public bool SickleCellOrSevereCombinedImmunodeficiencySyndromeViaBool 
        {
            get => SickleCellOrSevereCombinedImmunodeficiencySyndrome == SickleCellOrSevereCombinedImmunodeficiencySyndrome.Present;
            internal set => SickleCellOrSevereCombinedImmunodeficiencySyndrome = value ? SickleCellOrSevereCombinedImmunodeficiencySyndrome.Present : SickleCellOrSevereCombinedImmunodeficiencySyndrome.None;
        }

        /// <summary>
        /// Do you have a learning disability or Down's Syndrome?
        /// The most recently recorded value. If someone has a code both for learning disability and Downs, they should be coded as Downs.
        /// </summary>
        public LearningDisabilityOrDownsSyndrome LearningDisabilityOrDownsSyndrome { get; internal set; }

        /// <summary>
        /// Have you had any cancer treatments or are you taking any immuno-suppressants?
        /// </summary>
        public CancerTreatmentsAndImmunoSuppressants CancerTreatmentsAndImmunoSuppressants { get; }
        /// <summary>
        /// Do you have any respiratory problems?
        /// </summary>
        public RespiratoryProblems RespiratoryProblems { get; }
        /// <summary>
        /// Do you have any heart or circulation problems?
        /// </summary>
        public HeartOrCirculationProblems HeartOrCirculationProblems { get; }
        /// <summary>
        /// Do you have any neurological problems?
        /// </summary>
        public NeurologicalProblems NeurologicalProblems { get; }
        /// <summary>
        /// Do you have any of these other conditions?
        /// </summary>
        public OtherConditions OtherConditions { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diabetes"></param>
        /// <param name="chronicKidneyDisease"></param>
        /// <param name="sickleCellOrSevereCombinedImmunodeficiencySyndrome"></param>
        /// <param name="learningDisabilityOrDownsSyndrome"></param>
        /// <param name="cancerTreatmentsAndImmunoSuppressants"></param>
        /// <param name="respiratoryProblems"></param>
        /// <param name="heartOrCirculationProblems"></param>
        /// <param name="neurologicalProblems"></param>
        /// <param name="otherConditions"></param>
        public ClinicalInformation(Diabetes diabetes,
            ChronicKidneyDisease chronicKidneyDisease,
            SickleCellOrSevereCombinedImmunodeficiencySyndrome sickleCellOrSevereCombinedImmunodeficiencySyndrome,
            LearningDisabilityOrDownsSyndrome learningDisabilityOrDownsSyndrome,
            CancerTreatmentsAndImmunoSuppressants cancerTreatmentsAndImmunoSuppressants,
            RespiratoryProblems respiratoryProblems,
            HeartOrCirculationProblems heartOrCirculationProblems,
            NeurologicalProblems neurologicalProblems,
            OtherConditions otherConditions)
        {
            Diabetes = diabetes;
            ChronicKidneyDisease = chronicKidneyDisease;
            SickleCellOrSevereCombinedImmunodeficiencySyndrome = sickleCellOrSevereCombinedImmunodeficiencySyndrome;
            LearningDisabilityOrDownsSyndrome = learningDisabilityOrDownsSyndrome;
            CancerTreatmentsAndImmunoSuppressants = cancerTreatmentsAndImmunoSuppressants;
            RespiratoryProblems = respiratoryProblems;
            HeartOrCirculationProblems = heartOrCirculationProblems;
            NeurologicalProblems = neurologicalProblems;
            OtherConditions = otherConditions;
        }
    }
}
