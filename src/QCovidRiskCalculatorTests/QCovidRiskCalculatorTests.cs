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

using System.Data.Common;
using System.Linq;
using Microsoft.Data.Sqlite;
using QCovid.RiskCalculator.BodyMassIndex;
using QCovid.RiskCalculator.CodeMapping;
using QCovid.RiskCalculator.Risk;
using QCovid.RiskCalculator.Risk.Input;
using QCovid.RiskCalculator.Risk.Result;
using QCovid.RiskCalculator.Townsend;
using Xunit;
using Xunit.Abstractions;

namespace QCovidRiskCalculatorTests
{
    public class QCovidRiskCalculatorTests
    {
        // The open-source version accepts any string as a valid key.
        private const string LicenceKey = "";

        private readonly ITestOutputHelper _logging;

        public QCovidRiskCalculatorTests(ITestOutputHelper logging)
        {
            _logging = logging;
        }


        [Fact]
        public void ExampleRiskInputWorkflow()
        {
            // arrange

            // step 1 - initialise the calculator
            IQCovidRiskCalculator calculator = new QCovidRiskCalculator(LicenceKey);

            // step 2 - create input
            // our sample patient is a 55 year-old woman with asthma and no other conditions

            // patient inputs
            var age = new Age(55);
            var bmi = Bmi.CreateFromKgAndCm(60, 155);
            var sex = Sex.Female;
            // in the non-open source version, this would be obtained using the PostcodeToTownsendScoreConverter
            // alternatively, EncryptedTownsendScore.Default is available to provide the average score
            var townsendScore = new EncryptedTownsendScore(1.54);
            var housingCategory = HousingCategory.NeitherInNursingOrCareHomeNorHomeless;
            var ethnicity = Ethnicity.WhiteBritish;

            // clinical inputs
            var diabetes = Diabetes.None;
            var chronicKidneyDisease = ChronicKidneyDisease.None;
            var sickleCellOrSevereCombinedImmunodeficiencySyndrome =
                SickleCellOrSevereCombinedImmunodeficiencySyndrome.None;
            var learningDisabilityOrDownsSyndrome = LearningDisabilityOrDownsSyndrome.Neither;

            var cancerTreatmentsAndImmunoSuppressants = new CancerTreatmentsAndImmunoSuppressants(
                chemotherapyGroup: ChemotherapyGroup.NoneInLast12Months, radioTherapyInLast6Months: false,
                cancerOfBloodOrBoneMarrow: false, boneMarrowTransplantInLast6Months: false, solidOrganTransplant: false,
                prescribedImmunoSuppressantsInLast6Months: false, prescribedOralSteroids: false
            );

            var respiratoryProblems = new RespiratoryProblems(
                asthma: true, takingAntiLeukotrieneOrLaba: false, cysticFibrosisBronchiectasisAlveolitis: false,
                pulmonaryHypertensionOrFibrosis: false, copd: false, lungOrOralCancer: false
            );

            var heartOrCirculationProblems = new HeartOrCirculationProblems(
                congenitalHeartProblem: false, coronaryHeartDisease: false, strokeOrTia: false,
                atrialFibrillation: false, heartFailure: false, peripheralVascularDisease: false,
                thrombosisOrPulmonaryEmbolus: false
            );

            var neurologicalProblems = new NeurologicalProblems(
                parkinsonsDisease: false, epilepsy: false, dementia: false,
                motorNeuroneDiseaseOrMultipleSclerosisOrMyaestheniaOrHuntingtonsChorea: false, cerebralPalsy: false
            );

            var otherConditions = new OtherConditions(
                severeMentalIllness: false, cirrhosisOfTheLiver: false, rheumatoidArthritisOrSle: false,
                priorFractureOfHipWristSpineHumerus: false
            );

            var clinicalInformation = new ClinicalInformation(
                diabetes, chronicKidneyDisease, sickleCellOrSevereCombinedImmunodeficiencySyndrome,
                learningDisabilityOrDownsSyndrome, cancerTreatmentsAndImmunoSuppressants, respiratoryProblems,
                heartOrCirculationProblems, neurologicalProblems, otherConditions
            );

            // construct full input
            var input = new RiskInput(
                age, bmi, sex, townsendScore, housingCategory, ethnicity, clinicalInformation
            );

            // act

            // step 3 - run the calculation
            IRiskResult result = calculator.Calculate(input);

            // step 4 - check for errors preventing a result
            foreach (var errorCode in result.ErrorCodes)
            {
                _logging.WriteLine(errorCode.IsFatal ? "FATAL - {0}" : "{0}", errorCode);
            }

            // step 5 - read results
            LogResults(result);

            // assert
            RunSharedAssertions(result);
        }

