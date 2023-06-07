using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Memory
{
    public partial class Juego : Form
    {
        Pares pares;
        List<Imagenes> paresJuego;
        int numPares;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerCS = new System.Windows.Forms.Timer();
        String clicked;
        Byte contClicks = 0;
        Int16 pbsClicked = -1;
        List<Int16> pbsClickeds = new List<Int16>();
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        bool terminado = false;

        public Juego(int pars)
        {
            pares = new Pares();
            Functions.Shuffle(pares.imagenes);
            InitializeComponent();
            numPares = pars;
            paresJuego = CrearPares(numPares);
            Functions.Shuffle(paresJuego);

            timer.Interval = 3000;
            timer.Tick += (s, ev) =>
            {
                foreach (var c in Controls)
                {
                    if (c is PictureBox)
                    {
                        PictureBox pic = (PictureBox)c;
                        pic.Image = Image.FromFile("imgs/csharp.png");
                    }
                }
                timer.Stop();
            };
            timer.Start();
            CrearPictureBox(numPares, paresJuego);
        }
        private List<Imagenes> CrearPares(int num)
        {
            List<Imagenes> result = new List<Imagenes>();
            for (int i = 0; i < num; i++)
            {
                result.Add(new Imagenes(pares.imagenes[i].Image, pares.imagenes[i].Guid));
                result.Add(result[result.Count - 1]);
            }
            return result;
        }
        private void CrearPictureBox(int num, List<Imagenes> imgs)
        {
            this.Size = new Size(0, 0);
            int x = 20;
            int y = 20;
            for (int i = 0; i < num * 2; i++)
            {
                PictureBox pb = new PictureBox();
                pb.Image = imgs[i].Image;
                pb.Location = new Point(x, y);
                x += 150;
                if ((i + 1) % 6 == 0)
                {
                    y += 150;
                    x = 20;
                }
                var tags = new { Guid = imgs[i].Guid, Num = i };

                pb.Tag = tags;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Size = new Size(130, 130);
                pb.Click += new EventHandler(PictureBox_Click);
                Controls.Add(pb);
                pictureBoxes.Add(pb);
            }
            this.AutoSize = true;
            this.Width = this.Width + 20;
            this.Height = this.Height + 20;
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            var tags = (dynamic)p.Tag;
            p.Image = pares.imagenes.FirstOrDefault(pares => pares.Guid == tags.Guid).Image;
            if (contClicks == 0)
            {
                pbsClicked = Convert.ToInt16(tags.Num);
                clicked = tags.Guid.ToString();
                contClicks++;
            }
            else if (contClicks == 1)
            {
                if (clicked == tags.Guid.ToString() && pbsClicked != Convert.ToInt16(tags.Num))
                {
                    foreach (Imagenes img in paresJuego.Where(x => x.Guid == tags.Guid))
                    {
                        img.Acertado = true;
                        pbsClickeds.Add(pbsClicked);
                        pbsClickeds.Add(Convert.ToInt16(tags.Num));

                        if (terminado) return;
                        foreach (Imagenes pj in paresJuego)
                        {
                            if (!pj.Acertado)
                            {
                                terminado = false;
                                break;
                            }
                            else
                            {
                                terminado = true;
                            }
                        }
                        if (terminado)
                        {
                            paresJuego[0].Acertado = false;
                            MessageBox.Show("Felicidades! Has ganado.");
                            this.Hide();
                            Nivel nivel = (Nivel)Application.OpenForms["Nivel"];
                            if (nivel == null) nivel = new Nivel();
                            nivel.Show();
                        }
                    }
                }
                else
                {
                    this.Enabled = false;
                    timerCS.Interval = 1000;
                    timerCS.Tick += (s, ev) =>
                    {
                        foreach (PictureBox pb in pictureBoxes)
                        {
                            pb.Image = Image.FromFile("imgs/csharp.png");
                        }
                        foreach (Int16 i in pbsClickeds)
                        {
                            var tagsF = (dynamic)pictureBoxes[i].Tag;
                            pictureBoxes[i].Image = pares.imagenes.FirstOrDefault(x => x.Guid == tagsF.Guid).Image;
                        }
                        this.Enabled = true;
                        timerCS.Stop();
                    };
                    timerCS.Start();
                }
                contClicks = 0;
                clicked = "";
            }
        }
        private void Juego_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Nivel nivel = (Nivel)Application.OpenForms["Nivel"];
            if (nivel == null) nivel = new Nivel();
            nivel.Show();
        }
    }
}
