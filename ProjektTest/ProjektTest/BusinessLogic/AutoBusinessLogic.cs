using ProjektTest.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektTest.BusinessLogic
{
    public class AutoBusinessLogic: IAutoBusinessLogic
    {
        public string CheckIfUserIsAuthAndReturnName()
        {
            string name = "Niezalogowany";
            if (CheckIfUserIsAutorize())
                name = HttpContext.Current.User.Identity.Name;
            return name;
        }
        public bool CheckIfUserIsAutorize()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}