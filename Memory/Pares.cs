using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    internal class Pares
    {
        public List<Imagenes> imagenes;
        public Pares()
        {
            imagenes = new List<Imagenes>()
            {
                new Imagenes(Image.FromFile("imgs/audiobook.png")),
                new Imagenes(Image.FromFile("imgs/book (1).png")),
                new Imagenes(Image.FromFile("imgs/book(2).png")),
                new Imagenes(Image.FromFile("imgs/book.png")),
                new Imagenes(Image.FromFile("imgs/bookmark.png")),
                new Imagenes(Image.FromFile("imgs/books (1).png")),
                new Imagenes(Image.FromFile("imgs/books.png")),
                new Imagenes(Image.FromFile("imgs/bookstore.png")),
                new Imagenes(Image.FromFile("imgs/download.png")),
                new Imagenes(Image.FromFile("imgs/education.png")),
                new Imagenes(Image.FromFile("imgs/glasses.png")),
                new Imagenes(Image.FromFile("imgs/love.png")),
                new Imagenes(Image.FromFile("imgs/pen.png")),
                new Imagenes(Image.FromFile("imgs/search.png")),
                new Imagenes(Image.FromFile("imgs/world-book-day (1).png")),
                new Imagenes(Image.FromFile("imgs/world-book-day (2).png")),
                new Imagenes(Image.FromFile("imgs/world-book-day.png")),
                new Imagenes(Image.FromFile("imgs/best-seller.png"))
            };
        }
    }
}