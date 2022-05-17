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
        private int _Height { get; set; }
        private int _Width { get; set; }
        private int _Veiwdepth { get; set; }
        private int Sides { get; set; }
        private string transparent { get; set; }
        private string lightSource { get; set; }
        private string spin { get; set; }
        private double Pheight { get; set; }
        private double Pwidth { get; set; }
        private double Pdepth { get; set; }


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
                _Height = int.Parse(textBox1.Text);
                _Width = int.Parse(textBox3.Text);
                _Veiwdepth = int.Parse(textBox2.Text);
                Sides = int.Parse(comboBox3.Text);
                lightSource = comboBox1.Text;
                transparent = comboBox2.Text;
                Pheight = double.Parse(textBox5.Text);
                Pwidth = double.Parse(textBox6.Text);
                Pdepth = double.Parse(textBox7.Text);
                spin = comboBox4.Text;

                render();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fields Must contain Integer Type Values ");    
            };

          
        }

        private void render()
        {
            pyramid = new Pyramid(_Height, _Width, "Pyramid");
            pyramid.setLightSource(lightSource);
            pyramid.setSides(Sides);
            pyramid.setViewDepth(_Veiwdepth);
            pyramid.setTransparency(transparent);
            pyramid.setShapeSizes(Pheight, Pwidth, Pdepth);
            pyramid.setSpin(spin);
            pyramid.Run(1.0 / 60.0);  //refresh every 60 seconds
           
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
