using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmHomeWork : Form
    {
        public FrmHomeWork()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array = { 100, 66, 77 };
            lblResult.Text = "最大數為:" + array.Max();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int odd = 0;
            int even = 0;
            int[] nums = { 33, 4, 5, 11, 222, 34 };
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }

            }
            lblResult.Text = "int[] nums = { 33, 4, 5, 11, 222, 34 };" + "偶數為:" + even + "  奇數為:" + odd;

        }

        private void button14_Click(object sender, EventArgs e)
        {

            string[] names = { "aaa", "ksdkfjsdk", "asdasdasdasdas", "asda" };
            int x = names[0].Length;
            string max = "";

            for (int i = 0; i < names.Length; i++)
            {
                if (x <= names[i].Length)
                {
                    x = names[i].Length;
                    max = names[i];
                }
            }
            lblResult.Text = "名字最長的為:" + max;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtnum.Text);
            if (x % 2 == 0)
            {
                lblResult.Text = "輸入的數  " + x + "為偶數";
            }
            else
            {
                lblResult.Text = "輸入的數  " + x + "為奇數";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] scores = { 2, 3, 46, 33, 22, 100, 150, 33, 55 };

            int max = scores.Max();

            int min = scores.Min();
            lblResult.Text = "最小值為:  " + min+ "最大值為:  " + max; ;
            //MessageBox.Show("Max = " + max);

            //Array.Sort(scores);
            //MessageBox.Show("Max =" + scores[scores.Length - 1]);

            //================================

            //Point[] points = new Point[3];
            //points[0].X = 3;
            //points[0].Y = 4;
            ////System.InvalidOperationException: '無法比較陣列中的兩個元素。'

            //Array.Sort(points);

            //=================================

            //MessageBox.Show("Max = " + ClsUtility.MyMax(scores));

        }

        int MyMinScore(int[] nums)
        {
            return 10;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 2; j <= 9; j++)
                {
                    lblResult.Text += j + " x " + i + " = " + j * i + "  ";

                }
                lblResult.Text += "\n";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string[] arr0771_Str = { "mother張", "emma", "迪克蕭", "J40", "Candy", "Cindy", "Coconut", "Motherfacker" };
            int x = 0;
            for (int i = 0; i < arr0771_Str.Length; i++)
            {
                foreach (char c in arr0771_Str[i])
                {
                    if (c == 'c' || c == 'C')
                    {
                        x++;
                    }
                }
            }
            lblResult.Text= "string[] arr0771_Str = { mother張, emma, 迪克蕭, J40, Candy, Cindd, Coconut, Motherfacker } 有C 及 c的名字共有 " + x + " 個";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            List<int> LS = new List<int>();
            lblResult.Text = "";
            for (int i = 1; i <= 6; i++)
            {
                int tmp = rd.Next(1, 49);
                if (LS.Contains(tmp))  
                {
                    i--;
                }
                else
                {
                    LS.Add(tmp); 
                    lblResult.Text += "  " + tmp.ToString();
                }
            }
        }
    }
}
