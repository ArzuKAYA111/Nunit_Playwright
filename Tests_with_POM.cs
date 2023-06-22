using Microsoft.Playwright;
using Playwright_MyProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_MyProject
    {
    public class Tests_with_POM : PageTest
        {

        [Test]
        public async Task Test_POM()
            {

            await Page.GotoAsync("http://www.eaapp.somee.com");

            LoginPage lgin = new LoginPage(Page);

            lgin.ClickLogin();
            lgin.Login("admin", "password");


            await Page.ScreenshotAsync(new PageScreenshotOptions
                {
                // ScrennShot root directory de net7.0 folder'in icinde olusuyor
                Path = "test_POM_Scrnshot.jpg"
                });

            var isExists = await lgin.isEmpDetailsExists();


            }



        }
    }
