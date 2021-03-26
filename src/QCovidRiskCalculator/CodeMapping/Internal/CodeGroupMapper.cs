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

using System.Collections.Generic;
using QCovid.RiskCalculator.BodyMassIndex;
using QCovid.RiskCalculator.CodeMapping.Internal.CodeGroupMappings;
using QCovid.RiskCalculator.Risk.Input;
using QCovid.RiskCalculator.Townsend;

namespace QCovid.RiskCalculator.CodeMapping.Internal
{
    // <summary>
    // Converts a list of code group instances, e.g. Read2 codes from a patient record,
    // input a RiskInput object, upon which the RiskCalculator can act
    // </summary>
    internal class CodeGroupMapper
    {
        // <summary>
        // Process the code group instances and return the risk result
        // </summary>
        // <param name="codeGroupInstances"></param>
        // <param name="age"></param>
        // <param name="sex"></param>
        // <param name="bmi"></param>
        // <param name="townsendScore"></param>
        // <param name="processingReferenceDate">The reference date for "now" when for the processing, in the same timezone as that on the code group instances</param>
        // <returns></returns>
        public CodeGroupMapperResult Process(IReadOnlyList<CodeGroupInstance> codeGroupInstances, Age age, Sex sex, Bmi bmi, EncryptedTownsendScore townsendScore, Date processingReferenceDate)
        {
            RiskInput input = RiskInput.CreateInitialRiskInput(age, sex, bmi, townsendScore);
            List<CodeGroupInstance> recognisedInstances = new List<CodeGroupInstance>();

            foreach (CodeGroupMapping mapping in CodeGroupMappingItems.Items)
            {
                recognisedInstances.AddRange(mapping.Process(input, codeGroupInstances, processingReferenceDate));
            }

            return new CodeGroupMapperResult(input, recognisedInstances);
        }
    }
}
