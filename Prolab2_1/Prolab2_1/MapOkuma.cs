using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab2_1
{
    class MapOkuma
    {
        private string path;
        private int[,] engelHaritasi;

        public MapOkuma(string path)
        {
            this.Path = path;
            MapOkuma1();
        }

        public void MapOkuma1()
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            int uzunluk = lines.Length + 2;
            engelHaritasi = new int[uzunluk, uzunluk];
            for (int i = 0; i < uzunluk; i++)
            {
                for (int j = 0; j < uzunluk; j++)
                {
                    if (i == 0 || i == uzunluk - 1 || j == 0 || j == uzunluk - 1)
                        engelHaritasi[i, j] = 1;
                }
            }
            int a = 0, b = 0;
            for (int i = 1; i < uzunluk - 1; i++)
            {
                for (int j = 1; j < uzunluk - 1; j++)
                {
                    engelHaritasi[i, j] = lines[a][b] - '0';
                    b++;
                }
                b = 0;
                a++;
            }
        }

        public string Path { get => path; set => path = value; }
        public int[,] EngelHaritasi { get => engelHaritasi; set => engelHaritasi = value; }
    }
}
