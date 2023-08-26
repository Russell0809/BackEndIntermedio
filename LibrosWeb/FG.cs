using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Activities;

namespace Libros
{
    public class FG
    {
        public static void Load_Principal()
        {
            VG.CXN_Libros = @"data source=LocalHost; initial catalog=ProyectoFinal; User ID=root;password=Anonymous08091996@";
            //@"data source=LocalHost; initial catalog=Libros; User ID=root;password=Anonymous08091996@";        
        }

        public static DataSet QueryBD(string _Query, string CXN = "")
        {
            if (string.IsNullOrWhiteSpace(CXN))
            {
                Load_Principal();
                CXN = VG.CXN_Libros;
            }

            MySqlConnection _conection = new MySqlConnection(CXN);

            DataSet ds = new DataSet();

            try
            {
                MySqlDataAdapter adaptador = new MySqlDataAdapter(_Query, _conection);
                adaptador.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                ShowError(null, typeof(LibrosWeb._Default), ex.ToString());
                return null;
            }
        }

        public static void LlenaGrid(GridView dv, DataTable dt)
        {
            dv.DataSource = null;
            dv.DataSource = dt;
            dv.DataBind();
        }

        public static void LlenaCombo(DropDownList ddl, DataTable dt, string dsc, string id, bool adicional = false)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = dsc;
            ddl.DataValueField = id; 
            ddl.DataBind();

            if(adicional)
                ddl.Items.Insert(0, new ListItem("--Seleccionar--", "-1"));
        }

        public static void ShowError(Page page, Type type,  string msj)
        {
            ScriptManager.RegisterStartupScript(page, type, "showMessage", $"alert('{msj}');", true);
        }

        public static string SeleccionarGrid(object sender)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            return gvr.Cells[0].Text;
        }
    }
}
