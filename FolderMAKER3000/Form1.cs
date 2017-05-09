using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderMAKER3000
{
    public partial class Form1 : Form
    {
        public List<string> names = new List<string>();
        
        private bool _pathSet;
        private string _path;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            if (result == DialogResult.OK) // Test result.
            {

                string file = openFileDialog1.FileName;
                try
                {
                    string[] lines = File.ReadAllLines(file);
                    foreach (string s in lines)
                    {
                        names.Add(s);
                    }

                    label2.Text = openFileDialog1.SafeFileName;


                }
                catch (IOException)
                {
                }
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
           

            if(_pathSet)
            {
                int index = 0;
                bool legacyflag = true;
                foreach (string s in names)
                {

                    if (legacyflag && s.Equals("Proprietary and Confidential"))
                    {
                        Directory.CreateDirectory(_path + @"\0" + "1.5" + " " + s);
                        File.WriteAllText(_path + @"\0" + "1.5" + " " + s + "\\keep.txt", "");
                        legacyflag = false;
                    }

                    else
                    {
                        if (index < 10)
                        {
                            Directory.CreateDirectory(_path + @"\0" + index + " " + s);
                            File.WriteAllText(_path + @"\0" + index + " " + s + "\\keep.txt", "");
                        }
                        else
                        {
                            Directory.CreateDirectory(_path + @"\" + index + " " + s);
                            File.WriteAllText(_path + @"\" + index + " " + s + "\\keep.txt", "");
                        }
                        index++;
                    }


                }

                _pathSet = false;
            }
            else
            {
                MessageBox.Show("Please set the path!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                label4.Text = folderBrowserDialog1.SelectedPath;
                _pathSet = true;
                _path = folderBrowserDialog1.SelectedPath;

                Process.Start(_path);
            }
        }

 
    }
}
