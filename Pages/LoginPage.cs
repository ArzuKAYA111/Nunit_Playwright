using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_MyProject.Pages
    {
    public class LoginPage
        {
        private static IPage _page;    //     created IPage interface variable

        //defining page elements 
        private readonly ILocator _lnkLogin;
        private readonly ILocator _txtUserName;
        private readonly ILocator _txtPassword;
        private readonly ILocator _btnLogin;
        private readonly ILocator _lnkEmployeeDetails;

        //Using Constructor to initialize All elements 
        public LoginPage(IPage page)
            {
            _page = page;
            _lnkLogin = _page.Locator("text=Login");
            _txtUserName = _page.Locator("#UserName");
            _txtPassword = _page.Locator("#Password");
            _btnLogin = _page.Locator("text=Log in");
            _lnkEmployeeDetails = _page.Locator("text='Employee Details'");

            }

                     // Creating methods to Oerform Actions 

        /*   public async Task ClickLogin()               
               {                                  //   <=== SAME ===>       public async Task ClickLogin() => await _lnkLogin.CheckAsync();
               await _lnkLogin.CheckAsync();
               }*/

        public async Task ClickLogin() => await _lnkLogin.ClickAsync();

        public async Task Login(string userName, string password)
            {
            _txtUserName.FillAsync(userName);
            _txtPassword.FillAsync(password);
            _btnLogin.ClickAsync();

            }

        /*   public async Task<bool> isEmpDetailsExists()
               {                                                     // <=== SAME ===>   public async Task<bool> isEmpDetailsExists() => await _lnkEmployeeDetails.IsVisibleAsync();
               return await _lnkEmployeeDetails.IsVisibleAsync();
               }*/


        public async Task<bool> isEmpDetailsExists() => await _lnkEmployeeDetails.IsVisibleAsync();

        }
    }
