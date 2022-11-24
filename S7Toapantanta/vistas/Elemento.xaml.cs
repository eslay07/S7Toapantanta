using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Elemento : ContentPage
    {
        public int idSel;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> borrar;
        IEnumerable<Estudiante> actualizar;
        public Elemento(int id)
        {
            InitializeComponent();
            idSel = id;
            con = DependencyService.Get<Database>().GetConnection();


        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var databasePatch = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePatch);
                actualizar = actualizar1(db, txtNombre.Text,txtUsuario.Text,txtContraseña.Text,idSel);
                DisplayAlert("Mensaje", "Actualzar", "Ok");
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "ok");
            }

        }

        private IEnumerable<Estudiante> actualizar1(SQLiteConnection db, string Nombre, string usuario, string contraseña, int idSel)
        {
            return db.Query<Estudiante>("Update Estudiante SET Nombre = ?, usuario=?, contraseña=? where Id=?", Nombre, usuario, contraseña, idSel);
        }

        public static IEnumerable<Estudiante> Borrar1(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("Delete from Estudiante where id=?", id);
        }
        

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var databasePatch = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePatch);
                borrar = Borrar1(db, idSel);
                DisplayAlert("Mensaje", "Eliminar", "Ok");
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception)
            {
                throw;
            }
           

        }
    }
}