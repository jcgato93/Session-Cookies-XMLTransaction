using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CockiesAndSession.Interfaces
{
    public partial class frmPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Token"] != null)
                {
                    txtLogin.Text = Request.Cookies["Token"].Value;
                }
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Logica.Clases.clsUsuarios usuarios = new Logica.Clases.clsUsuarios();

                DataSet dsConsulta = usuarios.dsConsultar(txtLogin.Text,txtPassword.Text);

                if (dsConsulta.Tables[0].Rows.Count>0)
                {
                    if (chkRecordar.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("Token",txtLogin.Text);
                        cookie.Expires = DateTime.Now.AddDays(2);

                        this.Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        HttpCookie cookie=new HttpCookie("Token", txtLogin.Text);
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        this.Response.Cookies.Add(cookie);
                    }

                    Session["Login"] = txtLogin.Text;
                    Response.Redirect("Inicio");
                }
                else
                {
                    throw new Exception("Login or password incorrect");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}