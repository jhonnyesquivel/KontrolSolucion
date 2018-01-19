using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace Kontrol.Web
{
    public class Global : System.Web.HttpApplication
    {

        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("default",
        "Dashboard/{action}/{categoryName}",
        "~/Test.aspx");

            routes.MapPageRoute("loginRoute",
       "kontrolforms/login/",
       "~/KontrolForms/Login.aspx");


            routes.MapPageRoute("usuarios",
      "kontrolforms/seguridad/usuarios/{evento}/{id}",
      "~/KontrolForms/Seguridad/Usuarios.aspx",true,new RouteValueDictionary { { "evento", "consultar" }, { "id", "0" } });

        }
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}