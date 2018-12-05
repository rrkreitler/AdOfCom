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
            int maxWidth = 0;
            int maxHeight = 0;

            var data = textBox1.Text.Replace("\r\n","|").Split('|');
            Claim[] claims = new Claim[data.Length];
            int index = 0;

            foreach (var claim in data)
            {
                claims[index] = new Claim(claim);

                if (maxWidth < claims[index].left + claims[index].width)
                {
                    maxWidth = claims[index].left + claims[index].width;
                }
                if (maxHeight < claims[index].height + claims[index].top)
                {
                    maxHeight = claims[index].height + claims[index].top;
                }
                index++;
            }

            int[,] fabric = new int[maxWidth, maxHeight];

            foreach (var claim in claims)
            {
                for (int y = claim.top; y < claim.top + claim.height; y++)
                {
                    for (int x = claim.left; x < claim.left + claim.width; x++)
                    {
                        if (fabric[x, y] != 2) fabric[x, y]++;
                    }
                }
            }

            int count = 0;

            foreach (var i in fabric)
            {
                if (i == 2) count++;
            }

            textBox1.Text = count.ToString();
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

    public class Claim
    {
        public Claim(string claim)
        {
            var data = claim.Split(':');
            var wh = data[1].Trim().Split('x');
            width = Int32.Parse(wh[0].Trim());
            height = Int32.Parse(wh[1].Trim());

            var leftTop = data[0].Split('@');
            var lt = leftTop[1].Trim().Split(',');
            left = Int32.Parse(lt[0].Trim());
            top = Int32.Parse(lt[1].Trim());
            
        }
        public int left;
        public int top;

        public int width;
        public int height;
    }
}
