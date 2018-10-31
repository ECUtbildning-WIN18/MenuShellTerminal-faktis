using System.Collections.Generic;
using System.Xml.Linq;



namespace Domain
{
    public class Database
    {
        public static HashSet<string> UserNames { get; set; } = new HashSet<string>();
        public static Dictionary<string, User> Users { get; set; } = new Dictionary<string, User>();
        public Database() {}
    }
}
    
