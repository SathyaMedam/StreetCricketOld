using System.IO;
using StreetCricket.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(StreetCricket.Droid.Data.SQLiteAndroid))]
namespace StreetCricket.Droid.Data
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid()
        {

        }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}