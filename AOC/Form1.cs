using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AOC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = textBox1.Text.Replace("\r\n",",").Split(',');
            Array.Sort(data);
            //var data = textBox1.Text.Split(',');
            textBox1.Text = "";
            for (int i = 0; i < data.Length-1; i++)
            {
                for (int x = i + 1; x < data.Length; x++)
                {
                    if (CountDiffs(data[i], data[x]) == 1)
                    {
                        for (int c = 0; c < data[i].Length; c++)
                        {
                            if (data[i].Substring(c,1) == data[x].Substring(c,1)) textBox1.AppendText(data[i].Substring(c,1));
                        }
                        break;
                    }
                }
                if (textBox1.Text != "") break;
            }

            //textBox1.Text = "Done";

        }

        private int CountDiffs(string s1, string s2)
        {
            int c = 0;
            int count = 0;
            do
            {
                if (s1.Substring(c, 1) != s2.Substring(c++, 1)) count++;
            } while (c < s1.Length && count < 2);
            return count;
        }
    }

    class Possible
    {
        public int x;
        public int y;
    }
}
