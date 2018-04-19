using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;

namespace SeleniumInvokationCore
{
	// Enter the browser names as one of the following 
	// Chrome, Firefox, IE, Edge, Opera, Appium-Android, Appium-iOS, PhantomJS
	public static class InvokationManagement
	{
		static IWebDriver InbrowserObject = null;
		static RemoteWebDriver remoteBrowserObject = null;
		//ChromeDriverPath is where the chromium driver is.
		public static IWebDriver InvokeChrome(String ChromeDriverPath = @"C:\Selenium\Browsers drivers\")
		{
			InbrowserObject = null;
			InbrowserObject = new ChromeDriver(ChromeDriverPath);
			return InbrowserObject;
		}
		//FirefoxDriverPath is where the firefox driver is.
		public static IWebDriver InvokeFirefox(String FirefoxBrowserPath = @"C:\Program Files\Mozilla Firefox\firefox.exe", 
			String FirefoxDriverPath = @"C:\Selenium\Browsers drivers\",
			String FirefoxDriverName = "geckodriver.exe")
		{
			InbrowserObject = null;
			FirefoxDriverService firefoxDriverService =
				FirefoxDriverService.CreateDefaultService(FirefoxDriverPath, FirefoxDriverName);
			firefoxDriverService.FirefoxBinaryPath = FirefoxBrowserPath;
			InbrowserObject = new FirefoxDriver(firefoxDriverService);
			return InbrowserObject;
		}
		//IEDriverPath is where the firefox driver is.
		public static IWebDriver InvokeInternetExplorer(String IEDriverPath = @"C:\Selenium\Browsers drivers\")
		{
			InbrowserObject = null;
			InbrowserObject = new InternetExplorerDriver(IEDriverPath);
			return InbrowserObject;
		}
		//EdgeDriverPath is where the firefox driver is.
		public static IWebDriver InvokeEdge(String EdgeDriverPath = @"C:\Selenium\Browsers drivers\")
		{
			InbrowserObject = null;
			InbrowserObject = new EdgeDriver(EdgeDriverPath);
			return InbrowserObject;
		}
		//OperaDriverPath is where the firefox driver is.
		//OperaBrowserPath is where the opera browser is installed.
		//OperaDriverName is the name of the opera driver with its' extension (ex: .exe)
		public static IWebDriver InvokeOpera(String OperaBrowserPath = @"C:\Program Files\Opera\51.0.2830.55\opera.exe",
			String OperaDriverPath = @"C:\Selenium\Browsers drivers\",
			String OperaDriverName = "operadriver.exe")
		{
			InbrowserObject = null;
			OperaDriverService operaDriverService =
						OperaDriverService.CreateDefaultService(OperaDriverPath, "operadriver.exe");
			OperaOptions options = new OperaOptions();
			options.BinaryLocation = (OperaBrowserPath);
			InbrowserObject = new OperaDriver(operaDriverService, options);
			return InbrowserObject;
		}
		//PhantomjsDriverPath is where the phantomJS driver is.
		//PhantomjsDriverName is the name of the PhantomJS driver with its' extension (ex: .exe)
		public static IWebDriver InvokePhantomJS(String PhantomjsDriverPath = @"C:\Selenium\Browsers drivers\",
			String PhantomjsDriverName = "phantomjs.exe")
		{
			PhantomJSDriverService phantomJSDriverService =
						PhantomJSDriverService.CreateDefaultService(PhantomjsDriverPath, "phantomjs.exe");
			PhantomJSOptions phantomJSOptions = new PhantomJSOptions();
			InbrowserObject = new PhantomJSDriver(phantomJSDriverService, phantomJSOptions);
			return InbrowserObject;
		}
		//Refer to appium documentation for the variables meaning.
		public static RemoteWebDriver InvokeAppiumAndroid(String AppiumDriverUrl = "http://127.0.0.1:4723/wd/hub",
			String deviceName = "",
			String PlatformVersion = "8.0.0",
			String app = "",
			String appPackage = "",
			String appWaitActivity = "")
		{
			remoteBrowserObject = null;
			try
			{
				DesiredCapabilities desiredCapabilitiesAndroid = new DesiredCapabilities();
				desiredCapabilitiesAndroid.SetCapability("deviceName", "" + deviceName + "");
				desiredCapabilitiesAndroid.SetCapability("platformName", "Android");
				desiredCapabilitiesAndroid.SetCapability("platformVersion", "" + PlatformVersion + "");
				desiredCapabilitiesAndroid.SetCapability("app", "" + app + "");
				desiredCapabilitiesAndroid.SetCapability("appPackage", "" + appPackage + "");
				desiredCapabilitiesAndroid.SetCapability("appWaitActivity", "" + appWaitActivity + "");
				remoteBrowserObject = new RemoteWebDriver(new Uri(AppiumDriverUrl), desiredCapabilitiesAndroid, TimeSpan.FromMinutes(10));
			} catch (Exception e)
			{
				Console.WriteLine("An exception happened. Please, validate the inputs and prerequisites.");
				Console.WriteLine(e.StackTrace.ToString());
			}
			return remoteBrowserObject;
		}
		//Refer to appium documentation for the variables meaning.
		public static RemoteWebDriver InvokeAppiumiOS(String AppiumDriverUrl = "http://127.0.0.1:4723/wd/hub",
			String app = "",
			String PlatformVersion = "11.0.2",
			String appName = "",
			String deviceUDID = "",
			String deviceName = "iPhone")
		{
			remoteBrowserObject = null;
			try
			{
				DesiredCapabilities desiredCapabilitiesiOS = new DesiredCapabilities();
				desiredCapabilitiesiOS.SetCapability("platformName", "iOS");
				desiredCapabilitiesiOS.SetCapability("app", "" + app + "");
				desiredCapabilitiesiOS.SetCapability("platformVersion", "" + PlatformVersion + "");
				desiredCapabilitiesiOS.SetCapability("launchTimeout", "20000");
				desiredCapabilitiesiOS.SetCapability("appName", "");
				desiredCapabilitiesiOS.SetCapability("udid", "" + deviceUDID + "");
				desiredCapabilitiesiOS.SetCapability("fullReset", "true");
				desiredCapabilitiesiOS.SetCapability("automationName", "XCUITest");
				desiredCapabilitiesiOS.SetCapability("deviceName", "" + deviceName + "");
				remoteBrowserObject = new RemoteWebDriver(new Uri(AppiumDriverUrl), desiredCapabilitiesiOS, TimeSpan.FromMinutes(10));

			} catch (Exception e)
			{
				Console.WriteLine("An exception happened. Please, validate the inputs and prerequisites.");
				Console.WriteLine(e.StackTrace.ToString());
			}
			return remoteBrowserObject;
		}
	}
}