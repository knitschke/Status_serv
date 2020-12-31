using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanDysków.Models
{
    public class WindowsModel
    {
        public int Id { get; set; }
        public string Serwer { get; set; }
        public string Wolumen { get; set; }
        public double Rozmiar { get; set; }
        public double Wolna_przestrzeń { get; set; }
        public double Zajeta_przestrzeń { get; set; }
        public double Procent_wolnej { get; set; }
        public DateTime Data { get; set; }
    }
}
