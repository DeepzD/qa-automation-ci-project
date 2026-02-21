using System.Threading;
using ConsoleApp2.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

internal class Program
{
    private static void Main(string[] args)
    {
        //Open Chrome Brower
		IWebDriver driver = DeviceManager.GetDriver();
		//Launch TurnUp Portal
		driver.Navigate().GoToUrl("http://horse.industryconnect.io/");

		
		//Identify username textbox and enter valid username
		IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
		usernameTextbox.SendKeys("hari");

		//Identify password textbox and enter valid password
		IWebElement passwordTextox = driver.FindElement(By.Id("Password"));
		passwordTextox.SendKeys("123123");
		
		//identify Login button and click on it
		IWebElement loginButton = driver.FindElement(By.XPath("//input[@type='submit']"));
		loginButton.Click();
		Thread.Sleep(5000);
		// Check if user has logged in successfully
		IWebElement loggedUser = driver.FindElement(By.XPath("//form[@id='logoutForm']/ul/li"));
		if (loggedUser.Text == "Hello hari!")
		{
			Console.WriteLine("User has logged in successfully. Test passed!");
		}
		else
		{
			Console.WriteLine("User has not logged in successfully. Test Failed!");
		}
		

		//Create New Time and Material Recor
		//Thread.Sleep(5000);
		IWebElement administratorMenu = driver.FindElement(By.XPath("//ul[@class='nav navbar-nav']/li[5]/a/span"));
		administratorMenu.Click();

		//Thread.Sleep(5000);
		IWebElement timeAndMaterialsMenu = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
		timeAndMaterialsMenu.Click();
		

		IWebElement createNew = driver.FindElement(By.XPath("//*[@id='container']/p/a[text()='Create New']"));
		WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
		wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id='container']/p/a[text()='Create New']")));
		createNew.Click();

		
		//Fill the form
		IWebElement typeOfCode = driver.FindElement(By.XPath("//span[@aria-owns='TypeCode_listbox']"));
		typeOfCode.Click();
		Thread.Sleep(5000);
		String valueToSelect = "Time";
		IWebElement typeOption = driver.FindElement(By.XPath($"//ul[@id='TypeCode_listbox']/li[text()='{valueToSelect}']"));
		typeOption.Click();
		

		IWebElement code = driver.FindElement(By.CssSelector("#Code"));
		code.SendKeys("1234");

		IWebElement description = driver.FindElement(By.Id("Description"));
		description.SendKeys("1234DescriptionDescription");

		IWebElement priceOverlapTag = driver.FindElement(By.XPath("//input[@class='k-formatted-value k-input']"));
		priceOverlapTag.Click();

		IWebElement price = driver.FindElement(By.Id("Price"));
		price.SendKeys("12.34");

		IWebElement files = driver.FindElement(By.Id("files"));
		files.SendKeys("C:\\Users\\deepi\\OneDrive\\Documents\\Desktop\\Industry Connect\\workspace\\TAProgramme2\\ConsoleApp2\\ConsoleApp2\\test.txt");

		IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
		saveButton.Click();

		//Thread.Sleep(5000);
		
		//Go to last page(pagination)

		IWebElement lastpage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@title='Go to the last page']")));
		lastpage.Click();

		IWebElement newrecord = driver.FindElement(By.XPath("//table[@role='grid']//tbody/tr[last()]/td[1]"));
		

		if(newrecord.Text=="1234")
		{
			Console.WriteLine("Newrecord is created successfylly");
		}
		else
		{
			Console.WriteLine("Newrecord is not created successfylly");
		}
	}
}
