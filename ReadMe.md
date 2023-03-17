#WWiT SeleniumBase Framework


The Framework is based on snippits take from various areas to assist in making life easier when Automation projects 

This base frame work can be plugged into any C# project and setup to run Automatedt Tests 


#Framework Overview 
The base framework contains a Core module that supports testing on multiple platfoms : Mobile, Web GUI and Api. These module consists out of multiple elements that assist in the day
to day testing tasks and also provides HTML Reports.

#Framework Modules
Core Modules 
	-- Helpers
		These classes are setup to be helper classes for the Core framework currnetly ranges from Encryption helpers to Loghelpers
		While these classes are not limited to only the current set, they can be extended 
	-- Logging 
		These classes assist with all the logging capabilities of the framework
	-- Selenium
		These clases use the base functions of Selenium like the : Driver , Wait and Webdriver factory/options
	-- Services
		These classes are used with Api Testing and contains service calls for rest services
	-- Utilities
		These classes are customs sets of commands used to build basic test cases in a new project


#Additional updates to be added
- Framework Usage 
 * Create new project, add the WWitSeleniumFramework nuget package 
 * Setup runsettings file 
 ***************Example*******************
 <?xml version="1.0" encoding="utf-8" ?>
<RunSettings>
  <!-- Parameters used by tests at runtime on the New Environment -->
  <TestRunParameters>
    <Parameter name="TestUrl" value="https://wwit.netlify.app" />

    <!--Browser Type has a Selection of 
    - Firefox
    - InternetExplorer
    - Edge
    - Chrome
    -->

    <Parameter name="BrowserType" value="Chrome" />
	<Parameter nmae="IsHeadless" value="false" />

  </TestRunParameters>
</RunSettings>

*******************************************
 ## SampleProjects 
  
  The link below has some of the sample projects that ustilizes the framework

 https://github.com/waynewa/SampleProjects