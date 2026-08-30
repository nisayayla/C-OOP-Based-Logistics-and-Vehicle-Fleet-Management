using System;
using System.Collections.Generic;
using System.Text;

namespace projem
{
    internal class Paket
    {
        
            private int en, boy, fiyat, adet;
            private int agirlik;
            public Paket(int en, int boy, int agirlik)
            {
                this.en = en;
                this.boy = boy;
                this.agirlik = agirlik;
                fiyat = adet = 0;
            }
            public int Boxproperty
            {
                set
                {
                    if (en < 0 & boy < 0 & agirlik < 0)
                    {
                        agirlik = -value;
                        en = -value;
                        boy = -value;
                    }
                }
            }
            public int KutuAgirlik(ref int agirlik)
            {
                return agirlik;
            }
            public int Tabanalan()
            {
                return en * boy;
            }
            public int Tutar()
            {
                return adet * fiyat;
            }
        }
    }

