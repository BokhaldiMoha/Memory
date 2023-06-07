using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class Nivel : Form
    {
        public Nivel()
        {
            InitializeComponent();
            this.Size = new Size(0, 0);
            int x = 20;
            int y = 20;
            int cont = 0;
            for (int i = 3; i <= 18; i += 3)
            {
                Button btn = new Button();
                btn.Text = i.ToString();
                btn.Size = new Size(100, 60);
                btn.Location = new Point(x, y);
                x += 120;
                cont++;

                if (cont % 3 == 0)
                {
                    y += 75;
                    x = 20;
                }
                btn.Click += new EventHandler(btn_Click);

                Controls.Add(btn);
            }
            this.AutoSize = true;
            this.Width = this.Width + 20;
            this.Height = this.Height + 20;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Juego juego = new Juego(int.Parse(((Button)sender).Text));
            this.Hide();
            juego.Show();
        }
        private void Nivel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
