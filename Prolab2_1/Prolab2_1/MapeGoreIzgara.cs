using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Prolab2_1
{
    class MapeGoreIzgara : BaseIzgara
    {

        public MapeGoreIzgara(string path)
        {
            this.Path = path;
        }


        public override List<List<Button>> generateIzgara()
        {
            MapOkuma mp = new MapOkuma(Path);
            this.LastIzgara = mp.EngelHaritasi;
            for (int i = 0; i < Math.Sqrt(LastIzgara.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(LastIzgara.Length); j++)
                {
                    Console.Write(LastIzgara[i, j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < Math.Sqrt(LastIzgara.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(LastIzgara.Length); j++)
                {
                    //Mapte verilen alanlara rastgele engelleri yerleştireceğim 3x3
                    if (LastIzgara[i, j] == 3)
                    {
                        int[,] temp = new int[3, 3];
                        int sayac = 0, sayac2 = 0;
                        for (int k = 0; k < 3; k++)
                        {
                            for (int a = 0; a < 3; a++)
                            {
                                temp[k, a] = LastIzgara[i + sayac2, j + sayac];
                                LastIzgara[i + sayac2, j + sayac] = 1;
                                sayac++;
                            }
                            sayac2++;
                            sayac = 0;
                        }

                        _3x3Engel rastgeleAlan = new _3x3Engel();
                        System.Threading.Thread.Sleep(100);
                        temp = rastgeleAlan.engelOlustur();
                        int sayac3 = 0, sayac4 = 0;
                        for (int k = 0; k < 3; k++)
                        {
                            for (int a = 0; a < 3; a++)
                            {
                                LastIzgara[i + sayac4, j + sayac3] = temp[k, a];
                                sayac3++;
                            }
                            sayac4++;
                            sayac3 = 0;
                        }
                    }
                    //3x3 lük alanlar için engel atamanın son noktası

                    //Şimdi 2x2 lik alanları yerleştirme
                    if (LastIzgara[i, j] == 2)
                    {
                        int[,] temp = new int[2, 2];
                        int sayac = 0, sayac2 = 0;
                        for (int k = 0; k < 2; k++)
                        {
                            for (int a = 0; a < 2; a++)
                            {
                                temp[k, a] = LastIzgara[i + sayac2, j + sayac];
                                LastIzgara[i + sayac2, j + sayac] = 1;
                                sayac++;
                            }
                            sayac2++;
                            sayac = 0;
                        }

                        _2x2Engel rastgeleEngel = new _2x2Engel();
                        System.Threading.Thread.Sleep(100);
                        temp = rastgeleEngel.engelOlustur();
                        int sayac3 = 0, sayac4 = 0;
                        for (int k = 0; k < 2; k++)
                        {
                            for (int a = 0; a < 2; a++)
                            {
                                LastIzgara[i + sayac4, j + sayac3] = temp[k, a];
                                sayac3++;
                            }
                            sayac4++;
                            sayac3 = 0;
                        }
                    }
                }
            }
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
                        Buttons[last][last2].BackgroundImage = Wall;
                        Buttons[last][last2].Location = new Point(x, y);
                    }
                    x += 30;
                }
                x = 200;
                y += 30;
            }
            return Buttons;
        }

        

    }
}
