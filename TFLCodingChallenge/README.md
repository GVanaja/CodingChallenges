# TFLRoadStatus

Sample Console application , demonstrating a use of TFL open data Rest API to get RoadStatus and NUnit Test Cases to test the API data.This refrence application is meant to support the Console application with .Net Framework 4.5.2 and VisualStudio 2017.

![API] https://api.tfl.gov.uk/Road/RoadName?app_id=your_app_id&app_key=your_developer_key

The goal of this sample is to get the Road Status by RoadName

## Running the sample

After unZip the TFLCodingChallenge open the solution File in Visual Studio 2017.

### Configuring the sample in order to Run

1.Ensure you should Place valid AppId and AppKey Values in the app.config File of TFLCodingChallenge project

2. Build the solution 

3. Open Command Prompt and excute the following Commands

[UnZippedFolderpath]\TFLCodingChallenge\TFLCodingChallenge\bin\Debug\TFLCodingChallenge.exe A2

output as beloow after running the above command

The status of the A2 is as follows
Road Status is Good
Road Status Description is No Exceptional Delays

[UnZippedFolderpath]\TFLCodingChallenge\TFLCodingChallenge\bin\Debug\TFLCodingChallenge.exe A233

output as beloow after running the above command

A233 is not a valid road.

[UnZippedFolderpath]\TFLCodingChallenge\TFLCodingChallenge\bin\Debug\TFLCodingChallenge.exe A406

output as beloow after running the above command

The status of the North Circular (A406) is as follows
Road Status is Closure
Road Status Description is Closure

4. In order to Run the Test Case in Visual Studio select  TestExplorer Window of Test toolbar.

5.In TestExplorer click on Run All.

