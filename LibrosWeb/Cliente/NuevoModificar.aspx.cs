using Libros;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrosWeb.Cliente
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static int IdFolio = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            string titulo = "Nuevo";

            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["folio"]))
                    IdFolio = Convert.ToInt32(Request.QueryString["folio"]);

                CargaElementos();

                if (IdFolio != -1)
                {
                    string query = "select * from tblibros where Folio = " + IdFolio;
                    DataSet ds = FG.QueryBD(query);

                    txtNombre.Text = (string)ds.Tables[0].Rows[0]["Nombre"];
                    ddlAutores.SelectedValue = ds.Tables[0].Rows[0]["Autor"].ToString();
                    ddlEditoriales.SelectedValue = ds.Tables[0].Rows[0]["Editorial"].ToString();
                    numCosto.Text = ds.Tables[0].Rows[0]["Precio"].ToString();
                    numAño.Text = ds.Tables[0].Rows[0]["Año"].ToString();
                    titulo = "Modificar";
                    btnEliminar.Visible = true;
                }

                this.Title = titulo + " libro";
            }
        }

        private void CargaElementos()
        {
            numAño.Attributes["min"] = "1800";
            numAño.Attributes["max"] = DateTime.Now.Year.ToString();

            string query = "";
            DataSet ds;

            query = "select IdAutor as id, descripcion as dsc from tbAutores";
            ds = FG.QueryBD(query);
            FG.LlenaCombo(ddlAutores, ds.Tables[0], "dsc", "Id", true);

            query = "select IdEditorial as id, descripcion as dsc from tbEditoriales";
            ds = FG.QueryBD(query);
            FG.LlenaCombo(ddlEditoriales, ds.Tables[0], "dsc", "Id", true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LabelError.Visible = false;

                if (IdFolio == -1)
                    throw new Exception("No hay ID para eliminar");

                string query = "delete from tbLibros where Folio=" + IdFolio;
                FG.QueryBD(query);

                Response.Redirect("index.aspx");
            }
            catch (Exception ex)
            {
                FG.ShowError(this, GetType(), ex.Message);
                LabelError.Text = ex.Message;
                LabelError.Visible = true;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string msj = "";
                LabelError.Visible = false;
                LabelError0.Visible = false;
                LabelError1.Visible = false;
                LabelError2.Visible = false;
                LabelError3.Visible = false;
                LabelError4.Visible = false;

                if (string.IsNullOrEmpty(txtNombre.Text.TrimStart('\u0009').Trim()))
                {
                    LabelError0.Text = "Ingrese el nombre del libro";
                    msj += LabelError0.Text + "\\n";
                    LabelError0.Visible = true;
                }

                if ((string)ddlAutores.SelectedValue == "-1")
                {
                    LabelError1.Text = "Seleccione un autor";
                    msj += LabelError1.Text + "\\n";
                    LabelError1.Visible = true;
                }

                if ((string)ddlEditoriales.SelectedValue == "-1")
                {
                    LabelError2.Text = "Selecione una editorial";
                    msj += LabelError2.Text + "\\n";
                    LabelError2.Visible = true;
                }

                if (string.IsNullOrEmpty(numCosto.Text.TrimStart('\u0009').Trim()))
                {
                    LabelError4.Text = "Ingrese el costo";
                    msj += LabelError4.Text + "\\n";
                    LabelError4.Visible = true;
                }

                if (string.IsNullOrEmpty(numAño.Text.TrimStart('\u0009').Trim()))
                {
                    LabelError3.Text = "Ingrese el año de publicacion";
                    msj += LabelError3.Text + "\\n";
                    LabelError3.Visible = true;
                }

                if (msj != "")
                    throw new Exception(msj);

                string query = "";
                if (IdFolio == -1)
                {
                    query = "insert into tbLibros (Nombre, Autor, Año, Editorial, Precio) " +
                            " values ('" + txtNombre.Text.ToUpper() + "', "
                                        + ddlAutores.SelectedValue.ToString() + ", "
                                        + numAño.Text + ", "
                                        + ddlEditoriales.SelectedValue.ToString() + ", "
                                        + Convert.ToDecimal(numCosto.Text)
                                    + ")";

                }
                else
                {
                    query = "update tbLibros " +
                            "set    Nombre='" + txtNombre.Text.ToUpper() + "'" +
                            ",      Autor=" + ddlAutores.SelectedValue.ToString() +
                            ",      Año=" + numAño.Text +
                            ",      Editorial=" + ddlEditoriales.SelectedValue.ToString() +
                            ",      Precio=" + Convert.ToDecimal(numCosto.Text) +
                            " where Folio=" + IdFolio;
                }

                FG.QueryBD(query);

                Response.Redirect("index.aspx");
            }
            catch (Exception ex)
            {
                FG.ShowError(this, GetType(), ex.Message);
                //LabelError.Text = ex.Message;
                //LabelError.Visible = true;
            }
        }

        protected void btnObtenerValor_Click(object sender, EventArgs e)
        {
            string valor = numAño.Text;
        }
    }
}