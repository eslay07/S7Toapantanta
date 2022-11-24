using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using S7Toapantanta.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Environment = System.Environment;


[assembly: Xamarin.Forms.Dependency(typeof(SqlCliente))]

namespace S7Toapantanta.Droid
{
    public class SqlCliente : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            //se define la ruta donde se creara la base de datos
            var documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Se crea la base de datos
            var path = Path.Combine(documentsPath, "uisrael.db3");

            return new SQLiteAsyncConnection(path); 

        }
    }
}