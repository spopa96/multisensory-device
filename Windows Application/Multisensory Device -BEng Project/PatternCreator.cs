using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PatternCreator : Form
    {
        public PatternCreator()
        {   
            InitializeComponent();
        }

        Color bcolor = new Color();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        
            switch (comboBox1.SelectedIndex)
            {
                case 0: bcolor = Color.Black; break;
                case 1: bcolor = Color.White; break;
                case 2: bcolor = Color.Red; break;
                case 3: bcolor = Color.Green; break;
                case 4: bcolor = Color.Blue; break;
                case 5: bcolor = Color.PeachPuff; break;
                case 6: bcolor = Color.Yellow; break;
                case 7: bcolor = Color.LightBlue; break;
                case 8: bcolor = Color.Gray; break;
                case 9: bcolor = Color.Brown; break;
                case 10: bcolor = Color.Purple; break;
                case 11: bcolor = Color.DarkGreen; break;
                case 12: bcolor = Color.Pink; break;
                case 13: bcolor = Color.Orange; break;
                    
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.WhiteSmoke)     //if button has initial colour
            {
                button1.BackColor = bcolor;          //change colour to selected colour
                textBox1.AppendText("\tmatrix.drawPixel(0, 0," + comboBox1.SelectedItem.ToString() + ");\r\n");  //add "matrix.drawPixel(0,0,selected_colour);" to text box
            }
            else     //if colour has been changed before
            {
                button1.BackColor = Color.WhiteSmoke;     //revert button to the initial colour
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("0, 0,")).ToArray();   //delete the line which turns on the pixel at (0, 0)
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.WhiteSmoke)
            {
                button2.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(0, 1," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button2.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("0, 1,")).ToArray();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.WhiteSmoke)
            {
                button3.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(0, 2," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button3.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("0, 2,")).ToArray();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.WhiteSmoke)
            {
                button4.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(0, 3," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button4.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("0, 3,")).ToArray();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.WhiteSmoke)
            {
                button5.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(0, 4," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button5.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("0, 4,")).ToArray();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.WhiteSmoke)
            {
                button6.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(0, 5," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button6.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("0, 5,")).ToArray();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.WhiteSmoke)
            {
                button7.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(0, 6," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button7.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("0, 6,")).ToArray();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.WhiteSmoke)
            {
                button8.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(0, 7," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button8.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("0, 7,")).ToArray();
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor == Color.WhiteSmoke)
            {
                button9.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(1, 0," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button9.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("1, 0,")).ToArray();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.BackColor == Color.WhiteSmoke)
            {
                button10.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(1, 1," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button10.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("1, 1,")).ToArray();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.BackColor == Color.WhiteSmoke)
            {
                button11.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(1, 2," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button11.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("1, 2,")).ToArray();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.BackColor == Color.WhiteSmoke)
            {
                button12.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(1, 3," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button12.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("1, 3,")).ToArray();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.BackColor == Color.WhiteSmoke)
            {
                button13.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(1, 4," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button13.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("1, 4,")).ToArray();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.BackColor == Color.WhiteSmoke)
            {
                button14.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(1, 5," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button14.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("1, 5,")).ToArray();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.BackColor == Color.WhiteSmoke)
            {
                button15.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(1, 6," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button15.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("1, 6,")).ToArray();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (button16.BackColor == Color.WhiteSmoke)
            {
                button16.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(1, 7," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button16.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("1, 7,")).ToArray();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button17.BackColor == Color.WhiteSmoke)
            {
                button17.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(2, 0," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button17.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("2, 0,")).ToArray();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (button18.BackColor == Color.WhiteSmoke)
            {
                button18.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(2, 1," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button18.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("2, 1,")).ToArray();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (button19.BackColor == Color.WhiteSmoke)
            {
                button19.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(2, 2," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button19.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("2, 2,")).ToArray();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (button20.BackColor == Color.WhiteSmoke)
            {
                button20.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(2, 3," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button20.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("2, 3,")).ToArray();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (button21.BackColor == Color.WhiteSmoke)
            {
                button21.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(2, 4," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button21.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("2, 4,")).ToArray();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (button22.BackColor == Color.WhiteSmoke)
            {
                button22.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(2, 5," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button22.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("2, 5,")).ToArray();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (button23.BackColor == Color.WhiteSmoke)
            {
                button23.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(2, 6," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button23.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("2, 6,")).ToArray();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (button24.BackColor == Color.WhiteSmoke)
            {
                button24.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(2, 7," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button24.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("2, 7,")).ToArray();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (button25.BackColor == Color.WhiteSmoke)
            {
                button25.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(3, 0," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button25.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("3, 0,")).ToArray();
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (button26.BackColor == Color.WhiteSmoke)
            {
                button26.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(3, 1," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button26.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("3, 1")).ToArray();
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (button27.BackColor == Color.WhiteSmoke)
            {
                button27.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(3, 2," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button27.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("3, 2,")).ToArray();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (button28.BackColor == Color.WhiteSmoke)
            {
                button28.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(3, 3," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button28.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("3, 3,")).ToArray();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (button29.BackColor == Color.WhiteSmoke)
            {
                button29.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(3, 4," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button29.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("3, 4,")).ToArray();
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (button30.BackColor == Color.WhiteSmoke)
            {
                button30.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(3, 5," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button30.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("3, 5,")).ToArray();
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (button31.BackColor == Color.WhiteSmoke)
            {
                button31.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(3, 6," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button31.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("3, 6,")).ToArray();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (button32.BackColor == Color.WhiteSmoke)
            {
                button32.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(3, 7," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button32.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("3, 7,")).ToArray();
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (button33.BackColor == Color.WhiteSmoke)
            {
                button33.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(4, 0," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button33.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("4, 0,")).ToArray();
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (button34.BackColor == Color.WhiteSmoke)
            {
                button34.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(4, 1," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button34.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("4, 1,")).ToArray();
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (button35.BackColor == Color.WhiteSmoke)
            {
                button35.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(4, 2," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button35.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("4, 2,")).ToArray();
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (button36.BackColor == Color.WhiteSmoke)
            {
                button36.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(4, 3," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button36.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("4, 3,")).ToArray();
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (button37.BackColor == Color.WhiteSmoke)
            {
                button37.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(4, 4," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button37.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("4, 4,")).ToArray();
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (button38.BackColor == Color.WhiteSmoke)
            {
                button38.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(4, 5," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button38.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("4, 5,")).ToArray();
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (button39.BackColor == Color.WhiteSmoke)
            {
                button39.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(4, 6," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button39.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("4, 6,")).ToArray();
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (button40.BackColor == Color.WhiteSmoke)
            {
                button40.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(4, 7," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button40.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("4, 7,")).ToArray();
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (button41.BackColor == Color.WhiteSmoke)
            {
                button41.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(5, 0," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button41.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("5, 0,")).ToArray();
            }

        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (button42.BackColor == Color.WhiteSmoke)
            {
                button42.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(5, 1," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button42.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("5, 1,")).ToArray();
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (button43.BackColor == Color.WhiteSmoke)
            {
                button43.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(5, 2," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button43.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("5, 2,")).ToArray();
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (button44.BackColor == Color.WhiteSmoke)
            {
                button44.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(5, 3," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button44.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("5, 3,")).ToArray();
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (button45.BackColor == Color.WhiteSmoke)
            {
                button45.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(5, 4," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button45.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("5, 4,")).ToArray();
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (button46.BackColor == Color.WhiteSmoke)
            {
                button46.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(5, 5," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button46.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("5, 5,")).ToArray();
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (button47.BackColor == Color.WhiteSmoke)
            {
                button47.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(5, 6," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button47.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("5, 6,")).ToArray();
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (button48.BackColor == Color.WhiteSmoke)
            {
                button48.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(5, 7," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button48.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("5, 7,")).ToArray();
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (button49.BackColor == Color.WhiteSmoke)
            {
                button49.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(6, 0," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button49.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("6, 0,")).ToArray();
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (button50.BackColor == Color.WhiteSmoke)
            {
                button50.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(6, 1," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button50.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("6, 1,")).ToArray();
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            if (button51.BackColor == Color.WhiteSmoke)
            {
                button51.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(6, 2," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button51.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("6, 2,")).ToArray();
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (button52.BackColor == Color.WhiteSmoke)
            {
                button52.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(6, 3," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button52.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("6, 3,")).ToArray();
            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            if (button53.BackColor == Color.WhiteSmoke)
            {
                button53.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(6, 4," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button53.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("6, 4,")).ToArray();
            }
        }

        private void button54_Click(object sender, EventArgs e)
        {
            if (button54.BackColor == Color.WhiteSmoke)
            {
                button54.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(6, 5," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button54.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("6, 5,")).ToArray();
            }
        }

        private void button55_Click(object sender, EventArgs e)
        {
            if (button55.BackColor == Color.WhiteSmoke)
            {
                button55.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(6, 6," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button55.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("6, 6,")).ToArray();
            }
        }

        private void button56_Click(object sender, EventArgs e)
        {
            if (button56.BackColor == Color.WhiteSmoke)
            {
                button56.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(6, 7," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button56.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("6, 7,")).ToArray();
            }
        }

        private void button57_Click(object sender, EventArgs e)
        {
            if (button57.BackColor == Color.WhiteSmoke)
            {
                button57.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(7, 0," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button57.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("7, 0,")).ToArray();
            }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            if (button58.BackColor == Color.WhiteSmoke)
            {
                button58.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(7, 1," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button58.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("7, 1,")).ToArray();
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            if (button59.BackColor == Color.WhiteSmoke)
            {
                button59.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(7, 2," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button59.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("7, 2,")).ToArray();
            }
        }

        private void button60_Click(object sender, EventArgs e)
        {
            if (button60.BackColor == Color.WhiteSmoke)
            {
                button60.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(7, 3," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button60.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("7, 3,")).ToArray();
            }
        }

        private void button61_Click(object sender, EventArgs e)
        {
            if (button61.BackColor == Color.WhiteSmoke)
            {
                button61.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(7, 4," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button61.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("7, 4,")).ToArray();
            }
        }

        private void button62_Click(object sender, EventArgs e)
        {
            if (button62.BackColor == Color.WhiteSmoke)
            {
                button62.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(7, 5," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button62.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("7, 5,")).ToArray();
            }
        }

        private void button63_Click(object sender, EventArgs e)
        {
            if (button63.BackColor == Color.WhiteSmoke)
            {
                button63.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(7, 6," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button63.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("7, 6,")).ToArray();
            }
        }

        private void button64_Click(object sender, EventArgs e)
        {
            if (button64.BackColor == Color.WhiteSmoke)
            {
                button64.BackColor = bcolor;
                textBox1.AppendText("\tmatrix.drawPixel(7, 7," + comboBox1.SelectedItem.ToString() + ");\r\n");
            }
            else
            {
                button64.BackColor = Color.WhiteSmoke;
                textBox1.Lines = textBox1.Lines.Where(line => !line.Contains("7, 7,")).ToArray();
            }
        }

        private void button65_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("Please choose a name for the pattern!");
            else
            {
                string[] lines = textBox1.Lines;
                lines[0] = lines[0].Remove(12, 10);
                lines[0] = lines[0].Insert(12, textBox2.Text);
                textBox1.Lines = lines;
                textBox1.AppendText("\tmatrix.show();\r\n");
                textBox1.AppendText("\tdelay(20);\r\n");
                textBox1.AppendText("\treturn;\r\n");
                textBox1.AppendText("}");
                MessageBox.Show("Pattern created succesfully! You can now copy and paste the created function into the Arduino program.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            textBox1.AppendText("void patternNEWPATTERN(Adafruit_NeoMatrix matrix)\r\n");
            textBox1.AppendText("{\r\n");
        }

        private void button66_Click(object sender, EventArgs e)
        {
             groupBox1.Enabled = false;
     
             button1.BackColor = Color.WhiteSmoke;
             button2.BackColor = Color.WhiteSmoke;
             button3.BackColor = Color.WhiteSmoke;
             button4.BackColor = Color.WhiteSmoke;
             button5.BackColor = Color.WhiteSmoke;
             button6.BackColor = Color.WhiteSmoke;
             button7.BackColor = Color.WhiteSmoke;
             button8.BackColor = Color.WhiteSmoke;
             button9.BackColor = Color.WhiteSmoke;
             button10.BackColor = Color.WhiteSmoke;
             button11.BackColor = Color.WhiteSmoke;
             button12.BackColor = Color.WhiteSmoke;
             button13.BackColor = Color.WhiteSmoke;
             button14.BackColor = Color.WhiteSmoke;
             button15.BackColor = Color.WhiteSmoke;
             button16.BackColor = Color.WhiteSmoke;
             button17.BackColor = Color.WhiteSmoke;
             button18.BackColor = Color.WhiteSmoke;
             button19.BackColor = Color.WhiteSmoke;
             button20.BackColor = Color.WhiteSmoke;
             button21.BackColor = Color.WhiteSmoke;
             button22.BackColor = Color.WhiteSmoke;
             button23.BackColor = Color.WhiteSmoke;
             button24.BackColor = Color.WhiteSmoke;
             button25.BackColor = Color.WhiteSmoke;
             button26.BackColor = Color.WhiteSmoke;
             button27.BackColor = Color.WhiteSmoke;
             button28.BackColor = Color.WhiteSmoke;
             button29.BackColor = Color.WhiteSmoke;
             button30.BackColor = Color.WhiteSmoke;
             button31.BackColor = Color.WhiteSmoke;
             button32.BackColor = Color.WhiteSmoke;
             button33.BackColor = Color.WhiteSmoke;
             button34.BackColor = Color.WhiteSmoke;
             button35.BackColor = Color.WhiteSmoke;
             button36.BackColor = Color.WhiteSmoke;
             button37.BackColor = Color.WhiteSmoke;
             button38.BackColor = Color.WhiteSmoke;
             button39.BackColor = Color.WhiteSmoke;
             button40.BackColor = Color.WhiteSmoke;
             button41.BackColor = Color.WhiteSmoke;
             button42.BackColor = Color.WhiteSmoke;
             button43.BackColor = Color.WhiteSmoke;
             button44.BackColor = Color.WhiteSmoke;
             button45.BackColor = Color.WhiteSmoke;
             button46.BackColor = Color.WhiteSmoke;
             button47.BackColor = Color.WhiteSmoke;
             button48.BackColor = Color.WhiteSmoke;
             button49.BackColor = Color.WhiteSmoke;
             button50.BackColor = Color.WhiteSmoke;
             button51.BackColor = Color.WhiteSmoke;
             button52.BackColor = Color.WhiteSmoke;
             button53.BackColor = Color.WhiteSmoke;
             button54.BackColor = Color.WhiteSmoke;
             button55.BackColor = Color.WhiteSmoke;
             button56.BackColor = Color.WhiteSmoke;
             button57.BackColor = Color.WhiteSmoke;
             button58.BackColor = Color.WhiteSmoke;
             button59.BackColor = Color.WhiteSmoke;
             button60.BackColor = Color.WhiteSmoke;
             button61.BackColor = Color.WhiteSmoke;
             button62.BackColor = Color.WhiteSmoke;
             button63.BackColor = Color.WhiteSmoke;
             button64.BackColor = Color.WhiteSmoke;
           
            comboBox1.Text = "Select color";
            textBox2.Text = "";
            comboBox1.SelectionLength = 0;
            textBox1.Text = "";
            textBox1.AppendText("void patternNEWPATTERN(Adafruit_NeoMatrix matrix)\r\n");
            textBox1.AppendText("{\r\n");
        }
    }
}
