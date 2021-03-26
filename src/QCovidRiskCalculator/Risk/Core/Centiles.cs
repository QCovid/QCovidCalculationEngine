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

namespace Ox.QCovid
{
    internal static class Centiles
    {
        private readonly static double[,] model20_centiles =
        {
            { 0,0  },
            { .00011774113,.0035609046  },
            { .00015635823,.0051566572  },
            { .0001906649,.0067747864  },
            { .00021873983,.0084679471  },
            { .00024408175,.010249189  },
            { .00026837931,.011938641  },
            { .0002916886,.013399507  },
            { .00031440915,.014514574  },
            { .00033640279,.015543479  },
            { .00035832415,.016518887  },
            { .00037978581,.017431302  },
            { .00040200361,.018295592  },
            { .00042430707,.019131251  },
            { .00044716347,.019939898  },
            { .00047057209,.020714354  },
            { .00049507554,.021485809  },
            { .00052057568,.022240305  },
            { .00054686767,.022991179  },
            { .00057437818,.023739671  },
            { .00060275104,.024478285  },
            { .00063253054,.025216488  },
            { .00066358276,.02595925  },
            { .00069699233,.026702955  },
            { .00073158566,.027452787  },
            { .00076831965,.028218554  },
            { .00080733612,.02898756  },
            { .00084897166,.029773032  },
            { .0008937731,.030561578  },
            { .00094056263,.031379893  },
            { .00099153805,.032216199  },
            { .0010449402,.033070505  },
            { .0011036241,.033952378  },
            { .0011655866,.034857996  },
            { .0012327437,.0358046  },
            { .0013053204,.036775228  },
            { .0013827957,.037794158  },
            { .0014665266,.038848024  },
            { .0015564009,.039938919  },
            { .0016541348,.041046765  },
            { .0017597119,.042212591  },
            { .0018739488,.043412168  },
            { .0019958487,.044652622  },
            { .0021292591,.04593987  },
            { .0022754481,.047254425  },
            { .0024331363,.048608012  },
            { .0026005618,.049999204  },
            { .0027833148,.051459726  },
            { .002978567,.052954491  },
            { .0031926704,.054500159  },
            { .0034238072,.0560745  },
            { .0036729828,.05772873  },
            { .0039423723,.059443116  },
            { .0042336984,.061215986  },
            { .0045464938,.063070416  },
            { .0048896484,.064983048  },
            { .0052610538,.067002878  },
            { .0056597102,.069079168  },
            { .0060924375,.071236573  },
            { .0065658959,.073522225  },
            { .0070827641,.07594002  },
            { .0076438924,.078502916  },
            { .0082585905,.081166774  },
            { .0089257983,.083955348  },
            { .0096564051,.086945169  },
            { .010461868,.090088747  },
            { .011339764,.093391187  },
            { .012302249,.096905515  },
            { .013368877,.1006812  },
            { .014533225,.10466572  },
            { .015807757,.10890447  },
            { .01722574,.11346021  },
            { .018797802,.11831897  },
            { .020546164,.12360435  },
            { .022489324,.12926535  },
            { .024603922,.13535422  },
            { .026967451,.14192459  },
            { .029571006,.1489228  },
            { .032463998,.15668523  },
            { .03568317,.16515264  },
            { .039272107,.1741993  },
            { .04324659,.1841193  },
            { .047722671,.19500439  },
            { .05276148,.20707607  },
            { .058362819,.22049984  },
            { .064676635,.23536642  },
            { .071869083,.25202015  },
            { .080037028,.27093181  },
            { .089461349,.29205143  },
            { .10043349,.3159942  },
            { .11352882,.34397504  },
            { .12880865,.37698334  },
            { .14733459,.41633675  },
            { .17020459,.46499771  },
            { .1990035,.52472085  },
            { .2368518,.60314941  },
            { .28924796,.71045482  },
            { .37031463,.86817193  },
            { .51819724,1.1347612  },
            { .90928626,1.7467871  }
        };

        public static int get_death_centile(double t)
        {
            if (t < 0)
            {
                t = 0;
            }
            int i = 0;
            while (i < 100)
            {
                if (t < model20_centiles[i, 0])
                {
                    break;
                }
                i++;
            }
            return i;
        }

        public static int get_hospital_centile(double t)
        {
            if (t < 0)
            {
                t = 0;
            }
            int i = 0;
            while (i < 100)
            {
                if (t < model20_centiles[i, 1])
                {
                    break;
                }
                i++;
            }
            return i;
        }
    }
}
