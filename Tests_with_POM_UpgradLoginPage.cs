using Microsoft.Playwright;
using Playwright_MyProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_MyProject
    {
    public class Tests_with_POM_UpgradLoginPage : PageTest
        {

        [Test]
        public async Task Test_POM_With_UpgretedPage()
            {

            await Page.GotoAsync("http://www.eaapp.somee.com");

            var lgn = new LoginPage_Upgrated(Page);//initialization page class different not like      LoginPage_Upgrated lgn = new LoginPage_Upgrated(Page);

            await lgn.ClickLogin();
           await lgn.Login("admin", "password");

            var isExists = await lgn.isEmpDetailsExists();
               Assert.IsTrue(isExists );

            }



        }
    }
