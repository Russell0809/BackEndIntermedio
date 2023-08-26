using Libros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrosWeb.Cliente
{
    public partial class Editorial : System.Web.UI.Page
    {
        private static int IdFolio = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["folio"]))
                    IdFolio = Convert.ToInt32(Request.QueryString["folio"]);

                string msj = "NUEVA EDITORIAL";

                if (IdFolio != -1)
                {
                    string query = "select * from tbEditoriales where IdEditorial = " + IdFolio;
                    DataSet ds = FG.QueryBD(query);

                    txtNombre.Text = (string)ds.Tables[0].Rows[0]["descripcion"];

                    btnEliminar.Visible = true;

                    msj = "MODIFICAR EDITORIAL FOLIO: " + IdFolio;
                }

                LabelTitulo.Text = msj;
                this.Title = msj;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LabelError0.Visible = false;

                if (IdFolio == -1)
                    throw new Exception("No hay ID para eliminar");

                string query = "delete from tbEditoriales where IdEditorial=" + IdFolio;
                FG.QueryBD(query);

                Response.Redirect("index.aspx");
            }
            catch (Exception ex)
            {
                FG.ShowError(this, GetType(), ex.Message);
                LabelError0.Text = ex.Message;
                LabelError0.Visible = true;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string msj = "";
                LabelError0.Visible = false;

                if (string.IsNullOrEmpty(txtNombre.Text.TrimStart('\u0009').Trim()))
                {
                    msj = "Ingrese el nombre del libro";
                    LabelError0.Text = msj;
                    LabelError0.Visible = true;
                }

                if (msj != "")
                    throw new Exception(msj);

                string query = "";
                if (IdFolio == -1)
                {
                    query = "insert into tbEditoriales (descripcion) " +
                            " values ('" + txtNombre.Text.ToUpper() + "')";

                }
                else
                {
                    query = "update tbEditoriales " +
                            "set    descripcion='" + txtNombre.Text.ToUpper() + "' " +
                            "where IdEditorial=" + IdFolio;
                }

                FG.QueryBD(query);

                Response.Redirect("index.aspx");
            }
            catch (Exception ex)
            {
                FG.ShowError(this, GetType(), ex.Message);
                LabelError0.Text = ex.Message;
                LabelError0.Visible = true;
            }
        }
    }
}