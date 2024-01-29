﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab2_1
{
    class _3x3Engel : BaseEngel
    {

        public _3x3Engel()
        {
            this.Boyut = 3;
        }

        public override int[,] engelOlustur()
        {
            Random rnd = new Random();
            Engel = new int[Boyut, Boyut];

            //Bütün alanları duvar yapıyoruz.
            for (int i = 0; i < Boyut; i++)
            {
                for (int j = 0; j < Boyut; j++)
                {
                    Engel[i, j] = 1;
                }
            }

            int sayac = 0;

            for (int i = 0; i < Boyut; i++)
            {
                for (int j = 0; j < Boyut; j++)
                {
                    if (sayac == 2)
                        break;
                    if(rnd.Next(2) == 1)
                    {
                        sayac++;
                        Engel[i, j] = 0;
                    }

                }
            }

            for (int i = 0; i < Boyut; i++)
            {
                for (int j = 0; j < Boyut; j++)
                {
                    Console.Write(Engel[i, j]);
                }
                Console.WriteLine();
            }


            return Engel;
        }
    }
}
