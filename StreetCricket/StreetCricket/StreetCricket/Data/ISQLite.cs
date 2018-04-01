using SQLite;

namespace StreetCricket.Data
{
   public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
