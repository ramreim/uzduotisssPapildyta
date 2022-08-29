using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;


namespace Threads002
{
    public class DBClass
    {

        public void irasymasDb(int gautasid, int gautasLaikas, string gautaEilute, string gautaData, string gautasLikas2)
        {

            //insert into dbo.ThreadsTable3 (ThreadID, ThreadTimeMs, ThreadString, DateString, TimeString) values (10, 25, 'Saulius', '2021-12-25', '19:25:36.754');

            /*

            string timeee2 = "";
            string dateee2 = "";

            timeee2 = DateTime.Now.ToString("HH:mm:ss.fff");
            dateee2 = DateTime.Now.ToString("yyyy-MM-dd");
            */

            //DateTime timeeee = DateTime.Parse(timeee2, System.Globalization.CultureInfo.CurrentCulture);
            // DateTime dateeee = DateTime.Parse(dateee2, System.Globalization.CultureInfo.CurrentCulture);


            SqlConnection conn = new SqlConnection("Server=192.168.0.105;Database=uvsDB666;Integrated Security=True");
            conn.Open();
            string sakinys = "";
            // sakinys = "INSERT INTO sakosTable(ThreadID, Timee, Data) VALUES(" + gautasid + ", '" + gautasLaikas + "', '" + gautaEilute + "')";

            sakinys = "insert into dbo.ThreadsTable2(ThreadID, ThreadTimeMs, ThreadString, Dataa, Timee) values(" + gautasid + ", " + gautasLaikas + ", '" + gautaEilute + "', '" + gautaData + "', '" + gautasLikas2 + "')";

            //sakinys = "insert into dbo.ThreadsTable3 (ThreadID, ThreadTimeMs, ThreadString, DateString, TimeString) values (10, 25, 'Saulius', '"+dateee2+"', '"+timeee2+"')";


            SqlCommand cmd = new SqlCommand(sakinys, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            conn.Close();

















        }



    }
}