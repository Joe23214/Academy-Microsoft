using System.Data.SqlClient;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DBConnection.Instance.openConn();

           
            DBConnection.Instance.closeConn();
        }
    }

}
