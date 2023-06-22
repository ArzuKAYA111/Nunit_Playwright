using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_MyProject.Pages
    {
   public class LoginPage_Upgrated
        {
        private IPage _page;    //     created IPage interface variable

      public  LoginPage_Upgrated(IPage page)
            {
            _page = page;
            }


        //defining page elements 

    
        private ILocator _lnkLogin => _page.Locator("text=Login");
        private ILocator _txtUserName => _page.Locator("#UserName");
        private ILocator _txtPassword => _page.Locator("#Password");
        private ILocator _btnLogin => _page.Locator("text=Log in");
        private ILocator _lnkEmployeeDetails => _page.Locator("text='Employee Details'");

        // Creating methods to perform Actions 


        public async Task ClickLogin() => await _lnkLogin.ClickAsync();

        public async Task Login(string userName, string password)
            {
            await _txtUserName.FillAsync(userName);
            await _txtPassword.FillAsync(password);
            await _btnLogin.ClickAsync();

            }

        public async Task<bool> isEmpDetailsExists() => await _lnkEmployeeDetails.IsVisibleAsync();
            
        }
    }
