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
using QCovid.RiskCalculator.Risk.Input;

namespace QCovid.RiskCalculator.CodeMapping.Internal.CodeGroupMappings
{
    // <summary>
    // A mapping from one or more code groups to risk inputs, which can include various additional rules
    // </summary>
    // <remarks>
    // This non-generic version knows nothing about the object graph, see generic options
    // </remarks>
    internal abstract class CodeGroupMapping
    {
        public IReadOnlyList<int> CodeGroupIds { get; }

        public string Label { get; }

        protected CodeGroupMapping(IReadOnlyList<int> codeGroupIds, string label)
        {
            CodeGroupIds = codeGroupIds;
            Label = label;
        }

        // <summary>
        // Present code group instances to this method and it will either understand and use them, adding them to the returned list, or ignore them
        // </summary>
        // <param name="riskInput"></param>
        // <param name="codeGroupInstances"></param>
        // <param name="processingReferenceDate">The date, in the same timezone as the CodeGroupInstances, which we judge as "now"</param>
        // <returns>The code group instances recognised</returns>
        public IReadOnlyList<CodeGroupInstance> Process(RiskInput riskInput, IReadOnlyList<CodeGroupInstance> codeGroupInstances, Date processingReferenceDate)
        {
            List<CodeGroupInstance> recognisedInstances = codeGroupInstances.Where(cgi => CodeGroupIds.Contains(cgi.CodeGroupId)).ToList();

            if (recognisedInstances.Any())
                Process_Inner(riskInput, recognisedInstances, processingReferenceDate);

            return recognisedInstances;
        }

        public abstract string ToStringCodeGroupIds();

        public abstract string ToStringProcessingRules();

        // <summary>
        // Present recognised code group instances to this method will action them
        // </summary>
        // <param name="recognisedCodeGroupInstances">The list of recognised instances, which is guaranteed not to be empty</param>
        protected abstract void Process_Inner(RiskInput riskInput, IReadOnlyList<CodeGroupInstance> recognisedCodeGroupInstances, Date processingReferenceDate);
    }

    // <summary>
    // See non-generic case
    // </summary>
    // <typeparam name="TRoot">Type is the entry point to the object graph</typeparam>
    // <typeparam name="TParent">Type that contains the value as a property</typeparam>
    // <typeparam name="TValue">Type of value that is mapped to</typeparam>
    internal abstract class CodeGroupMapping<TRoot, TParent, TValue> : CodeGroupMapping
        where TParent : class
    {
        protected readonly Expression<Func<TRoot, TParent>> ParentExpression;
        protected readonly Expression<Func<TParent, TValue>> ChildExpression;

        protected CodeGroupMapping(IReadOnlyList<int> codeGroupIds, Expression<Func<TRoot, TParent>> parentExpression, Expression<Func<TParent, TValue>> childExpression) 
            : base(codeGroupIds, GetLabel(childExpression))
        {
            ParentExpression = parentExpression;
            ChildExpression = childExpression;
        }

        private static string GetLabel(Expression<Func<TParent, TValue>> childExpression)
        {
            return ExpressionHelper<TParent, TValue>.GetPropertyName(childExpression);
        }
    }
}
