using S7Toapantanta.models;
using SQLite;
using System.Collections.Generic;

namespace S7Toapantanta.vistas
{
    internal static class LoginHelpers
    {
        //debo agregar este using using S7Toapantanta.models;
        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contraseña)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where usuario=? and contraseña=?", usuario, contraseña);
        }
    }
}