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
using _Ethnicity = CRStandardDefinitions.Ethnicity;

namespace QCovid.RiskCalculator.Risk.Input
{
    /// <summary>
    /// Classifications of Ethnicity
    /// </summary>
    public class Ethnicity : IInputOption
    {
        /// <summary>
        /// Not recorded.
        /// This option is only for bulk calculations from a patient database.
        /// If performing a calculation for a single individual via a UI, this option should not be included.
        /// </summary>
        public static Ethnicity NotRecorded = new Ethnicity(_Ethnicity.NotRecorded, 0, "Not recorded");
        /// <summary>
        /// White British
        /// </summary>
        public static Ethnicity WhiteBritish = new Ethnicity(_Ethnicity.British, 1, "White British");
        /// <summary>
        /// White Irish
        /// </summary>
        public static Ethnicity WhiteIrish = new Ethnicity(_Ethnicity.Irish, 2, "White Irish");
        /// <summary>
        /// Other White background
        /// </summary>
        public static Ethnicity OtherWhiteBackground = new Ethnicity(_Ethnicity.OtherWhiteBackground, 3, "Other White background");
        /// <summary>
        /// White and Black Caribbean mixed
        /// </summary>
        public static Ethnicity WhiteAndBlackCaribbeanMixed = new Ethnicity(_Ethnicity.WhiteAndBlackCaribbeanMixed, 4, "White and Black Caribbean mixed");
        /// <summary>
        /// White and Black African mixed
        /// </summary>
        public static Ethnicity WhiteAndBlackAfricanMixed = new Ethnicity(_Ethnicity.WhiteAndBlackAfricanMixed, 5, "White and Black African mixed");
        /// <summary>
        /// White and Asian mixed
        /// </summary>
        public static Ethnicity WhiteAndAsianMixed = new Ethnicity(_Ethnicity.WhiteAndAsianMixed, 6, "White and Asian mixed");
        /// <summary>
        /// Other mixed or multiple ethnic background
        /// </summary>
        public static Ethnicity OtherMixedOrMultiEthnic = new Ethnicity(_Ethnicity.OtherMixed, 7, "Other mixed or multiple ethnic background");
        /// <summary>
        /// Indian
        /// </summary>
        public static Ethnicity Indian = new Ethnicity(_Ethnicity.Indian, 8, "Indian");
        /// <summary>
        /// Pakistani
        /// </summary>
        public static Ethnicity Pakistani = new Ethnicity(_Ethnicity.Pakistani, 9, "Pakistani");
        /// <summary>
        /// Bangladeshi
        /// </summary>
        public static Ethnicity Bangladeshi = new Ethnicity(_Ethnicity.Bangladeshi, 10, "Bangladeshi");
        /// <summary>
        /// Any other Asian background
        /// </summary>
        public static Ethnicity OtherAsian = new Ethnicity(_Ethnicity.OtherAsian, 11, "Any other Asian background");
        /// <summary>
        /// Caribbean
        /// </summary>
        public static Ethnicity Caribbean = new Ethnicity(_Ethnicity.Caribbean, 12, "Caribbean");
        /// <summary>
        /// Black African
        /// </summary>
        public static Ethnicity BlackAfrican = new Ethnicity(_Ethnicity.BlackAfrican, 13, "Black African");
        /// <summary>
        /// Any other Black/African/Caribbean
        /// </summary>
        public static Ethnicity OtherBlack = new Ethnicity(_Ethnicity.OtherBlack, 14, "Any other Black/African/Caribbean");
        /// <summary>
        /// Chinese
        /// </summary>
        public static Ethnicity Chinese = new Ethnicity(_Ethnicity.Chinese, 15, "Chinese");
        /// <summary>
        /// Other ethnic group including Arab
        /// </summary>
        public static Ethnicity OtherEthnicGroupIncludingArab = new Ethnicity(_Ethnicity.OtherEthnicGroup, 16, "Other ethnic group including Arab");
        /// <summary>
        /// Ethnicity not stated
        /// </summary>
        public static Ethnicity NotStated = new Ethnicity(_Ethnicity.NotStated, 17, "Ethnicity not stated");

        internal _Ethnicity CoreValue { get; }


        /// <inheritdoc />
        public int Index { get; }

        /// <inheritdoc />
        public string DisplayName { get; }

        internal Ethnicity(_Ethnicity coreValue, int index, string displayName)
        {
            CoreValue = coreValue;
            Index = index;
            DisplayName = displayName;
        }

        /// <summary>
        /// Get all available Ethnicity options in a set order.
        /// Excludes Not Recorded as it should not be shown on UIs.
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyList<Ethnicity> GetAllOptions()
        {
            return InputOptionHelpers.GetAllPublicStaticFields<Ethnicity>()
                .Where(e => e != NotRecorded)
                .OrderBy(e => e.Index)
                .ToArray();
        }

        /// <summary>
        /// Get all available Ethnicity options in a set order, including Not Recorded.
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyList<Ethnicity> GetAllOptionsForBulkCalculation()
        {
            return InputOptionHelpers.GetAllPublicStaticFields<Ethnicity>()
                .OrderBy(e => e.Index)
                .ToArray();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Ethnicity {Index} - {DisplayName}";
        }
    }
}
