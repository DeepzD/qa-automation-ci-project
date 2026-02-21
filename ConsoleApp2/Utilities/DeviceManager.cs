using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleApp2.Utilities
{
    public class DeviceManager
    {
        public static IWebDriver GetDriver() {

            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

			// Disable breach warning
			options.AddArgument("--disable-save-password-bubble");
			options.AddArgument("--disable-notifications");

			// VERY IMPORTANT: Use temporary profile
			options.AddArgument("--guest");

			IWebDriver driver = new ChromeDriver(options);
			driver.Manage().Window.Maximize();
			return driver;
        }
    }
}
