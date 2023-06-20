
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Playwright_MyProject;     // namespace ....> C# feature  /  Use to organize and the level of seperation of code 

[Parallelizable(ParallelScope.Self)]  // provides to run codes in parallel to   ParallelScope can be different from      Self
[TestFixture]
public class Example : PageTest     //    : means extent     PageTest...> comming rfrom playwright
    {
    [Test]     // if there is no [Test] attribute  Test expplorer will not appear 
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.                                     >
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));   //Expect(Page) ..... assertion its comes from playwright

        // create a locator
        var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
        }
    }