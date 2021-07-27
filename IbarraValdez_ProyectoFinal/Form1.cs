using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IbarraValdez_ProyectoFinal
{
    public partial class Form1 : Form
    {
        int mov = 50, contmar1 = 0, contmar2 = 0, contmar3 = 0, contmar4 = 0, disparo = 0, contbarrera1 = 0, contbarrera2 = 0, contbarrera3 = 0, contbarrera4 = 0, vida = 4, disparo1, disparo2, cont6, mayor, disparo3, disparo4, cont7, mayor2;
        bool fire = false, fire2 = false, fire3 = false, fire4 = false, fire5 = false, ka = false, kd = false, espera = false, vidmar1 = true, vidmar2 = true, vidmar3 = true, vidmar4 = true, dis1 = true, dis2 = true, dis3 = true, dis4 = true;
        Random rdn = new Random();
        Image[] mar = new Image[3];
        Image[] barrera = new Image[4];
        
        public Form1()
        {
            InitializeComponent();

            mar[0] = IbarraValdez_ProyectoFinal.Properties.Resources.mar1;
            mar[1] = IbarraValdez_ProyectoFinal.Properties.Resources.mar2;
            mar[2] = IbarraValdez_ProyectoFinal.Properties.Resources.explosion;

            barrera[0] = IbarraValdez_ProyectoFinal.Properties.Resources.barrera1;
            barrera[1] = IbarraValdez_ProyectoFinal.Properties.Resources.barrera2;
            barrera[2] = IbarraValdez_ProyectoFinal.Properties.Resources.barrera3;
            barrera[3] = IbarraValdez_ProyectoFinal.Properties.Resources.barrera3;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contgen.Start();
            alienmov.Start();
            aliendisp.Start();

        }

        private void contgen_Tick(object sender, EventArgs e)
        {
            if (fire == true)
            {
                rayo.Visible = true;
                rayo.Location = new Point(rayo.Location.X, rayo.Location.Y - 5);
            }

            if (fire2 == true)
            {
                laser1.Visible = true;
                laser1.Location = new Point(laser1.Location.X, laser1.Location.Y + 4);
            }

            if (fire3 == true)
            {
                laser2.Visible = true;
                laser2.Location = new Point(laser2.Location.X, laser2.Location.Y + 4);
            }

            if (fire4 == true)
            {
                laser3.Visible = true;
                laser3.Location = new Point(laser3.Location.X, laser3.Location.Y + 5);
            }

            if (fire5 == true)
            {
                laser4.Visible = true;
                laser4.Location = new Point(laser4.Location.X, laser4.Location.Y + 5);
            }

            if (ka == true && nave.Left > 0)
            {
                nave.Location = new Point(nave.Location.X - 5, nave.Location.Y);
            }

            if (kd == true && nave.Right < this.Width)
            {
                nave.Location = new Point(nave.Location.X + 5, nave.Location.Y);
            }

            if (laser1.Bounds.IntersectsWith(nave.Bounds))
            {
                vida--;
                fire2 = false;
                laser1.Visible = false;
                laser1.Location = new Point(855, 56);

            }

            if (laser2.Bounds.IntersectsWith(nave.Bounds))
            {
                vida--;
                fire3 = false;
                laser2.Visible = false;
                laser2.Location = new Point(855, 56);

            }

            if (laser3.Bounds.IntersectsWith(nave.Bounds))
            {
                vida--;
                fire4 = false;
                laser3.Visible = false;
                laser3.Location = new Point(855, 56);

            }

            if (laser4.Bounds.IntersectsWith(nave.Bounds))
            {
                vida--;
                fire5 = false;
                laser4.Visible = false;
                laser4.Location = new Point(855, 56);

            }

            switch (vida)
            {
                case 3:
                    pictureBox1.Visible = false;
                    break;
                case 2:
                    pictureBox2.Visible = false;
                    break;
                case 1:
                    pictureBox3.Visible = false;
                    break;
            }

            if (vida == 0 || marciano1.Bounds.IntersectsWith(panel1.Bounds)
                || marciano2.Bounds.IntersectsWith(panel1.Bounds) || marciano3.Bounds.IntersectsWith(panel1.Bounds)
                || marciano4.Bounds.IntersectsWith(panel1.Bounds))
            {
                contgen.Stop();
                Form4 f4 = new Form4();
                this.Hide();
                f4.Show();
            }
            
            if (rayo.Bounds.IntersectsWith(marciano1.Bounds))
            {
                vidmar1 = false;
                marciano1.Image = IbarraValdez_ProyectoFinal.Properties.Resources.explosion;
                fire = false;
                rayo.Visible = false;
                rayo.Location = new Point(845, 520);
            }

            if (rayo.Bounds.IntersectsWith(marciano2.Bounds))
            {
                vidmar2 = false;
                marciano2.Image = IbarraValdez_ProyectoFinal.Properties.Resources.explosion;
                fire = false;
                rayo.Visible = false;
                rayo.Location = new Point(845, 520);
            }

            if (rayo.Bounds.IntersectsWith(marciano3.Bounds))
            {
                vidmar3 = false;
                marciano3.Image = IbarraValdez_ProyectoFinal.Properties.Resources.explosion;
                fire = false;
                rayo.Visible = false;
                rayo.Location = new Point(845, 520);
            }

            if (rayo.Bounds.IntersectsWith(marciano4.Bounds))
            {
                vidmar4 = false;
                marciano4.Image = IbarraValdez_ProyectoFinal.Properties.Resources.explosion;
                fire = false;
                rayo.Visible = false;
                rayo.Location = new Point(845, 520);
            }
 

            if (vidmar1 == false && vidmar2 == false && vidmar3 == false && vidmar4 == false)
            {
                contgen.Stop();
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();

            }

            barrera1.Image = barrera[contbarrera1];

            if (contbarrera1 == 3)
            {
                barrera1.Location = new Point(1000, 1000);
                barrera1.Visible = false;
            }

            if (rayo.Bounds.IntersectsWith(barrera1.Bounds))
            {
                contbarrera1++;
                fire = false;
                rayo.Visible = false;
                rayo.Location = new Point(845, 720);
            }

            if (laser1.Bounds.IntersectsWith(barrera1.Bounds))
            {
                contbarrera1++;
                fire2 = false;
                laser1.Visible = false;
                laser1.Location = new Point(845, 720);
            }

            if (laser2.Bounds.IntersectsWith(barrera1.Bounds))
            {
                contbarrera1++;
                fire3 = false;
                laser2.Visible = false;
                laser2.Location = new Point(845, 720);
            }

            if (laser3.Bounds.IntersectsWith(barrera1.Bounds))
            {
                contbarrera1++;
                fire4 = false;
                laser3.Visible = false;
                laser3.Location = new Point(845, 720);
            }

            if (laser4.Bounds.IntersectsWith(barrera1.Bounds))
            {
                contbarrera1++;
                fire5 = false;
                laser4.Visible = false;
                laser4.Location = new Point(845, 720);
            }

            barrera2.Image = barrera[contbarrera2];

            if (contbarrera2 == 3)
            {
                barrera2.Location = new Point(1000, 1000);
                barrera2.Visible = false;
            }

            if (rayo.Bounds.IntersectsWith(barrera2.Bounds))
            {
                contbarrera2++;
                fire = false;
                rayo.Visible = false;
                rayo.Location = new Point(845, 720);
            }

            if (laser1.Bounds.IntersectsWith(barrera2.Bounds))
            {
                contbarrera2++;
                fire2 = false;
                laser1.Visible = false;
                laser1.Location = new Point(845, 720);
            }

            if (laser2.Bounds.IntersectsWith(barrera2.Bounds))
            {
                contbarrera2++;
                fire3 = false;
                laser2.Visible = false;
                laser2.Location = new Point(845, 720);
            }

            if (laser3.Bounds.IntersectsWith(barrera2.Bounds))
            {
                contbarrera2++;
                fire4 = false;
                laser3.Visible = false;
                laser3.Location = new Point(845, 720);
            }

            if (laser4.Bounds.IntersectsWith(barrera2.Bounds))
            {
                contbarrera2++;
                fire5 = false;
                laser4.Visible = false;
                laser4.Location = new Point(845, 720);
            }

            barrera3.Image = barrera[contbarrera3];

            if (contbarrera3 == 3)
            {
                barrera3.Location = new Point(1000, 1000);
                barrera3.Visible = false;
            }

            if (rayo.Bounds.IntersectsWith(barrera3.Bounds))
            {
                contbarrera3++;
                fire = false;
                rayo.Visible = false;
                rayo.Location = new Point(845, 720);
            }

            if (laser1.Bounds.IntersectsWith(barrera3.Bounds))
            {
                contbarrera3++;
                fire2 = false;
                laser1.Visible = false;
                laser1.Location = new Point(845, 720);
            }

            if (laser2.Bounds.IntersectsWith(barrera3.Bounds))
            {
                contbarrera3++;
                fire3 = false;
                laser2.Visible = false;
                laser2.Location = new Point(845, 720);
            }

            if (laser3.Bounds.IntersectsWith(barrera3.Bounds))
            {
                contbarrera3++;
                fire4 = false;
                laser3.Visible = false;
                laser3.Location = new Point(845, 720);
            }

            if (laser4.Bounds.IntersectsWith(barrera3.Bounds))
            {
                contbarrera3++;
                fire5 = false;
                laser4.Visible = false;
                laser4.Location = new Point(845, 720);
            }

            barrera4.Image = barrera[contbarrera4];

            if (contbarrera4 == 3)
            {
                barrera4.Location = new Point(1000, 1000);
                barrera4.Visible = false;
            }

            if (rayo.Bounds.IntersectsWith(barrera4.Bounds))
            {
                contbarrera4++;
                fire = false;
                rayo.Visible = false;
                rayo.Location = new Point(845, 520);
            }

            if (laser1.Bounds.IntersectsWith(barrera4.Bounds))
            {
                contbarrera4++;
                fire2 = false;
                laser1.Visible = false;
                laser1.Location = new Point(845, 720);
            }

            if (laser2.Bounds.IntersectsWith(barrera4.Bounds))
            {
                contbarrera4++;
                fire3 = false;
                laser2.Visible = false;
                laser2.Location = new Point(845, 720);
            }

            if (laser3.Bounds.IntersectsWith(barrera4.Bounds))
            {
                contbarrera4++;
                fire4 = false;
                laser3.Visible = false;
                laser3.Location = new Point(845, 720);
            }

            if (laser4.Bounds.IntersectsWith(barrera4.Bounds))
            {
                contbarrera4++;
                fire5 = false;
                laser4.Visible = false;
                laser4.Location = new Point(845, 720);
            }

        }

        private void alienmov_Tick(object sender, EventArgs e)
        {
            if (vidmar1 == true)
            {
                marciano1.Image = mar[contmar1];
                marciano1.Location = new Point(marciano1.Location.X + mov, marciano1.Location.Y);

                if (contmar1 == 1)
                {
                    contmar1 = -1;
                }
                contmar1++;

                if (marciano1.Left <= 0)
                {
                    alienmov.Stop();
                    bajada.Start();
                }

                if (marciano1.Right >= this.Width)
                {
                    alienmov.Stop();
                    bajada.Start();
                }

            }
            else
            {
                contmar1++;
                if (contmar1 == 2)
                {
                    marciano1.Visible = false;
                    marciano1.Location = new Point(1000, 700);
                }

            }

            if (vidmar2 == true)
            {
                marciano2.Image = mar[contmar2];
                marciano2.Location = new Point(marciano2.Location.X + mov, marciano2.Location.Y);

                if (contmar2 == 1)
                {
                    contmar2 = -1;
                }
                contmar2++;

                if (marciano2.Left <= 0)
                {
                    alienmov.Stop();
                    bajada.Start();
                }

                if (marciano2.Right >= this.Width)
                {
                    alienmov.Stop();
                    bajada.Start();
                }

            }
            else
            {
                contmar2++;
                if (contmar2 == 2)
                {
                    marciano2.Visible = false;
                    marciano2.Location = new Point(1000, 700);
                }

            }

            if (vidmar3 == true)
            {
                marciano3.Image = mar[contmar3];
                marciano3.Location = new Point(marciano3.Location.X + mov, marciano3.Location.Y);

                if (contmar3 == 1)
                {
                    contmar3 = -1;
                }
                contmar3++;

                if (marciano3.Left <= 0)
                {
                    alienmov.Stop();
                    bajada.Start();
                }

                if (marciano3.Right >= this.Width)
                {
                    alienmov.Stop();
                    bajada.Start();
                }

            }
            else
            {
                contmar3++;
                if (contmar3 == 2)
                {
                    marciano3.Visible = false;
                    marciano3.Location = new Point(1000, 700);
                }

            }

            

            if (vidmar4 == true)
            {
                marciano4.Image = mar[contmar4];
                marciano4.Location = new Point(marciano4.Location.X + mov, marciano4.Location.Y);

                if (contmar4 == 1)
                {
                    contmar4 = -1;
                }
                contmar4++;

                if (marciano4.Left <= 0)
                {
                    alienmov.Stop();
                    bajada.Start();
                }

                if (marciano4.Right >= this.Width)
                {
                    alienmov.Stop();
                    bajada.Start();
                }

            }
            else
            {
                contmar4++;
                if (contmar4 == 2)
                {
                    marciano4.Visible = false;
                    marciano4.Location = new Point(1000, 700);
                }

            }
   
        }

        private void bajada_Tick(object sender, EventArgs e)
        {
            if (vidmar1 == true)
            {
                marciano1.Location = new Point(marciano1.Location.X, marciano1.Location.Y + 50);
            }

            if (vidmar2 == true)
            {
                marciano2.Location = new Point(marciano2.Location.X, marciano2.Location.Y + 50);
            }

            if (vidmar3 == true)
            {
                marciano3.Location = new Point(marciano3.Location.X, marciano3.Location.Y + 50);
            }

            if (vidmar4 == true)
            {
                marciano4.Location = new Point(marciano4.Location.X, marciano4.Location.Y + 50);
            }

            mov = mov * -1;
            bajada.Stop();
            alienmov.Start();
        }

        private void espdis_Tick(object sender, EventArgs e)
        {
            disparo++;
            espera = true;

            if (disparo == 100)
            {
                disparo = 0;
                espdis.Stop();
                espera = false;
            }
        }

        private void aliendisp_Tick(object sender, EventArgs e)
        {
            cont6++;
            cont7++;

            if (dis1 == true)
            {
                disparo1 = rdn.Next(2, 6); 
                dis1 = false;
            }

            if (dis2 == true)
            {
                disparo2 = rdn.Next(2, 6); 
                dis2 = false;
            }

            if (disparo1 > disparo2)
            {
                mayor = disparo1 + 3;
            }
            else
            {
                mayor = disparo2 + 3;
            }

            if (cont6 == mayor)
            {
                dis1 = true;
                dis2 = true;
                cont6 = 0;
            }

            if (cont6 == disparo1 && vidmar2 == true)
            {
                laser1.Location = new Point(marciano2.Location.X + 25, marciano2.Location.Y + 50);
                fire2 = true;
            }

            if (cont6 == disparo2 && vidmar4 == true)
            {
                laser2.Location = new Point(marciano4.Location.X + 25, marciano4.Location.Y + 50);
                fire3 = true;
            }

            if (dis3 == true)
            {
                disparo3 = rdn.Next(6, 12);
                dis3 = false;
            }

            if (dis4 == true)
            {
                disparo4 = rdn.Next(6, 12); 
                dis4 = false;
            }

            if (disparo3 > disparo4)
            {
                mayor2 = disparo3 + 3;
            }
            else
            {
                mayor2 = disparo4 + 3;
            }

            if (cont7 == mayor2)
            {
                dis3 = true;
                dis4 = true;
                cont7 = 0;
            }

            if (cont7 == disparo3 && vidmar1 == true)
            {
                laser3.Location = new Point(marciano1.Location.X + 25, marciano1.Location.Y + 50);
                fire4 = true;

            }

            if (cont7 == disparo4 && vidmar3 == true)
            {
                laser4.Location = new Point(marciano3.Location.X + 25, marciano3.Location.Y + 50);
                fire5 = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                ka = true;
            }

            if (e.KeyCode == Keys.D)
            {
                kd = true;
            }

            if (e.KeyCode == Keys.S && espera == false)
            {
                fire = true;
                rayo.Location = new Point(nave.Location.X + 25, nave.Location.Y - 50);
                espdis.Start();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                ka = false;
            }

            if (e.KeyCode == Keys.D)
            {
                kd = false;
            }
        }


    }
}
