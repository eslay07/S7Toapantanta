﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7Toapantanta.models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7Toapantanta.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
       private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con=DependencyService.Get<Database>().GetConnection();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var datosRegistro = new Estudiante { Nombre = txtNombre.Text, usuario = txtUsuario.Text, contraseña = txtContraseña.Text };
            con.InsertAsync(datosRegistro);

                DisplayAlert("Mensaje", "Ingreso Correcto", "cerrar");

                txtUsuario.Text = "";
                txtNombre.Text = "";
                txtContraseña.Text = "";
                

            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje", ex.Message, "cerrar");
            }

        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new Login());

        }
    }
}