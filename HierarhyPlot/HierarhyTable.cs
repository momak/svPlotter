using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HierarhyPlot
{
    public partial class HierarhyTable : Form
    {
        List<ofiObj> lsRes = new List<ofiObj>();
        public HierarhyTable()
        {
            InitializeComponent();
        }

        private void HierarhyTable_Load(object sender, EventArgs e)
        {
            var _lstStavkaVrska = Hplot();
            var _lstS = LstStavki();
            var _lstStavka = new List<ofiObj>();

            foreach (Stavka s in _lstS)
            {
                lsRes.Clear();
                ChildNodes(s.eKod, _lstStavkaVrska);
                _lstStavka.Add(SumRes(s, lsRes));
            }

            dataGridView1.DataSource = _lstStavka;


            const string srcConnectionString = @"Data Source=""E:\\vs2017\\svPloter\\eOFIdata.db"";Version=3;";
            const string destConnectionString = @"Data Source=""E:\\vs2017\\svPloter\\eOFIdataBck.db"";Version=3;";

            var backup = new SqliteBackup();

            using (var unsubscriber = backup.Subscribe(new ConsoleWriterObserver()))
                backup.Execute(srcConnectionString, destConnectionString, 50);

            Console.ReadLine();
        }

        private List<Stavka> Hplot()
        {
            string joinQuery =
                @"SELECT S.Stavka, Vrska, Kod FROM [Stavki] AS S	LEFT JOIN [Vrski] AS V 	ON S.Stavka = V.Stavka ORDER BY S.Stavka, Vrska, 	Kod DESC LIMIT 40;";

            List<Stavka> _lstStavka = new List<Stavka>();

            string connStr = "Data Source = E:\\vs2017\\svPloter\\eOFIdata.db; Version = 3;";
            //System.Data.SQLite.SQLiteConnection.CreateFile("Data Source = Config\\Data\\eOFIdata.db; Version = 3;");
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection(connStr))
            {
                using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(con))
                {
                    con.Open(); // Open the connection to the database
                    com.CommandText = joinQuery; // Select all rows from our database table

                    using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Stavka s = new Stavka();
                            s.eKod = reader["Stavka"].ToString();
                            s.Vrska = reader["Vrska"].ToString();
                            s.Kod = ParseToNullableInt(reader["Kod"].ToString());

                            _lstStavka.Add(s);
                        }
                    }

                    con.Close(); // Close the connection to the database
                }
            }

            return _lstStavka;
        }

        private List<Stavka> LstStavki()
        {
            string joinQuery =
                @"SELECT Stavka, Opis FROM [Stavki] AS S ORDER BY Stavka;";

            List<Stavka> _lstStavka = new List<Stavka>();

            string connStr = "Data Source = E:\\vs2017\\svPloter\\eOFIdata.db; Version = 3;";
            //System.Data.SQLite.SQLiteConnection.CreateFile("Data Source = Config\\Data\\eOFIdata.db; Version = 3;");
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection(connStr))
            {
                using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(con))
                {
                    con.Open(); // Open the connection to the database
                    com.CommandText = joinQuery; // Select all rows from our database table

                    using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Stavka s = new Stavka();
                            s.eKod = reader["Stavka"].ToString();
                            s.Vrska = reader["Opis"].ToString();

                            _lstStavka.Add(s);
                        }
                    }

                    con.Close(); // Close the connection to the database
                }
            }

            return _lstStavka;
        }

        private ofiObj DataOfi(string eKod, string Ikod, DateTime datum, string rpt)
        {
            ofiObj ofiO = new ofiObj();
            ofiO.e_kod = eKod;
            string dataQuery =
                $"SELECT eKod, PocSost, steknuvanjeSo, namaluvanjeSo, promeniKR, promeniC, promeniO, KrajSost FROM  ofiData AS ofi WHERE ofi.eKod = '{eKod}' and ofi.IKODnbrm = '1230310007'   AND ofi.Datum = '2017-09-30'    AND ofi.rpt = 'OFI1'";

            string connStr = "Data Source = E:\\vs2017\\svPloter\\eOFIdata.db; Version = 3;";
            //System.Data.SQLite.SQLiteConnection.CreateFile("Data Source = Config\\Data\\eOFIdata.db; Version = 3;");
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection(connStr))
            {
                using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(con))
                {
                    con.Open(); // Open the connection to the database
                    com.CommandText = dataQuery; // Select all rows from our database table

                    using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ofiO.PocSostojba = Convert.ToDecimal(reader["PocSost"].ToString());
                            ofiO.SteknuvanjeSO = Convert.ToDecimal(reader["steknuvanjeSo"].ToString());
                            ofiO.NamaluvanjeSO = Convert.ToDecimal(reader["namaluvanjeSo"].ToString());
                            ofiO.PromeniKR = Convert.ToDecimal(reader["promeniKR"].ToString());
                            ofiO.PromeniC = Convert.ToDecimal(reader["promeniC"].ToString());
                            ofiO.PromeniO = Convert.ToDecimal(reader["promeniO"].ToString());
                            ofiO.KrajSostojba = Convert.ToDecimal(reader["KrajSost"].ToString());
                        }
                    }

                    con.Close(); // Close the connection to the database
                }
            }

            return ofiO;
        }


        private ofiObj ChildNodes(string podIvor, List<Stavka> svList)
        {
            ofiObj node = new ofiObj();
            foreach (Stavka stavkaVrska in svList)
            {
                if ((stavkaVrska.eKod == podIvor) && (!stavkaVrska.isProccesed) && (stavkaVrska.Kod != 1))
                {
                    node = DataOfi(stavkaVrska.eKod, "1230310007", new DateTime(2017, 12, 31), "OFI1");

                    node.Sum(ChildNodes(stavkaVrska.Vrska, svList));

                    stavkaVrska.isProccesed = true;
                }
                else if ((stavkaVrska.Kod == 1) && (stavkaVrska.eKod == podIvor))
                {
                    node = DataOfi(stavkaVrska.eKod, "1230310007", new DateTime(2017, 12, 31), "OFI1");

                    lsRes.Add(node);
                    stavkaVrska.isProccesed = true;
                    return node;
                }
            }
            return node;
        }


        public static int? ParseToNullableInt(string value)
        {
            return String.IsNullOrEmpty(value) ? null : (int.Parse(value) as int?);
        }

        private ofiObj SumRes(Stavka s, List<ofiObj> lsRes)
        {
            ofiObj ofiRes = new ofiObj();
            ofiRes.e_kod = s.eKod;
            ofiRes.Opis = s.Vrska;
            foreach (ofiObj o in lsRes)
            {
                ofiRes.Sum(o);
            }
            return ofiRes;
        }
    }
}
