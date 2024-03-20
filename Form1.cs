using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Advantech.Adam;
using System.Net.Sockets;
using cszmcaux;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Diagnostics.Metrics;
using System.Text.Json.Nodes;


namespace ECI0064
{
    public partial class Form1 : Form
    {
        //連線 ECI0064 及 ADAM-6017
        //string ipaddr ="192.168.0.11";  //ECI0064
        //string phandle="ECI0064C" ;
        //string szip1 ="192.168.0.12"; //ADAM-6017E  1~6 類比電壓  7~8類比電流
        //string szip2 ="192.168.0.13"; //ADAM-6017A 1~6 類比電壓  7~8類比電流
        //string szip3 ="192.168.0.14"; //ADAM-6017B 1~6 類比電壓  7~8類比電流
        //string szip4 ="192.168.0.15"; //ADAM-6017C 1~6 類比電壓  7~8類比電流
        //string szip5 ="192.168.0.16"; //ADAM-6017D 1~6 類比電壓  7~8類比電流

        string ipaddr = "192.168.0.11";  //ECI0064 IP 位置
        string Schang = "a";  //抓夾起始設定
        int TCount = 1000; // TCount 保壓時間 TCount *1000= Thread.Sleep(TCount)  Thread.Sleep(1000)=1S ;
        int Amun = 10; //保壓次數
        int Bmun = 20; //動作次數
        int Wtime = 1; //工作時間  Wtime*1000= Thread.Sleep(Wtime)  Thread.Sleep(1000)=1S ;
        int AWtime = 1; //自作動時間  AWtime*1000= Thread.Sleep(Wtime)  Thread.Sleep(1000)=1S ;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C); //控制器 ECI0064 連接判斷 返回 0為連線成功 
            if (rssult == 0)
            {

                zmcaux.ZAux_Direct_SetOp(ECI0064C, 0, 1); //A組
                zmcaux.ZAux_Direct_SetOp(ECI0064C, 4, 1); //B組
                zmcaux.ZAux_Direct_SetOp(ECI0064C, 8, 1); //C組
                zmcaux.ZAux_Direct_SetOp(ECI0064C, 12, 1); //D組
                zmcaux.ZAux_Direct_SetOp(ECI0064C, 16, 1); //E組
                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("ECI0046 控制器 連接成功");

            }
            else
            {
                MessageBox.Show("ECI0046 控制器 連接失敗");
            }
        }

        private void button2_Click(Object sender, EventArgs e)
        {
        }

        private void button32_Click(object sender, EventArgs e) // 送出停止訊號B 第一組主電磁閥送0
        {
            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
            if (rssult == 0)
            {
                for (int i = 0; i <= 3; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }
                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("第一組關閉");
            }
            else
            {
                MessageBox.Show("第一組關閉失敗");
            }
        }

        private void button33_Click(object sender, EventArgs e) // 送出停止訊號C 第二組主電磁閥送0
        {
            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
            if (rssult == 0)
            {
                for (int i = 4; i <= 7; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }

                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("第二組關閉");
            }
            else
            {
                MessageBox.Show("第二組關閉失敗");
            }
        }

        private void button34_Click(object sender, EventArgs e) // 送出停止訊號D 第三組主電磁閥送0
        {

            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
            if (rssult == 0)
            {
                for (int i = 8; i <= 11; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }
                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("第三組關閉");
            }
            else
            {
                MessageBox.Show("第三組關閉失敗");
            }
        }

        private void button35_Click(object sender, EventArgs e) // 送出停止訊號E 第四組主電磁閥送0
        {
            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
            if (rssult == 0)
            {
                for (int i = 12; i <= 15; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }
                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("第四組關閉");
            }
            else
            {
                MessageBox.Show("第四組關閉失敗");
            }
        }

        private void button36_Click(object sender, EventArgs e) // 送出停止訊號A 第五組主電磁閥送 0
        {
            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
            if (rssult == 0)
            {
                for (int i = 16; i <= 19; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }
                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("第五組關閉");
            }
            else
            {
                MessageBox.Show("第五組關閉失敗");
            }
        }

