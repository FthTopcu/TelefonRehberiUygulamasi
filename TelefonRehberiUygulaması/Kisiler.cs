using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiUygulamasi
{
    public class Kisiler
    {
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Numara { get; set; }

        public Kisiler()
        {

        }

        public Kisiler(string ısim, string soyisim, string numara)
        {
            Isim = ısim;
            Soyisim = soyisim;
            Numara = numara;
        }
    }
}
