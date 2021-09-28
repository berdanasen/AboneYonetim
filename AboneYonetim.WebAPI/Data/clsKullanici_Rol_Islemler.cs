using AboneYonetim.Entities.Concrete;
using AboneYonetim.Entities.Genel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboneYonetim.WebAPI.Data
{
    public class clsKullanici_Rol_Islemler
    {
        public Mesajlar<KULLANICI_ROL> Ekle(KULLANICI_ROL k, int aktifKulID)
        {
            Mesajlar<KULLANICI_ROL> m = new Mesajlar<KULLANICI_ROL>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    k.Durum = true;
                    k.KayitTarih = DateTime.Now;
                    k.Ka_KullaniciID = aktifKulID;

                    cnt.KULLANICI_ROLLER.Add(k);
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

        public Mesajlar<KULLANICI_ROL> Getir(int refID, int aktifKulID)
        {
            Mesajlar<KULLANICI_ROL> m = new Mesajlar<KULLANICI_ROL>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.KULLANICI_ROLLER.Where(x => x.ObjectID == refID).SingleOrDefault();
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

        public Mesajlar<KULLANICI_ROL> Duzelt(KULLANICI_ROL k, int aktifKulID)
        {
            Mesajlar<KULLANICI_ROL> m = new Mesajlar<KULLANICI_ROL>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.KULLANICI_ROLLER.Where(x => x.ObjectID == k.ObjectID).SingleOrDefault();
                    if (m != null)
                    {
                        m.Nesne.Durum = true;
                        m.Nesne.DuzeltmeTarih = DateTime.Now;
                        m.Nesne.Du_KullaniciID = aktifKulID;
                        m.Nesne.RolAd = k.RolAd;
                        m.Nesne.Aktif = k.Aktif;
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

        public Mesajlar<KULLANICI_ROL> Sil(KULLANICI_ROL k, int aktifKulID)
        {
            Mesajlar<KULLANICI_ROL> m = new Mesajlar<KULLANICI_ROL>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {

                    m.Nesne = cnt.KULLANICI_ROLLER.Where(x => x.ObjectID == k.ObjectID).SingleOrDefault();

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

        public Mesajlar<KULLANICI_ROL> Sil_ID(int refID, int aktifKulID)
        {
            Mesajlar<KULLANICI_ROL> m = new Mesajlar<KULLANICI_ROL>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.KULLANICI_ROLLER.Where(x => x.ObjectID == refID && x.Durum == true).SingleOrDefault();

                    if (m != null)
                    {
                        m.Nesne.Durum = false;
                        m.Nesne.SilmeTarih = DateTime.Now;
                        m.Nesne.Sil_KullaniciID = aktifKulID;

                        cnt.SaveChanges();
                        m.Durum = true;
                        m.Mesaj = "Rol Silindi.";
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

        public Mesajlar<KULLANICI_ROL> Listele(int aktifKulID)
        {
            Mesajlar<KULLANICI_ROL> m = new Mesajlar<KULLANICI_ROL>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.KULLANICI_ROLLER.Where(x => x.Durum == true).ToList();


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
    }
}
