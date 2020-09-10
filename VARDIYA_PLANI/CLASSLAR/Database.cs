using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace VARDIYA_PLANI
{
    public class Database
    {


        public static string GlobalServerName = "DESKTOP-J2TDLUS";

        public static SqlConnection GetConnection()
        {

            string dbAdi = "Pimtas_Vardiya";

            string connectionString = @"Data Source=" + GlobalServerName + "; Initial Catalog=" + dbAdi + ";Integrated Security=True";
            //Trusted_Connection=True
            return new SqlConnection(connectionString);
        }
    }
}

        
