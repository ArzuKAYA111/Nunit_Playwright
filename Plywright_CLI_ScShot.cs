using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_MyProject
    {
    public class CLI_ScrShot 
        {                               

        [Test]
         public static async Task Main()
                {
                using var playwright = await Playwright.CreateAsync();
                await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                    Headless = false,
                    });
                var context = await browser.NewContextAsync();

                var page = await context.NewPageAsync();

                await page.GotoAsync("http://www.eaapp.somee.com/");

                await page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();

                await page.GetByLabel("UserName").ClickAsync();

                await page.GetByLabel("UserName").FillAsync("admin");

                await page.GetByLabel("Password").ClickAsync();

                await page.GetByLabel("Password").FillAsync("password");

                await page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

                await page.GetByRole(AriaRole.Link, new() { Name = "Employee Details" }).ClickAsync();


            }
        }
    }
