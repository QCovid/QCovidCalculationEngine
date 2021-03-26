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
using System.Reflection;

namespace QCovid.RiskCalculator.CodeMapping
{
    /// <summary>
    /// A class-based "enum" for types of medical codes, e.g. Read2
    /// </summary>
    public class CodeType
    {
        // These must match CodesTypes.Id in the database.

        /// <summary>
        /// SNOMED codes
        /// </summary>
        public static CodeType Snomed = new CodeType(1, "SNOMED");

        /// <summary>
        /// Read version 2 (5-byte Read) codes
        /// </summary>
        public static CodeType Read2 = new CodeType(2, "Read2");

        /// <summary>
        /// Codes from the OPCS Classification of Interventions and Procedures
        /// </summary>
        public static CodeType Opcs = new CodeType(3, "OPCS");

        /// <summary>
        /// Codes from the International Classification of Diseases, 10th revision
        /// </summary>
        public static CodeType Icd10 = new CodeType(4, "ICD10");

        /// <summary>
        /// Codes from the Dictionary of medicines and devices
        /// </summary>
        public static CodeType DmPlusD = new CodeType(5, "DM+D");

        /// <summary>
        /// A custom list of drugs and treatments mapping to a Chemotherapy Group
        /// See Sheet 3b of the QCovid-YYYY-RX-Inputs.xlsx file
        /// </summary>
        public static CodeType ChemotherapyTreatmentBenchmarkGroup = new CodeType(6, "Chemotherapy Treatment Benchmark Group");

        /// <summary>
        /// The enum value of a code type
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// The human-readable name of a code type
        /// </summary>
        public string Name { get; }

        private CodeType(int value, string name)
        {
            Value = value;
            Name = name;
        }

        /// <summary>
        /// Get a list of all available code types
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyList<CodeType> GetAllTypes()
        {
            return typeof(CodeType).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(fi => fi.FieldType == typeof(CodeType))
                .Select(fi => (CodeType)fi.GetValue(null)!)
                .OrderBy(e => e.Value)
                .ToArray();
        }

        /// <summary>
        /// Get the CodeType represented by a specified value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static CodeType GetByValue(int value)
        {
            return GetAllTypes().Single(c => c.Value == value);
        }
    }
}
