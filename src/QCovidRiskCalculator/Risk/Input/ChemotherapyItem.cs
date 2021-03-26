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
// ReSharper disable UnusedMember.Global because of reflection!
// ReSharper disable StringLiteralTypo

// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

namespace QCovid.RiskCalculator.Risk.Input
{
    /// <summary>
    /// An input representing a specific chemotherapy treatment
    /// </summary>
    public class ChemotherapyItem : IInputOption
    {
        private readonly ChemotherapyGroup _group;

        /// <summary>
        /// &lt; 10 %
        /// </summary>
        public static ChemotherapyItem LessThan10Percent = new ChemotherapyItem(ChemotherapyGroup.GroupA, 0, "< 10 %");

        /// <summary>
        /// 5FU single agent
        /// </summary>
        public static ChemotherapyItem FiveFuSingleAgent =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 1, "5FU single agent");

        /// <summary>
        /// Abiraterone
        /// </summary>
        public static ChemotherapyItem Abiraterone = new ChemotherapyItem(ChemotherapyGroup.GroupA, 2, "Abiraterone");

        /// <summary>
        /// Anagrelide
        /// </summary>
        public static ChemotherapyItem Anagrelide = new ChemotherapyItem(ChemotherapyGroup.GroupA, 3, "Anagrelide");

