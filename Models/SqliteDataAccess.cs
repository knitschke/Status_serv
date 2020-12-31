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
                var output = cnn.Query<String>($"select Serwer from Windows where (Serwer = '{Serwer}' and Wolumen = '{Wolumen}' and Data = '{Data.Date}')", new DynamicParameters());
                if (output.ToList().Count == 0)
                {
                    double temp = Math.Round((Rozmiar - Wolna_przestrzen),2);
                    double perc = Math.Round(((100 * Wolna_przestrzen) / Rozmiar), 2);
                    cnn.Execute($"insert into Windows (Serwer, Wolumen, Rozmiar, Wolna_przestrzen, Zajeta_przestrzen, Procent_wolnej, Data) values('{Serwer}','{Wolumen}','{Rozmiar}','{Wolna_przestrzen}','{temp}' ,'{perc}', '{Data.Date}');");
                }
            }
        }

        public static void AddLinux(string Serwer, string Wolumen, double Rozmiar, double Wolna_przestrzen, DateTime Data)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<String>($"select Serwer from Linux where (Serwer = '{Serwer}' and Wolumen = '{Wolumen}' and Data = '{Data.Date}')", new DynamicParameters());
                if (output.ToList().Count == 0)
                {
                    double temp = Math.Round((Rozmiar - Wolna_przestrzen), 2);
                    double perc = Math.Round(((100 * Wolna_przestrzen) / Rozmiar), 2);
                    cnn.Execute($"insert into Linux (Serwer, Wolumen, Rozmiar, Wolna_przestrzen, Zajeta_przestrzen, Procent_wolnej, Data) values('{Serwer}','{Wolumen}','{Rozmiar}','{Wolna_przestrzen}','{temp}' ,'{perc}', '{Data.Date}');");

                }
            }
        }


        //
        

        public static List<WindowsModel> LoadWindows()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))//testit+scantime add
            {
                var output = cnn.Query<WindowsModel>("select * from Windows;", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<LinuxModel> LoadLinux()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))//testit+scantime add
            {
                var output = cnn.Query<LinuxModel>("select * from Linux;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<String> ScanTime(string idscan)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))//testit+scantime add
            {
                var output = cnn.Query<String>($"select time from Scans where scan_id = {idscan}", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<WindowsModel> LoadUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>("select * from Users", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void AddUser(string nm, string ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into users (pc_name, ip) values('{nm}', '{ ip}');");
            }
        }

        public static void UpdateUserIp(string nm, string ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"update users set ip='{ip}' where pc_name='{nm}';");
            }
        }
        public static void UpdateUserName(string nm, string ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"update users set pc_name='{nm}' where ip='{ip}';");
            }
        }

        public static List<WindowsModel> LoadProcs()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>("select * from Processes;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<WindowsModel> LoadUserName(string ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>($"select * from Users where ip='{ip}';", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<WindowsModel> LoadUserIp(string nm)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>($"select * from Users where pc_name='{nm}';", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void AddProcess(string p)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into processes (process_name) values('{p}');");
            }
        }

        public static List<WindowsModel> LoadData()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>("select * from Data", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<WindowsModel> LoadDataExact(string proc_name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>($"select * from Data where process_name='{proc_name}';", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AddData(int p, int n, string pc, string proc, int scn)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into data (positive_scan, negative_scan, ip, scan_id, process_name) values('{p}','{n}','{pc}','{scn}','{proc}');");
            }
        }
        public static void AddScan(string time, string date)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into scans (time, date) values('{time}', '{date}');");
            }
        }

        public static void DelList(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"delete from Lists where list_name = '{name}';");
            }

        }

        public static List<WindowsModel> LoadDataTime(String proc)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>($"select * from Data where process_name='{proc}';", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<WindowsModel> LoadDataByProcAndIp(String proc, String Ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>($"select * from Data where process_name='{proc}' and ip='{Ip}';", new DynamicParameters());
                return output.ToList();
            }
        }


        public static List<WindowsModel> LoadScans()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>("select * from Scans", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<WindowsModel> LoadScan(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>($"select * from Scans where scan_id = {id};", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<WindowsModel> LoadList(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>($"select * from Lists where list_name = '{name}';", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<WindowsModel> LoadListname()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>("select distinct list_name from Lists;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<WindowsModel> LoadListPCname(string ip)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>($"select distinct ip from Lists where ip='{ip}';", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AddList(string ip, string listname, string proc1 = "", string proc2 = "", string proc3 = "", string proc4 = "", string proc5 = "")
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into lists (ip, list_name, proc1, proc2, proc3, proc4, proc5) values('{ip}', '{listname}', '{proc1}', '{proc2}', '{proc3}', '{proc4}', '{proc5}');");
            }
        }

        public static void DeletefromList(string listname, string ip = "")
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"delete from Lists where ip='{ip}' and list_name='{listname}';");
            }
        }

        public static List<WindowsModel> StatsLoad(string proc)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WindowsModel>($"SELECT DISTINCT pc_name, ip from (select * from Users join Data on (Data.ip = Users.ip AND process_name = '{proc}'))", new DynamicParameters());
                return output.ToList();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
