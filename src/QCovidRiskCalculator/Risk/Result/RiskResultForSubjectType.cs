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
    /// The risk results for a given subject
    /// </summary>
    public class RiskResultForSubjectType : IEquatable<RiskResultForSubjectType>
    {
        /// <summary>
        /// Results for catching COVID-19 and dying as a result
        /// </summary>
        public RiskResultForOutcomeType? Death { get; }

        /// <summary>
        /// Results for catching COVID-19 and being admitted into hospital as a result
        /// </summary>
        public RiskResultForOutcomeType? Hospitalisation { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="death"></param>
        /// <param name="hospitalisation"></param>
        public RiskResultForSubjectType(RiskResultForOutcomeType? death, RiskResultForOutcomeType? hospitalisation)
        {
            Death = death;
            Hospitalisation = hospitalisation;
        }

        /// <inheritdoc />
        public bool Equals(RiskResultForSubjectType? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Death, other.Death) && Equals(Hospitalisation, other.Hospitalisation);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RiskResultForSubjectType) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(Death, Hospitalisation);
        }
    }
}
