using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Collections;


namespace _1072040finalproject
{
    public partial class Form1 : Form
    {
        int[] ImageList = {1,2,6,4,5,6,7,8,1,8,3,4,5,2,7,3};
        int lastBtn = 0;
        int lastImg = 0;
        int clicktime = 0;
        int here = 0;
        double sec;

        static Button[] btn = new Button[16];
    
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            rtxSec.Text = "0";
            rtxTime.Text = "0";
            clicktime = 0;

            btn[0] = button1; btn[1] = button2; btn[2] = button3; btn[3] = button4; btn[4] = button5;
            btn[5] = button6; btn[6] = button7; btn[7] = button8; btn[8] = button9; btn[9] = button10;
            btn[10] = button11; btn[11] = button12; btn[12] = button13; btn[13] = button14; btn[14] = button15; btn[15] = button16;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            //重設
            sec = 0;
            clicktime = 0;
            rtxSec.Text = "0秒";
            rtxTime.Text = "0次";
            timer1.Enabled = false;

            for (int i = 0; i < 16; i++)
            {
                btn[i].Enabled = false;//關閉按鈕
                btn[i].BackgroundImage = imageList1.Images[0];//關掉圖示
            }
            btnRestart.Enabled = false;
            btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
            for (int i = 0; i < 16; i++)
                btn[i].Enabled = true;//開啟按鈕

            //打亂
            Random crandom = new Random();
            int rand = crandom.Next(1, 7);

            for (int i = 0; i < 16; i++)
            {
                ImageList[i] = ImageList[i] + rand;
                if (ImageList[i] > 8) ImageList[i] -= 8;
            }
            btnStart.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e){
        }
        public void OpenBox(int here)//打開button
        {
            btn[here-1].BackgroundImage = imageList1.Images[ImageList[here -1]];//翻開
            btn[here-1].Enabled = false;//關閉已翻開的button
            clicktime++;
            rtxTime.Text = clicktime + "次";

            if (clicktime % 2 == 0)//點擊兩次後判斷是否相同
            {
                if (lastImg != ImageList[here - 1])
                {
                    Thread.Sleep(500);
                    CoverBox(here);
                    CoverBox(lastBtn);
                }
                finish();
            }
            lastImg = ImageList[here-1];
            lastBtn = here;
        }
        public void CoverBox(int n)//蓋上button
        {
            btn[n - 1].BackgroundImage = imageList1.Images[0];
            btn[n - 1].Enabled = true;
        }
        public void finish()
        {
            int n = 0;
            for(int i = 0; i < 16; i++)
                if (btn[i].Enabled == false) n++;
            
            if(n == 16)
            {
                timer1.Enabled = false;
                btnRestart.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            here = 1;
            OpenBox(here);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            here = 2;
            OpenBox(here);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            here = 3;
            OpenBox(here);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            here = 4;
            OpenBox(here);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            here = 5;
            OpenBox(here);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            here = 6;
            OpenBox(here);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            here = 7;
            OpenBox(here);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            here = 8;
            OpenBox(here);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            here = 9;
            OpenBox(here);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            here = 10;
            OpenBox(here);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            here = 11;
            OpenBox(here);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            here = 12;
            OpenBox(here);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            here = 13;
            OpenBox(here);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            here = 14;
            OpenBox(here);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            here = 15;
            OpenBox(here);
        }
        private void button16_Click(object sender, EventArgs e)
        {
            here = 16;
            OpenBox(here);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            rtxSec.Text = sec + "秒";
        }
        private void rtxTime_TextChanged(object sender, EventArgs e)
        {
            rtxTime.Text = clicktime + "次";
        }
        private void rtxSec_TextChanged(object sender, EventArgs e)
        {
            rtxSec.Text = sec + "秒";
        }
    }
}
