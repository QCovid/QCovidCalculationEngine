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

using QCovid.RiskCalculator.Exceptions;

namespace QCovid.RiskCalculator.BodyMassIndex
{
    /// <summary>
    /// Body Mass Index
    /// </summary>
    public class Bmi
    {
        internal const double DefaultValue = 25;

        /// <summary>
        /// The body mass index (mass or weight in kilograms divided by the square of height in metres)
        /// </summary>
        public double BodyMassIndex { get; }

        /// <summary>
        /// An error code from generating the BodyMassIndex
        /// </summary>
        public QCovidErrorCode? ErrorCode { get; }

        private Bmi(double bmi)
        {
            BodyMassIndex = bmi;
        }

        private Bmi(QCovidErrorCode errorCode)
        {
            BodyMassIndex = DefaultValue;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Get the default instance of the Bmi class, representing no bmi value provided.
        /// </summary>
        public static readonly Bmi Default = new Bmi(QCovidErrorCode.BmiNotProvided);

        /// <summary>
        /// Create an instance of the bmi class from a bmi value
        /// </summary>
        /// <param name="bmi"></param>
        /// <returns></returns>
        public static Bmi CreateFromBmi(double bmi)
        {
            return double.IsNaN(bmi) ? new Bmi(QCovidErrorCode.BmiIsNaN) : new Bmi(bmi);
        }

        /// <summary>
        /// Create an instance of the bmi class from a weight in kg and a height in centimetres
        /// </summary>
        /// <param name="weightKg"></param>
        /// <param name="heightCentimetres"></param>
        /// <returns></returns>
        public static Bmi CreateFromKgAndCm(double weightKg, double heightCentimetres)
        {
            const double centimetresToMetres = 1.0 / 100.0;
            double heightMetres = heightCentimetres * centimetresToMetres;

            var bodyMassIndex = weightKg / (heightMetres * heightMetres);

            return CreateFromBmi(bodyMassIndex);
        }
    }
}
