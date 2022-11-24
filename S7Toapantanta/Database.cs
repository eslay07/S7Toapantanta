using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace S7Toapantanta
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();

    }
}
