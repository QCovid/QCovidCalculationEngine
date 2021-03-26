# Introduction 

QCovid&reg; Calculation Engine is an evidence-based model that uses a range of factors such as age, sex, ethnicity and existing medical conditions to predict risk of death or hospitalisation from COVID-19.

To find out more about the QCovid&reg; algorithm, visit https://qcovid.org. This site includes an FAQ and links to publications.

To find out more about how the NHS is using QCovid® Calculation Engine, visit https://digital.nhs.uk/coronavirus/risk-assessment


## About this repository

This repository provides the open source version. This version is not medically certified, and does not include the option of using a UK Postcode to determine the Townsend deprivation score.

Details on the Townsend Score, and how to derive them from the 2011 census data can be found here: https://www.statistics.digitalresources.jisc.ac.uk/dataset/2011-uk-townsend-deprivation-scores, http://s3-eu-west-1.amazonaws.com/statistics.digitalresources.jisc.ac.uk/dkan/files/Townsend_Deprivation_Scores/UK%20Townsend%20Deprivation%20Scores%20from%202011%20census%20data.pdf

To license the CE Marked version of QCovid® Calculation Engine, including the postcode to Townsend mapping module, please contact enquiries@innovation.ox.ac.uk quoting reference 17939.

## Build and test

QCovid® Calculation Engine is a C# library targeting .NET Core 3.1, so you will need both a .NET Core 3.1 SDK and a program capable of building C#. Visual Studio 2019 provides both of these.

- To build the library with Visual Studio 2019, open src/QCovid.sln and run Build > Build Solution.

- To run the included tests, run Test > Run All Tests.

The tests, found at src/QCovidRiskCalculatorTests/QCovidRiskCalculatorTests.cs, also double as examples of how to use the QCovid® Calculation Engine.

## Contribute

Check out the [contributing](CONTRIBUTING.md) page.

## Licence

QCovid® Calculation Engine is Copyright © 2020 Oxford University Innovation Limited.

Code licensed under the [AGPL-v3 licence](LICENSE.md).

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as
    published by the Free Software Foundation, either version 3 of the
    License, or (at your option) any later version.
 
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY.  See the GNU Affero General Public License for more details.
 
This source code version of QCovid® Calculation Engine is provided as is, and as such your use of it is entirely at your own risk.  It is your responsibility to comply with any criminal, civil, regulatory or other legal provisions that may apply in any jurisdiction in which You sell the Software, supply it, make it available or place it on the market, or otherwise put it into service. 
 
**PLEASE NOTE:**
**In its compiled form, QCovid® Calculation Engine is a Class I Medical Device and is covered by the Medical Device Regulations 2002 (as amended).**

**Modification of the source code and subsequently placing that modified code on the market may make that person/entity a legal manufacturer of a medical device and so subject to the requirements listed in Medical Device Regulations 2002 (as amended). Failure to comply with these regulations (for example, failure to comply with the relevant registration requirements or failure to meet the relevant essential requirements) may result in prosecution and a penalty of an unlimited fine and/or 6 months’ imprisonment.These legal consequences are not exhaustive.**
 
You are specifically reminded that under your License, liability is excluded to the fullest extent permitted by law and the relevant wording from the License is copied below.  Where these potential obligations, risks and liabilities are unclear to you, we strongly encourage you to take legal advice in relation to any relevant jurisdiction.
 
    “THERE IS NO WARRANTY FOR THE PROGRAM, TO THE EXTENT PERMITTED BY APPLICABLE LAW. EXCEPT WHEN OTHERWISE STATED
    IN WRITING THE COPYRIGHT HOLDERS AND/OR OTHER PARTIES PROVIDE THE PROGRAM "AS IS" WITHOUT WARRANTY OF ANY KIND,
    EITHER EXPRESSED OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
    FOR A PARTICULAR PURPOSE. THE ENTIRE RISK AS TO THE QUALITY AND PERFORMANCE OF THE PROGRAM IS WITH YOU. 
    SHOULD THE PROGRAM PROVE DEFECTIVE, YOU ASSUME THE COST OF ALL NECESSARY SERVICING, REPAIR OR CORRECTION.
    
    IN NO EVENT UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING WILL ANY COPYRIGHT HOLDER, OR ANY OTHER
    PARTY WHO MODIFIES AND/OR CONVEYS THE PROGRAM AS PERMITTED ABOVE, BE LIABLE TO YOU FOR DAMAGES, INCLUDING ANY
    GENERAL, SPECIAL, INCIDENTAL OR CONSEQUENTIAL DAMAGES ARISING OUT OF THE USE OR INABILITY TO USE THE PROGRAM 
    (INCLUDING BUT NOT LIMITED TO LOSS OF DATA OR DATA BEING RENDERED INACCURATE OR LOSSES SUSTAINED BY YOU OR THIRD
    PARTIES OR A FAILURE OF THE PROGRAM TO OPERATE WITH ANY OTHER PROGRAMS), EVEN IF SUCH HOLDER OR OTHER PARTY 
    HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.”
 