        [Fact]
        public void ExampleMedicalCodesWorkflow()
        {
            // arrange

            // step 1 - open a connection to the medical codes database
            // in this example, the zipped file included in the repo is copied to the below directory as a pre-build action
            // however you can host the database however you want, including converting it to another type of SQL database
            var builder = new SqliteConnectionStringBuilder
            {
                DataSource = "./TestData/medical-codes.sqlite",
                Mode = SqliteOpenMode.ReadOnly
            };

            using DbConnection dbConnection = new SqliteConnection(builder.ConnectionString);
            dbConnection.Open();

            // step 2 - initialise the medical codes converter
            using var medicalCodesConverter = new MedicalCodesToRiskInputConverter(LicenceKey, dbConnection);

            // step 3 - create inputs for the medical code converter
            var currentDate = new Date(2020, 03, 19);
            var age = new Age(55);
            var bmi = Bmi.CreateFromKgAndCm(60, 155);
            var sex = Sex.Female;
            var townsendScore = new EncryptedTownsendScore(1.54);

            var codes = new[]
            {
                // snomed code for white, british
                new MedicalCodeInstance(CodeType.Snomed, "315236000", new Date(2000, 1, 1)),
                // snomed code for asthma
                new MedicalCodeInstance(CodeType.Snomed, "103781000119103", new Date(2000, 1, 1))
            };

            // act

            // step 4 - get risk inputs from the converter
            MedicalCodeMappingResult mappingResult =
                medicalCodesConverter.CreateRiskInputFromMedicalCodes(currentDate, codes, age, sex, townsendScore, bmi);

            // step 5 - check medical codes were recognised
            foreach (var errorCode in mappingResult.ErrorCodes)
            {
                _logging.WriteLine(errorCode.IsFatal ? "FATAL - {0}" : "{0}", errorCode);
            }

            _logging.WriteLine("Recognised medical codes: ");
            if (mappingResult.RecognisedMedicalCodes.Any())
            {
                foreach (var medicalCode in mappingResult.RecognisedMedicalCodes)
                {
                    _logging.WriteLine(medicalCode.Code);
                }
            }
            else
            {
                _logging.WriteLine("None");
            }

            _logging.WriteLine("Unrecognised medical codes: ");
            if (mappingResult.UnrecognisedMedicalCodes.Any())
            {
                foreach (var medicalCode in mappingResult.UnrecognisedMedicalCodes)
                {
                    _logging.WriteLine(medicalCode.Code);
                }
            }
            else
            {
                _logging.WriteLine("None");
            }

            // step 6 - calculate risk as normal
            IQCovidRiskCalculator calculator = new QCovidRiskCalculator(LicenceKey);
            IRiskResult result = calculator.Calculate(mappingResult.RiskInput);

            // step 7 - get risk inputs from the converter
            foreach (var errorCode in result.ErrorCodes)
            {
                _logging.WriteLine(errorCode.IsFatal ? "FATAL - {0}" : "{0}", errorCode);
            }

            // step 8 - read results
            if (!mappingResult.ErrorCodes.Any(e => e.IsFatal))
            {
                LogResults(result);
            }

            // assert

            Assert.DoesNotContain(mappingResult.ErrorCodes, errorCode => errorCode.IsFatal);
            Assert.Equal(2, mappingResult.RecognisedMedicalCodes.Count);
            Assert.Empty(mappingResult.UnrecognisedMedicalCodes);

            RunSharedAssertions(result);
        }

        private void LogResults(IRiskResult result)
        {
            if (!result.ErrorCodes.Any(e => e.IsFatal))
            {
                // if no fatal errors, the risk results will not be null
                _logging.WriteLine("Risk of death for patient: {0:0.0000}%",
                    result.ResultForPatient.Death!.RiskPercentage);
                _logging.WriteLine("Risk of death for a typical person of the same age and sex: {0:0.0000}%",
                    result.ResultForTypicalPersonSameAgeSex.Death!.RiskPercentage);
                _logging.WriteLine("Relative risk of death: {0:0.0000}",
                    result.ResultForPatient.Death!.RiskPercentage /
                    result.ResultForTypicalPersonSameAgeSex.Death!.RiskPercentage);
                _logging.WriteLine("Risk of hospitalisation for patient: {0:0.0000}%",
                    result.ResultForPatient.Hospitalisation!.RiskPercentage);
                _logging.WriteLine("Risk of hospitalisation for a typical person of the same age and sex: {0:0.0000}%",
                    result.ResultForTypicalPersonSameAgeSex.Hospitalisation!.RiskPercentage);
                _logging.WriteLine("Relative risk of hospitalisation: {0:0.0000}",
                    result.ResultForPatient.Hospitalisation!.RiskPercentage /
                    result.ResultForTypicalPersonSameAgeSex.Hospitalisation!.RiskPercentage);
                _logging.WriteLine("Risk of death rank: {0:0} / 100 where 100 is most at risk",
                    result.ResultForPatient.Death.Centile);
            }
        }

        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private static void RunSharedAssertions(IRiskResult result)
        {
            Assert.DoesNotContain(result.ErrorCodes, errorCode => errorCode.IsFatal);

            Assert.Equal(0.0042, result.ResultForPatient.Death!.RiskPercentage, 4);
            Assert.Equal(0.0575, result.ResultForPatient.Hospitalisation!.RiskPercentage, 4);

            Assert.Equal(0.0045, result.ResultForTypicalPersonSameAgeSex.Death!.RiskPercentage, 4);
            Assert.Equal(0.0452, result.ResultForTypicalPersonSameAgeSex.Hospitalisation!.RiskPercentage, 4);

            Assert.Equal(54, result.ResultForPatient.Death!.Centile);

            Assert.Equal(24.97, result.Input.Bmi.BodyMassIndex, 2);
        }
    }
}
