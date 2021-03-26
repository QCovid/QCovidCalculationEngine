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
    /// Inputs representing various conditions not covered otherwise
    /// </summary>
    public class OtherConditions
    {
        /// <summary>
        /// Do you have severe mental illness?
        /// </summary>
        public bool SevereMentalIllness { get; internal set; }

        /// <summary>
        /// Do you have cirrhosis of the liver?
        /// </summary>
        public bool LiverCirrhosis { get; internal set; }

        /// <summary>
        /// Do you have rheumatoid arthritis or SLE?
        /// </summary>
        public bool RheumatoidArthritisOrSle { get; internal set; }

        /// <summary>
        /// Have you had a prior fracture of hip, wrist, spine or humerus?
        /// </summary>
        public bool PriorFractureOfHipWristSpineHumerus { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="severeMentalIllness"></param>
        /// <param name="cirrhosisOfTheLiver"></param>
        /// <param name="rheumatoidArthritisOrSle"></param>
        /// <param name="priorFractureOfHipWristSpineHumerus"></param>
        public OtherConditions(
            bool severeMentalIllness,
            bool cirrhosisOfTheLiver,
            bool rheumatoidArthritisOrSle,
            bool priorFractureOfHipWristSpineHumerus)
        {
            SevereMentalIllness = severeMentalIllness;
            LiverCirrhosis = cirrhosisOfTheLiver;
            RheumatoidArthritisOrSle = rheumatoidArthritisOrSle;
            PriorFractureOfHipWristSpineHumerus = priorFractureOfHipWristSpineHumerus;
        }
    }
}
