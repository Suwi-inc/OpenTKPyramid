using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PyramidLabThree
{
    public partial class Form1 : Form
    {
        private int Height { get; set; }
        private int Width { get; set; }
        private int Depth { get; set; }
        private int Sides { get; set; }

        private string lightSource { get; set; }    

        Pyramid pyramid;

        //added to git v2
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

        }

        private void Render_Click(object sender, EventArgs e)
        {
            try
            {
                Height = int.Parse(textBox1.Text);
                Width = int.Parse(textBox3.Text);
                Depth = int.Parse(textBox2.Text);
                Sides = int.Parse(textBox4.Text);
                lightSource = comboBox1.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fields Must contain Integer Type Values ");    
            };

            render();




        }

        private void render()
        {
            pyramid = new Pyramid(Height, Width, "Pyramid");
            pyramid.setLightSource(lightSource);
            pyramid.setSides(Sides);
            pyramid.Run(1.0 / 60.0);
           
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            pyramid.Exit(); 
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pyramid.rotateXaxis();

        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            pyramid.rotateYaxis();

        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            pyramid.rotateZaxis();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
