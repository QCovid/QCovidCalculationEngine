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
using System.Linq;
using CRStandardDefinitions;

namespace QCovid.RiskCalculator.Risk.Input
{
    /// <summary>
    /// An input representing classifications of Chemotherapy treatment
    /// </summary>
    public class ChemotherapyGroup : InputWithSeverity<ChemotherapyGroup>
    {
        /// <summary>
        /// No Chemotherapy in the last 12 months
        /// </summary>
        public static ChemotherapyGroup NoneInLast12Months =
            new ChemotherapyGroup(Chemocat.No_chemotherapy_in_the_last_12_months, 0,
                "No Chemotherapy in the last 12 months");

        /// <summary>
        /// Group A
        /// </summary>
        public static ChemotherapyGroup GroupA = new ChemotherapyGroup(Chemocat.Chemotherapy_Group_A, 1, "Group A");

        /// <summary>
        /// Group B
        /// </summary>
        public static ChemotherapyGroup GroupB = new ChemotherapyGroup(Chemocat.Chemotherapy_Group_B, 2, "Group B");

        /// <summary>
        /// Group C
        /// </summary>
        public static ChemotherapyGroup GroupC = new ChemotherapyGroup(Chemocat.Chemotherapy_Group_C, 3, "Group C");

        internal Chemocat CoreValue { get; }

        private ChemotherapyGroup(Chemocat coreValue, int index, string displayName) : base(index, index, displayName)
        {
            // For now index and severity can use the same value
            CoreValue = coreValue;
        }

        /// <summary>
        /// Get all available Chemotherapy Groups in order of ascending severity
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyList<ChemotherapyGroup> GetAllOptions()
        {
            return InputOptionHelpers.GetAllPublicStaticFieldsInSortOrder<ChemotherapyGroup>()
                .ToArray();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Chemotherapy Group {Index} - {DisplayName}";
        }
    }
}
