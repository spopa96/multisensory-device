using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;  //start the thread that treads from the Arduino thread 
        }

        public TcpClient client;
        public NetworkStream stream;

        int selected_trigger = -1;
        string[] response = new string[11];                  //string array to store the automatic responses
        string[] event_list = new string[11];                //string array to store the event log lines 

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
        
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //read the list of available haptic patterns
            StreamReader sr1 = new StreamReader(@System.IO.Directory.GetCurrentDirectory().ToString() + "/Hapticpatterns.txt");
            string line1 = sr1.ReadLine();
            while(line1 != null)
            {
                comboBox2.Items.Add(line1);
                comboBox7.Items.Add(line1);
                line1 = sr1.ReadLine();

            }
            //read the list of available sound files 
            StreamReader sr2 = new StreamReader(@System.IO.Directory.GetCurrentDirectory().ToString() + "/Soundfiles.txt");
            string line2 = sr2.ReadLine();
            while (line2 != null)
            {
                comboBox1.Items.Add(line2);
                comboBox6.Items.Add(line2);
                line2 = sr2.ReadLine();

            }
            //read the list of matrix patterns 
            StreamReader sr3 = new StreamReader(@System.IO.Directory.GetCurrentDirectory().ToString() + "/Matrixpatterns.txt");
            string line3 = sr3.ReadLine();
            while (line3 != null)
            {
                comboBox5.Items.Add(line3);
                comboBox9.Items.Add(line3);
                line3 = sr3.ReadLine();

            }
        }

     
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {    
                Byte[] data = new Byte[256];         //array of bytes to store the incoming bytes from the server
                String responseData = String.Empty;  // string to store the response ASCII representation.
                Int32 bytes = stream.Read(data, 0, data.Length);  // Read the first batch of the TcpServer response bytes.

                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);   //convert the byte array to string
                stream.Flush();

                // check the type of respone secieved from the server
                if (responseData.Contains("SX\r\n"))
                {
                    responseData = responseData.Replace("SX\r\n", ""); //remove the message from the response (the whole response may contain extra information)
                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\t"); });   //append time to event log

                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText("Shake in X direction\t\r\n"); }); //append event to event log
                    //check if automatic response was set
                    if (checkedListBox1.GetItemCheckState(2) == CheckState.Checked)
                    {
                        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(response[2]);   //convert the response message to byte array
                        stream.Write(outStream, 0, outStream.Length);           //send the response message to server
                        stream.Flush();
                        textBox2.Invoke((MethodInvoker)delegate { textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + event_list[2]); });   //add response to event log
                    }
                }
                if (responseData.Contains("SY\r\n"))
                {
                    responseData = responseData.Replace("SY\r\n", "");
                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\t"); });

                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText("Shake in Y direction\t\r\n"); });
                    if (checkedListBox1.GetItemCheckState(3) == CheckState.Checked)
                    {
                        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(response[3]);
                        stream.Write(outStream, 0, outStream.Length);
                        stream.Flush();
                        textBox2.Invoke((MethodInvoker)delegate { textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + event_list[3]); });
                    }
                }
                if (responseData.Contains("SZ\r\n"))
                {
                    responseData = responseData.Replace("SZ\r\n", "");
                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\t"); });

                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText("Shake in Z direction\t\r\n"); });
                    if (checkedListBox1.GetItemCheckState(4) == CheckState.Checked)
                    {
                        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(response[4]);
                        stream.Write(outStream, 0, outStream.Length);
                        stream.Flush();
                        textBox2.Invoke((MethodInvoker)delegate { textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + event_list[4]); });
                    }
                }
                if (responseData.Contains("RX\r\n"))
                {
                    responseData = responseData.Replace("RX\r\n", "");
                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\t"); });

                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText("Rotation about X axis\t\r\n"); });
                    if (checkedListBox1.GetItemCheckState(5) == CheckState.Checked)
                    {
                        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(response[5]);
                        stream.Write(outStream, 0, outStream.Length);
                        stream.Flush();
                        textBox2.Invoke((MethodInvoker)delegate { textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + event_list[5]); });
                    }
                }
                if (responseData.Contains("RY\r\n"))
                {
                    responseData = responseData.Replace("RY\r\n", "");
                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\t"); });

                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText("Rotation about Y axis\t\r\n"); });
                    if (checkedListBox1.GetItemCheckState(6) == CheckState.Checked)
                    {
                        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(response[6]);
                        stream.Write(outStream, 0, outStream.Length);
                        stream.Flush();
                        textBox2.Invoke((MethodInvoker)delegate { textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + event_list[6]); });
                    }
                }
                if (responseData.Contains("RZ\r\n"))
                {
                    responseData = responseData.Replace("RZ\r\n", "");
                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\t"); });

                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText("Rotation about Z axis\t\r\n"); });
                    if (checkedListBox1.GetItemCheckState(7) == CheckState.Checked)
                    {
                        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(response[7]);
                        stream.Write(outStream, 0, outStream.Length);
                        stream.Flush();
                        textBox2.Invoke((MethodInvoker)delegate { textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + event_list[7]); });
                    }
                }

                if (responseData.Contains("MIC\r\n"))
                {
                    responseData = responseData.Replace("MIC\r\n", "");
                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\t"); });

                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText("Sound Detected\t\r\n"); });
                    if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked)
                    {
                        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(response[0]);
                        stream.Write(outStream, 0, outStream.Length);
                        stream.Flush();
                        textBox2.Invoke((MethodInvoker)delegate { textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + event_list[0]); });
                    }
                }

                if (responseData.Contains("F1\r\n"))
                {
                    responseData = responseData.Replace("F1\r\n", "");
                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\t"); });

                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText("Force Detected F1\t\r\n"); });
                    if (checkedListBox1.GetItemCheckState(8) == CheckState.Checked)
                    {
                        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(response[8]);
                        stream.Write(outStream, 0, outStream.Length);
                        stream.Flush();
                        textBox2.Invoke((MethodInvoker)delegate { textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + event_list[8]); });
                    }
                }

                if (responseData.Contains("F2\r\n"))
                {
                    responseData = responseData.Replace("F2\r\n", "");
                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\t"); });

                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText("Force Detected F2\t\r\n"); });
                    if (checkedListBox1.GetItemCheckState(9) == CheckState.Checked)
                    {
                        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(response[9]);
                        stream.Write(outStream, 0, outStream.Length);
                        stream.Flush();
                        textBox2.Invoke((MethodInvoker)delegate { textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + event_list[9]); });
                    }
                }

                if (responseData.Contains("F3\r\n"))
                {
                    responseData = responseData.Replace("F3\r\n", "");
                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\t"); });

                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText("Force Detected F3\t\r\n"); });
                    if (checkedListBox1.GetItemCheckState(10) == CheckState.Checked)
                    {
                        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(response[10]);
                        stream.Write(outStream, 0, outStream.Length);
                        stream.Flush();
                        textBox2.Invoke((MethodInvoker)delegate { textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + event_list[10]); });
                    }
                }
                // check the type of respone secieved from the server
                if (responseData.Contains("BUT\r\n"))
                {
                    responseData = responseData.Replace("BUT\r\n", ""); //remove the message from the response (the whole response may contain extra information)
                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\t"); }); //append time to event log
                    textBox2.Invoke((MethodInvoker)delegate { this.textBox2.AppendText("Button Pressed\t\r\n"); }); //append event to event log
                    //check if automatic response was set
                    if (checkedListBox1.GetItemCheckState(1) == CheckState.Checked)
                    {
                        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(response[1]); //convert the response message to byte array
                        stream.Write(outStream, 0, outStream.Length);   //send the response message to server
                        stream.Flush();
                        textBox2.Invoke((MethodInvoker)delegate { textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + event_list[1]); });  //add response to event log
                    }
                }

                //append timestamp before acceleration measurement (begining of data set)
                if (responseData.Contains("accX"))
                    responseData = responseData.Insert((responseData.IndexOf("accX")), (DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\t"));

                textBox1.Invoke((MethodInvoker)delegate { this.textBox1.AppendText(responseData); });  //add readigs to IMU reading table


                System.Threading.Thread.Sleep(50);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        bool enable_IMU = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();   //start background server reading process
            }

            stream.Flush();


            //if transmission is stopped send enable message to Arduino
            if (enable_IMU == false)
            {
                enable_IMU = true; 
                button2.Text = "STOP";
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes("e\r\n");   
                stream.Write(outStream, 0, outStream.Length);
                stream.Flush();          
            }
            //if transmission in on send disable message to Arduino
            else if (enable_IMU == true)
            {
                enable_IMU = false;
                button2.Text = "START";
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes("d\r\n");
                stream.Write(outStream, 0, outStream.Length);
                stream.Flush();
                textBox1.AppendText("");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt, dte;
            DataSet ds;

            ds = new DataSet();      
            dt = new DataTable();     //data table with IMU readings
            dte = new DataTable();    //data table with event log
            ds.Tables.Add(dt);
            ds.Tables.Add(dte);

            //add columns to data tables
            dt.Columns.Add("Time", typeof(string));
            dt.Columns.Add("accX", typeof(string));
            dt.Columns.Add("accY", typeof(string));
            dt.Columns.Add("accZ", typeof(string));
            dt.Columns.Add("gyroX", typeof(string));
            dt.Columns.Add("gyroY", typeof(string));
            dt.Columns.Add("gyroZ", typeof(string));
            dt.Columns.Add("angleX", typeof(string));
            dt.Columns.Add("angleY", typeof(string));
            dt.Columns.Add("angleZ", typeof(string));

            dte.Columns.Add("Time", typeof(string));
            dte.Columns.Add("Event", typeof(string));

            
            for (int i = 0; i < textBox1.Lines.Length; i++) //read contents of text box line by line
            {
                string[] line = textBox1.Lines[i].Split('\t');   //split line into components separated by tab characters
                DataRow dr = dt.NewRow();
                for (int j = 0; j < (line.Length - 1); j++)      
                {
                    dr[j] = line[j].Substring(line[j].LastIndexOf(' ') + 1);  //select the numerical value of each component and add them to table
                }
                dt.Rows.Add(dr);
            }

            for (int k = 0; k < textBox2.Lines.Length; k++)   //read contents of text box line by line
            {
                string[] line = textBox2.Lines[k].Split('\t');    //split line into components separated by tab characters
                DataRow dr = dte.NewRow();
                for (int j = 0; j < (line.Length - 1); j++)
                {
                    dr[j] = line[j];          //select the numerical time and event and add them to table
                }
                dte.Rows.Add(dr);
            }

            SaveFileDialog x = new SaveFileDialog();      //open a save file dialog
            x.Filter = "XML-File | *.xml";
            if (x.ShowDialog() == DialogResult.OK)
            {
                ds.WriteXml(x.FileName);   //create a xml file
            }  
        }

        
        //select sound effect for automated response
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            response[selected_trigger] = "s$" + comboBox1.SelectedIndex.ToString();
            event_list[selected_trigger] = "\tSound played " + comboBox1.SelectedItem.ToString() + "\t\r\n";
            //  checkedListBox1.Text = event_list[selected_trigger];
            string[] lines = event_list;
            for (int i = 0; i <= 10; i++)
                if (lines[i] != null)
                    lines[i] = lines[i].Replace("\n", "");
            textBox3.Lines = lines;
            comboBox1.Enabled = false;
            checkedListBox1.SetItemChecked(selected_trigger, true);
            checkedListBox1.Enabled = true;
            comboBox1.Text = "Select sound file";
            
        }

        //trigger sound effect for manual response response
        string audio_file = "";
        private void button4_Click(object sender, EventArgs e)
        {

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(audio_file);
            stream.Write(outStream, 0, outStream.Length);      //send trigger message to Arduino
            stream.Flush();
            textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\tSound played " + comboBox6.SelectedItem.ToString() + "\t\r\n");
           
        }

        //select haptic pattern for automatic response
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            response[selected_trigger] = "v$" + comboBox2.SelectedIndex.ToString();
            event_list[selected_trigger] = "\tVibration started " + comboBox2.SelectedItem.ToString() + "\t\r\n";
            //checkedListBox1.Text = event_list[selected_trigger];
            comboBox2.Enabled = false;
            string[] lines = event_list;
            for (int i = 0; i <= 10; i++)
                if (lines[i] != null)
                    lines[i] = lines[i].Replace("\n", "");
            textBox3.Lines = lines;
            comboBox2.Text = "Select vibration pattern";
            checkedListBox1.SetItemChecked(selected_trigger, true);
            checkedListBox1.Enabled = true;
        }

        //trigger haptic pattern for manual response
        private void button5_Click(object sender, EventArgs e)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(haptic_file);
            stream.Write(outStream, 0, outStream.Length);
            stream.Flush();
            textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11) + "\tVibration started" + comboBox7.SelectedItem.ToString() + "\t\r\n");
            
            
        }

        //select matrix for automatic response
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox5.Enabled = true;           
            comboBox4.Text = "Select Matrix";
        }

        //select LED pattern for automatic response
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            response[selected_trigger] = "m$" + (comboBox4.SelectedIndex + 1).ToString() + "$" + (comboBox5.SelectedIndex + 1).ToString();
            event_list[selected_trigger] = "\tPattern " + comboBox5.SelectedItem.ToString() + " displayed on " + comboBox4.SelectedItem.ToString() + "\t\r\n";
            checkedListBox1.SetItemChecked(selected_trigger, true);
            checkedListBox1.Text = checkedListBox1.Text.ToString() + "->" + event_list[selected_trigger];
            comboBox5.Enabled = false;
            string[] lines = event_list;
            for (int i = 0; i <= 10; i++)
                if(lines[i]!=null)
                 lines[i] = lines[i].Replace("\n", "");
            textBox3.Lines = lines;
            checkedListBox1.Enabled = true;
            comboBox5.Text = "Select Pattern";
            comboBox4.Enabled = false;
        }

        //display LED pattern as manual response
        private void button1_Click_1(object sender, EventArgs e)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(matrix_file);
            stream.Write(outStream, 0, outStream.Length);
            stream.Flush();
            textBox2.AppendText(DateTime.Now.TimeOfDay.ToString().Substring(0,11)+"\tPattern " + comboBox9.SelectedItem.ToString() + " displayed on " + comboBox8.SelectedItem.ToString() + "\t\r\n");
            comboBox9.Text = "Select Pattern";
            comboBox9.Enabled = false;
            comboBox8.Text = "Select Matrix";
            
        }

        
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)  //select the input trigger action
        {
            comboBox3.Enabled = true;
            selected_trigger = checkedListBox1.SelectedIndex;
            checkedListBox1.Enabled = false;  //enable the response type selection combo box
        }

       
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)   //select response type for the selected action
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0: { comboBox1.Enabled = true; } break;  //enable the sound selection combo box
                case 1: { comboBox2.Enabled = true; } break;  //enable the haptic selection combo box
                case 2: { comboBox4.Enabled = true; } break;  //enable the matrix selection combo box
            }
            comboBox3.Text = "Select response type";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string haptic_file = "";
        
        //select sound file for manual response
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            audio_file = "s$" + comboBox6.SelectedIndex.ToString();
            comboBox6.Text = "Select sound file";
            button4.Enabled = true;
        }
        //select haptic pattern for manual response
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            haptic_file = "v$" + comboBox7.SelectedIndex.ToString();
            comboBox7.Text = "Select vibration pattern";
            button5.Enabled = true;
        }

        string matrix_file = "";

        //select matric for amnual response
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.Enabled = true;
            comboBox8.Text = "Select Matrix";
        }

        //select LED pattern form manual response
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            matrix_file = "m$" + (comboBox8.SelectedIndex + 1).ToString() + "$" + (comboBox9.SelectedIndex + 1).ToString();
            button1.Enabled = true;
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //show the pattern sedigner applet
        private void patternDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var designer = new PatternCreator();
            designer.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //check if client is not connected
            if (client == null || !client.Connected)                             
            {
                label3.Text = "Connecting...";
                label3.ForeColor = Color.Orange;
                label3.Refresh();
                try
                {   //connect to server 
                    client = new TcpClient("192.168.4.1", 80);     
                    stream = client.GetStream();                   
                    label3.ForeColor = Color.Green;
                    label3.Text = "Connected";
                    button2.Enabled = true;
                }
                catch (SocketException )
                {   //show error message is connection is not succesfull 
                    MessageBox.Show("The app could not connect to the device. Check if the pc is connected to the ESP_86E2F5 access point. ");
                    label3.ForeColor = Color.Red;
                    label3.Text = "Not Connected";
                }
            }            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var help = new Form2();
            help.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
