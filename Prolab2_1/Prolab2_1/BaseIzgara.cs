using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Prolab2_1
{
    abstract class BaseIzgara
    {
        private string path;
        private int boyut;
        private List<List<Button>> buttons = new List<List<Button>>();
        private int[,] lastIzgara;



        private Image wall;

        public BaseIzgara()
        {
            string uygulamaDizini = AppDomain.CurrentDomain.BaseDirectory;
            string modifiedString = uygulamaDizini.Substring(0, uygulamaDizini.Length - 10);
            modifiedString += "\\img\\111.jpg";
            Wall = Image.FromFile(modifiedString);
        }

        public abstract List<List<Button>> generateIzgara();


        public string Path { get => path; set => path = value; }
        public int Boyut { get => boyut; set => boyut = value; }
        public List<List<Button>> Buttons { get => buttons; set => buttons = value; }
        public int[,] LastIzgara { get => lastIzgara; set => lastIzgara = value; }
        public Image Wall { get => wall; set => wall = value; }
    }
}
