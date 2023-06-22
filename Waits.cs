using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_MyProject
    {
    public class Waits : PageTest
        {

        [Test]
        public async Task TestAsync()
            {
            //We can add implicit wait directly to the "Page" like below   (It will be global)
            Page.SetDefaultTimeout(5000);

            // http://www.eaapp.somee.com test yaptigi site

            // *********   by default playwright apply auto waiting to actions/methods but if we want to add custom wait for specific conditions we can add   like below in GotoAsync() method
          
            /*	Rightclick on  GotoAsync(url) > click on Go to definition > rightclick on PageGotoOptions 

            parameter > go to definition > see the options in [JsonPropertyName] tabs    

            Options you can see  Timeout,  WaitUntil etc.   use one of them and over write like below 
            */

            await Page.GotoAsync("http://www.eaapp.somee.com", new PageGotoOptions
                {
                WaitUntil=WaitUntilState.DOMContentLoaded
                });

            var loginElm = Page.Locator("text=Login");
            await loginElm.ClickAsync(new LocatorClickOptions
                {
                Timeout=500
                });


            await Page.ScreenshotAsync(new PageScreenshotOptions
                {
                // ScrennShot root directory de net7.0 folder'in icinde olusuyor
                Path = "testScrnshot.jpg"
                });

            var userName= Page.Locator("id=UserName");
            await userName.FillAsync("admin",new LocatorFillOptions
                {
                Force=true
                });

            var password = Page.Locator("#Password");
            await password.FillAsync("password");


            /*  var log_in = Page.Locator("text=Log in");
              await log_in.ClickAsync();*/

            //2 way 
            var btnLog_in = Page.Locator("input", new PageLocatorOptions { HasTextString = "Log in" });

            await btnLog_in.ClickAsync();

            /*  NOT : for some methods therei is no Wait options like IsVisibleAsync() method. We can use different methods instead of those method (if exist)  to add wait.
             *  For example instead of IsVisibleAsync() method we can use ToBeVisibleAsync() method. */
            var isExist = await Page.Locator("text='Employee Details'").IsVisibleAsync();

            Assert.IsTrue(isExist);


            var empDetl = Page.Locator("text='Employee Details'");

          await Expect(empDetl).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions
              {
              Timeout =5000
              });






            }
        }
    }
