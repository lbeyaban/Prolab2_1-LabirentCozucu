using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Diagnostics;



namespace Prolab2_1
{
    class Robot : BaseRobot
    {
       
        private int totalKareSayisi = 0;

        public Robot(List<List<Button>> buttons , int[,] lastIzgara, Tuple<int,int> baslangic , Tuple<int,int> bitis)
        {
            this.Buttons= buttons;
            this.LastIzgara = lastIzgara;
            this.Baslangic = baslangic;
            this.Bitis = bitis;
            this.labirentiCoz();
        }

        

        public override void labirentiCoz()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Stack<Tuple<int, int>> yigin = new Stack<Tuple<int, int>>();
            //Karma verileri tutmak için liste çok benzer bir yapı.
            List<Tuple<int, int>> ziyaretEdilen = new List<Tuple<int, int>>();
            List<Tuple<int, int>> dfsPath = new List<Tuple<int, int>>();

            //stacağa başlangıc elemanını alıyoruz.
            yigin.Push(Baslangic);

            Buttons[Bitis.Item1][Bitis.Item2].BackColor = Color.Red;
            Buttons[Bitis.Item1][Bitis.Item2].Invoke((MethodInvoker)delegate
            {
                Buttons[Bitis.Item1][Bitis.Item2].Visible = true;
            });


            Buttons[Baslangic.Item1][Baslangic.Item2].BackColor = Color.Yellow;

            //Stackteki eleman bitene kadar devam ediyoruz.
            while (yigin.Count > 0)
            {
                //Stackin başından bir eleman alıyoruz.
                Tuple<int, int> a = yigin.Pop();

                //İlerlemeyi daha net görebilmek için threadi uyutuyoruz.
                Thread.Sleep(100);
                if (a.Item1 + 1 < Math.Sqrt(Buttons.Count) - 1 || a.Item1 - 1 > 0 || a.Item2 + 1 < Math.Sqrt(Buttons.Count) - 1 || a.Item2 - 1 > 0)
                {
                    Buttons[a.Item1][a.Item2].Invoke((MethodInvoker)delegate
                    {
                        Buttons[a.Item1][a.Item2].Visible = true;
                        Buttons[a.Item1 + 1][a.Item2].Visible = true;
                        Buttons[a.Item1 - 1][a.Item2].Visible = true;
                        Buttons[a.Item1 - 1][a.Item2 - 1].Visible = true;
                        Buttons[a.Item1 + 1][a.Item2 + 1].Visible = true;
                        Buttons[a.Item1][a.Item2 + 1].Visible = true;
                        Buttons[a.Item1][a.Item2 - 1].Visible = true;
                        Buttons[a.Item1 - 1][a.Item2 + 1].Visible = true;
                        Buttons[a.Item1 + 1][a.Item2 - 1].Visible = true;
                    });
                }
                else
                {
                    Buttons[a.Item1][a.Item2].Invoke((MethodInvoker)delegate
                    {
                        Buttons[a.Item1][a.Item2].Visible = true;
                        Buttons[a.Item1 + 1][a.Item2].Visible = true;
                        Buttons[a.Item1 - 1][a.Item2].Visible = true;
                        Buttons[a.Item1][a.Item2 + 1].Visible = true;
                        Buttons[a.Item1][a.Item2 - 1].Visible = true;
                    });
                }


                Buttons[a.Item1][a.Item2].BackColor = Color.Green;

                //Bitiş noktasına varmış mıyız kontrol ediyoruz.
                if (a.Item1 == Bitis.Item1 && a.Item2 == Bitis.Item2)
                {
                    stopwatch.Stop();
                    MessageBox.Show("Labirent Çıkışına Ulaşıldı. \nSüre ve kare bilgileri sol alt köşeye yazıldı...", "Tebrikler....");
                    break;
                }

                //Yığına eklediğimiz noktayı daha önceden ziyaret ettiysek direk geçiyoruz.
                if (ziyaretEdilen.Contains(a))
                {
                    Buttons[a.Item1][a.Item2].BackColor = Color.Blue;
                    continue;
                }
                ziyaretEdilen.Add(a);
                totalKareSayisi++;

                Console.WriteLine("Brom ben buyum : " + LastIzgara[a.Item1, a.Item2]);
               

                if (a.Item1 - 1 == Bitis.Item1 && a.Item2 == Bitis.Item2)
                {
                    Console.WriteLine("Girdim x");
                    yigin.Push(Tuple.Create((a.Item1 - 1), (a.Item2)));
                    continue;
                }

                if (a.Item1 + 1 == Bitis.Item1 && a.Item2 == Bitis.Item2)
                {
                    Console.WriteLine("Girdim x");
                    yigin.Push(Tuple.Create((a.Item1 + 1), (a.Item2)));
                    continue;
                }

                if (a.Item1 == Bitis.Item1 && a.Item2 - 1 == Bitis.Item2)
                {
                    Console.WriteLine("Girdim y");
                    yigin.Push(Tuple.Create((a.Item1), (a.Item2 - 1)));
                    continue;
                }

                if (a.Item1 == Bitis.Item1 && a.Item2 + 1 == Bitis.Item2)
                {
                    Console.WriteLine("Girdim y");
                    yigin.Push(Tuple.Create((a.Item1), (a.Item2 + 1)));
                    continue;
                }


                //Yukarıyı Kontrol ediyoruz eğer orada yol varsa yığına ekleyeceğiz.
                if (LastIzgara[a.Item1 - 1, a.Item2] == 0)
                {
                    yigin.Push(Tuple.Create((a.Item1 - 1), (a.Item2)));
                }

                //Sağ tarafı kontrol ediyoruz eğer orada yol var ise yığına ekleyeceğiniz.
                if (LastIzgara[a.Item1, a.Item2 + 1] == 0)
                {
                    yigin.Push(Tuple.Create((a.Item1), (a.Item2 + 1)));
                }

                //Aşağıyı kontrol ediyoruz eğer orada yol var ise yığına ekleyeceğiniz.
                if (LastIzgara[a.Item1 + 1, a.Item2] == 0)
                {
                    yigin.Push(Tuple.Create((a.Item1 + 1), (a.Item2)));
                }

                //Sol tarafı kontrol ediyoruz eğer orada yol var ise yığına ekleyeceğiniz.
                if(LastIzgara[a.Item1, a.Item2 - 1] == 0)
                {
                    yigin.Push(Tuple.Create((a.Item1), (a.Item2 - 1)));
                }


                Console.WriteLine(a.Item1 + " " + a.Item2);

                foreach (var item in yigin)
                {
                    Console.WriteLine("stack :" + item.Item1 + " " + item.Item2);
                }
            }

            Console.WriteLine("Gezilen total kare sayisi : " + totalKareSayisi);
            double sure = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine("Gecen sure : " + sure);
            Form1.lblGecenSure.Invoke((MethodInvoker)delegate
            {
                Form1.lblGecenSure.Text = sure.ToString() + " sn";
                Form1.lbltotalKare.Text = totalKareSayisi.ToString();
            });
    }

       
        public int TotalKareSayisi { get => totalKareSayisi; set => totalKareSayisi = value; }
    }
}
