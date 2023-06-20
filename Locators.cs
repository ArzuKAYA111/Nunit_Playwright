using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_MyProject
    {
    public class Locators : PageTest
        {

        [Test]
        public async Task TestAsync()
            {


            // http://www.eaapp.somee.com test yaptigi site


            await Page.GotoAsync("http://www.eaapp.somee.com");

            var loginElm = Page.Locator("text=Login");
            await loginElm.ClickAsync();


            await Page.ScreenshotAsync(new PageScreenshotOptions
                {
                // ScrennShot root directory de net7.0 folder'in icinde olusuyor
                Path = "testScrnshot.jpg"
                });

            var userName= Page.Locator("id=UserName");
            await userName.FillAsync("admin");

            var password = Page.Locator("#Password");
            await password.FillAsync("password");


            /*  var log_in = Page.Locator("text=Log in");
              await log_in.ClickAsync();*/

            //2 way 
            var btnLog_in = Page.Locator("input", new PageLocatorOptions { HasTextString = "Log in" });

            await btnLog_in.ClickAsync();
            /*  var isExist = await Page.Locator("text='Employee Details'").IsVisibleAsync();      

                      Assert.IsTrue(isExist);
              */

            var empDetl = Page.Locator("text='Employee Details'");

          await Expect(empDetl).ToBeVisibleAsync();






            }
        }
    }
