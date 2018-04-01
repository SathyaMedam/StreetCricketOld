using SQLite;
using StreetCricket.Model;
using Xamarin.Forms;

namespace StreetCricket.Data
{
   public class TokenDatabase
    {
        static object locker = new object();
        SQLiteConnection database;
        public TokenDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Token>();

        }

        public Token GetUser()
        {
            lock (locker)
            {
                if (database.Table<Token>().Count() == 0)
                {
                    return null;

                }
                else
                {
                    return database.Table<Token>().First();
                }
            }
        }

        public int SaveUser(Token user)
        {
            lock (locker)
            {
                if (user.Id != 0)
                {
                    database.Update(user);
                    return user.Id;
                }
                else
                {
                    return database.Insert(user);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<Token>(id);
            }
        }
    }
}
