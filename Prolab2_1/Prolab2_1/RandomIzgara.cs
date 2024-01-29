using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace Prolab2_1
{
    class RandomIzgara : BaseIzgara
    {
        private Tuple<int, int> baslangic, bitis;

        public RandomIzgara(int boyut , Tuple<int , int> baslangic , Tuple<int,int> bitis)
        {
            this.Baslangic = baslangic;
            this.Bitis = bitis;
            this.Boyut = boyut;
            LastIzgara = new int[Boyut, Boyut];
            rastgeleLabirentUret();
        }

      

        public override List<List<Button>> generateIzgara()
        {
            int uzunluk1 =  Convert.ToInt16( Math.Sqrt(LastIzgara.Length)) + 2;
            Console.WriteLine("uzunluk 1 : " + uzunluk1);
            int[,] temp = new int[uzunluk1, uzunluk1];
            for (int i = 0; i < uzunluk1; i++)
            {
                for (int j = 0; j < uzunluk1; j++)
                {
                    if (i == 0 || i == uzunluk1 - 1 || j == 0 || j == uzunluk1 - 1)
                        temp[i, j] = 1;
                }
            }
            int a = 0, b = 0;
            for (int i = 1; i < uzunluk1 - 1; i++)
            {
                for (int j = 1; j < uzunluk1 - 1; j++)
                {
                    temp[i, j] = LastIzgara[a,b];
                    b++;
                }
                b = 0;
                a++;
            }
            LastIzgara = temp;

            LastIzgara[Baslangic.Item1 + 1, Baslangic.Item2 + 1] = 0;
            LastIzgara[bitis.Item1 + 1, bitis.Item2 + 1] = 0;


            int x = 200, y = 20;
            int uzunluk = Convert.ToInt16(Math.Sqrt(LastIzgara.Length));
            for (int i = 0; i < Math.Sqrt(LastIzgara.Length); i++)
            {
                this.Buttons.Add(new List<Button>());
                for (int j = 0; j < Math.Sqrt(LastIzgara.Length); j++)
                {
                    if (LastIzgara[i, j] == 0)
                    {
                        int last = Buttons.Count - 1;
                        Buttons[last].Add(new Button());
                        int last2 = Buttons[last].Count - 1;
                        Buttons[last][last2].Width = 30;
                        Buttons[last][last2].Height = 30;
                        Buttons[last][last2].BackColor = Color.White;
                        Buttons[last][last2].Visible = false;
                        Buttons[last][last2].Location = new Point(x, y);
                    }
                    else
                    {
                        int last = Buttons.Count - 1;
                        Buttons[last].Add(new Button());
                        int last2 = Buttons[last].Count - 1;
                        Buttons[last][last2].Width = 30;
                        Buttons[last][last2].Height = 30;
                        Buttons[last][last2].Visible = false;
                        //engeller[last][last2].BackColor = Color.Black;
                        Buttons[last][last2].BackgroundImage = Wall;
                        Buttons[last][last2].Location = new Point(x, y);
                    }
                    x += 30;
                }
                x = 200;
                y += 30;
            }
            Buttons[Baslangic.Item1 + 1][Baslangic.Item2 + 1].BackColor = Color.Green;
            Buttons[Bitis.Item1 + 1][Bitis.Item2 + 1].BackColor = Color.Red;
            return Buttons;
        }


        public void rastgeleLabirentUret()
        {

            //Bütün ızgarayı duvarlarla dolduruyoruz.
            for (int i = 0; i < Boyut ; i++)
            {
                for (int j = 0; j < Boyut; j++)
                {
                    LastIzgara[i, j] = 1;
                }
            }

            //Başlangıcı yol yapıyoruz.
            LastIzgara[Baslangic.Item1, Baslangic.Item2] = 0;


            List<Tuple<int, int>> duvarlar = new List<Tuple<int, int>>();

            if (Baslangic.Item1 > 0)
            {
                duvarlar.Add(new Tuple<int, int>(Baslangic.Item1 - 1, Baslangic.Item2));
            }

            if (Baslangic.Item1 <  Boyut - 1)
            {
                duvarlar.Add(new Tuple<int, int>(Baslangic.Item1 + 1, Baslangic.Item2));
            }

            if (Baslangic.Item2 > 0)
            {
                duvarlar.Add(new Tuple<int, int>(Baslangic.Item1, Baslangic.Item2 - 1));
            }

            if (Baslangic.Item2 < Boyut - 1)
            {
                duvarlar.Add(new Tuple<int, int>(Baslangic.Item1, Baslangic.Item2 + 1));
            }

            //Kenarları karıştırıyoruz.
            Random rnd = new Random();
            for (int i = duvarlar.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                Tuple<int, int> temp = duvarlar[i];
                duvarlar[i] = duvarlar[j];
                duvarlar[j] = temp;
            }

            //Şimdi tüm hücrelere bakana bakar ekleyeceğiz köşeleri
            while(duvarlar.Count > 0)
            {
                Tuple<int, int> sonrakiDuvar = duvarlar[rnd.Next(0, duvarlar.Count)];

                //Aldığımız duvarı siliyoruz.
                duvarlar.Remove(sonrakiDuvar);

                //Şimdi komşu arayacağız.
                int komsu = 0;

                if (sonrakiDuvar.Item1 > 0 && LastIzgara[sonrakiDuvar.Item1 - 1, sonrakiDuvar.Item2] == 0)
                    komsu++;
                if (sonrakiDuvar.Item1 < Boyut - 1 && LastIzgara[sonrakiDuvar.Item1 + 1, sonrakiDuvar.Item2] == 0)
                    komsu++;
                if (sonrakiDuvar.Item2 > 0 && LastIzgara[sonrakiDuvar.Item1, sonrakiDuvar.Item2 - 1] == 0)
                    komsu++;
                if (sonrakiDuvar.Item2 < Boyut - 1 && LastIzgara[sonrakiDuvar.Item1, sonrakiDuvar.Item2 + 1] == 0)
                    komsu++;


                if(komsu == 1)
                {
                    LastIzgara[sonrakiDuvar.Item1, sonrakiDuvar.Item2] = 0;

                    //Şimdi bu noktanın komsularını yazıyoruz.
                    if(sonrakiDuvar.Item1 > 0 && LastIzgara[sonrakiDuvar.Item1 - 1,  sonrakiDuvar.Item2] == 1)
                    {
                        duvarlar.Add(new Tuple<int, int>(sonrakiDuvar.Item1 - 1, sonrakiDuvar.Item2));
                    }

                    if (sonrakiDuvar.Item1 < Boyut - 1 && LastIzgara[sonrakiDuvar.Item1 + 1, sonrakiDuvar.Item2] == 1)
                    {
                        duvarlar.Add(new Tuple<int, int>(sonrakiDuvar.Item1 + 1, sonrakiDuvar.Item2) );
                    }

                    if (sonrakiDuvar.Item2 > 0 && LastIzgara[sonrakiDuvar.Item1, sonrakiDuvar.Item2 - 1] == 1)
                    {
                        duvarlar.Add(new Tuple<int, int>(sonrakiDuvar.Item1, sonrakiDuvar.Item2 - 1));
                    }

                    if (sonrakiDuvar.Item2 < Boyut - 1 && LastIzgara[sonrakiDuvar.Item1 , sonrakiDuvar.Item2 + 1] == 1)
                    {
                        duvarlar.Add(new Tuple<int, int>(sonrakiDuvar.Item1, sonrakiDuvar.Item2 + 1));
                    }
                }
            }

            
        }


        public Tuple<int, int> Baslangic { get => baslangic; set => baslangic = value; }
        public Tuple<int, int> Bitis { get => bitis; set => bitis = value; }


    }
}