        private void button37_Click(object sender, EventArgs e)// 測試第一組動作  D0 為第一組主電磁閥  D1動作次數
        {
            Amun = Convert.ToInt32(textBox2.Text);   //保壓次數
            Bmun = Convert.ToInt32(textBox3.Text);   //動作次數
            TCount = 1000 * Convert.ToInt32(textBox4.Text); //保壓等待時間
            Wtime = 1000 * Convert.ToInt32(Wtime1.Text);    //動作時間
            zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);

            for (int j = 1; j <= Amun; j++) // 第一組保壓次數 D1保壓
            {
                int rssult = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                if (rssult == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 0, 1);   //第一組 主電磁閥
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 4, 1);   //第二組 主電磁閥
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 8, 1);   //第三組 主電磁閥
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 12, 1);//第四組 主電磁閥
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 16, 1);//第五組 主電磁閥
                    Thread.Sleep(50);
                    zmcaux.ZAux_Close(ECI0064C);
                }
                else
                {

                    MessageBox.Show("初始控制器 連接失敗");
                }
                for (int i = 1; i <= Bmun; i++)//抓夾動作 次數 D1次數
                {
                    if (Schang == "a")
                    {
                        int rss1 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                        if (rss1 == 0)
                        {
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 1, 1);    // 第一組                        
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 2, 0);    // 第一組
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 5, 1);  //第二組
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 6, 0);  //第二組
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 1); // 第三組 
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 0); //第三組
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 13, 1); //第四組
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 14, 0);//第四組
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 17, 0);//第五組
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 18, 1);//第五組
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 1, 0); // 第一組
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 2, 1); // 第一組
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 5, 0);//第二組
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 6, 1);//第二組
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 0); //第三組
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 1);//第三組
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 13, 0); //第四組
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 14, 1);//第四組
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 17, 1);//第五組
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 18, 0);//第五組
                            Thread.Sleep(50);
                            zmcaux.ZAux_Close(ECI0064C);
                            Thread.Sleep(500);
                        }
                        else
                        {
                            MessageBox.Show("第一組A 控制器 連接失敗第" + i + "次 ; 保壓控制器 連接失敗第" + j + "次");
                        }
                    }
                    else
                    {
                        int rss2 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                        if (rss2 == 0)
                        {
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 1, 0); // 第一組                           
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 2, 1); // 第一組                           
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 5, 0);//第二組
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 6, 1);//第二組
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 0);//第三組
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 1);//第三組
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 13, 0); //第四組
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 14, 1); //第四組 
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 17, 1);//第五組
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 18, 0);//第五組
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 1, 1); // 第一組                           
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 2, 0); // 第一組                           
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 5, 1);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 6, 0);
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 1);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 0);
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 13, 1);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 14, 0);
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 17, 0);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 18, 1);
                            Thread.Sleep(50);
                            zmcaux.ZAux_Close(ECI0064C);
                            Thread.Sleep(500);
                        }
                        else
                        {

                            MessageBox.Show("第一組B控制器 連接失敗第" + i + "次 ; 保壓控制器 連接失敗第" + j + "次");
                        }
                    }
                }

                if (Schang == "a")  //左右停止 抓夾 A B
                    Schang = "b";
                else Schang = "a";
                //保壓動作 第一組主電磁閥

                //   Thread.Sleep(500);
                int rss3 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C); //保壓等待時間
                if (rss3 == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 0, 0);
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 4, 0);
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 8, 0);
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 12, 0);
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 16, 0);
                    Thread.Sleep(50);
                    zmcaux.ZAux_Close(ECI0064C);
                    Thread.Sleep(TCount);
                }
                else
                {

                    MessageBox.Show("第一組保壓控制器 連接失敗第" + j + "次");
                }

            }
            int rss4 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
            if (rss4 == 0)
            {
                for (int i = 0; i <= 31; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }
                zmcaux.ZAux_Close(ECI0064C);
            }
            textBox5.Text = "測試完成"; // A測試品
            textBox27.Text = "測試完成"; //B測試品
            textBox9.Text = "測試完成";//C測試品
            textBox13.Text = "測試完成";//D測試品
            textBox17.Text = "測試完成";//E測試品
                                    // MessageBox.Show("氣閥測試完成");// 測試結束

            Thread.Sleep(500);



        }

        private void button38_Click(object sender, EventArgs e)// 測試第二組動作  D4 為第二組主電磁閥  D5動作次數
        {
            Amun = Convert.ToInt32(textBox28.Text);   //保壓次數
            Bmun = Convert.ToInt32(textBox29.Text);   //動作次數
            TCount = 1000 * Convert.ToInt32(textBox30.Text); //保壓等待時間
            Wtime = 1000 * Convert.ToInt32(Wtime2.Text); //動作時間
            for (int j = 0; j <= Amun; j++) // 第二組保壓次數 D4保壓
            {
                int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
                if (rssult == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 4, 1);
                    Thread.Sleep(50);
                    zmcaux.ZAux_Close(ECI0064C);

                }
                else
                {
                    MessageBox.Show("第二組 開始控制器 連接失敗");
                }
                for (int i = 0; i <= Bmun; i++)//抓夾動作 次數 D5次數
                {
                    if (Schang == "a")
                    {
                        int rss1 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                        if (rss1 == 0)
                        {
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 5, 1);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 6, 0);
                            Thread.Sleep(Wtime);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 5, 0);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 6, 1);
                            Thread.Sleep(50);
                            zmcaux.ZAux_Close(ECI0064C);
                            Thread.Sleep(Wtime);

                        }
                        else
                        {
                            MessageBox.Show("第二組A控制器 連接失敗第" + i + "次");
                        }
                    }
                    else
                    {
                        int rss2 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                        if (rss2 == 0)
                        {
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 5, 0);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 6, 1);
                            Thread.Sleep(Wtime);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 5, 1);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 6, 0);
                            Thread.Sleep(50);
                            zmcaux.ZAux_Close(ECI0064C);
                            Thread.Sleep(Wtime);
                        }
                        else
                        {
                            MessageBox.Show("第二組B控制器 連接失敗第" + i + "次");
                        }
                    }
                }

                if (Schang == "a")  //左右停止 抓夾 A B
                    Schang = "b";
                else Schang = "a";
                //保壓動作 第二組主電磁閥
                //   Thread.Sleep(500);
                int rss3 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                if (rss3 == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 4, 0);
                    zmcaux.ZAux_Close(ECI0064C);
                    Thread.Sleep(TCount);
                }
                else
                {
                    MessageBox.Show("第二組保壓控制器 連接失敗第" + j + "次保壓控制器 連接失敗第" + j + "次");
                }

            }
            int rss4 = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C1);
            if (rss4 == 0)
            {
                for (int i = 4; i <= 7; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C1, i, 0);
                }
                zmcaux.ZAux_Close(ECI0064C1);
            }

            textBox27.Text = "測試完成"; //B測試品

            MessageBox.Show("B測試品 氣閥測試完成");// 測試結束

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //保壓時間 秒數
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) //循環次數
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)  //保壓次數
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Amun = Convert.ToInt32(textBox31.Text);   //保壓次數
            Bmun = Convert.ToInt32(textBox32.Text);   //動作次數
            TCount = 1000 * Convert.ToInt32(textBox33.Text); //保壓等待時間
            Wtime = 1000 * Convert.ToInt32(Wtime3.Text); //保壓等待時間

            for (int j = 1; j <= Amun; j++) // 第三組保壓次數 D8保壓
            {
                int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
                if (rssult == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 8, 1);
                    Thread.Sleep(50);
                    zmcaux.ZAux_Close(ECI0064C);
                }
                else
                {
                       MessageBox.Show("第三組初始控制器 連接失敗");
                }
                for (int i = 1; i <= Bmun; i++)//抓夾動作 次數 D1次數
                {
                    if (Schang == "a")
                    {
                        int rss1 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                        if (rss1 == 0)
                        {
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 1);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 0);
                            Thread.Sleep(Wtime);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 0);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 1);
                            Thread.Sleep(50);
                            zmcaux.ZAux_Close(ECI0064C);
                            Thread.Sleep(Wtime);

                        }
                        else
                        {
                            MessageBox.Show("第二組A控制器 連接失敗第" + i + "次");
                        }
                    }
                    else
                    {
                        int rss2 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                        if (rss2 == 0)
                        {
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 0);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 1);
                            Thread.Sleep(Wtime);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 1);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 0);
                            Thread.Sleep(50);
                            zmcaux.ZAux_Close(ECI0064C);
                            Thread.Sleep(Wtime);
                        }
                        else
                        {
                            MessageBox.Show("第二組A控制器 連接失敗第" + i + "次");
                        }
                    }
                }
                if (Schang == "a")  //左右停止 抓夾 A B
                    Schang = "b";
                else Schang = "a";
                //保壓動作 第三組主電磁閥
                int rss3 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                if (rss3 == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 8, 0);
                    zmcaux.ZAux_Close(ECI0064C);
                    Thread.Sleep(TCount);
                }
                else
                {
                    MessageBox.Show("第三組保壓控制器 連接失敗第" + j + "次");
                }
            }

            int rss4 = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C1);
            if (rss4 == 0)
            {
                zmcaux.ZAux_Direct_SetOp(ECI0064C1, 9, 0);
                zmcaux.ZAux_Direct_SetOp(ECI0064C1, 10, 0);
                zmcaux.ZAux_Close(ECI0064C1);
            }

            textBox9.Text = "測試完成";//C測試品

            //  MessageBox.Show("氣閥測試完成");// 測試結束
            zmcaux.ZAux_Close(ECI0064C1);
            Thread.Sleep(500);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button37_Click(true, e);  //第一組
            button38_Click(true, e);//第二組
            button14_Click(true, e);//第三組
            MessageBox.Show("氣閥測試完成");// 測試結束        
        }

        private void button22_Click(object sender, EventArgs e)
        {

            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
            if (rssult == 0)
            {
                for (int i = 0; i < 31; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }
                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("全歸零成功");
            }
            else
            {
                MessageBox.Show("歸零失敗");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {

            int rss = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
            if (rss == 0)
            {
                zmcaux.ZAux_Direct_SetOp(ECI0064C, 8, 1);
                for (int i = 0; i < 2000; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 1);
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 0);
                    Thread.Sleep(100);
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 0);
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 1);
                    Thread.Sleep(100);
                }

            }
            int rss1 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
            if (rss1 == 0)
            {
                for (int i = 8; i < 11; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }
            }
            MessageBox.Show("連動測試完成 2000次");
            zmcaux.ZAux_Close(ECI0064C);
            Thread.Sleep(500);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Amun = Convert.ToInt32(textBox24.Text);   //保壓次數
            Bmun = Convert.ToInt32(textBox23.Text);   //動作次數
            TCount = 1000 * Convert.ToInt32(textBox22.Text); //保壓等待時間
            Wtime = 1000 * Convert.ToInt32(Wtime4.Text); //保壓等待時間

            for (int j = 1; j <= Amun; j++) // 第三組保壓次數 D8保壓
            {
                int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
                if (rssult == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 12, 1);
                    Thread.Sleep(50);
                      }
                else
                {
                    MessageBox.Show("D測試品  初始控制器 連接失敗");
                }
                for (int i = 0; i <= Bmun; i++)//抓夾動作 次數 D1次數
                {
                    if (Schang == "a")
                    {
                        int rss1 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                        if (rss1 == 0)
                        {
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 13, 1);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 14, 0);
                            Thread.Sleep(Wtime);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 13, 0);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 14, 1);
                            Thread.Sleep(50);
                            zmcaux.ZAux_Close(ECI0064C);
                            Thread.Sleep(Wtime);
                        }
                        else
                        {
                            MessageBox.Show("D測試品  A組控制器 連接失敗");
                        }
                    }
                    else
                    {
                        int rss2 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                        if (rss2 == 0)
                        {
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 13, 0);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 14, 1);
                            Thread.Sleep(Wtime);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 13, 1);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 14, 0);
                            Thread.Sleep(50);
                            zmcaux.ZAux_Close(ECI0064C);
                            Thread.Sleep(Wtime);
                        }
                        else
                        {
                            MessageBox.Show("D測試品  B組控制器 連接失敗");
                        }
                    }
                }

                if (Schang == "a")  //左右停止 抓夾 A B
                    Schang = "b";
                else Schang = "a";
                //保壓動作 第三組主電磁閥
                int rss3 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                if (rss3 == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 12, 0);
                    zmcaux.ZAux_Close(ECI0064C);
                    Thread.Sleep(TCount);
                }
                else
                {
                    MessageBox.Show("第三組保壓控制器 連接失敗第" + j + "次");
                }
            }

            int rss4 = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C1);
            if (rss4 == 0)
            {
                zmcaux.ZAux_Direct_SetOp(ECI0064C1, 13, 0);
                zmcaux.ZAux_Direct_SetOp(ECI0064C1, 14, 0);
                zmcaux.ZAux_Close(ECI0064C1);
            }

            textBox13.Text = "測試完成";//D測試品

            //  MessageBox.Show("氣閥測試完成");// 測試結束
            zmcaux.ZAux_Close(ECI0064C1);
            Thread.Sleep(500);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Amun = Convert.ToInt32(textBox37.Text);   //保壓次數
            Bmun = Convert.ToInt32(textBox36.Text);   //動作次數
            TCount = 1000 * Convert.ToInt32(textBox35.Text); //保壓等待時間
            Wtime = 1000 * Convert.ToInt32(Wtime5.Text); //保壓等待時間

            for (int j = 0; j <= Amun; j++) // 第三組保壓次數 D8保壓
            {
                int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
                if (rssult == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 16, 1);
                    Thread.Sleep(50);
                    zmcaux.ZAux_Close(ECI0064C);
                }
                else
                {

                    MessageBox.Show("E測試品  初始控制器 連接失敗");
                }
                for (int i = 0; i <= Bmun; i++)//抓夾動作 次數 D1次數
                {
                    if (Schang == "a")
                    {
                        int rss1 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                        if (rss1 == 0)
                        {
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 17, 1);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 18, 0);
                            Thread.Sleep(Wtime);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 17, 0);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 18, 1);
                            Thread.Sleep(50);
                            zmcaux.ZAux_Close(ECI0064C);
                            Thread.Sleep(Wtime);
                        }
                        else
                        {
                            MessageBox.Show("E測試品  A組控制器 連接失敗");
                        }
                    }
                    else
                    {
                        int rss1 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                        if (rss1 == 0)
                        {
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 17, 0);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 18, 1);
                            Thread.Sleep(Wtime);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 17, 1);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 18, 0);
                            Thread.Sleep(50);
                            zmcaux.ZAux_Close(ECI0064C);
                            Thread.Sleep(Wtime);
                        }
                        else
                        {
                            MessageBox.Show("E測試品  B組控制器 連接失敗");
                        }
                    }
                }

                if (Schang == "a")  //左右停止 抓夾 A B
                    Schang = "b";
                else Schang = "a";
                //保壓動作 第三組主電磁閥
                int rss3 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                if (rss3 == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 16, 0);
                    zmcaux.ZAux_Close(ECI0064C);
                    Thread.Sleep(TCount);
                }
                else
                {
                    MessageBox.Show("E測試品  保壓控制器 連接失敗第" + j + "次");
                }
            }

            int rss4 = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C1);
            if (rss4 == 0)
            {
                zmcaux.ZAux_Direct_SetOp(ECI0064C1, 17, 0);
                zmcaux.ZAux_Direct_SetOp(ECI0064C1, 18, 0);
                zmcaux.ZAux_Close(ECI0064C1);
            }

            textBox13.Text = "測試完成";//E測試品

            //  MessageBox.Show("氣閥測試完成");// 測試結束
            zmcaux.ZAux_Close(ECI0064C1);
            Thread.Sleep(500);
        }
    }
}
