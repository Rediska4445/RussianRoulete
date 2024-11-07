using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parysov_ISP_223k___Russian_Roulete
{
    public partial class Form1 : Form
    {
        private bool urself;
        public static bool debug;
        public static int numberOfAmmo;
        public static int numberOfMaxAmmo;
        Revolver revolver;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
            revolver_image.Controls.Add(pictureBox1);
            pictureBox1.Location = new Point(150, 50);
            revolver = new Revolver(numberOfMaxAmmo);
            button2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            revolver_image.Image = Properties.Resources.standart;
            revolver.Scroll(new Random().Next(1, 10));
            SetDebug(label1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu frm = new Menu();
            Hide();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            revolver_image.Image = Properties.Resources.standart;
            revolver.Load();
            SetDebug(label1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool shoot = revolver.Shot();
            if (shoot == true && urself == true)
            {
                pictureBox1.Image = Properties.Resources.blood_smash1;
                Die();
            }
            else
            {
                Save("Тебе крупно повезло :/");
                if(shoot == true) 
                    pictureBox1.Image = Properties.Resources.gun_shoot1;
            }

            new Thread(() =>
            {
                Thread.Sleep(2500);
                pictureBox1.Image = null;
            }).Start();

            button2.Hide();
            button3.Show();
            SetDebug(label1);
        }

        public void Save(string text)
        {
            label2.Text = text;
        }

        public void Die()
        {
            var result = MessageBox.Show("В следующей жизни повезёт :)", "Form Closing",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);

            if(result == DialogResult.OK)
            {
                Menu frm = new Menu();
                Hide();
                frm.Show();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Text = "Текущий патрон: " + revolver.GetLoad()[0];
        }

        public void SetDebug(Label label1)
        {
            if(debug)
            {
                label1.Text = "";
                for (int i = 0; i < numberOfMaxAmmo; i++)
                {
                    label1.Text += i + " = " + revolver.GetLoad()[i] + "\n";
                }
            }
        }

        public void SetGun(string filePath)
        {
            revolver_image.Image = Image.FromFile(filePath); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button2.Text == "SHOT URSELF")
            {
                urself = false;
                button2.Text = "SHOT TO OPPONENT";
                revolver_image.Image = Properties.Resources.shotToVoid; // Properties.Resources.ImageName;
            }
            else
            {
                urself = true;
                button2.Text = "SHOT URSELF";
                revolver_image.Image = Properties.Resources.toUShot;
            }
            button3.Hide();
            button2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button2.Text = "SHOT URSELF";
        }

        private void revolver_image_Click(object sender, EventArgs e)
        {
           revolver.Scroll(3);
        }
    }

    class Revolver
    {
        int countShot;
        int[] load;
        public Revolver(int max)
        {
            load = new int[max];
            countShot = 0;
        }

        public int MoreAmmo()
        {
            int more = 0;
            for(int i = 0; i < load.Length; i++)
            {
                if (load[i] == 1) more =+ 1;
            }
            return more;
        }

        public void Scroll(int power)
        {
            for(int pow = 0; pow < power; pow++)
            {
                int temp = load[0];

                for (int i = 0; i < load.Length - 1; i++)
                    load[i] = load[i + 1];

                load[load.Length - 1] = temp;
            }
        }

        public int[] GetLoad()
        {
            return load;
        }

        public void Load()
        {
            for(int i = 0; i < load.Length; i++)
            {
                if (load[i] != 1)
                {
                    load[i] = 1;
                    break;
                }
            }
        }

        public bool Shot()
        {
            if (load[0] == 1) {
                Scroll(1);
                return true; 
            } else {
                Scroll(1);
                return false;
            }
        }
    }
}
