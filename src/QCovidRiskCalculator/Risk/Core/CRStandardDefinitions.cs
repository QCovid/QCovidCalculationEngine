//This file is Copyright (c) 2020 ClinRisk Ltd. 
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
using System.Text;
using System.Text.RegularExpressions;

namespace CRStandardDefinitions
{
    internal enum Gender { Female, Male };
    internal enum DiabetesCat { None, Type1, Type2 };
    internal enum Ethnicity
    {
        NotRecorded,
        British,
        Irish,
        OtherWhiteBackground,
        WhiteAndBlackCaribbeanMixed,
        WhiteAndBlackAfricanMixed,
        WhiteAndAsianMixed,
        OtherMixed,
        Indian,
        Pakistani,
        Bangladeshi,
        OtherAsian,
        Caribbean,
        BlackAfrican,
        OtherBlack,
        Chinese,
        OtherEthnicGroup,
        NotStated
    };

    internal partial class Utilities
    {
        public static int ethnicityToEthrisk(Ethnicity e)
        {
            int ethrisk = 0;
            switch (e)
            {
                case Ethnicity.NotRecorded:
                case Ethnicity.British:
                case Ethnicity.Irish:
                case Ethnicity.OtherWhiteBackground:
                    ethrisk = 1;
                    break;
                case Ethnicity.WhiteAndBlackCaribbeanMixed:
                case Ethnicity.WhiteAndBlackAfricanMixed:
                case Ethnicity.WhiteAndAsianMixed:
                case Ethnicity.OtherMixed:
                    ethrisk = 9;
                    break;
                case Ethnicity.Indian:
                    ethrisk = 2;
                    break;
                case Ethnicity.Pakistani:
                    ethrisk = 3;
                    break;
                case Ethnicity.Bangladeshi:
                    ethrisk = 4;
                    break;
                case Ethnicity.OtherAsian:
                    ethrisk = 5;
                    break;
                case Ethnicity.Caribbean:
                    ethrisk = 6;
                    break;
                case Ethnicity.BlackAfrican:
                    ethrisk = 7;
                    break;
                case Ethnicity.OtherBlack:
                    ethrisk = 9;
                    break;
                case Ethnicity.Chinese:
                    ethrisk = 8;
                    break;
                case Ethnicity.OtherEthnicGroup:
                    ethrisk = 9;
                    break;
                case Ethnicity.NotStated:
                    ethrisk = 1;
                    break;
                default:
                    break;
            }
            return ethrisk;
        }
        public static int boolToInt(bool b)
        {
            if (b)
                return 1;
            else
                return 0;
        }
        public static int diabetescatToType1(DiabetesCat dc)
        {
            int tmp = 0;
            if (dc == DiabetesCat.Type1)
                tmp = 1;
            return tmp;
        }
        public static int diabetescatToType2(DiabetesCat dc)
        {
            int tmp = 0;
            if (dc == DiabetesCat.Type2)
                tmp = 1;
            return tmp;
        }
        public static int genderToInt(Gender g)
        {
            if (g == Gender.Female)
                return 0;
            else
                return 1;
        }
    }

    internal class Constants
    {
        public const double minTown = -8.0;
        public const double maxTown = 12.0;
        public const double minBmi = 15.0;
        public const double maxBmi = 47.0;
    }
}
