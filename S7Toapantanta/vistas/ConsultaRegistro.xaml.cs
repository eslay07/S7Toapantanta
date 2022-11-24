using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;
using S7Toapantanta.models;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization;

namespace S7Toapantanta.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage


    {

        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tablaEstudiante;

        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            //ocultar boton de regresar
            NavigationPage.SetHasBackButton(this, false);
            Datos();
        }

        public async void Datos()
        {
            var Resultado = await con.Table<Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Estudiante>(Resultado);
            ListaEstudiantes.ItemsSource=tablaEstudiante;
            base.OnAppearing();
        }

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var oBJ = (Estudiante)e.SelectedItem;
            var item = oBJ.Id.ToString();
            var IdSeleccionado = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(IdSeleccionado));
            }
            catch (Exception)
            {
                throw;
            }

            

        }
        
    }
}