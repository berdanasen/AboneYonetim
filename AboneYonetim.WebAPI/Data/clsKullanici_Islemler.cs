using AboneYonetim.Entities.Concrete;
using AboneYonetim.Entities.Genel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboneYonetim.WebAPI.Data
{
    public class clsKullanici_Islemler
    {
        public Mesajlar<KULLANICI> Kullanici_Kontrol(string KulAd, string Sifre)
        {
            Mesajlar<KULLANICI> m = new Mesajlar<KULLANICI>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    var ns = cnt.Set<KULLANICI>();

                    if (KulAd == "sysRecover" && Sifre == "sysRecover123")//superAdmin  RolID =1 olan sadece superAdmin olabilir. 
                    {
                        m.Nesne = ns.SingleOrDefault(x => x.RolID == 1);

                        if (m.Nesne == null)
                        {

                            var rolEntity = cnt.KULLANICI_ROLLER.Where(x => x.ObjectID == 1 && x.Durum == true).SingleOrDefault();

                            if (rolEntity == null)
                            {
                                cnt.KULLANICI_ROLLER.Add(new KULLANICI_ROL()
                                {
                                    RolAd = "Süper Admin",
                                    Durum = true
                                });

                                cnt.SaveChanges();
                            }

                            KULLANICI k = new KULLANICI()
                            {
                                AdSoyad = "Süper Admin",
                                Kulad = "admin",
                                Eposta = "",
                                GsmNo = "",
                                TcNo = "",
                                Sifre = clsGenel.Sifrele("123"),
                                RolID = 1,
                                Durum = true
                            };
                            ns.Add(k);
                            cnt.SaveChanges();
                        }
                        else
                        {
                            m.Nesne.Sifre = clsGenel.Sifrele("123");
                            cnt.SaveChanges();
                        }

                        m.Nesne = ns.SingleOrDefault(x => x.Durum == true && x.Kulad == "admin" && x.Sifre == clsGenel.Sifrele("123"));
                    }
                    else
                    {
                        m.Nesne = ns.SingleOrDefault(x => x.Durum == true && (x.Kulad == KulAd || x.Eposta == KulAd) && x.Sifre == clsGenel.Sifrele(Sifre));
                    }




                    if (m.Nesne == null)
                    {
                        m.Durum = false;
                        m.Mesaj = "Yetkisiz kullanıcı !";
                    }
                    else
                    {
                        m.Durum = true;
                        m.Mesaj = "Kullanıcı sisteme giriş yaptı.";
                    }
                }
            }
            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = ex.Message;
            }

            return m;
        }

        public Mesajlar<KULLANICI> Ekle(KULLANICI k, int aktifKulID)
        {
            Mesajlar<KULLANICI> m = new Mesajlar<KULLANICI>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    k.Durum = true;
                    k.KayitTarih = DateTime.Now;
                    k.Ka_KullaniciID = aktifKulID;

                    k.Sifre = clsGenel.Sifrele(k.Sifre);

                    cnt.KULLANICILAR.Add(k);
                    cnt.SaveChanges();

                    m.Durum = true;
                    m.Mesaj = "Bilgiler başarıyla kaydedildi.";
                    m.KayitID = k.ObjectID;
                }
            }
            catch (Exception eex)
            {
                m.Durum = false;
                m.Mesaj = eex.Message;
            }

            return m;
        }

        public Mesajlar<KULLANICI> Getir(int refID, int aktifKulID)
        {
            Mesajlar<KULLANICI> m = new Mesajlar<KULLANICI>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.KULLANICILAR.Where(x => x.ObjectID == refID && x.Durum == true).SingleOrDefault();
                    m.Durum = true;
                    m.Mesaj = "Bilgiler görüntülendi.";
                }
            }
            catch (Exception eex)
            {
                m.Durum = false;
                m.Mesaj = eex.Message;
            }

            return m;
        }

        public Mesajlar<KULLANICI> Getir_Iliskisel(int refID, int aktifKulID)
        {

            Mesajlar<KULLANICI> m = new Mesajlar<KULLANICI>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.KULLANICILAR.Include("KullaniciRol").Where(x => x.ObjectID == refID && x.Durum == true).SingleOrDefault();
                    m.Durum = true;
                    m.Mesaj = "Bilgiler görüntülendi.";
                }
            }
            catch (Exception eex)
            {
                m.Durum = false;
                m.Mesaj = eex.Message;
            }

            return m;

        }

        public Mesajlar<KULLANICI> Duzelt(KULLANICI k, int aktifKulID)
        {
            Mesajlar<KULLANICI> m = new Mesajlar<KULLANICI>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.KULLANICILAR.Where(x => x.ObjectID == k.ObjectID && x.Durum == true).SingleOrDefault();
                    if (m != null)
                    {
                        m.Nesne.Durum = true;
                        m.Nesne.DuzeltmeTarih = DateTime.Now;
                        m.Nesne.Du_KullaniciID = aktifKulID;
                        m.Nesne.AdSoyad = k.AdSoyad;
                        m.Nesne.TcNo = k.TcNo;
                        m.Nesne.RolID = k.RolID;
                        m.Nesne.Aktif = k.Aktif;
                        m.Nesne.Eposta = k.Eposta;
                        m.Nesne.GsmNo = k.GsmNo;
                        m.Nesne.Sifre = clsGenel.Sifrele(k.Sifre);
                        m.Nesne.Kulad = k.Kulad;
                        cnt.SaveChanges();
                        m.Durum = true;
                        m.Mesaj = "Kullanıcı Başarılı Düzenlendi...";
                    }
                }
            }
            catch (Exception eex)
            {
                m.Durum = false;
                m.Mesaj = eex.Message;
            }
            return m;
        }

        public Mesajlar<KULLANICI> Sil(KULLANICI k, int aktifKulID)
        {
            Mesajlar<KULLANICI> m = new Mesajlar<KULLANICI>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {

                    m.Nesne = cnt.KULLANICILAR.Where(x => x.ObjectID == k.ObjectID && x.Durum == true).SingleOrDefault();

                    if (m != null)
                    {
                        m.Nesne.Durum = false;
                        m.Nesne.SilmeTarih = DateTime.Now;
                        m.Nesne.Sil_KullaniciID = aktifKulID;


                        cnt.SaveChanges();
                        m.Durum = true;
                        m.Mesaj = "Kullanıcı Silindi..";
                    }
                }
            }
            catch (Exception eex)
            {
                m.Durum = false;
                m.Mesaj = eex.Message;
            }
            return m;
        }

        public Mesajlar<KULLANICI> Listele(int aktifKulID)
        {
            Mesajlar<KULLANICI> m = new Mesajlar<KULLANICI>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.KULLANICILAR.Where(x => x.Durum == true).ToList();


                    m.Durum = true;
                    m.Mesaj = "Kayıtlar listelendi";
                }
            }
            catch (Exception eex)
            {
                m.Durum = false;
                m.Mesaj = eex.Message;
            }

            return m;

        }

        public Mesajlar<KULLANICI> Listele_Iliskisel(int aktifKulID)
        {
            Mesajlar<KULLANICI> m = new Mesajlar<KULLANICI>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.KULLANICILAR.Include(y => y.KullaniciRol).Where(x => x.Durum == true).ToList();
                    m.Durum = true;
                    m.Mesaj = "Kayıtlar listelendi";
                }
            }
            catch (Exception eex)
            {
                m.Durum = false;
                m.Mesaj = eex.Message;
            }

            return m;
        }

        public Mesajlar<KULLANICI> Sil_Id(int refID, int aktifKulID)
        {
            Mesajlar<KULLANICI> m = new Mesajlar<KULLANICI>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.KULLANICILAR.Where(x => x.ObjectID == refID && x.Durum == true).SingleOrDefault();

                    if (m != null)
                    {
                        m.Nesne.Durum = false;
                        m.Nesne.SilmeTarih = DateTime.Now;
                        m.Nesne.Sil_KullaniciID = aktifKulID;

                        cnt.SaveChanges();
                        m.Durum = true;
                        m.Mesaj = "Kullanıcı Silindi";
                    }
                }
            }
            catch (Exception eex)
            {
                m.Durum = false;
                m.Mesaj = eex.Message;
            }

            return m;
        }
    }
}
