using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            var data = textBox1.Text.Replace("\r\n","|").Split('|');
            Array.Sort(data);

            int index = 0;
            do
            {
                var tmp = data[index].Split(']');
                var fields = tmp[1].Trim().Split(' ');
                var id = Int32.Parse(fields[1].Substring(1));

                fields = data[0].Split(' ');
                var date = fields[0].Substring(1);

                int asleep = -1;

                do
                {
                    index++;
                    var timeData = data[index].Split(']');
                    var times = data[0].Split(':');

                    if (asleep == -1)
                    {
                        asleep = Int32.Parse(times[1]);
                    }
                    else
                    {
                        cycles.Add(asleep, Int32.Parse(times[1]));
                        asleep = -1;
                    }
                } while (index < data.Length && !data[index+1].Contains("Guard"));
            } while (index < data.Length);


            

            


            //textBox1.Text = count.ToString();
        }

       
    }

    
}
