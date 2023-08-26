<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrosWeb._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Administracion de una libreria</h1>

            <section id="content-section">
                <p class="lead">Importancia de un Sistema para el Control de una Librería</p>
                <p>La implementación de un sistema de control en una librería no es simplemente una opción, sino una necesidad en la era digital. Con la creciente demanda de eficiencia y rapidez en los servicios, un sistema automatizado contribuye significativamente a la gestión efectiva de los recursos disponibles, incluidos los libros, el personal y el tiempo.</p>
                <br />
                <p class="lead">Alcances</p>
                <p>El alcance de un sistema de control de librería puede variar desde funciones básicas como el seguimiento del inventario de libros hasta capacidades más avanzadas como el análisis de datos para comprender las preferencias de los lectores. Algunos de los alcances más comunes incluyen la catalogación de libros, la gestión de membresías, la emisión de recibos y facturas, y el seguimiento de los préstamos y devoluciones.</p>
            </section>
            <div id="ubicacion"></div>    
            <p><a href="Cliente/Index.aspx" class="btn btn-primary btn-md">COMENZAR &raquo;</a></p>
        </section>
    </main>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="Js/TuUbicacion.js"></script>

</asp:Content>
