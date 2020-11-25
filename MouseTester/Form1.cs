#define KEY
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
        public Form1()
        {
            InitializeComponent();
        }


        private void mouseMove(object sender, MouseEventArgs e)
        {
            if(sender is Button) { 
                this.Text = "X: " + (e.X+((Button)sender).Location.X)+ "  Y: " + (e.Y+((Button)sender).Location.Y);
            }
            else
            {
                this.Text = "X: " + e.X + "  Y: " + e.Y;
            }
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Text = "Mouse Tester";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = Color.Green;
            }else if(e.Button == MouseButtons.Right)
            {
                button2.BackColor = Color.Aqua;
            }else if(e.Button == MouseButtons.Middle)
            {
                button1.BackColor = Color.Green;
                button2.BackColor = Color.Aqua;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left )
            {
                button1.BackColor = button1.BackColor = default;
            } 
            if(e.Button == MouseButtons.Right)
            {
                button2.BackColor = button2.BackColor = default;
            }
            if(e.Button == MouseButtons.Middle)
            {
                button1.BackColor = button1.BackColor = default;
                button2.BackColor = button2.BackColor = default;
            }

        }

#if KEYS 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Text = "Mouse Tester";
            }
            else
            {
                this.Text =  e.KeyCode.ToString();
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
    }
}
