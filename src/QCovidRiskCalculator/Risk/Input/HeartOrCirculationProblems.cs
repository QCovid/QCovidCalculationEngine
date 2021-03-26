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
    /// Inputs representing various heart or circulation problems
    /// </summary>
    public class HeartOrCirculationProblems
    {
        /// <summary>
        /// Do you have congenital heart disease or have you had surgery for it in the past?
        /// </summary>
        public bool CongenitalHeartProblem { get; internal set; }

        /// <summary>
        /// Do you have coronary heart disease? 
        /// </summary>
        public bool CoronaryHeartDisease { get; internal set; }

        /// <summary>
        /// Have you had a stroke or TIA?
        /// </summary>
        public bool StrokeOrTia { get; internal set; }

        /// <summary>
        /// Do you have atrial fibrillation?
        /// </summary>
        public bool AtrialFibrillation { get; internal set; }

        /// <summary>
        /// Do you have heart failure?
        /// </summary>
        public bool HeartFailure { get; internal set; }

        /// <summary>
        /// Do you have peripheral vascular disease?
        /// </summary>
        public bool PeripheralVascularDisease { get; internal set; }

        /// <summary>
        /// Have you had a thrombosis or pulmonary embolus? 
        /// </summary>
        public bool ThrombosisOrPulmonaryEmbolus { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="congenitalHeartProblem"></param>
        /// <param name="coronaryHeartDisease"></param>
        /// <param name="strokeOrTia"></param>
        /// <param name="atrialFibrillation"></param>
        /// <param name="heartFailure"></param>
        /// <param name="peripheralVascularDisease"></param>
        /// <param name="thrombosisOrPulmonaryEmbolus"></param>
        public HeartOrCirculationProblems(
            bool congenitalHeartProblem,
            bool coronaryHeartDisease,
            bool strokeOrTia,
            bool atrialFibrillation,
            bool heartFailure,
            bool peripheralVascularDisease,
            bool thrombosisOrPulmonaryEmbolus)
        {
            CongenitalHeartProblem = congenitalHeartProblem;
            CoronaryHeartDisease = coronaryHeartDisease;
            StrokeOrTia = strokeOrTia;
            AtrialFibrillation = atrialFibrillation;
            HeartFailure = heartFailure;
            PeripheralVascularDisease = peripheralVascularDisease;
            ThrombosisOrPulmonaryEmbolus = thrombosisOrPulmonaryEmbolus;
        }
    }
}
