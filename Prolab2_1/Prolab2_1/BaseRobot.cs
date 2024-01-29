using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prolab2_1
{
    abstract class BaseRobot
    {
        private Tuple<int, int> baslangic, bitis;
        private List<List<Button>> buttons = new List<List<Button>>();
        private int[,] lastIzgara;
        private int totalKareSayisi = 0;



        public abstract void labirentiCoz();



        public Tuple<int, int> Baslangic { get => baslangic; set => baslangic = value; }
        public Tuple<int, int> Bitis { get => bitis; set => bitis = value; }
        public List<List<Button>> Buttons { get => buttons; set => buttons = value; }
        public int[,] LastIzgara { get => lastIzgara; set => lastIzgara = value; }
        public int TotalKareSayisi { get => totalKareSayisi; set => totalKareSayisi = value; }
    }
}
