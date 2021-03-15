using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace StanDysków.Models
{
    public class SqliteDataAccess
    {

        public static void AddWindows(string Serwer, string Wolumen, double Rozmiar, double Wolna_przestrzen, DateTime Data)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<String>($"select Serwer from Windows where (Serwer = '{Serwer}' and Wolumen = '{Wolumen}' and Data = '{Data.Date.ToString()}')", new DynamicParameters());
                if (output.ToList().Count == 0)
                {
                    double temp = Math.Round((Rozmiar - Wolna_przestrzen),2);
                    double perc = Math.Round(((100 * Wolna_przestrzen) / Rozmiar), 2);
                    cnn.Execute($"insert into Windows (Serwer, Wolumen, Rozmiar, Wolna_przestrzen, Zajeta_przestrzen, Procent_wolnej, Data) values('{Serwer}','{Wolumen}','{Rozmiar}','{Wolna_przestrzen}','{temp}' ,'{perc}', '{Data.Date.ToString()}');");
                }
            }
        }

        public static List<WindowsModel> LoadDateIDWin(string x)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>($"select * from Windows where Data LIKE  '{x}%'", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<LinuxModel> LoadDateIDLin(string x)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<LinuxModel>($"select * from Linux where Data LIKE  '{x}%'", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<WindowsModel> LoadDateWin(string serv, string wol, int proc, int x, int y)
        {
            string qry = $"select * from Windows where ";
            int counter = 0;
            if (serv != "")
            {
                qry += $"Serwer LIKE '%{serv}%' ";
                counter++;
            }
            if (wol != "")
            {
                if (counter > 0)
                    qry += "and ";
                qry += $"Wolumen LIKE '%{wol}%' ";
            }
            if (proc != 0)
            {
                if (counter > 0)
                    qry += "and ";
                qry += $"Procent_wolnej <= (100-{proc}) ";

            }
            if (x != 0)
            {
                if (counter > 0)
                    qry += "and ";
                qry += $"Id>={x} ";

            }
            if (y != 0)
            {
                if (counter > 0)
                    qry += "and ";
                qry += $"Id<={y} ";

            }

            
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>(qry, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<LinuxModel> LoadDateLin(string serv, string wol, int proc, int x, int y)
        {
            string qry = $"select * from Linux where ";
            int counter = 0;
            if (serv != "")
            {
                qry += $"Serwer LIKE '%{serv}%' ";
                counter++;
            }
            if (wol != "")
            {
                if (counter > 0)
                    qry += "and ";
                qry += $"Wolumen LIKE '%{wol}%' ";
            }
            if (proc != 0)
            {
                if (counter > 0)
                    qry += "and ";
                qry += $"Procent_wolnej <= (100-{proc}) ";

            }
            if (x != 0)
            {
                if (counter > 0)
                    qry += "and ";
                qry += $"Id>={x} ";

            }
            if (y != 0)
            {
                if (counter > 0)
                    qry += "and ";
                qry += $"Id<={y} ";

            }


            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<LinuxModel>(qry, new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AddLinux(string Serwer, string Wolumen, double Rozmiar, double Wolna_przestrzen, DateTime Data)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<String>($"select Serwer from Linux where (Serwer = '{Serwer}' and Wolumen = '{Wolumen}' and Data = '{Data.Date.ToString()}')", new DynamicParameters());
                if (output.ToList().Count == 0)
                {
                    double temp = Math.Round((Rozmiar - Wolna_przestrzen), 2);
                    double perc = Math.Round(((100 * Wolna_przestrzen) / Rozmiar), 2);
                    cnn.Execute($"insert into Linux (Serwer, Wolumen, Rozmiar, Wolna_przestrzen, Zajeta_przestrzen, Procent_wolnej, Data) values('{Serwer}','{Wolumen}','{Rozmiar}','{Wolna_przestrzen}','{temp}' ,'{perc}', '{Data.Date.ToString()}');");

                }
            }
        }


        //
        

        public static List<WindowsModel> LoadWindows()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>("select * from Windows;", new DynamicParameters());//"select w.Id, w.Serwer, w.Wolumen, w.Rozmiar, w.Wolnaprzestrzen, w.Zajetaprzestrzen, w.Procentwolnej, w.Data from Windows2 w;", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<LinuxModel> LoadLinux()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<LinuxModel>("select * from Linux;", new DynamicParameters());
                return output.ToList();
            }
        }

       

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
