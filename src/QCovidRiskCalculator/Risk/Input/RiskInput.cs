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
using QCovid.RiskCalculator.BodyMassIndex;
using QCovid.RiskCalculator.Townsend;

namespace QCovid.RiskCalculator.Risk.Input
{
    /// <summary>
    /// The input to <see cref="QCovidRiskCalculator"/>
    /// </summary>
    public class RiskInput
    {
        /// <summary>
        /// The age of the patient in years at the date of calculation.
        /// </summary>
        public Age Age { get; }

        /// <summary>
        /// Body Mass Index.
        /// The most recently recorded patient BMI within the last 5 years.
        /// </summary>
        public Bmi Bmi { get; }

        /// <summary>
        /// The sex of the patient.
        /// This is usually biological sex at birth.
        /// There is insufficient data to model those who are intersex or trans, or indeed what the long term effect of hormone treatment etc on COVID risk for those who are biologically reassigned.
        /// </summary>
        public Sex Sex { get; }

        /// <summary>
        /// The Townsend score for the patient's residence.
        /// </summary>
        public EncryptedTownsendScore EncryptedTownsendScore { get; }

        /// <summary>
        /// What is your housing category - care home or homeless or neither?
        /// The most recently recorded accommodation status recorded on GP record.
        /// </summary>
        public HousingCategory HousingCategory { get; internal set; }

        /// <summary>
        /// What is your ethnic group?
        /// </summary>
        public Ethnicity Ethnicity { get; internal set; }

        /// <summary>
        /// Clinical observations and medications
        /// </summary>
        public ClinicalInformation ClinicalInformation { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="age"></param>
        /// <param name="bmi"></param>
        /// <param name="sex"></param>
        /// <param name="townsendScore"></param>
        /// <param name="housingCategory"></param>
        /// <param name="ethnicity"></param>
        /// <param name="clinicalInformation"></param>
        public RiskInput(Age age, Bmi bmi, Sex sex, EncryptedTownsendScore townsendScore, HousingCategory housingCategory, Ethnicity ethnicity, ClinicalInformation clinicalInformation)
        {
            Age = age;
            Bmi = bmi;
            Sex = sex;
            EncryptedTownsendScore = townsendScore;
            HousingCategory = housingCategory;
            Ethnicity = ethnicity;
            ClinicalInformation = clinicalInformation;
        }

        internal static RiskInput CreateInitialRiskInput(Age age, Sex sex, Bmi bmi, EncryptedTownsendScore townsendScore)
        {
            // use an empty list for no treatments
            IEnumerable<ChemotherapyItem> chemotherapyTreatmentList = new ChemotherapyItem[0];
            ChemotherapyGroup chemotherapyGroup = ChemotherapyItem.GetGroupFromTreatmentList(chemotherapyTreatmentList);

            CancerTreatmentsAndImmunoSuppressants cancerAndImmunSup = new CancerTreatmentsAndImmunoSuppressants(chemotherapyGroup, false, false, false, false, false, false);
            RespiratoryProblems respiratory = new RespiratoryProblems(false, false, false, false, false, false);
            HeartOrCirculationProblems heartOrCirc = new HeartOrCirculationProblems(false, false, false, false, false, false, false);
            NeurologicalProblems neurological = new NeurologicalProblems(false, false, false, false, false);
            OtherConditions other = new OtherConditions(false, false, false, false);

            ClinicalInformation clinical = new ClinicalInformation(
                Diabetes.None,
                ChronicKidneyDisease.None,
                SickleCellOrSevereCombinedImmunodeficiencySyndrome.None,
                LearningDisabilityOrDownsSyndrome.Neither,
                cancerAndImmunSup,
                respiratory,
                heartOrCirc,
                neurological,
                other
            );

            RiskInput input = new RiskInput(
                age,
                bmi,
                sex,
                townsendScore,
                HousingCategory.NeitherInNursingOrCareHomeNorHomeless,
                Ethnicity.NotRecorded,
                clinical
            );

            return input;
        }
    }
}
