using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer
{
    public class LoginPresenter
    {
        private readonly Login login;

        public LoginPresenter(Login login)
        {
            this.login = login;
            this.login.LoginBtn += LoginFunc;
        }
        public void LoginFunc()
        {
            this.login.LoginV();

        }
    }
}
