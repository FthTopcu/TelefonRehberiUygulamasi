using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiUygulamasi
{
    public class KisiIslemleri
    {
        List<Kisiler> KisilerListesi = new List<Kisiler>();

        public KisiIslemleri(List<Kisiler> kisilerListesi)
        {
            this.KisilerListesi = kisilerListesi;
        }
        void KisiGoruntule(Kisiler kisi)
        {
            Console.WriteLine("İsim : "+kisi.Isim);
            Console.WriteLine("Soyisim : "+kisi.Soyisim);
            Console.WriteLine("numara : "+kisi.Numara);
            Console.WriteLine();
        }
        public void IsimSoyisimAramasi(string gelen)
        {
            bool kayitVarmi = false;

            for (int i = 0; i < KisilerListesi.Count; i++)
            {
                if(gelen== KisilerListesi[i].Isim|| gelen == KisilerListesi[i].Soyisim)
                {
                    KisiGoruntule(KisilerListesi[i]);
                    kayitVarmi = true;
                }
            }

            if(!kayitVarmi)
            {
                IslemSonucuIsle("Aradığınız ifadayle eşleşen sonuç bulunamamıştır");
            }
        }
        public void TelefonNumarasıArama(string gelen)
        {
            Console.WriteLine();
            bool kayitVarmi = false;

            for (int i = 0; i < KisilerListesi.Count; i++)
            {
                if (gelen == KisilerListesi[i].Numara)
                {
                    KisiGoruntule(KisilerListesi[i]);
                    kayitVarmi = true;
                }
            }
            if (!kayitVarmi)
            {
                IslemSonucuIsle("Aradığınız ifadeyle eşleşen sonuç bulunamamıştır.");
            }

        }
        public bool NumaraVarmi(string gelen ,out int index)
        {
            for (int i = 0; i < KisilerListesi.Count; i++)
            {
                if (gelen == KisilerListesi[i].Isim || gelen == KisilerListesi[i].Soyisim)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
        public void NumaraSil(int index)
        {
            KisilerListesi.RemoveAt(index);
            IslemSonucuIsle("Silme işlemi başarılı");
        }
        public void NumaraGuncelle(int index,string yeniNumara)
        {
            KisilerListesi[index].Numara = yeniNumara;
            IslemSonucuIsle("Güncelleme işlemi başarılı");
        }
        public void RehberListele(Siralama siralama)
        {
            KisilerListesi.Sort((u1, u2) => u1.Isim.CompareTo(u2.Isim));

            if (siralama == Siralama.Azalan)
            {
                KisilerListesi.Reverse();
            }
            Console.WriteLine();
            foreach (var item in KisilerListesi)
            {
                KisiGoruntule(item);
            }
        }
        void IslemSonucuIsle(string islemSonucu)
        {
            Console.WriteLine(islemSonucu);
        }
    }
}
