using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManagerPro.ViewModel;

namespace ManagerPro.BusinessLayer
{
    public class IsValidUser
    {
        public bool IsUser(UserDetails user)
        {
            if (user.UserName == "Admin" && user.PassWord == "jjck@123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}