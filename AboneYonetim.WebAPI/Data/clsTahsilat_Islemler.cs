using AboneYonetim.Entities.Concrete;
using AboneYonetim.Entities.Genel;
using AboneYonetim.Entities.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AboneYonetim.WebAPI.Data
{
    public class clsTahsilat_Islemler
    {
        public Mesajlar<TAHSILAT> Duzelt(TAHSILAT t, int aktifKulID)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.TAHSILATLAR.Where(x => x.ObjectID == t.ObjectID).SingleOrDefault();
                    if (m != null)
                    {
                        m.Nesne.Durum = true;
                        m.Nesne.DuzeltmeTarih = DateTime.Now;
                        m.Nesne.Du_KullaniciID = aktifKulID;

                        m.Nesne.AboneID = t.AboneID;
                        m.Nesne.FaturaID = t.FaturaID;
                        m.Nesne.TahTarhi = t.TahTarhi;
                        m.Nesne.TahTutar = t.TahTutar;

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

        public Mesajlar<TAHSILAT> Ekle(TAHSILAT t, int aktifKulID)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    t.Durum = true;
                    t.KayitTarih = DateTime.Now;
                    t.Ka_KullaniciID = aktifKulID;
                    var dateTime = DateTime.Now;

                    var varmi = cnt.TAHSILATLAR.Any(x => x.FaturaID == t.FaturaID);

                    if (varmi)
                    {
                        m.Durum = false;
                        m.Mesaj = "Bu faturaya daha önce tahsilat oluşturulmuştur";
                    }
                    else
                    {
                        cnt.TAHSILATLAR.Add(t);
                        cnt.SaveChanges();
                        
                        m.Durum = true;
                        m.Mesaj = "Bilgiler başarıyla kaydedildi.";
                        m.KayitID = t.ObjectID;
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

        public Mesajlar<TAHSILAT> Getir(int refID, int aktifKulID)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.TAHSILATLAR.Where(x => x.ObjectID == refID && m.Durum == true).SingleOrDefault();
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

        public Mesajlar<TAHSILAT> Getir_Iliskisel(int refID, int aktifKulID)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.TAHSILATLAR.Include("Fatura").Include("Abone").Include("Donem").Where(x => x.ObjectID == refID && x.Durum == true).SingleOrDefault();
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

        public Mesajlar<TAHSILAT> Listele(int aktifKulID)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.TAHSILATLAR.Where(x => x.Durum == true).ToList();
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
        public Mesajlar<TAHSILAT> Listele_Iliskisel(int aktifKulID)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.TAHSILATLAR.Include("Fatura").Include("Abone").Include("Donem").Where(x => x.Durum == true).ToList();
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

        public Mesajlar<TAHSILAT> Kisi_Listele_Iliskisel(string kullaniciAd, int aktifKulID)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.TAHSILATLAR.Include("Fatura").Include("Abone").Include("Donem").Where(x => x.Durum == true && x.Abone.Kullanici.Kulad == kullaniciAd).ToList();
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

        public Mesajlar<TAHSILAT> Kisi_Odenmis_Listele_Iliskisel(string kullaniciAd, int aktifKulID)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.TAHSILATLAR.Include("Fatura").Include("Abone").Include("Donem").Where(x => x.Durum == true && x.Abone.Kullanici.Kulad == kullaniciAd && x.Fatura.FaturaOdendiMi == true).ToList();
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

        public Mesajlar<TAHSILAT> Kisi_Odenmemis_Listele_Iliskisel(string kullaniciAd, int aktifKulID)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.TAHSILATLAR.Include("Fatura").Include("Abone").Include("Donem").Where(x => x.Durum == true && x.Abone.Kullanici.Kulad == kullaniciAd && x.Fatura.FaturaOdendiMi == false).ToList();
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

        public Mesajlar<TAHSILAT> Sil(TAHSILAT t, int aktifKulID)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {

                    m.Nesne = cnt.TAHSILATLAR.Where(x => x.ObjectID == t.ObjectID).SingleOrDefault();

                    if (m != null)
                    {
                        m.Nesne.Durum = false;
                        m.Nesne.SilmeTarih = DateTime.Now;
                        m.Nesne.Sil_KullaniciID = aktifKulID;

                        cnt.SaveChanges();
                        m.Durum = true;
                        m.Mesaj = "Tahsilat Başarıyla Silindi.";
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

        public Mesajlar<TAHSILAT> Ode(TAHSILAT t, int aktifKulID)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {

                    m.Nesne = cnt.TAHSILATLAR.Where(x => x.ObjectID == t.ObjectID).SingleOrDefault();

                    if (m != null)
                    {
                        //m.Nesne.Durum = false;
                        m.Nesne.SilmeTarih = DateTime.Now;
                        m.Nesne.Sil_KullaniciID = aktifKulID;

                        var varmi = cnt.FATURALAR.Any(x => x.ObjectID == t.FaturaID && x.Durum == true);
                        var fatura = cnt.FATURALAR.Where(x => x.ObjectID == t.FaturaID && x.Durum == true && x.FaturaOdendiMi == false).SingleOrDefault();
                        if (varmi && fatura != null)
                        {
                            fatura.FaturaOdendiMi = true;

                            cnt.SaveChanges();
                            m.Durum = true;
                            m.Mesaj = "Tahsilat Başarıyla Ödendi.";
                        }
                        else
                        {
                            m.Durum = false;
                            m.Mesaj = "Bu faturanın ödemesi yapılmış.";
                        }
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

        public Mesajlar<TAHSILAT> Ekle_Ode(TAHSILAT t, int aktifKulID)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {

                    //m.Nesne = cnt.TAHSILATLAR.Where(x => x.ObjectID == t.ObjectID).SingleOrDefault();
                    t.Durum = true;
                    t.KayitTarih = DateTime.Now;
                    t.Ka_KullaniciID = aktifKulID;

                    var faturaVarmi = cnt.TAHSILATLAR.Any(x => x.FaturaID == t.FaturaID);

                    if (faturaVarmi)
                    {
                        m.Durum = false;
                        m.Mesaj = "Bu faturaya daha önce tahsilat oluşturulmuştur.";
                    }

                    else
                    {
                        var varmi = cnt.FATURALAR.Any(x => x.ObjectID == t.FaturaID);
                        var fatura = cnt.FATURALAR.Where(x => x.ObjectID == t.FaturaID && x.FaturaOdendiMi == false).SingleOrDefault();

                        if (varmi || fatura != null)
                        {
                            fatura.FaturaOdendiMi = true;
                        }

                        cnt.TAHSILATLAR.Add(t);
                        cnt.SaveChanges();
                        m.Durum = true;
                        m.Mesaj = "Tahsilat Başarıyla Ödendi.";
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