        /// <summary>
        /// Aromatase inhibitors
        /// </summary>
        public static ChemotherapyItem AromataseInhibitors =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 4, "Aromatase inhibitors");

        /// <summary>
        /// Bevacizumab single agent
        /// </summary>
        public static ChemotherapyItem BevacizumabSingleAgent =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 5, "Bevacizumab single agent");

        /// <summary>
        /// Bisphosphonate
        /// </summary>
        public static ChemotherapyItem Bisphosphonate =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 6, "Bisphosphonate");

        /// <summary>
        /// Busulfan 
        /// </summary>
        public static ChemotherapyItem Busulfan = new ChemotherapyItem(ChemotherapyGroup.GroupA, 7, "Busulfan ");

        /// <summary>
        /// Capecitabine single agent
        /// </summary>
        public static ChemotherapyItem CapecitabineSingleAgent =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 8, "Capecitabine single agent");

        /// <summary>
        /// CDK4/6 inhibitors
        /// </summary>
        public static ChemotherapyItem Cdk4Slash6Inhibitors =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 9, "CDK4/6 inhibitors");

        /// <summary>
        /// Cetuximab
        /// </summary>
        public static ChemotherapyItem Cetuximab = new ChemotherapyItem(ChemotherapyGroup.GroupA, 10, "Cetuximab");

        /// <summary>
        /// Cisplatin based  regimens
        /// </summary>
        public static ChemotherapyItem CisplatinBasedRegimens =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 11, "Cisplatin based  regimens");

        /// <summary>
        /// Denosumab 
        /// </summary>
        public static ChemotherapyItem Denosumab = new ChemotherapyItem(ChemotherapyGroup.GroupA, 12, "Denosumab ");

        /// <summary>
        /// Durvalumab
        /// </summary>
        public static ChemotherapyItem Durvalumab = new ChemotherapyItem(ChemotherapyGroup.GroupA, 13, "Durvalumab");

        /// <summary>
        /// Enzalutamide
        /// </summary>
        public static ChemotherapyItem
            Enzalutamide = new ChemotherapyItem(ChemotherapyGroup.GroupA, 14, "Enzalutamide");

        /// <summary>
        /// Fulvestrant
        /// </summary>
        public static ChemotherapyItem Fulvestrant = new ChemotherapyItem(ChemotherapyGroup.GroupA, 15, "Fulvestrant");

        /// <summary>
        /// Hydroxycarbamide
        /// </summary>
        public static ChemotherapyItem Hydroxycarbamide =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 16, "Hydroxycarbamide");

        /// <summary>
        /// Interferon (all formulations)
        /// </summary>
        public static ChemotherapyItem InterferonAllFormulations =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 17, "Interferon (all formulations)");

        /// <summary>
        /// Ipilimumab
        /// </summary>
        public static ChemotherapyItem Ipilimumab = new ChemotherapyItem(ChemotherapyGroup.GroupA, 18, "Ipilimumab");

        /// <summary>
        /// Lenvatinib
        /// </summary>
        public static ChemotherapyItem Lenvatinib = new ChemotherapyItem(ChemotherapyGroup.GroupA, 19, "Lenvatinib");

        /// <summary>
        /// Methotrexate
        /// </summary>
        public static ChemotherapyItem
            Methotrexate = new ChemotherapyItem(ChemotherapyGroup.GroupA, 20, "Methotrexate");

        /// <summary>
        /// Mitomycin C
        /// </summary>
        public static ChemotherapyItem MitomycinC = new ChemotherapyItem(ChemotherapyGroup.GroupA, 21, "Mitomycin C");

        /// <summary>
        /// mTOR inhibitors
        /// </summary>
        public static ChemotherapyItem MtorInhibitors =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 22, "mTOR inhibitors");

        /// <summary>
        /// Nivolumab 
        /// </summary>
        public static ChemotherapyItem Nivolumab = new ChemotherapyItem(ChemotherapyGroup.GroupA, 23, "Nivolumab ");

        /// <summary>
        /// Panitumumab
        /// </summary>
        public static ChemotherapyItem Panitumumab = new ChemotherapyItem(ChemotherapyGroup.GroupA, 24, "Panitumumab");

        /// <summary>
        /// PARP inhibitors
        /// </summary>
        public static ChemotherapyItem ParpInhibitors =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 25, "PARP inhibitors");

        /// <summary>
        /// Pembrolizumab
        /// </summary>
        public static ChemotherapyItem Pembrolizumab =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 26, "Pembrolizumab");

        /// <summary>
        /// Pemetrexed
        /// </summary>
        public static ChemotherapyItem Pemetrexed = new ChemotherapyItem(ChemotherapyGroup.GroupA, 27, "Pemetrexed");

        /// <summary>
        /// Raltitrexed
        /// </summary>
        public static ChemotherapyItem Raltitrexed = new ChemotherapyItem(ChemotherapyGroup.GroupA, 28, "Raltitrexed");

        /// <summary>
        /// Regorafinib
        /// </summary>
        public static ChemotherapyItem Regorafinib = new ChemotherapyItem(ChemotherapyGroup.GroupA, 29, "Regorafinib");

        /// <summary>
        /// Single agent: Atezolizumab
        /// </summary>
        public static ChemotherapyItem SingleAgentAtezolizumab =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 30, "Single agent: Atezolizumab");

        /// <summary>
        /// Sorafenib
        /// </summary>
        public static ChemotherapyItem Sorafenib = new ChemotherapyItem(ChemotherapyGroup.GroupA, 31, "Sorafenib");

        /// <summary>
        /// Tamoxifen
        /// </summary>
        public static ChemotherapyItem Tamoxifen = new ChemotherapyItem(ChemotherapyGroup.GroupA, 32, "Tamoxifen");

        /// <summary>
        /// Taxane – weekly
        /// </summary>
        public static ChemotherapyItem TaxaneWeekly =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 33, "Taxane – weekly");

        /// <summary>
        /// Tyrosine kinase inhibitors (including ALK &/or ROS)
        /// </summary>
        public static ChemotherapyItem TyrosineKinaseInhibitorsIncludingAlkAndOrRos =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 34, "Tyrosine kinase inhibitors (including ALK &/or ROS)");

        /// <summary>
        /// Trastuzumab +/- pertuzumab
        /// </summary>
        public static ChemotherapyItem TrastuzumabPertuzumab =
            new ChemotherapyItem(ChemotherapyGroup.GroupA, 35, "Trastuzumab +/- pertuzumab");

        /// <summary>
        /// Etoposide based regimens
        /// </summary>
        public static ChemotherapyItem EtoposideBasedRegimens =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 36, "Etoposide based regimens");

        /// <summary>
        /// CMF
        /// </summary>
        public static ChemotherapyItem Cmf = new ChemotherapyItem(ChemotherapyGroup.GroupB, 37, "CMF");

        /// <summary>
        /// Irinotecan and Oxaliplatin based regimens
        /// </summary>
        public static ChemotherapyItem IrinotecanAndOxaliplatinBasedRegimens =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 38, "Irinotecan and Oxaliplatin based regimens");

        /// <summary>
        /// Cabazitaxel
        /// </summary>
        public static ChemotherapyItem Cabazitaxel = new ChemotherapyItem(ChemotherapyGroup.GroupB, 39, "Cabazitaxel");

        /// <summary>
        /// Gemcitabine
        /// </summary>
        public static ChemotherapyItem Gemcitabine = new ChemotherapyItem(ChemotherapyGroup.GroupB, 40, "Gemcitabine");

        /// <summary>
        /// Chorambucil
        /// </summary>
        public static ChemotherapyItem Chorambucil = new ChemotherapyItem(ChemotherapyGroup.GroupB, 41, "Chorambucil");

        /// <summary>
        /// Temozolomide
        /// </summary>
        public static ChemotherapyItem
            Temozolomide = new ChemotherapyItem(ChemotherapyGroup.GroupB, 42, "Temozolomide");

        /// <summary>
        /// Daratumumab
        /// </summary>
        public static ChemotherapyItem Daratumumab = new ChemotherapyItem(ChemotherapyGroup.GroupB, 43, "Daratumumab");

        /// <summary>
        /// Rituximab 
        /// </summary>
        public static ChemotherapyItem Rituximab = new ChemotherapyItem(ChemotherapyGroup.GroupB, 44, "Rituximab ");

        /// <summary>
        /// Obinutuzumab
        /// </summary>
        public static ChemotherapyItem
            Obinutuzumab = new ChemotherapyItem(ChemotherapyGroup.GroupB, 45, "Obinutuzumab");

        /// <summary>
        /// Pentostatin
        /// </summary>
        public static ChemotherapyItem Pentostatin = new ChemotherapyItem(ChemotherapyGroup.GroupB, 46, "Pentostatin");

        /// <summary>
        /// Proteosome inhibitors
        /// </summary>
        public static ChemotherapyItem ProteosomeInhibitors =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 47, "Proteosome inhibitors");

        /// <summary>
        /// IMIDs 
        /// </summary>
        public static ChemotherapyItem Imids = new ChemotherapyItem(ChemotherapyGroup.GroupB, 48, "IMIDs ");

        /// <summary>
        /// PI3Kinase inhibitors
        /// </summary>
        public static ChemotherapyItem Pi3KinaseInhibitors =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 49, "PI3Kinase inhibitors");

        /// <summary>
        /// BTK inhibitors
        /// </summary>
        public static ChemotherapyItem BtkInhibitors =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 50, "BTK inhibitors");

        /// <summary>
        /// JAK inhibitors
        /// </summary>
        public static ChemotherapyItem JakInhibitors =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 51, "JAK inhibitors");

        /// <summary>
        /// Ventoclax
        /// </summary>
        public static ChemotherapyItem Ventoclax = new ChemotherapyItem(ChemotherapyGroup.GroupB, 52, "Ventoclax");

        /// <summary>
        /// Trastuzumab-emtansine
        /// </summary>
        public static ChemotherapyItem TrastuzumabEmtansine =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 53, "Trastuzumab-emtansine");

        /// <summary>
        /// Anthracycline based regimens
        /// </summary>
        public static ChemotherapyItem AnthracyclineBasedRegimens =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 54, "Anthracycline based regimens");

        /// <summary>
        /// FEC
        /// </summary>
        public static ChemotherapyItem Fec = new ChemotherapyItem(ChemotherapyGroup.GroupB, 55, "FEC");

        /// <summary>
        /// MVAC
        /// </summary>
        public static ChemotherapyItem Mvac = new ChemotherapyItem(ChemotherapyGroup.GroupB, 56, "MVAC");

        /// <summary>
        /// ABVD
        /// </summary>
        public static ChemotherapyItem Abvd = new ChemotherapyItem(ChemotherapyGroup.GroupB, 57, "ABVD");

        /// <summary>
        /// CHOP
        /// </summary>
        public static ChemotherapyItem Chop = new ChemotherapyItem(ChemotherapyGroup.GroupB, 58, "CHOP");

        /// <summary>
        /// BEACOPP
        /// </summary>
        public static ChemotherapyItem Beacopp = new ChemotherapyItem(ChemotherapyGroup.GroupB, 59, "BEACOPP");

        /// <summary>
        /// Liposomal doxorubicin 
        /// </summary>
        public static ChemotherapyItem LiposomalDoxorubicin =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 60, "Liposomal doxorubicin ");

        /// <summary>
        /// Taxane – 3 weekly
        /// </summary>
        public static ChemotherapyItem Taxane3Weekly =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 61, "Taxane – 3 weekly");

        /// <summary>
        /// Nab-paclitaxel
        /// </summary>
        public static ChemotherapyItem NabPaclitaxel =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 62, "Nab-paclitaxel");

        /// <summary>
        /// Carboplatin based regimens
        /// </summary>
        public static ChemotherapyItem CarboplatinBasedRegimens =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 63, "Carboplatin based regimens");

        /// <summary>
        /// Ifophosphamide based regimens
        /// </summary>
        public static ChemotherapyItem IfophosphamideBasedRegimens =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 64, "Ifophosphamide based regimens");

        /// <summary>
        /// Bendamustine
        /// </summary>
        public static ChemotherapyItem
            Bendamustine = new ChemotherapyItem(ChemotherapyGroup.GroupB, 65, "Bendamustine");

        /// <summary>
        /// Cladrabine 
        /// </summary>
        public static ChemotherapyItem Cladrabine = new ChemotherapyItem(ChemotherapyGroup.GroupB, 66, "Cladrabine ");

        /// <summary>
        /// Topotecan
        /// </summary>
        public static ChemotherapyItem Topotecan = new ChemotherapyItem(ChemotherapyGroup.GroupB, 67, "Topotecan");

        /// <summary>
        /// Cyclophosphamide/Fludarabine combinations
        /// </summary>
        public static ChemotherapyItem CyclophosphamideSlashFludarabineCombinations =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 68, "Cyclophosphamide/Fludarabine combinations");

        /// <summary>
        /// ICE
        /// </summary>
        public static ChemotherapyItem Ice = new ChemotherapyItem(ChemotherapyGroup.GroupB, 69, "ICE");

        /// <summary>
        /// GDP
        /// </summary>
        public static ChemotherapyItem Gdp = new ChemotherapyItem(ChemotherapyGroup.GroupB, 70, "GDP");

        /// <summary>
        /// DHAP
        /// </summary>
        public static ChemotherapyItem Dhap = new ChemotherapyItem(ChemotherapyGroup.GroupB, 71, "DHAP");

        /// <summary>
        /// ESHAP
        /// </summary>
        public static ChemotherapyItem Eshap = new ChemotherapyItem(ChemotherapyGroup.GroupB, 72, "ESHAP");

        /// <summary>
        /// CVAD
        /// </summary>
        public static ChemotherapyItem Cvad = new ChemotherapyItem(ChemotherapyGroup.GroupB, 73, "CVAD");

        /// <summary>
        /// Dacarbazine based regimens
        /// </summary>
        public static ChemotherapyItem DacarbazineBasedRegimens =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 74, "Dacarbazine based regimens");

        /// <summary>
        /// Lomustine
        /// </summary>
        public static ChemotherapyItem Lomustine = new ChemotherapyItem(ChemotherapyGroup.GroupB, 75, "Lomustine");

        /// <summary>
        /// Mogalizumab
        /// </summary>
        public static ChemotherapyItem Mogalizumab = new ChemotherapyItem(ChemotherapyGroup.GroupB, 76, "Mogalizumab");

        /// <summary>
        /// Brentuximab vedotin
        /// </summary>
        public static ChemotherapyItem BrentuximabVedotin =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 77, "Brentuximab vedotin");

        /// <summary>
        /// Asparaginase based regimens
        /// </summary>
        public static ChemotherapyItem AsparaginaseBasedRegimens =
            new ChemotherapyItem(ChemotherapyGroup.GroupB, 78, "Asparaginase based regimens");

        /// <summary>
        /// All ALL/AML regimens
        /// </summary>
        // ReSharper disable once InconsistentNaming Confusing use of all next to ALL otherwise
        public static ChemotherapyItem AllALLSlashAMLRegimens =
            new ChemotherapyItem(ChemotherapyGroup.GroupC, 79, "All ALL/AML regimens");

        /// <summary>
        /// BEP
        /// </summary>
        public static ChemotherapyItem Bep = new ChemotherapyItem(ChemotherapyGroup.GroupC, 80, "BEP");

        /// <summary>
        /// Highly immunosuppressive chemotherapy (e.g. FluDAP, high dose Methotrexate & Cytarabine)
        /// </summary>
        public static ChemotherapyItem HighlyImmunosuppressiveChemotherapy =
            new ChemotherapyItem(ChemotherapyGroup.GroupC, 81,
                "Highly immunosuppressive chemotherapy (e.g. FluDAP, high dose Methotrexate & Cytarabine)");

        /// <summary>
        /// Trifuradine/ Tipracil
        /// </summary>
        public static ChemotherapyItem TrifuradineSlashTipracil =
            new ChemotherapyItem(ChemotherapyGroup.GroupC, 82, "Trifuradine/ Tipracil");

        /// <inheritdoc />
        public int Index { get; }

        /// <inheritdoc />
        public string DisplayName { get; }

        private ChemotherapyItem(ChemotherapyGroup group, int index, string displayName)
        {
            _group = group;
            Index = index;
            DisplayName = displayName;
        }

        /// <summary>
        /// Get the corresponding Chemotherapy Group from a list of Chemotherapy Items taken in the last 12 months.
        /// An empty list will return the NoneInLast12Months group.
        /// </summary>
        /// <param name="treatments"></param>
        /// <returns></returns>
        public static ChemotherapyGroup GetGroupFromTreatmentList(IEnumerable<ChemotherapyItem> treatments)
        {
            return treatments.Max(t => t._group) ?? ChemotherapyGroup.NoneInLast12Months;
        }

        /// <summary>
        /// Get all available Chemotherapy Items in alphabetical order
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyList<ChemotherapyItem> GetAllOptions()
        {
            return InputOptionHelpers.GetAllPublicStaticFieldsInAlphabeticalOrder<ChemotherapyItem>()
                .ToArray();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Chemotherapy Item {Index} - {DisplayName}";
        }
    }
}
