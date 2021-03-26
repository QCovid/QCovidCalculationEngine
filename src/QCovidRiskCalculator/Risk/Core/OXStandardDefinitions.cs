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

namespace CRStandardDefinitions
{
    internal enum Chemocat
    {
        No_chemotherapy_in_the_last_12_months,
        Chemotherapy_Group_A,
        Chemotherapy_Group_B,
        Chemotherapy_Group_C
    }
    internal enum Homecat
    {
        Neither_in_a_nursing_or_care_home_nor_homeless,
        Nursing_or_care_home,
        Homeless
    }
    internal enum Learncat
    {
        Neither,
        Learning_disability_excluding_Downs_syndrome,
        Downs_syndrome
    }
    internal enum Renalcat
    {
        Not_used,
        No_CKD,
        CKD3,
        CKD4,
        CKD5_with_neither_dialysis_nor_transplant,
        CKD5_with_dialysis,
        CKD5_with_transplant
    }

    internal partial class Utilities
    {
        public static int chemocatToInt(Chemocat cc)
        {
            int chemocat = 0;
            switch (cc)
            {
                case Chemocat.No_chemotherapy_in_the_last_12_months:
                    chemocat = 0;
                    break;
                case Chemocat.Chemotherapy_Group_A:
                    chemocat = 1;
                    break;
                case Chemocat.Chemotherapy_Group_B:
                    chemocat = 2;
                    break;
                case Chemocat.Chemotherapy_Group_C:
                    chemocat = 3;
                    break;
            }
            return chemocat;
        }
        public static int homecatToInt(Homecat hc)
        {
            int homecat = 0;
            switch (hc)
            {
                case Homecat.Neither_in_a_nursing_or_care_home_nor_homeless:
                    homecat = 0;
                    break;
                case Homecat.Nursing_or_care_home:
                    homecat = 1;
                    break;
                case Homecat.Homeless:
                    homecat = 2;
                    break;
            }
            return homecat;
        }
        public static int learncatToInt(Learncat lc)
        {
            int learncat = 0;
            switch (lc)
            {
                case Learncat.Neither:
                    learncat = 0;
                    break;
                case Learncat.Learning_disability_excluding_Downs_syndrome:
                    learncat = 1;
                    break;
                case Learncat.Downs_syndrome:
                    learncat = 2;
                    break;
            }
            return learncat;
        }
        public static int renalcatToInt(Renalcat rc)
        {
            int renalcat = 1;
            switch (rc)
            {
                case Renalcat.No_CKD:
                    renalcat = 1;
                    break;
                case Renalcat.CKD3:
                    renalcat = 2;
                    break;
                case Renalcat.CKD4:
                    renalcat = 3;
                    break;
                case Renalcat.CKD5_with_neither_dialysis_nor_transplant:
                    renalcat = 4;
                    break;
                case Renalcat.CKD5_with_dialysis:
                    renalcat = 5;
                    break;
                case Renalcat.CKD5_with_transplant:
                    renalcat = 6;
                    break;
            }
            return renalcat;
        }
    }

}
