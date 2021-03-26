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
using System.Linq;
using System.Linq.Expressions;
using QCovid.RiskCalculator.Exceptions.Internal;
using QCovid.RiskCalculator.Risk.Input;

namespace QCovid.RiskCalculator.CodeMapping.Internal.CodeGroupMappings
{
    // <summary>
    // Mapping from a code group or groups to a value object "enum" property 
    // </summary>
    internal abstract class EnumMapping<TParent, TEnum> : CodeGroupMapping<RiskInput, TParent, TEnum>
        where TEnum : class
        where TParent : class
    {
        private readonly IReadOnlyList<(int[] ids, TEnum value)> _codeGroupIdValuePairs;

        protected EnumMapping(IReadOnlyList<(int[] ids, TEnum value)> codeGroupIdValuePairs, Expression<Func<RiskInput, TParent>> parentExpression, Expression<Func<TParent, TEnum>> childExpression)
            : base(codeGroupIdValuePairs.SelectMany(p => p.ids).ToList(), parentExpression, childExpression)
        {
            if (codeGroupIdValuePairs.SelectMany(p => p.ids).Distinct().Count() != CodeGroupIds.Count)
                throw new InvalidCodeGroupMappingException("A code group ID has been repeated");

            _codeGroupIdValuePairs = codeGroupIdValuePairs;
        }

        public override string ToStringCodeGroupIds()
        {
            var items = _codeGroupIdValuePairs.Select(p => $"{string.Join(",", p.ids)} -> {p.value}");
            return string.Join("; ", items);
        }

        protected TEnum GetValueFromCodeGroupInstance(CodeGroupInstance codeGroupInstance)
        {
            return _codeGroupIdValuePairs.Single(p => p.ids.Contains(codeGroupInstance.CodeGroupId)).value;
        }

        protected void SetValue(RiskInput riskInput, CodeGroupInstance codeGroupInstance)
        {
            SetValue(riskInput, GetValueFromCodeGroupInstance(codeGroupInstance));
        }

        // <summary>
        // Sets the enum to the appropriate value
        // </summary>
        protected void SetValue(RiskInput riskInput, TEnum value)
        {
            TParent parent = ExpressionHelper<RiskInput, TParent>.GetValue(riskInput, ParentExpression);

            ExpressionHelper<TParent, TEnum>.SetPropertyValue(parent, ChildExpression, value);
        }
    }
}
