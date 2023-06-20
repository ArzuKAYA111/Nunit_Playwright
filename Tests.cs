using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_MyProject
    {
    public class Tests
        {

        [SetUp]
        public void Setup()
            {
            }


        [Test]
        public async Task TestAsync()
            {
            // playwright      { Launches Playwright.  Getting all internet connections etc.
            using var playwright = await Playwright.CreateAsync();


            /*  
             *     By Default playwrigt runs the browser in headless mode. Headless=true   we can do Headles =false 
             *      
             *      LaunchAsync() method definitinina gidersek orada gorecegimiz gibi bu methodun     BrowserTypeLaunchOptions   parameter'i var
             *  
             *  BrowserTypeLaunchOptions 'in definitionina gittigimizde orada asagidaki optionlar var
             *  
             *    Args = clone.Args;
        Channel = clone.Channel;                                            HandleSIGINT = clone.HandleSIGINT;
        ChromiumSandbox = clone.ChromiumSandbox;                            HandleSIGTERM = clone.HandleSIGTERM;
        Devtools = clone.Devtools;                                          Headless = clone.Headless;
        DownloadsPath = clone.DownloadsPath;                                IgnoreAllDefaultArgs = clone.IgnoreAllDefaultArgs;
        Env = clone.Env;                                                    IgnoreDefaultArgs = clone.IgnoreDefaultArgs;
        ExecutablePath = clone.ExecutablePath;                              Proxy = clone.Proxy;
        FirefoxUserPrefs = clone.FirefoxUserPrefs;                          SlowMo = clone.SlowMo;
        HandleSIGHUP = clone.HandleSIGHUP;                                  Timeout = clone.Timeout;
                                                                            TracesDir = clone.TracesDir;

           LaunchAsync() methodundan optionlari kullanarak default headless olani  asagidaki gibi yaparak degistirebiliriz
                   
           
            // Browser  
             */
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                Headless = false
                }); ;

            // Page

            var page = await browser.NewPageAsync();

            // http://www.eaapp.somee.com test yaptigi site

            await page.GotoAsync("http://www.eaapp.somee.com");
            await page.ClickAsync("text=Login");

       /*    await page.ScreenshotAsync(new PageScreenshotOptions
                    {
                 // ScrennShot root directory de net7.0 folder'in icinde olusuyor
             Path="testScrnshot.jpg"
            });
*/
            await page.FillAsync("id=UserName","admin");
            await page.FillAsync("#Password","password");

            await page.ClickAsync("text=Log in");

            var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync();      

                    Assert.IsTrue(isExist);
            }
        }
        }
