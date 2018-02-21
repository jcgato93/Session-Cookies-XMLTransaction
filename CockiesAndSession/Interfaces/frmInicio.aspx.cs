using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CockiesAndSession.Interfaces
{
    public partial class frmInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Login"]==null)
                {
                    Response.Redirect("Principal");
                }
                else
                {
                    lblUsuario.Text = Session["Login"].ToString();
                }
            }
        }

    

        protected void gvwDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Eliminar")
            {
                int inIndex = Convert.ToInt32(e.CommandArgument);

                DataTable dtDatos = (DataTable)Session["datos"];
                dtDatos.Rows.RemoveAt(inIndex);

                Session["datos"] = dtDatos;
                gvwDatos.DataSource = dtDatos;
                gvwDatos.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dtDatos = new DataTable();

                if (Session["datos"] == null)
                {
                    dtDatos.Columns.Add("prodCodigo", typeof(string));
                    dtDatos.Columns.Add("prodDescripcion", typeof(string));
                    dtDatos.Columns.Add("prodCantidad", typeof(string));
                    dtDatos.Columns.Add("prodValor", typeof(string));
                }
                else
                {
                    dtDatos = (DataTable)Session["datos"];
                }

                DataRow drRow = dtDatos.NewRow();
                drRow["prodCodigo"]=txtCodigo.Text;
                drRow["prodDescripcion"] = txtDescripcion.Text;
                drRow["prodCantidad"] = txtCantidad.Text;
                drRow["prodValor"] = txtValor.Text;


                dtDatos.Rows.Add(drRow);
                dtDatos.AcceptChanges();

                gvwDatos.DataSource = dtDatos;
                gvwDatos.DataBind();

                Session["datos"] = dtDatos;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("datos");
                gvwDatos.DataSource = null;
                gvwDatos.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}