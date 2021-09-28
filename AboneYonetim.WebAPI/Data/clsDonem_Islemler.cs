using AboneYonetim.Entities.Concrete;
using AboneYonetim.Entities.Genel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboneYonetim.WebAPI.Data
{
    public class clsDonem_Islemler
    {
        public Mesajlar<DONEM> Duzelt(DONEM d, int aktifKulID)
        {
            Mesajlar<DONEM> m = new Mesajlar<DONEM>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne.Durum = true;
                    m.Nesne.DuzeltmeTarih = DateTime.Now;
                    m.Nesne.Du_KullaniciID = aktifKulID;

                    m.Nesne.Donem = d.Donem;

                    cnt.SaveChanges();
                    m.Durum = true;
                    m.Mesaj = "Dönem Başarıyla Düzenlendi...";
                }
            }
            catch (Exception eex)
            {
                m.Durum = false;
                m.Mesaj = eex.Message;
            }

            return m;
        }

        public Mesajlar<DONEM> Ekle(DONEM d, int aktifKulID)
        {
            Mesajlar<DONEM> m = new Mesajlar<DONEM>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    d.Durum = true;
                    d.KayitTarih = DateTime.Now;
                    d.Ka_KullaniciID = aktifKulID;
                    d.DuzeltmeTarih = DateTime.Now;
                    d.Aktif = true;

                    var donem = d.Donem.ToUpper();

                    if (donem == "OCAK" || donem == "ŞUBAT" || donem == "MART" || donem == "NİSAN" || donem == "MAYIS" || donem == "HAZİRAN" || donem == "TEMMUZ" || donem == "AĞUSTOS" || donem == "EYLÜL" || donem == "EKİM" || donem == "KASIM" || donem == "ARALIK")
                    {
                        donem += " - " + DateTime.Now.Year;

                        d.Donem = donem;

                        cnt.DONEMLER.Add(d);
                        cnt.SaveChanges();

                        m.Durum = true;
                        m.Mesaj = "Bilgiler başarıyla kaydedildi.";
                        m.KayitID = d.ObjectID;
                    }
                    else
                    {
                        m.Durum = false;
                        m.Mesaj = "Girdiğiniz dönem yoktur.";
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

        public Mesajlar<DONEM> Getir(int refID, int aktifKulID)
        {
            Mesajlar<DONEM> m = new Mesajlar<DONEM>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.DONEMLER.Where(x => x.ObjectID == refID && m.Durum == true).SingleOrDefault();
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

        public Mesajlar<DONEM> Listele(int aktifKulID)
        {
            Mesajlar<DONEM> m = new Mesajlar<DONEM>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.DONEMLER.Where(x => x.Durum == true).ToList();
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

        public Mesajlar<DONEM> Sil(DONEM d, int aktifKulID)
        {
            Mesajlar<DONEM> m = new Mesajlar<DONEM>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {

                    m.Nesne = cnt.DONEMLER.Where(x => x.ObjectID == d.ObjectID && x.Durum == true).SingleOrDefault();

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

        public Mesajlar<DONEM> Sil_Id(int refId, int aktifKulID)
        {
            Mesajlar<DONEM> m = new Mesajlar<DONEM>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {

                    m.Nesne = cnt.DONEMLER.Where(x => x.ObjectID == refId && x.Durum == true).SingleOrDefault();

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
    }
}
