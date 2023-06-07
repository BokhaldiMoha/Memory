using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class Imagenes
    {
        private Guid guid;
        private Image image;
        private bool acertado;

        public Imagenes(Image img)
        {
            guid = Guid.NewGuid();
            image = img;
            acertado = false;
        }
        public Imagenes(Image img, Guid _guid)
        {
            guid = _guid;
            image = img;
            acertado = false;
        }

        public Guid Guid { get => guid; set => guid = value; }
        public Image Image { get => image; set => image = value; }
        public bool Acertado { get => acertado; set => acertado = value; }
    }
}
