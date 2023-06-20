using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_MyProject
    {
    public class Tests_Nunit :PageTest  //PageTest class'a extension yaptik.   Asagidaki Lunch PLaywright, Browser ve Page steplerini yapmamiza gerek kalmiyor.
                                        //Asagidaki code lari yazarken variable olarak olusturdugumuz 'page' yerine Class ismi 'Page' kullanmamiz yeterli oluyor.
        {
  

        [SetUp]
        public void Setup()
            {
            }


        [Test]
        public async Task TestAsync()
            {
      /*      // playwright      { Launches Playwright.  Getting all internet connections etc.
            using var playwright = await Playwright.CreateAsync();


              
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
             
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                Headless = false
                }); ;                                                                                  ******* PageTest e extent yaptigimiz icin bukismi commandout yaptik dolayisi ile 
                                                                                                                Headlesss False kalmis oldu bunu 
                                                                                                                Windows icin Commandline'Terminalden Set HEADED=1  command'i ile yapacagiz.    **********

            // Page

            var page = await browser.NewPageAsync();*/
 // ..........................................................................................................


            // http://www.eaapp.somee.com test yaptigi site

            await Page.GotoAsync("http://www.eaapp.somee.com");
            await Page.ClickAsync("text=Login");

            await Page.ScreenshotAsync(new PageScreenshotOptions
                {
                // ScrennShot root directory de net7.0 folder'in icinde olusuyor
                Path = "testScrnshot.jpg"
                });

            await Page.FillAsync("id=UserName","admin");
            await Page.FillAsync("#Password","password");

            await Page.ClickAsync("text=Log in");

          /*  var isExist = await Page.Locator("text='Employee Details'").IsVisibleAsync();      

                    Assert.IsTrue(isExist);
*/
              await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();





            }
        }
        }
