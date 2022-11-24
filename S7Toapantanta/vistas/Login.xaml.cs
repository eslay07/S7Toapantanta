using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7Toapantanta.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace S7Toapantanta.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = LoginHelpers.SELECT_WHERE(db, txtUsuario.Text, txtContraseña.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "NO existe el usuario", "Cerrar");
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());

        }
    }
}