using EAGetMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StanDysków.Models;
using System.Text.RegularExpressions;

namespace StanDysków
{
    public class Functions
    {
        private void parseDataLinux(string dt, ref int i, DateTime date)
        {
            string[] separatingStrings = { "<td>", "</td>" };
            string[] parsed = dt.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < parsed.Length; j++)
            {
                if ((parsed[j].Contains("GB") && parsed[j + 1].Contains("GB")) || (parsed[j].Contains("MB") && parsed[j + 1].Contains("MB")))
                {
                    double x = -1;
                    double y = -1;
                    string xx = parsed[j].Replace('.', ',');
                    string yy = parsed[j + 1].Replace('.', ',');
                    string name = parsed[j - 2].Replace('<',' ').Replace('>',' ').Replace('/',' ').Trim();
                    foreach (string str in xx.Split(' '))
                    {
                        if (Double.TryParse(str, out x) == true)
                        {
                            foreach (string str2 in yy.Split(' '))
                            {
                                if (Double.TryParse(str2, out y) == true)
                                {
                                    SqliteDataAccess.AddLinux(name, Regex.Replace(parsed[j - 1], @"\s+", "") , x, y, date);
                                }
                            }
                        }
                    }
                    j += 1;
                }
            }
        }

        private void parseDataWindows(string dt, ref int i, DateTime date)
        {
            string[] separatingStrings = { "<td>", "</td>" };
            string[] parsed = dt.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < parsed.Length; j++)
            {
                if ((parsed[j].Contains("GB") && parsed[j + 1].Contains("GB")) || (parsed[j].Contains("MB") && parsed[j + 1].Contains("MB")))
                {
                    double x = -1;
                    double y = -1;
                    string xx = parsed[j].Replace('.', ',');
                    string yy = parsed[j + 1].Replace('.', ',');
                    foreach (string str in xx.Split(' '))
                    {
                        if (Double.TryParse(str, out x) == true)
                        {
                            foreach (string str2 in yy.Split(' '))
                            {
                                if (Double.TryParse(str2, out y) == true)
                                {
                                    SqliteDataAccess.AddWindows(parsed[j - 2], parsed[j - 1], x, y, date);
                                }
                            }
                        }
                    }
                    j += 1;
                }
            }
        }

        public void ScanAndAdd(string login, string haslo)
        {
            int ii = 0;
            MailServer oServer = new MailServer("smtp.office365.com",
                        login,//"krzysztof.nitschke@powiat.poznan.pl",
                        haslo,
                        ServerProtocol.Pop3);

            // Enable SSL/TLS connection, most modern email server require SSL/TLS by default
            oServer.SSLConnection = true;
            oServer.Port = 995;

            // if your server doesn't support SSL/TLS, please use the following codes
            // oServer.SSLConnection = false;
            // oServer.Port = 110;

            MailClient oClient = new MailClient("TryIt");
            oClient.Connect(oServer);

            MailInfo[] infos = oClient.GetMailInfos();
            Console.WriteLine("Total {0} email(s)\r\n", infos.Length);
            for (int i = 0; i < infos.Length; i++)
            {
                MailInfo info = infos[i];
                // Receive email from POP3 server
                Mail oMail = oClient.GetMail(info);
                if ((oMail.From.ToString() == "<app1@admin.powiat.poznan.pl>") || oMail.From.ToString() == "<linbac1@powiat.poznan.pl>")
                {

                    Console.WriteLine(oMail.ReceivedDate.ToString().Replace(".", "_").Replace(" ", "_").Replace(":", "_"));
                    // Generate an unqiue email file name based on date time.
                    if (oMail.From.ToString() == "<app1@admin.powiat.poznan.pl>")
                    {
                        //fileName = "win" + oMail.ReceivedDate.ToString().Replace(".", "_").Replace(" ", "_").Replace(":", "_");
                        parseDataWindows(oMail.HtmlBody.ToString(), ref ii, oMail.SentDate);
                    }
                    else
                    {
                        //fileName = "lin" + oMail.ReceivedDate.ToString().Replace(".", "_").Replace(" ", "_").Replace(":", "_");
                        parseDataLinux(oMail.HtmlBody.ToString(), ref ii, oMail.SentDate);
                    }

                    //string fullPath = string.Format("{0}\\{1}", localInbox, fileName);
                    //fileName = _generateFileName(i + 1);
                    // Save email to local disk
                    //oMail.SaveAs(fullPath+".html", true);

                    Console.WriteLine("Saved");
                }
                
            }
        }
    }
}
