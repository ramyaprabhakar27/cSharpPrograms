using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using worksheet = Microsoft.Office.Interop.Excel.Worksheet;
using workbook = Microsoft.Office.Interop.Excel.Workbook;
using OpenQA.Selenium.Interactions;
using System.Runtime.InteropServices;

namespace ReadWriteExcel
{
    public class Read_Write_excel
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }


        [Test]
        public void ReadValuesFromExcelAndWrite()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            //string str;
            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.Application();
            /* {
                 Visible = false
             };*/
            //Opening Excel file
            // xlWorkBook = xlApp.Workbooks.Open(@"C:\ShopGo_Docs\ExeclData.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            xlWorkBook = xlApp.Workbooks.Open(@"C:\ShopGo_Docs\ExcelData.xls");
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Add");
            //Gives the used cells in the sheet
            range = xlWorkSheet.UsedRange;
            for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                for (cCnt = 1; cCnt <= (range.Columns.Count) - 1; cCnt += 2)
                {
                    //Get the string from the sheet
                    double a = Convert.ToDouble((range.Cells[rCnt, cCnt] as Excel.Range).get_Value());
                    double b = Convert.ToDouble((range.Cells[rCnt, cCnt + 1] as Excel.Range).get_Value());
                    double c = Convert.ToDouble(a + b);
                    xlWorkSheet.Cells[rCnt, cCnt + 2] = c;
                    //xlApp.Cells[rCnt, cCnt + 2] = c;
                }
            }
            xlWorkBook.Save();
            xlWorkBook.Close();
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }




        [Test]
        public void CashrewardsConnectExcel()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            // Excel.Range range;

            //string str;
            int rCnt = 8;
            int cCnt = 2;
            string Username;
            string Password;

            string baseURL = "https://www.cashrewards.com.au/";
            driver.Navigate().GoToUrl(baseURL + "/");
            Assert.AreEqual("Sign In", driver.FindElement(By.Id("lnkSignIn")).Text);
            driver.FindElement(By.Id("lnkSignIn")).Click();

            xlApp = new Excel.Application();
            //{
            // Visible = false
            //  };
            //Opening Excel file
            xlWorkBook = xlApp.Workbooks.Open(@"C:\ShopGo_Docs\ExcelData.xls");
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("CashRewards");
            // int row = xlWorkSheet.Rows.get_Value();
            //range = xlWorkSheet.UsedRange;
            try
            {
                for (rCnt = 2; rCnt <= 8; rCnt++)
                {
                    for (cCnt = 1; cCnt <= (2) - 1; cCnt += 2)
                    {
                        if ((xlWorkSheet.Cells[rCnt, cCnt] as Excel.Range).get_Value() != null)
                            Username = (xlWorkSheet.Cells[rCnt, cCnt] as Excel.Range).get_Value();
                        else
                            Username = "";

                        if ((xlWorkSheet.Cells[rCnt, cCnt + 1] as Excel.Range).get_Value() != null)
                            Password = (xlWorkSheet.Cells[rCnt, cCnt + 1] as Excel.Range).get_Value();
                        else
                            Password = "";

                        driver.FindElement(By.Name("EmailAddress")).Click();
                        driver.FindElement(By.Name("EmailAddress")).Clear();
                        Thread.Sleep(2000);
                        driver.FindElement(By.Name("EmailAddress")).SendKeys(Username);
                        driver.FindElement(By.Name("Password")).Click();
                        driver.FindElement(By.Name("Password")).Clear();
                        Thread.Sleep(2000);
                        driver.FindElement(By.Name("Password")).SendKeys(Password);
                        //driver.FindElement(By.Id("checkbox1")).Click();
                        /* try
                         {
                             Assert.AreEqual(" Keep me signed in", driver.FindElement(By.CssSelector("div.terms")).Text);
                         }
                         catch (AssertionException e)
                         {
                             verificationErrors.Append(e.Message);
                         }*/
                        driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
                        Thread.Sleep(5000);
                        try
                        {
                            string value = Convert.ToString(xlWorkSheet.Cells[rCnt, cCnt + 2]);
                            Assert.AreEqual(value, driver.FindElement(By.CssSelector("h5")).Text);
                        }
                        catch (AssertionException e)
                        {
                            verificationErrors.Append(e.Message);
                        }
                        String i = driver.FindElement(By.ClassName("erroMessages")).Text;
                        //String i = driver.FindElement(By.CssSelector("h5")).Text;
                        xlWorkSheet.Cells[rCnt, cCnt + 3] = i;
                        //xlApp.Cells[rCnt, cCnt + 2] = i;

                        //Console.WriteLine("Username : " + Username + " Password : " + Password + " Error Message : " + i);

                        // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    }
                }
            }
            finally
            {
                xlWorkBook.Save();
                xlWorkBook.Close();
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
        }

        [Test]
        public void ConnectExcel()
        {
            // string baseURL = "https://www.cashrewards.com.au/";
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;
            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.Application();
            //Opening Excel file
            xlWorkBook = xlApp.Workbooks.Open(@"C:\ShopGo_Docs\ExcelData.xls");
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("GoogleSearch");

            //Gives the used cells in the sheet
            range = xlWorkSheet.UsedRange;

            for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                    //Get the string from the sheet
                    str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                    driver.Navigate().GoToUrl("http://www.google.com.au");
                    // Find the text input element by its name
                    IWebElement query = driver.FindElement(By.Name("q"));
                    // Convert the search string to lower case
                    string lowerstr = str.ToLower();
                    // Input the search string
                    query.SendKeys(lowerstr);
                    // Submit the form
                    query.Submit();

                    // Google's search is rendered dynamically with JavaScript.
                    // Wait for the page to load, timeout after 5 seconds
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    IWebElement title = wait.Until<IWebElement>((d) =>
                    {
                        return d.FindElement(By.ClassName("ab_button"));
                    });

                    //Check that the Title is what we are expecting
                    Assert.True(driver.Title.ToLower().StartsWith(lowerstr));
                    //Assert.True(driver.Title.Contains(lowerstr));
                    //Console.WriteLine("Page Title is: " + driver.Title);
                }
            }
            xlWorkBook.Save();
            xlWorkBook.Close();
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }



        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}