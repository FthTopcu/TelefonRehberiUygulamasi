using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberiUygulamasi
{
    class Program
    {
        static void Main()
        {
            Kisiler kisi1 = new Kisiler()
            {
                Isim = "Erdem",
                Soyisim = "şevik",
                Numara = "05448625314"
            };
            Kisiler kisi2 = new Kisiler()
            {
                Isim = "Fatih",
                Soyisim = "topcu",
                Numara = "05314930473"
            };
            Kisiler kisi3 = new Kisiler()
            {
                Isim = "serdar",
                Soyisim = "karakurt",
                Numara = "05448624725"
            };
            Kisiler kisi4 = new Kisiler()
            {
                Isim = "mehmet",
                Soyisim = "ali",
                Numara = "05448631469"
            };
            Kisiler kisi5 = new Kisiler()
            {
                Isim = "ali",
                Soyisim = "yılmaz",
                Numara = "05448782146"
            };
            List<Kisiler> KisilerListesi = new List<Kisiler>();
            KisilerListesi.Add(kisi1);
            KisilerListesi.Add(kisi2);
            KisilerListesi.Add(kisi3);
            KisilerListesi.Add(kisi4);
            KisilerListesi.Add(kisi5);

            KisiIslemleri kisiIslemleri = new KisiIslemleri(KisilerListesi);
            while (true)
            {
                Console.WriteLine("----------------");
                Console.WriteLine("İşlemler");
                Console.WriteLine("(1).Telefon Numarası Kaydet");
                Console.WriteLine("(2).Telefon Numarası Sil");
                Console.WriteLine("(3).Telefon Numarası Güncelle");
                Console.WriteLine("(4).Rehber Listele");
                Console.WriteLine("(5).Rehberde Arama");
                Console.WriteLine("(6).Sonlandır");
                Console.WriteLine("----------------");

                Console.Write("\nİşlem seçiniz:");

                try
                {
                    int islemNo = Convert.ToInt16(Console.ReadLine());

                    if (islemNo < 1 || islemNo > 6)
                    {
                        Console.WriteLine("\nLütfen 1-6 arası işlem seçiniz!");
                        continue;
                    }
                    else if (islemNo == 6)
                    {
                        Console.WriteLine("İşlem Sonlandırıldı.");
                        break;
                    }

                    Console.Clear();

                    switch (islemNo)
                    {
                        case 1:
                            Console.Write("Lütfen isim giriniz : ");
                            string ad = Console.ReadLine();
                            Console.Write("Lütfen Soyisim giriniz : ");
                            string soyad = Console.ReadLine();
                            Console.Write("Lütfen telefon numarası giriniz : ");
                            string numara = Console.ReadLine();
                            Kisiler tempKisi = new Kisiler(ad, soyad, numara);
                            KisilerListesi.Add(tempKisi);
                            Console.WriteLine("Kayıt başarılı");
                            break;
                        case 2:
                            while (true)
                            {
                                Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz :");
                                string girilen = Console.ReadLine();
                                int index = -1;
                                if (kisiIslemleri.NumaraVarmi(girilen, out index))
                                {
                                    Console.WriteLine($"{KisilerListesi[index].Isim} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
                                    Console.WriteLine("Seçiminiz : ");
                                    string islem = Console.ReadLine();
                                    if (islem == "y")
                                    {
                                        kisiIslemleri.NumaraSil(index);
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen işlem seçiniz.");
                                    Console.WriteLine(" *İşlemi sonlandırmak için: (1)");
                                    Console.WriteLine(" *Yeniden denemek için: (2)");

                                    Console.Write("Seçiminiz:");
                                    int yenisecim = Convert.ToInt16(Console.ReadLine());
                                    if (yenisecim == 1)
                                    {
                                        break;
                                    }
                                }
                            } 
                            break;
                        case 3:
                            while (true)
                            {
                                Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz :");
                                string girilen = Console.ReadLine();
                                int index = -1;
                                if (kisiIslemleri.NumaraVarmi(girilen, out index))
                                {
                                    Console.WriteLine($"{KisilerListesi[index].Isim} isimli kişiyi güncellemek için yeni numara giriniz");
                                    string yeniNo = Console.ReadLine();
                                    kisiIslemleri.NumaraGuncelle(index, yeniNo);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen işlem seçiniz.");
                                    Console.WriteLine(" *İşlemi sonlandırmak için: (1)");
                                    Console.WriteLine(" *Yeniden denemek için: (2)");

                                    Console.Write("Seçiminiz:");
                                    int yenisecim = Convert.ToInt16(Console.ReadLine());
                                    if (yenisecim == 1)
                                    {
                                        break;
                                    }
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("Hangi düzende sıralamak istediğinizi seçiniz.");
                            Console.WriteLine(" *A-Z için: (1)");
                            Console.WriteLine(" *Z-A için: (2)");
                            Console.Write("Seçiminiz:");
                            int siralamaSecimi = Convert.ToInt32(Console.ReadLine());

                            if (siralamaSecimi == 1)
                            {
                                kisiIslemleri.RehberListele(Siralama.Artan);
                            }
                            else
                            {
                                kisiIslemleri.RehberListele(Siralama.Azalan);
                            }
                            break;
                        case 5:
                            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                            Console.WriteLine(" *İsim veya soyisime göre arama yapmak için: (1)");
                            Console.WriteLine(" *Telefon numarasına göre arama yapmak için: (2)");

                            Console.Write("Seçiminiz:");
                            int yeniSecim = Convert.ToInt16(Console.ReadLine());

                            if (yeniSecim == 1)
                            {
                                Console.Write("İsim veya soyisim giriniz:");
                                string aranan_adveyaSoyad = Console.ReadLine();
                                kisiIslemleri.IsimSoyisimAramasi(aranan_adveyaSoyad);
                            }
                            else
                            {
                                Console.Write("Telefon giriniz:");
                                string aranan_telefon = Console.ReadLine();
                                kisiIslemleri.TelefonNumarasıArama(aranan_telefon);
                            }
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("\nYeni işlem için bir tuşa basınız");
                    Console.ReadKey();
                    Console.Clear();
                }

                catch (FormatException e)
                {
                    Console.WriteLine("Hatalı giriş yapıldı!\n");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
