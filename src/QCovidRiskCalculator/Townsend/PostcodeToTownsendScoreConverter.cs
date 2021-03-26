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
// In the licensed version, this class reads from a provided database.
// This implementation has not been open-sourced, so only a stub is provided here.
//

using System;
using System.Data.Common;
using QCovid.RiskCalculator.Exceptions;

namespace QCovid.RiskCalculator.Townsend
{
    /// <inheritdoc cref="IPostcodeToTownsendScoreConverter"/>
    public class PostcodeToTownsendScoreConverter : IPostcodeToTownsendScoreConverter, IDisposable
    {
        /// <summary>
        /// Construct a PostcodeToTownsendScoreConverter with a provided licence key and a function to create a new database connection.
        /// Will close created database connection on dispose.
        /// </summary>
        /// <param name="licenceKey"></param>
        /// <param name="newConnectionFactoryFunc"></param>
        /// <exception cref="LicenceKeyException"></exception>
        public PostcodeToTownsendScoreConverter(string licenceKey, Func<DbConnection> newConnectionFactoryFunc)
        {
        }

        /// <summary>
        /// Construct a PostcodeToTownsendScoreConverter with a provided licence key and a pre-existing database connection.
        /// Will not close database connection on dispose.
        /// </summary>
        /// <param name="licenceKey"></param>
        /// <param name="dbConnection"></param>
        /// <exception cref="LicenceKeyException"></exception>
        public PostcodeToTownsendScoreConverter(string licenceKey, DbConnection dbConnection)
        {
        }

        /// <summary>
        /// Construct a QCovidRiskCalculator with a provided licence key and an ITownsendScoreDbReader instance
        /// </summary>
        /// <param name="licenceKey"></param>
        /// <param name="townsendScoreDbReader"></param>
        /// <exception cref="LicenceKeyException"></exception>
        public PostcodeToTownsendScoreConverter(string licenceKey, ITownsendScoreDbReader townsendScoreDbReader)
        {

        }

        /// <inheritdoc />
        public EncryptedTownsendScore GetTownsendScore(Postcode postcode)
        {
            return new EncryptedTownsendScore(QCovidErrorCode.PostcodeNotFound);
        }

        /// <inheritdoc />
        public void Dispose()
        {

        }
    }
}
