﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CockiesAndSession
{
    public class Global : System.Web.HttpApplication
    {
        void Rutas(RouteCollection routes)
        {
            
            routes.MapPageRoute("Principal", "Principal","~/Interfaces/frmPrincipal.aspx");
            routes.MapPageRoute("Inicio", "Inicio", "~/Interfaces/frmInicio.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Rutas(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
             
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}