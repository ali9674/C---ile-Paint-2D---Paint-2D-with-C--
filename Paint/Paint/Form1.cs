using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        ColorDialog dlg = new ColorDialog();
        public Form1()
        {
            InitializeComponent();
        }

        
        bool state;
        int baslaX, baslaY;
        int kalinlik = 5;

       

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            state = false;

        }

        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {

            state = true;
            baslaX = e.X;
            baslaY = e.Y;

        }
        bool silgidurum;
        int silgiboyut;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            silgidurum = false;
            Graphics g = this.CreateGraphics();
            
            Pen p = new Pen(dlg.Color, kalinlik);
            Pen silgi = new Pen(Form1.DefaultBackColor, silgiboyut);
            Point p1 = new Point(baslaX, baslaY);
            Point p2 = new Point(e.X, e.Y);

            if (silgiToolStripMenuItem.Checked == true)
            {
                g.DrawLine(silgi, p1, p2);
                baslaX = e.X;
                baslaY = e.Y;
                silgidurum = true;  
            }






            if (state == true &&silgidurum==false)
            {
                g.DrawLine(p, p1, p2);
                baslaX = e.X;
                baslaY = e.Y;

            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kalinlik = int.Parse(comboBox1.Text);
        }

      

        private void temizleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Form1.DefaultBackColor);
        }

        private void silgiToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            object[] kalınlık = { "10", "20", "30", "40", "50", "60" };
            toolStripComboBox1.Items.AddRange(kalınlık);
            toolStripComboBox1.Text = "10";

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button2.BackColor = dlg.Color;

            silgiboyut = int.Parse(toolStripComboBox1.Text);    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dlg.ShowDialog();
        }
    }
}
