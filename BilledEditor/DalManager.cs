using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace BilledEditor
{
   public static class DalManager
    {
        // fælles lærer
       // private static string _cs = "Data Source= ZBC-RGA11702919\\URDATABASE;Initial Catalog=UrmagerDatabasen;User ID=Michael;Password=Michael123";

        // Claus
         private static string _cs = "Data Source= .\\URDATABASE;Initial Catalog=UrmagerDatabase;User ID=Michael;Password=Michael123";

        // Michael
        // private static string _cs = "Data Source=ZBCRGB13MNP660L\\SQLEXPRESS;Initial Catalog=UrmagerDatabase;User ID=Michael;Password=Michael12345";

        public static bool FindesNummer(string nr)
        {
            bool svar = false;
            Tabel temp = new Tabel();

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from Tabel", conn);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Tabel t4 = new Tabel((int)rdr["id"], (string)rdr["calnr"], (string)rdr["dansknavn"], (string)rdr["lokation"], (string)rdr["etanr"], (string)rdr["blisternr"], (string)rdr["artikkelnr"], (string)rdr["engelsknavn"], (string)rdr["tysknavn"], (string)rdr["fransknavn"], (string)rdr["tekst"]);
                        if (t4.ArtikkelNr == nr)
                        {
                            svar = true;
                        }
                    }
                }
            }
            catch (SqlException sEx)
            {
                MessageBox.Show("Fejl - " + sEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fejl - " + ex.Message);
            }
            return svar;
        }

    }
}
