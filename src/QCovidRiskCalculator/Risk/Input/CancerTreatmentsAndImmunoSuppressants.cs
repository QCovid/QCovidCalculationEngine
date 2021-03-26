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
    /// Inputs representing various cancer treatments or medication effecting the immune system
    /// </summary>
    public class CancerTreatmentsAndImmunoSuppressants
    {
        /// <summary>
        /// Have you had chemotherapy in the last 12 months?
        /// Chemotherapy prescribed in preceding 12 months as recorded on the Systemic Anti Cancer Treatment (SACT) data.
        /// </summary>
        public ChemotherapyGroup ChemotherapyGroup { get; internal set; }

        /// <summary>
        /// Have you had radiotherapy in the last 6 months?
        /// </summary>
        public bool RadioTherapyInLast6Months { get; internal set; }

        /// <summary>
        /// Have you had a bone marrow or stem cell transplant in the last 6 months?
        /// </summary>
        public bool BoneMarrowTransplantInLast6Months { get; internal set; }
    
        /// <summary>
        /// Have you a cancer of the blood or bone marrow such as leukaemia, myelodysplastic syndromes, lymphoma or myeloma and are at any stage of treatment?
        /// </summary>
        public bool CancerOfBloodOrBoneMarrow { get; internal set; }

        /// <summary>
        /// Have you had a solid organ transplant (lung, liver, stomach, pancreas, spleen, heart or thymus)?
        /// </summary>
        public bool SolidOrganTransplant { get; internal set; }

        /// <summary>
        /// Have you been prescribed immunosuppressants prescribed by your GP?
        /// Prescribed four or more times in the previous 6 months.
        /// </summary>
        public bool PrescribedImmunoSuppressants { get; internal set; }

        /// <summary>
        /// Have you been prescribed oral steroids by your GP in the last 6 months?
        /// Oral prednisolone containing preparations prescribed four or more times in the previous 6 months.
        /// </summary>
        public bool PrescribedOralSteroids { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chemotherapyGroup"></param>
        /// <param name="radioTherapyInLast6Months"></param>
        /// <param name="cancerOfBloodOrBoneMarrow"></param>
        /// <param name="boneMarrowTransplantInLast6Months"></param>
        /// <param name="solidOrganTransplant"></param>
        /// <param name="prescribedImmunoSuppressantsInLast6Months"></param>
        /// <param name="prescribedOralSteroids"></param>
        public CancerTreatmentsAndImmunoSuppressants(ChemotherapyGroup chemotherapyGroup,
            bool radioTherapyInLast6Months,
            bool cancerOfBloodOrBoneMarrow,
            bool boneMarrowTransplantInLast6Months,
            bool solidOrganTransplant,
            bool prescribedImmunoSuppressantsInLast6Months,
            bool prescribedOralSteroids)
        {
            ChemotherapyGroup = chemotherapyGroup;
            RadioTherapyInLast6Months = radioTherapyInLast6Months;
            BoneMarrowTransplantInLast6Months = boneMarrowTransplantInLast6Months;
            CancerOfBloodOrBoneMarrow = cancerOfBloodOrBoneMarrow;
            SolidOrganTransplant = solidOrganTransplant;
            PrescribedImmunoSuppressants = prescribedImmunoSuppressantsInLast6Months;
            PrescribedOralSteroids = prescribedOralSteroids;
        }
    }
}
