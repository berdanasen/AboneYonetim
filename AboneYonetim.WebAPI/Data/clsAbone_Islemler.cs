using AboneYonetim.Entities.Concrete;
using AboneYonetim.Entities.Genel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboneYonetim.WebAPI.Data
{
    public class clsAbone_Islemler
    {
        public Mesajlar<ABONE> Duzelt(ABONE a, int aktifKulID)
        {

            Mesajlar<ABONE> m = new Mesajlar<ABONE>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.ABONELER.Where(x => x.ObjectID == a.ObjectID && x.Durum == true).SingleOrDefault();
                    if (m != null)
                    {
                        m.Nesne.Durum = true;
                        m.Nesne.DuzeltmeTarih = DateTime.Now;
                        m.Nesne.Du_KullaniciID = aktifKulID;

                        m.Nesne.AdSoyad = a.AdSoyad;
                        m.Nesne.TcKimlikNO = a.TcKimlikNO;
                        m.Nesne.AboneNo = a.AboneNo;
                        m.Nesne.TelefonNo = a.TelefonNo;
                        // KulId nasıl eklenecek
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

        public Mesajlar<ABONE> Ekle(ABONE a, int aktifKulID)
        {
            Mesajlar<ABONE> m = new Mesajlar<ABONE>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    a.Durum = true;
                    a.KayitTarih = DateTime.Now;
                    a.Ka_KullaniciID = aktifKulID;

                    var kullaniciVarmi = cnt.ABONELER.Any(x => x.KulID == a.KulID && x.Durum == true);
                    var aboneVarmi = cnt.ABONELER.Any(x => x.AboneNo == a.AboneNo && x.Durum == true);

                    if (kullaniciVarmi || aboneVarmi)
                    {
                        m.Durum = false;
                        m.Mesaj = "Bu kullanıcıya daha önce abone oluşturulmuş.";
                    }
                    else
                    {
                        cnt.ABONELER.Add(a);
                        cnt.SaveChanges();

                        m.Durum = true;
                        m.Mesaj = "Bilgiler başarıyla kaydedildi.";
                        m.KayitID = a.ObjectID;
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

        public Mesajlar<ABONE> Getir(int refID, int aktifKulID)
        {
            Mesajlar<ABONE> m = new Mesajlar<ABONE>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.ABONELER.Where(x => x.ObjectID == refID && m.Durum == true).SingleOrDefault();
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
        public Mesajlar<ABONE> Getir_Iliskisel(int refID, int aktifKulID)
        {
            Mesajlar<ABONE> m = new Mesajlar<ABONE>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.ABONELER.Include(x=>x.Kullanici).Where(x => x.ObjectID == refID && x.Durum == true).SingleOrDefault();
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
        public Mesajlar<ABONE> Listele(int aktifKulID)
        {
            Mesajlar<ABONE> m = new Mesajlar<ABONE>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.ABONELER.Where(x => x.Durum == true).ToList();
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

        public Mesajlar<ABONE> Listele_Iliskisel(int aktifKulID)
        {
            Mesajlar<ABONE> m = new Mesajlar<ABONE>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.ABONELER.Include(y => y.Kullanici).Where(x => x.Durum == true).ToList();
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

        public Mesajlar<ABONE> Sil(ABONE k, int aktifKulID)
        {
            Mesajlar<ABONE> m = new Mesajlar<ABONE>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {

                    m.Nesne = cnt.ABONELER.Where(x => x.ObjectID == k.ObjectID && x.Durum == true).SingleOrDefault();

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

        public Mesajlar<ABONE> Sil_Id(int refID, int aktifKulID)
        {
            Mesajlar<ABONE> m = new Mesajlar<ABONE>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {

                    m.Nesne = cnt.ABONELER.Where(x => x.ObjectID == refID && x.Durum == true).SingleOrDefault();

                    if (m != null)
                    {
                        m.Nesne.Durum = false;
                        m.Nesne.SilmeTarih = DateTime.Now;
                        m.Nesne.Sil_KullaniciID = aktifKulID;


                        cnt.SaveChanges();
                        m.Durum = true;
                        m.Mesaj = "Abone Silindi..";
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
