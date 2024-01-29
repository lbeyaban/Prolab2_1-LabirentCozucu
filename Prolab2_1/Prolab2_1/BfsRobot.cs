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
    class BfsRobot : BaseRobot
    {
        //private int[,] labirent;
        //private List<List<Button>> engeller = new List<List<Button>>();
        //private Tuple<int, int> baslangic, bitis;
        private int totalKareSayisi = 0;

        public BfsRobot(List<List<Button>> buttons, int[,] lastIzgara, Tuple<int, int> baslangic, Tuple<int, int> bitis)
        {
            this.LastIzgara = lastIzgara;
            this.Buttons = buttons;
            this.Baslangic = baslangic;
            this.Bitis = bitis;
            labirentiCoz();
        }


        public override void labirentiCoz()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int x1 = Baslangic.Item1;
            int y1 = Baslangic.Item2;
            int x2 = Bitis.Item1;
            int y2 = Bitis.Item2;

            Queue<Tuple<int, int, int>> kuyruk = new Queue<Tuple<int, int, int>>();
            Tuple<int, int, int> newPoint = Tuple.Create(x1, y1, -1);
            List<Tuple<int, int, int>> path = new List<Tuple<int, int, int>>();
            List<Tuple<int, int>> realPath = new List<Tuple<int, int>>();

            kuyruk.Enqueue(newPoint);
            LastIzgara[x1, y1] = 2;

            while (kuyruk.Count > 0)
            {
                Tuple<int, int, int> currNode = kuyruk.Dequeue();
                totalKareSayisi++;
                if (currNode.Item1 + 1 < Math.Sqrt(Buttons.Count) - 1 || currNode.Item1 - 1 > 0 || currNode.Item2 + 1 < Math.Sqrt(Buttons.Count) - 1 || currNode.Item2 - 1 > 0)
                {
                    Buttons[currNode.Item1][currNode.Item2].Invoke((MethodInvoker)delegate
                    {
                        Buttons[currNode.Item1][currNode.Item2].Visible = true;
                        Buttons[currNode.Item1 + 1][currNode.Item2].Visible = true;
                        Buttons[currNode.Item1 - 1][currNode.Item2].Visible = true;
                        Buttons[currNode.Item1 - 1][currNode.Item2 - 1].Visible = true;
                        Buttons[currNode.Item1 + 1][currNode.Item2 + 1].Visible = true;
                        Buttons[currNode.Item1][currNode.Item2 + 1].Visible = true;
                        Buttons[currNode.Item1][currNode.Item2 - 1].Visible = true;
                        Buttons[currNode.Item1 - 1][currNode.Item2 + 1].Visible = true;
                        Buttons[currNode.Item1 + 1][currNode.Item2 - 1].Visible = true;
                    });
                }
                else
                {
                    Buttons[currNode.Item1][currNode.Item2].Invoke((MethodInvoker)delegate
                    {
                        Buttons[currNode.Item1][currNode.Item2].Visible = true;
                        Buttons[currNode.Item1 + 1][currNode.Item2].Visible = true;
                        Buttons[currNode.Item1 - 1][currNode.Item2].Visible = true;
                        Buttons[currNode.Item1][currNode.Item2 + 1].Visible = true;
                        Buttons[currNode.Item1][currNode.Item2 - 1].Visible = true;
                    });
                }

                path.Add(currNode);
                Buttons[currNode.Item1][currNode.Item2].BackColor = Color.Green;
                Thread.Sleep(100);
                if (currNode.Item1 == x2 && currNode.Item2 == y2)
                {
                    stopwatch.Stop();
                    Console.WriteLine("girdim...");
                    realPath.Add(new Tuple<int, int>(path[path.Count - 1].Item1, path[path.Count - 1].Item2));
                    int i = path[path.Count - 1].Item3;
                    while (i >= 0)
                    {
                        Tuple<int, int, int> node = path[i];
                        realPath.Add(new Tuple<int, int>(node.Item1, node.Item2));
                        i = node.Item3;
                    }
                    realPath.Reverse();
                    foreach (var item in realPath)
                    {
                        Console.WriteLine(item.Item1 + "-" + item.Item2);
                        Buttons[item.Item1][item.Item2].BackColor = Color.Gold;
                    }
                    MessageBox.Show("Bitiş noktasına ulaşıldı...");
                    break;
                }

                if (LastIzgara[currNode.Item1 + 1, currNode.Item2] == 0)
                {
                    int count = path.Count - 1;
                    kuyruk.Enqueue(new Tuple<int, int, int>(currNode.Item1 + 1, currNode.Item2, path.Count - 1));
                    LastIzgara[currNode.Item1 + 1, currNode.Item2] = 2;
                }

                if (LastIzgara[currNode.Item1 - 1, currNode.Item2] == 0)
                {
                    int count = path.Count - 1;
                    kuyruk.Enqueue(new Tuple<int, int, int>(currNode.Item1 - 1, currNode.Item2, path.Count - 1));
                    LastIzgara[currNode.Item1 - 1, currNode.Item2] = 2;
                }

                if (LastIzgara[currNode.Item1, currNode.Item2 - 1] == 0)
                {
                    int count = path.Count - 1;
                    kuyruk.Enqueue(new Tuple<int, int, int>(currNode.Item1, currNode.Item2 - 1, path.Count - 1));
                    LastIzgara[currNode.Item1, currNode.Item2 - 1] = 2;
                }

                if (LastIzgara[currNode.Item1, currNode.Item2 + 1] == 0)
                {
                    int count = path.Count - 1;
                    kuyruk.Enqueue(new Tuple<int, int, int>(currNode.Item1, currNode.Item2 + 1, path.Count - 1));
                    LastIzgara[currNode.Item1, currNode.Item2 + 1] = 2;
                }

                else
                {
                    Console.WriteLine("Sonuca ulaşılamadı....");
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

        
    }
}
