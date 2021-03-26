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

using System;

namespace QCovid.RiskCalculator.Risk.Result
{
    /// <summary>
    /// The probability of outcome (e.g. catching COVID-19 and dying) during a 90 day period and the percentile ranking of that risk
    /// </summary>
    public class RiskResultForOutcomeType : IEquatable<RiskResultForOutcomeType>
    {
        /// <summary>
        /// The probability of outcome (e.g. catching COVID-19 and dying) during a 90 day period.
        /// This is expressed as a percentage (rather than as a fraction)
        /// </summary>
        public double RiskPercentage { get; }

        /// <summary>
        /// The percentile ranking of the risk, i.e. if we put the whole population in a line, ranked according to their risk, 
        /// and then divide this line into 100 equally sized groups, in which group does the subject lie. The highest risk is the 100th centile.
        /// </summary>
        public int Centile { get; }

        /// <summary>
        /// Construct the result from the risk percentage and the centile
        /// </summary>
        /// <param name="riskPercentage">See RiskPercentage</param>
        /// <param name="centile">See Centile</param>
        public RiskResultForOutcomeType(double riskPercentage, int centile)
        {
            RiskPercentage = riskPercentage;
            Centile = centile;
        }

        // <summary>
        // Returns null either either input is null, otherwise just runs the constructor
        // </summary>
        // <param name="riskPercentage"></param>
        // <param name="centile"></param>
        // <returns></returns>
        internal static RiskResultForOutcomeType? CreateOrReturnNull(double? riskPercentage, int? centile)
        {
            if (riskPercentage == null || centile == null)
                return null;

            return new RiskResultForOutcomeType(riskPercentage.Value, centile.Value);
        }

        /// <inheritdoc />
        public bool Equals(RiskResultForOutcomeType? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return RiskPercentage.Equals(other.RiskPercentage) && Centile == other.Centile;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RiskResultForOutcomeType) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(RiskPercentage, Centile);
        }
    }
}
