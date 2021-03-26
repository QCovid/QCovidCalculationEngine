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
    /// A classification of Chronic Kidney Disease
    /// </summary>
    public class ChronicKidneyDisease : InputWithSeverity<ChronicKidneyDisease>
    {
        /// <summary>
        /// No serious kidney disease
        /// </summary>
        public static ChronicKidneyDisease None =
            new ChronicKidneyDisease(Renalcat.No_CKD, 0, "No serious kidney disease");

        /// <summary>
        /// CKD3
        /// </summary>
        public static ChronicKidneyDisease Ckd3 = new ChronicKidneyDisease(Renalcat.CKD3, 1, "CKD3");

        /// <summary>
        /// CKD4
        /// </summary>
        public static ChronicKidneyDisease Ckd4 = new ChronicKidneyDisease(Renalcat.CKD4, 2, "CKD4");

        /// <summary>
        /// CKD5 without dialysis or transplant
        /// </summary>
        public static ChronicKidneyDisease Ckd5WithNeitherDialysisNorTransplant =
            new ChronicKidneyDisease(Renalcat.CKD5_with_neither_dialysis_nor_transplant, 3,
                "CKD5 without dialysis or transplant");

        /// <summary>
        /// CKD5 with dialysis in the last 12 months
        /// </summary>
        public static ChronicKidneyDisease Ckd5WithDialysis = new ChronicKidneyDisease(Renalcat.CKD5_with_dialysis, 4,
            "CKD5 with dialysis in the last 12 months");

        /// <summary>
        /// CKD5 with transplant
        /// </summary>
        public static ChronicKidneyDisease Ckd5WithTransplant =
            new ChronicKidneyDisease(Renalcat.CKD5_with_transplant, 5, "CKD5 with transplant");

        internal Renalcat CoreValue { get; }

        private ChronicKidneyDisease(Renalcat coreValue, int index, string displayName) : base(index, index,
            displayName)
        {
            // For now index and severity can use the same value
            CoreValue = coreValue;
        }

        /// <summary>
        /// Get all available Chronic Kidney Disease options in order of ascending severity
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyList<ChronicKidneyDisease> GetAllOptions()
        {
            return InputOptionHelpers.GetAllPublicStaticFieldsInSortOrder<ChronicKidneyDisease>()
                .ToArray();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Chronic Kidney Disease {Index} - {DisplayName}";
        }
    }
}
