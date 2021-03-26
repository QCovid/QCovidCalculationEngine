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

//
// This class has been modified for the open source version.
// In the licensed version, you cannot input a townsend score yourself, as a bespoke scoring system is used.
// Instead, the PostcodeToTownsendScoreConverter can obtain instances of this class from a postcode.
// In the open source version, you can create instances of this class yourself,
// passing in a townsend score of your choosing.
//

using QCovid.RiskCalculator.Exceptions;

namespace QCovid.RiskCalculator.Townsend
{
    /// <summary>
    /// An encrypted version of the Townsend score, plus any error code present
    /// from the lookup in the encrypted database.
    /// For demonstration purposes, in the open source version this is a thin wrapper
    /// around the score with no encryption provided.
    /// </summary>
    public class EncryptedTownsendScore
    {
        /// <summary>
        /// The value of the encrypted score or null if the default score is to be used.
        /// </summary>
        public double? Value { get; }

        /// <summary>
        /// An error code from generating the TownsendScore
        /// </summary>
        public QCovidErrorCode? ErrorCode { get; }

        /// <summary>
        /// For the open source version, this constructor has been made public.
        /// </summary>
        /// <param name="unencryptedScore">An Townsend score, between -8.0 to 12.0</param>
        public EncryptedTownsendScore(double unencryptedScore) 
        {
            Value = unencryptedScore;
        }

        internal EncryptedTownsendScore(QCovidErrorCode errorCode) 
        {
            Value = null;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Use this instance to represent the default Townsend score
        /// </summary>
        public static readonly EncryptedTownsendScore Default = new EncryptedTownsendScore(QCovidErrorCode.PostcodeNotProvided);
    }
}
