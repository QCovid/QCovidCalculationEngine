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

using QCovid.RiskCalculator.BodyMassIndex;
using QCovid.RiskCalculator.Townsend.Internal;

namespace QCovid.RiskCalculator.Exceptions
{
    /// <summary>
    /// A code representing an exception returned by a QCovid operation.
    /// </summary>
    public class QCovidErrorCode
    {
        /// <summary>
        /// A unique id for this error type.
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// Whether the error means no valid result could be returned.
        /// </summary>
        public bool IsFatal { get; }

        /// <summary>
        /// A human readable message associated with this error code.
        /// </summary>
        public string Message { get; }

        // 1xx - General
        /// <summary>
        /// An unhandled exception occurred
        /// </summary>
        public static readonly QCovidErrorCode UnhandledException = new QCovidErrorCode(100, true, "An unhandled exception occurred.");

        // 2xx - Input validation

        /// <summary>
        /// The provided age in years is below the calculators range
        /// </summary>
        public static readonly QCovidErrorCode AgeBelowMinimumValue = new QCovidErrorCode(201, true, "The provided age in years is below the calculators range.");
        /// <summary>
        /// The provided age in years is above the calculators range
        /// </summary>
        public static readonly QCovidErrorCode AgeAboveMaximumValue = new QCovidErrorCode(202, true, "The provided age in years is above the calculators range.");
        /// <summary>
        /// The provided BMI is below the calculators range. The minimum valid BMI will be used instead
        /// </summary>
        public static readonly QCovidErrorCode BmiBelowMinimumValue = new QCovidErrorCode(204, false, "The provided BMI is below the calculators range. The minimum valid BMI will be used instead.");
        /// <summary>
        /// The provided BMI is above the calculators range. The maximum valid BMI will be used instead
        /// </summary>
        public static readonly QCovidErrorCode BmiAboveMaximumValue = new QCovidErrorCode(205, false, "The provided BMI is above the calculators range. The maximum valid BMI will be used instead.");
        /// <summary>
        /// No BMI was provided. A default BMI will be used
        /// </summary>
        public static readonly QCovidErrorCode BmiNotProvided = new QCovidErrorCode(206, false, $"No BMI was provided. A BMI of {Bmi.DefaultValue:0.##} will be used.");
        /// <summary>
        /// The provided BMI was not a number. A default BMI will be used
        /// </summary>
        public static readonly QCovidErrorCode BmiIsNaN = new QCovidErrorCode(207, false, $"The provided BMI was not a number. A BMI of {Bmi.DefaultValue:0.##} will be used.");
        /// <summary>
        /// One or more inputs is null
        /// </summary>
        public static readonly QCovidErrorCode NullInput = new QCovidErrorCode(208, true, "One or more inputs is null.");

        // 3xx - Postcode validation
        /// <summary>
        /// The provided postcode was not found
        /// </summary>
        public static readonly QCovidErrorCode PostcodeNotFound = new QCovidErrorCode(300, false, $"The provided postcode was not found. A Townsend score of {TownsendScore.DefaultScore:0.##} will be used.");
        /// <summary>
        /// No postcode was provided
        /// </summary>
        public static readonly QCovidErrorCode PostcodeNotProvided = new QCovidErrorCode(301, false, $"No postcode was provided. A Townsend score of {TownsendScore.DefaultScore:0.##} will be used.");

        // 4xx - Townsend database errors
        /// <summary>
        /// Could not open a connection to the Townsend database
        /// </summary>
        public static readonly QCovidErrorCode CouldNotConnectToTownsendDatabase = new QCovidErrorCode(400, true, "Could not open a connection to the Townsend database.");
        /// <summary>
        /// An error occurred while querying the Townsend database
        /// </summary>
        public static readonly QCovidErrorCode CouldNotQueryTownsendDatabase = new QCovidErrorCode(401, true, "An error occurred while querying the Townsend database.");
        /// <summary>
        /// The Townsend database did not pass the version check
        /// </summary>
        public static readonly QCovidErrorCode IncorrectTownsendDatabaseVersion = new QCovidErrorCode(402, true, "The Townsend database did not pass the version check.");

        // 5xx - Medical codes database errors
        /// <summary>
        /// Could not open a connection to the Medical code database
        /// </summary>
        public static readonly QCovidErrorCode CouldNotConnectToMedicalCodeDatabase = new QCovidErrorCode(500, true, "Could not open a connection to the Medical code database.");
        /// <summary>
        /// An error occurred while querying the Medical code database
        /// </summary>
        public static readonly QCovidErrorCode CouldNotQueryMedicalCodeDatabase = new QCovidErrorCode(501, true, "An error occurred while querying the Medical code database.");
        /// <summary>
        /// The Medical code database did not pass the version check
        /// </summary>
        public static readonly QCovidErrorCode IncorrectMedicalCodeDatabaseVersion = new QCovidErrorCode(502, true, "The Medical code database did not pass the version check.");


        private QCovidErrorCode(int code, bool isFatal, string message)
        {
            Code = code;
            IsFatal = isFatal;
            Message = message;
        }

        /// <summary>
        /// For a fatal error code, returns a throw-able exception. Returns null otherwise
        /// </summary>
        /// <returns></returns>
        public QCovidException? ToExceptionIfFatal()
        {
            return IsFatal ? new QCovidException(this) : null;
        }
    }
}
