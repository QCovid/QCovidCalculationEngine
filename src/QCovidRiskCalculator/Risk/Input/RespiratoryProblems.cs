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
    /// Inputs representing various respiratory problems
    /// </summary>
    public class RespiratoryProblems
    {
        /// <summary>
        /// Do you have asthma?
        /// </summary>
        public bool Asthma { get; internal set; }

        /// <summary>
        /// Are you taking anti-leukotriene or long acting beta2-agonists (LABA)?
        /// Prescribed four or more times in the previous 6 months.
        /// </summary>
        public bool TakingAntiLeukotrieneOrLaba { get; internal set; }

        /// <summary>
        /// Do you have cystic fibrosis or bronchiectasis or alveolitis?
        /// </summary>
        public bool CysticFibrosisBronchiectasisAlveolitis { get; internal set; }

        /// <summary>
        /// Do you have pulmonary hypertension or pulmonary fibrosis?
        /// </summary>
        public bool PulmonaryHypertensionOrFibrosis { get; internal set; }

        /// <summary>
        /// Do you have chronic obstructive pulmonary disease (COPD)?
        /// </summary>
        public bool Copd { get; internal set; }

        /// <summary>
        /// Do you have lung or oral cancer?
        /// </summary>
        public bool LungOrOralCancer { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asthma"></param>
        /// <param name="takingAntiLeukotrieneOrLaba"></param>
        /// <param name="cysticFibrosisBronchiectasisAlveolitis"></param>
        /// <param name="pulmonaryHypertensionOrFibrosis"></param>
        /// <param name="copd"></param>
        /// <param name="lungOrOralCancer"></param>
        public RespiratoryProblems(bool asthma,
            bool takingAntiLeukotrieneOrLaba,
            bool cysticFibrosisBronchiectasisAlveolitis,
            bool pulmonaryHypertensionOrFibrosis,
            bool copd,
            bool lungOrOralCancer)
        {
            Asthma = asthma;
            TakingAntiLeukotrieneOrLaba = takingAntiLeukotrieneOrLaba;
            CysticFibrosisBronchiectasisAlveolitis = cysticFibrosisBronchiectasisAlveolitis;
            PulmonaryHypertensionOrFibrosis = pulmonaryHypertensionOrFibrosis;
            Copd = copd;
            LungOrOralCancer = lungOrOralCancer;
        }
    }
}
