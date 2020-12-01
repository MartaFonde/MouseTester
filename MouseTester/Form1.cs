#define KEYS
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseTester
{
    public partial class Form1 : Form
    {
        static string titulo;
        static Color btnDefault;
        public Form1()
        {
            InitializeComponent();
#if KEYS
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
#else
            
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
#endif
            titulo = this.Text;
            btnDefault = button1.BackColor;
        }


        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                this.Text = "X: " + (e.X + ((Button)sender).Location.X) + "  Y: " + (e.Y + ((Button)sender).Location.Y);
            }
            else
            {
                this.Text = "X: " + e.X + "  Y: " + e.Y;
            }
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Text = titulo;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = (Color)button1.Tag;
            }
            else if (e.Button == MouseButtons.Right)
            {
                button2.BackColor = (Color)button2.Tag;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                button1.BackColor = (Color)button1.Tag;
                button2.BackColor = (Color)button2.Tag;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = btnDefault;
            }
            if (e.Button == MouseButtons.Right)
            {
                button2.BackColor = btnDefault;
            }
            if (e.Button == MouseButtons.Middle)
            {
                button1.BackColor = btnDefault;
                button2.BackColor = btnDefault;
            }
        }

#if KEYS 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Text = titulo;
            }
            else
            {
                this.Text = e.KeyCode.ToString();
            }
        }

#else

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Text = e.KeyChar.ToString();
        }
#endif

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Deseas salir?", "Mouse Tester", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = ((Button)sender).BackColor == (Color)((Button)sender).Tag ? btnDefault :
                                                            ((Button)sender).BackColor = (Color)((Button)sender).Tag;
        }
    }
}
