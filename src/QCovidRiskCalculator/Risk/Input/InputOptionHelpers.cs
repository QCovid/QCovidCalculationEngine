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
using System.Reflection;

namespace QCovid.RiskCalculator.Risk.Input
{
    internal static class InputOptionHelpers
    {
        // <summary>
        // Via reflection, get all public static fields of type T, on type T.
        // Do not use this unsorted! C# refuses to guarantee sort order of reflected things.
        // </summary>
        // <typeparam name="T"></typeparam>
        // <returns></returns>
        public static IEnumerable<T> GetAllPublicStaticFields<T>()
        {
            return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(fi => fi.FieldType == typeof(T))
                .Select(fi => (T) fi.GetValue(null)!);
        }

        // <summary>
        // Via reflection, get all public static fields of type T, on type T
        // and sort them alphabetically by display name
        // </summary>
        // <typeparam name="T"></typeparam>
        // <returns></returns>
        public static IOrderedEnumerable<T> GetAllPublicStaticFieldsInAlphabeticalOrder<T>()
            where T : IInputOption
        {
            return GetAllPublicStaticFields<T>()
                .OrderBy(e => e.DisplayName);
        }

        // <summary>
        // Via reflection, get all public static fields of type T, on type T
        // and sort them in ascending order
        // </summary>
        // <typeparam name="T"></typeparam>
        // <returns></returns>
        public static IOrderedEnumerable<T> GetAllPublicStaticFieldsInSortOrder<T>()
            where T : IInputOption, IComparable<T>
        {
            return GetAllPublicStaticFields<T>()
                .OrderBy(e => e);
        }
    }
}