using System;
using SQLite;

namespace StreetCricket.Model
{
   public class Token
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime ExpireDate { get; set; }
        public Token()
        {

        }
    }
}
