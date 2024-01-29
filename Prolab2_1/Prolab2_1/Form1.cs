using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Prolab2_1
{
    public partial class Form1 : Form
    {
        private string path;
        private List<List<Button>> buttons = new List<List<Button>>();
        private int[,] lastIzgara;
        private int timer = 0;
        public static Label lblGecenSure = new Label();
        public static Label lbltotalKare = new Label();


        public Form1()
        {
            lblGecenSure.Location = new System.Drawing.Point(80, 446);
            lblGecenSure.Text = "";
            this.Controls.Add(lblGecenSure);
            lbltotalKare.Location = new System.Drawing.Point(80, 476);
            lbltotalKare.Text = "";
            this.Controls.Add(lbltotalKare);
            InitializeComponent();
        }

     

        //Bize verilen text dosyasını seçmek içi
        private void loadMazebtn_Click(object sender, EventArgs e)
        {

            try
            {
                using (OpenFileDialog openFile = new OpenFileDialog())
                {
                    openFile.Title = "Open Image";
                    openFile.Filter = "All Files (*.*)|*.txt*";

                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        path = openFile.FileName;
                    }
                }

                if (Buttons.Count != 0)
                {
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        for (int j = 0; j < Buttons.Count; j++)
                        {
                            this.Controls.Remove(Buttons[i][j]);
                        }
                    }
                }

                MapeGoreIzgara mp = new MapeGoreIzgara(path);
                Buttons = mp.generateIzgara();
                LastIzgara = mp.LastIzgara;

                Console.WriteLine("Button dolu mu? " + Buttons.Count);

                
                Console.WriteLine("Engellerin count : " + Buttons.Count);

                for (int i = 0; i < buttons.Count; i++)
                {
                    for (int j = 0; j < buttons.Count; j++)
                    {
                        this.Controls.Add(buttons[i][j]);
                    }
                }
                Console.WriteLine("controls count : " + this.Controls.Count);
            }
            catch (Exception)
            {
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void task1btn_Click(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random();
                int max = Convert.ToInt16(Math.Sqrt(lastIzgara.Length)) - 1;
                int baslangicX = rnd.Next(1, max);
                int baslangicY = rnd.Next(1, max);
                int bitisX = rnd.Next(1, max);
                int bitisY = rnd.Next(1, max);
                while (LastIzgara[baslangicX, baslangicY] == 1 || LastIzgara[bitisX, bitisY] == 1 || (bitisX == baslangicX && baslangicY == bitisY))
                {
                    baslangicX = rnd.Next(1, max);
                    baslangicY = rnd.Next(1, max);
                    bitisX = rnd.Next(1, max);
                    bitisY = rnd.Next(1, max);
                }
                if(dfsradioButton.Checked == true)
                {
                    Tuple<int, int> baslangic = Tuple.Create(baslangicX, baslangicY);
                    Tuple<int, int> bitis = Tuple.Create(bitisX, bitisY);
                    ThreadStart start = delegate { Robot rbt = new Robot(Buttons, LastIzgara, baslangic, bitis); };
                    new Thread(start).Start();
                }
                else if(bfsradioButton.Checked == true)
                {
                    Tuple<int, int> baslangic = Tuple.Create(baslangicX, baslangicY);
                    Tuple<int, int> bitis = Tuple.Create(bitisX, bitisY);
                    ThreadStart start = delegate {BfsRobot bfsRobot = new BfsRobot(Buttons, LastIzgara, baslangic, bitis); };
                    new Thread(start).Start();
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Labirenti seçip yüklemeden çözmeye çalışmayın..." , "Uyarı!!!");
            }
            
        }


        public string Path { get => path; set => path = value; }
        public List<List<Button>> Buttons { get => buttons; set => buttons = value; }
        public int[,] LastIzgara { get => lastIzgara; set => lastIzgara = value; }
        public int Timer { get => timer; set => timer = value; }
        public Tuple<int, int> BaslangicNoktası { get => baslangicNoktası; set => baslangicNoktası = value; }
        public Tuple<int, int> BitisNoktasi { get => bitisNoktasi; set => bitisNoktasi = value; }

        private Tuple<int, int> baslangicNoktası, bitisNoktasi;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string uygulamaDizini = Environment.CurrentDirectory;
                string dosyaAdi = "111.jpg";
                // Tam dosya yolu
                Console.WriteLine("Uygulama dizini : " + uygulamaDizini);
                //int boyut = Convert.ToInt16(boyuttxt.Text);
                int boyut = 10;
                Console.WriteLine("Boyut : " + boyut);
                List<Tuple<int, int>> baslangicNoktalari = new List<Tuple<int, int>>();
                Tuple<int, int> solustKose = Tuple.Create(0, 0);
                Tuple<int, int> sagustKose = Tuple.Create(0, boyut - 1);
                Tuple<int, int> solaltKose = Tuple.Create(boyut - 1, 0);
                Tuple<int, int> sagaltKose = Tuple.Create(boyut - 1, boyut - 1);
                baslangicNoktalari.Add(solustKose);
                baslangicNoktalari.Add(sagustKose);
                baslangicNoktalari.Add(solaltKose);
                baslangicNoktalari.Add(sagaltKose);
                Random rnd = new Random();
                baslangicNoktası = Tuple.Create(baslangicNoktalari[rnd.Next(0, 4)].Item1, baslangicNoktalari[rnd.Next(0, 4)].Item2);
                if (baslangicNoktası.Item1 == solustKose.Item1 && baslangicNoktası.Item2 == solustKose.Item2)
                    bitisNoktasi = sagaltKose;
                else if (baslangicNoktası.Item1 == sagustKose.Item1 && baslangicNoktası.Item2 == sagustKose.Item2)
                    bitisNoktasi = solaltKose;
                else if (baslangicNoktası.Item1 == solaltKose.Item1 && baslangicNoktası.Item2 == solaltKose.Item2)
                    bitisNoktasi = sagustKose;
                else
                    bitisNoktasi = solustKose;

                Console.WriteLine("baslangic noktasi : " + baslangicNoktası.Item1 + "," + baslangicNoktası.Item2);
                Console.WriteLine("bitis noktasi : " + bitisNoktasi.Item1 + "," + bitisNoktasi.Item2);

                RandomIzgara rndIzgara = new RandomIzgara(boyut, baslangicNoktası, bitisNoktasi);
                if (buttons.Count != 0)
                {
                    Console.WriteLine("Button sayisi : " + buttons.Count);
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        for (int j = 0; j < buttons.Count; j++)
                        {
                            this.Controls.Remove(Buttons[i][j]);
                        }
                    }
                    Buttons = rndIzgara.generateIzgara();
                    LastIzgara = rndIzgara.LastIzgara;

                    Console.WriteLine("Engellerin count : " + buttons.Count);

                    for (int i = 0; i < buttons.Count; i++)
                    {
                        for (int j = 0; j < buttons.Count; j++)
                        {
                            this.Controls.Add(buttons[i][j]);
                        }
                    }
                    Console.WriteLine("controls count : " + this.Controls.Count);
                }
                else
                {
                    Buttons = rndIzgara.generateIzgara();
                    LastIzgara = rndIzgara.LastIzgara;
                    if (buttons.Count != 0)
                    {
                        for (int i = 0; i < buttons.Count; i++)
                        {
                            for (int j = 0; j < buttons.Count; j++)
                            {
                                this.Controls.Remove(buttons[i][j]);
                            }
                        }
                    }
                    Console.WriteLine("Engellerin count : " + buttons.Count);

                    for (int i = 0; i < buttons.Count; i++)
                    {
                        for (int j = 0; j < buttons.Count; j++)
                        {
                            this.Controls.Add(buttons[i][j]);
                        }
                    }
                    Console.WriteLine("controls count : " + this.Controls.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Boyut bilgilerini yazmayı unutmayın..." , "Uyarı!!");
                Console.WriteLine("Hata Mesajı" + ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(buttons.Count != 0)
            {
                if (dfsradioButton2.Checked == true)
                {

                    BaslangicNoktası = Tuple.Create(BaslangicNoktası.Item1 + 1, BaslangicNoktası.Item2 + 1);
                    BitisNoktasi = Tuple.Create(BitisNoktasi.Item1 + 1, BitisNoktasi.Item2 + 1);

                    ThreadStart start = delegate {
                        Robot rbt = new Robot(Buttons, LastIzgara, BaslangicNoktası, BitisNoktasi);
                    };
                    Thread a = new Thread(start);
                    a.Start();
                }
                else if (bfsradioButton2.Checked == true)
                {
                    BaslangicNoktası = Tuple.Create(BaslangicNoktası.Item1 + 1, BaslangicNoktası.Item2 + 1);
                    BitisNoktasi = Tuple.Create(BitisNoktasi.Item1 + 1, BitisNoktasi.Item2 + 1);

                    ThreadStart start = delegate {
                        BfsRobot bfsRbt = new BfsRobot(Buttons, LastIzgara, BaslangicNoktası, BitisNoktasi);
                    };
                    Thread a = new Thread(start);
                    a.Start();
                }
            }



        }

        
    }
}
