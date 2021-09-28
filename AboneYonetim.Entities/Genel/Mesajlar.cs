using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboneYonetim.Entities.Genel
{
    public class Mesajlar<T> where T: class, new()
    {
        public bool Durum { get; set; }
        public string Mesaj { get; set; }
        public int KayitID { get; set; }
        public T Nesne { get; set; }
        public List<T> Liste { get; set; }
    }
}
