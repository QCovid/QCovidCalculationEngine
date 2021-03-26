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
using System.Collections.Generic;
using System.Linq.Expressions;
using QCovid.RiskCalculator.Risk.Input;

namespace QCovid.RiskCalculator.CodeMapping.Internal.CodeGroupMappings
{
    // <summary>
    // A mapping which will set a boolean flag to true if the appropriate conditions are met
    // </summary>
    // <typeparam name="TParent"></typeparam>
    internal abstract class BoolMapping<TParent> : CodeGroupMapping<ClinicalInformation, TParent, bool>
        where TParent : class
    {
        protected BoolMapping(IReadOnlyList<int> codeGroupIds, Expression<Func<ClinicalInformation, TParent>> parentExpression, Expression<Func<TParent, bool>> childExpression)
            : base(codeGroupIds, parentExpression, childExpression)
        {
        }

        public override string ToStringCodeGroupIds()
        {
            return string.Join(", ", CodeGroupIds);
        }

        // <summary>
        // Sets the bool to true
        // </summary>
        protected void SetValue(RiskInput riskInput)
        {
            TParent parent = ExpressionHelper<ClinicalInformation, TParent>.GetValue(riskInput.ClinicalInformation, ParentExpression);

            ExpressionHelper<TParent, bool>.SetPropertyValue(parent, ChildExpression, true);
        }
    }
}
