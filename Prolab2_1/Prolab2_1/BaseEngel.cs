using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab2_1
{
    abstract class BaseEngel
    {
        private int boyut;
        private int[,] engel;

        public int Boyut { get => boyut; set => boyut = value; }
        public int[,] Engel { get => engel; set => engel = value; }

        public abstract int[,] engelOlustur();

    }
}
