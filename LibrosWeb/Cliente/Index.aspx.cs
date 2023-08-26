using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using System.EnterpriseServices;
using Libros;
using System.Collections;
using Microsoft.Ajax.Utilities;

namespace LibrosWeb.Cliente
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FG.Load_Principal();

            if (!IsPostBack)
            {
                GridLibros();
                GridEditoriales();
                GridAutor();
            }
        }

        protected void btnAccion_Click(object sender, EventArgs e)
        {
            try
            {
                string folio = FG.SeleccionarGrid(sender);

                Response.Redirect("NuevoModificar.aspx?folio=" + Server.UrlEncode(folio), false);
            }
            catch (Exception ex)
            {
                FG.ShowError(this, GetType(), ex.Message);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            GridLibros();
        }

        protected void rblBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int opcion = Convert.ToInt32(rblBuscarPor.SelectedValue);

                txtConsulta2.Text = "1000";
                txtConsulta2.Visible = opcion == 3 ? true : false;

                txtConsulta.Text = "";
            }
            catch (Exception ex)
            {
                FG.ShowError(this, GetType(), ex.Message);
            }
        }

        private void GridLibros()
        {
            try
            {
                LabelError.Visible = false;

                string query = "select * from vw_Libros";
                string item = "";

                int opcion = Convert.ToInt32(rblBuscarPor.SelectedValue);

                if (opcion != -1)
                {
                    if (string.IsNullOrWhiteSpace(txtConsulta.Text.Trim('\u0009')))
                    {
                        LabelError.Text = "Ingrese informacion en el campo de texto";
                        LabelError.Visible = true;
                        return;
                    }
                    else
                    {
                        item = rblBuscarPor.SelectedItem.ToString();

                        if (opcion != 3)
                            query += " where " + item + " like '%" + txtConsulta.Text.Trim('\u0009') + "%' order by " + item;
                        else
                            query += " where " + item + " between " + txtConsulta.Text.Trim('\u0009') + " and " + txtConsulta2.Text.Trim('\u0009') + " order by " + item;
                    }
                }

                DataSet ds = FG.QueryBD(query);

                FG.LlenaGrid(dgvUniverso, ds.Tables[0]);
            }
            catch (Exception ex)
            {
                FG.ShowError(this, GetType(), ex.Message);
                LabelError.Text = ex.Message;
                LabelError.Visible = true;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoModificar.aspx?folio=" + Server.UrlEncode("-1"), false);
        }

        //-----------------------------------------------------------------------------------------------------------------------------

        private void GridEditoriales()
        {
            try
            {
                string query = "select IdEditorial as Folio, descripcion as NombreEditorial from tbEditoriales;";

                DataSet ds = FG.QueryBD(query);

                FG.LlenaGrid(dgvUniversoEditoriales, ds.Tables[0]);
            }
            catch (Exception ex)
            {
                FG.ShowError(this, GetType(), ex.Message);
            }
        }

        protected void btnNuevoEditorial_Click(object sender, EventArgs e)
        {
            Response.Redirect("Editorial.aspx?folio=" + Server.UrlEncode("-1"), false);
        }

        protected void btnAccionEditorial_Click(object sender, EventArgs e)
        {
            try
            {
                string folio = FG.SeleccionarGrid(sender);

                Response.Redirect("Editorial.aspx?folio=" + Server.UrlEncode(folio), false);
            }
            catch (Exception ex)
            {
                FG.ShowError(this, GetType(), ex.Message);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------

        private void GridAutor()
        {
            try
            {
                string query = "select IdAutor as Folio, descripcion as NombreAutor from tbAutores;";

                DataSet ds = FG.QueryBD(query);

                FG.LlenaGrid(dgvUniversoAutores, ds.Tables[0]);
            }
            catch (Exception ex)
            {
                FG.ShowError(this, GetType(), ex.Message);
            }
        }

        protected void btnNuevoAutor_Click(object sender, EventArgs e)
        {
            Response.Redirect("Autores.aspx?folio=" + Server.UrlEncode("-1"), false);
        }

        protected void btnAccionAutor_Click(object sender, EventArgs e)
        {
            try
            {
                string folio = FG.SeleccionarGrid(sender);

                Response.Redirect("Autores.aspx?folio=" + Server.UrlEncode(folio), false);
            }
            catch (Exception ex)
            {
                FG.ShowError(this, GetType(), ex.Message);
            }
        }
    }
}