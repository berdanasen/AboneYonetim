using AboneYonetim.Entities.Concrete;
using AboneYonetim.Entities.Genel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboneYonetim.WebAPI.Data
{
    public class clsFatura_Islemler
    {
        public Mesajlar<FATURA> Duzelt(FATURA f, int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.FATURALAR.Where(x => x.ObjectID == f.ObjectID && x.Durum == true).SingleOrDefault();
                    if (m != null)
                    {
                        m.Nesne.Durum = true;
                        m.Nesne.DuzeltmeTarih = DateTime.Now;
                        m.Nesne.Du_KullaniciID = aktifKulID;

                        m.Nesne.AboneID = f.AboneID;
                        m.Nesne.FaturaOdendiMi = f.FaturaOdendiMi;
                        m.Nesne.FaturaDuzenlenmeTarih = f.FaturaDuzenlenmeTarih;
                        m.Nesne.FaturaSonOdemeTarih = f.FaturaSonOdemeTarih;
                        m.Nesne.Donem.Donem = f.Donem.Donem;
                        m.Nesne.FaturaTutari = f.FaturaTutari;


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

        public Mesajlar<FATURA> Ekle(FATURA f, int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    var faturaVarmi = cnt.FATURALAR.Any(x => x.DonemID == f.DonemID && x.Durum == true);
                    if (faturaVarmi)
                    {
                        m.Durum = false;
                        m.Mesaj = "Bu dönemde daha önce fatura oluşturulmuş.";
                    }
                    else
                    {
                        f.Durum = true;
                        f.KayitTarih = DateTime.Now;
                        f.Ka_KullaniciID = aktifKulID;
                        f.DuzeltmeTarih = DateTime.Now;
                        f.FaturaOdendiMi = false;
                        f.Aktif = true;

                        cnt.FATURALAR.Add(f);
                        cnt.SaveChanges();

                        m.Durum = true;
                        m.Mesaj = "Bilgiler başarıyla kaydedildi.";
                        m.KayitID = f.ObjectID;
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

        public Mesajlar<FATURA> Getir(int refID, int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.FATURALAR.Where(x => x.ObjectID == refID && m.Durum == true).SingleOrDefault();
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

        public Mesajlar<FATURA> Getir_Iliskisel(int refID, int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Nesne = cnt.FATURALAR.Include(x => x.Abone).Include(x => x.Donem).Where(x => x.ObjectID == refID && x.Durum == true).SingleOrDefault();
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

        public Mesajlar<FATURA> Getir_AboneID(int refID, int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.FATURALAR.Include(x => x.Abone).Include(x => x.Donem).Where(x => x.AboneID == refID && x.Durum == true && x.FaturaOdendiMi == false).ToList();
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

        public Mesajlar<FATURA> Listele(int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.FATURALAR.Where(x => x.Durum == true).ToList();
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
        public Mesajlar<FATURA> Listele_Iliskisel(int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.FATURALAR.Include(x => x.Abone).Include(x => x.Donem).Where(x => x.Durum == true).OrderBy(x => x.FaturaSonOdemeTarih).ToList();
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

        public Mesajlar<FATURA> Listele_Abone(int refID, int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.FATURALAR.Include(x => x.Abone).Include(x => x.Donem).Where(x => x.AboneID == refID).ToList();
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

        public Mesajlar<FATURA> Kisi_Listele_Iliskisel(string kullaniciAd, int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.FATURALAR.Include(x => x.Abone).Include(x => x.Donem).Where(x => x.Durum == true && x.Abone.Kullanici.Kulad == kullaniciAd).ToList();
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

        public Mesajlar<FATURA> Odenmemis_Kisi_Listele_Iliskisel(string kullaniciAd, int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.FATURALAR.Include(x => x.Abone).Include(x => x.Donem).Where(x => x.Durum == true && x.Abone.Kullanici.Kulad == kullaniciAd && x.FaturaOdendiMi == false).ToList();
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

        public Mesajlar<FATURA> Odenmis_Kisi_Listele_Iliskisel(string kullaniciAd, int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    m.Liste = cnt.FATURALAR.Include(x => x.Abone).Include(x => x.Donem).Where(x => x.Durum == true && x.Abone.Kullanici.Kulad == kullaniciAd && x.FaturaOdendiMi == true).ToList();
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

        public Mesajlar<FATURA> Sil(FATURA f, int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {

                    m.Nesne = cnt.FATURALAR.Where(x => x.ObjectID == f.ObjectID && x.Durum == true).SingleOrDefault();

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
        public Mesajlar<FATURA> Sil_Id(int refId, int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {

                    m.Nesne = cnt.FATURALAR.Where(x => x.ObjectID == refId && x.Durum == true).SingleOrDefault();

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

        public Mesajlar<FATURA> Fatura_Toplu_Fatura(int refID, int aktifKulID)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();

            try
            {
                using (AboneYonetimContext cnt = new AboneYonetimContext())
                {
                    var donem = cnt.DONEMLER.Where(x => x.ObjectID == refID && x.Durum == true).SingleOrDefault();
                    var aboneler = cnt.ABONELER.Where(x => x.Durum == true).ToList();
                    var faturaVarmi = cnt.FATURALAR.Any(x => x.DonemID == refID && x.Durum == true);

                    if (donem != null && aboneler != null && !faturaVarmi)
                    {
                        foreach (var abone in aboneler)
                        {
                            var faturalar = cnt.FATURALAR.ToList();
                            FATURA f = new FATURA();
                            f.Durum = true;
                            f.KayitTarih = DateTime.Now;
                            f.Ka_KullaniciID = aktifKulID;
                            f.DuzeltmeTarih = DateTime.Now;
                            f.FaturaOdendiMi = false;
                            f.Aktif = true;
                            f.AboneID = abone.ObjectID;
                            f.FaturaNo = "09" + abone.AboneNo + faturalar.Count;
                            f.FaturaOdendiMi = false;
                            f.FaturaDuzenlenmeTarih = DateTime.Now;
                            f.FaturaSonOdemeTarih = DateTime.Now.AddDays(25);
                            var tutar = (decimal)(new Random().NextDouble() * 10000);
                            f.FaturaTutari = tutar;
                            f.DonemID = donem.ObjectID;

                            cnt.FATURALAR.Add(f);
                            cnt.SaveChanges();
                        }

                        m.Durum = true;
                        m.Mesaj = "Toplu fatura başarıyla oluşturuldu.";
                    }
                    else
                    {
                        m.Durum = false;
                        m.Mesaj = "Toplu fatura oluşturulamadı.";
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
