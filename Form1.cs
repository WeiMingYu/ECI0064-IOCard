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
        //�s�u ECI0064 �� ADAM-6017
        //string ipaddr ="192.168.0.11";  //ECI0064
        //string phandle="ECI0064C" ;
        //string szip1 ="192.168.0.12"; //ADAM-6017E  1~6 ����q��  7~8����q�y
        //string szip2 ="192.168.0.13"; //ADAM-6017A 1~6 ����q��  7~8����q�y
        //string szip3 ="192.168.0.14"; //ADAM-6017B 1~6 ����q��  7~8����q�y
        //string szip4 ="192.168.0.15"; //ADAM-6017C 1~6 ����q��  7~8����q�y
        //string szip5 ="192.168.0.16"; //ADAM-6017D 1~6 ����q��  7~8����q�y

        string ipaddr = "192.168.0.11";  //ECI0064 IP ��m
        string Schang = "a";  //�짨�_�l�]�w
        int TCount = 1000; // TCount �O���ɶ� TCount *1000= Thread.Sleep(TCount)  Thread.Sleep(1000)=1S ;
        int Amun = 10; //�O������
        int Bmun = 20; //�ʧ@����
        int Wtime = 1; //�u�@�ɶ�  Wtime*1000= Thread.Sleep(Wtime)  Thread.Sleep(1000)=1S ;
        int AWtime = 1; //�ۧ@�ʮɶ�  AWtime*1000= Thread.Sleep(Wtime)  Thread.Sleep(1000)=1S ;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C); //��� ECI0064 �s���P�_ ��^ 0���s�u���\ 
            if (rssult == 0)
            {

                zmcaux.ZAux_Direct_SetOp(ECI0064C, 0, 1); //A��
                zmcaux.ZAux_Direct_SetOp(ECI0064C, 4, 1); //B��
                zmcaux.ZAux_Direct_SetOp(ECI0064C, 8, 1); //C��
                zmcaux.ZAux_Direct_SetOp(ECI0064C, 12, 1); //D��
                zmcaux.ZAux_Direct_SetOp(ECI0064C, 16, 1); //E��
                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("ECI0046 ��� �s�����\");

            }
            else
            {
                MessageBox.Show("ECI0046 ��� �s������");
            }
        }

        private void button2_Click(Object sender, EventArgs e)
        {
        }

        private void button32_Click(object sender, EventArgs e) // �e�X����T��B �Ĥ@�եD�q�ϻְe0
        {
            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
            if (rssult == 0)
            {
                for (int i = 0; i <= 3; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }
                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("�Ĥ@������");
            }
            else
            {
                MessageBox.Show("�Ĥ@����������");
            }
        }

        private void button33_Click(object sender, EventArgs e) // �e�X����T��C �ĤG�եD�q�ϻְe0
        {
            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
            if (rssult == 0)
            {
                for (int i = 4; i <= 7; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }

                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("�ĤG������");
            }
            else
            {
                MessageBox.Show("�ĤG����������");
            }
        }

        private void button34_Click(object sender, EventArgs e) // �e�X����T��D �ĤT�եD�q�ϻְe0
        {

            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
            if (rssult == 0)
            {
                for (int i = 8; i <= 11; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }
                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("�ĤT������");
            }
            else
            {
                MessageBox.Show("�ĤT����������");
            }
        }

        private void button35_Click(object sender, EventArgs e) // �e�X����T��E �ĥ|�եD�q�ϻְe0
        {
            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
            if (rssult == 0)
            {
                for (int i = 12; i <= 15; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }
                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("�ĥ|������");
            }
            else
            {
                MessageBox.Show("�ĥ|����������");
            }
        }

        private void button36_Click(object sender, EventArgs e) // �e�X����T��A �Ĥ��եD�q�ϻְe 0
        {
            int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
            if (rssult == 0)
            {
                for (int i = 16; i <= 19; i++)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, i, 0);
                }
                zmcaux.ZAux_Close(ECI0064C);
                MessageBox.Show("�Ĥ�������");
            }
            else
            {
                MessageBox.Show("�Ĥ�����������");
            }
        }

        private void button37_Click(object sender, EventArgs e)// ���ղĤ@�հʧ@  D0 ���Ĥ@�եD�q�ϻ�  D1�ʧ@����
        {
            Amun = Convert.ToInt32(textBox2.Text);   //�O������
            Bmun = Convert.ToInt32(textBox3.Text);   //�ʧ@����
            TCount = 1000 * Convert.ToInt32(textBox4.Text); //�O�����ݮɶ�
            Wtime = 1000 * Convert.ToInt32(Wtime1.Text);    //�ʧ@�ɶ�
            zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);

            for (int j = 1; j <= Amun; j++) // �Ĥ@�իO������ D1�O��
            {
                int rssult = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                if (rssult == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 0, 1);   //�Ĥ@�� �D�q�ϻ�
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 4, 1);   //�ĤG�� �D�q�ϻ�
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 8, 1);   //�ĤT�� �D�q�ϻ�
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 12, 1);//�ĥ|�� �D�q�ϻ�
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 16, 1);//�Ĥ��� �D�q�ϻ�
                    Thread.Sleep(50);
                    zmcaux.ZAux_Close(ECI0064C);
                }
                else
                {

                    MessageBox.Show("��l��� �s������");
                }
                for (int i = 1; i <= Bmun; i++)//�짨�ʧ@ ���� D1����
                {
                    if (Schang == "a")
                    {
                        int rss1 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                        if (rss1 == 0)
                        {
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 1, 1);    // �Ĥ@��                        
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 2, 0);    // �Ĥ@��
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 5, 1);  //�ĤG��
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 6, 0);  //�ĤG��
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 1); // �ĤT�� 
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 0); //�ĤT��
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 13, 1); //�ĥ|��
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 14, 0);//�ĥ|��
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 17, 0);//�Ĥ���
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 18, 1);//�Ĥ���
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 1, 0); // �Ĥ@��
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 2, 1); // �Ĥ@��
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 5, 0);//�ĤG��
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 6, 1);//�ĤG��
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 0); //�ĤT��
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 1);//�ĤT��
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 13, 0); //�ĥ|��
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 14, 1);//�ĥ|��
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 17, 1);//�Ĥ���
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 18, 0);//�Ĥ���
                            Thread.Sleep(50);
                            zmcaux.ZAux_Close(ECI0064C);
                            Thread.Sleep(500);
                        }
                        else
                        {
                            MessageBox.Show("�Ĥ@��A ��� �s�����Ѳ�" + i + "�� ; �O����� �s�����Ѳ�" + j + "��");
                        }
                    }
                    else
                    {
                        int rss2 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                        if (rss2 == 0)
                        {
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 1, 0); // �Ĥ@��                           
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 2, 1); // �Ĥ@��                           
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 5, 0);//�ĤG��
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 6, 1);//�ĤG��
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 9, 0);//�ĤT��
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 10, 1);//�ĤT��
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 13, 0); //�ĥ|��
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 14, 1); //�ĥ|�� 
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 17, 1);//�Ĥ���
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 18, 0);//�Ĥ���
                            Thread.Sleep(500);
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 1, 1); // �Ĥ@��                           
                            zmcaux.ZAux_Direct_SetOp(ECI0064C, 2, 0); // �Ĥ@��                           
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

                            MessageBox.Show("�Ĥ@��B��� �s�����Ѳ�" + i + "�� ; �O����� �s�����Ѳ�" + j + "��");
                        }
                    }
                }

                if (Schang == "a")  //���k���� �짨 A B
                    Schang = "b";
                else Schang = "a";
                //�O���ʧ@ �Ĥ@�եD�q�ϻ�

                //   Thread.Sleep(500);
                int rss3 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C); //�O�����ݮɶ�
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

                    MessageBox.Show("�Ĥ@�իO����� �s�����Ѳ�" + j + "��");
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
            textBox5.Text = "���է���"; // A���ի~
            textBox27.Text = "���է���"; //B���ի~
            textBox9.Text = "���է���";//C���ի~
            textBox13.Text = "���է���";//D���ի~
            textBox17.Text = "���է���";//E���ի~
                                    // MessageBox.Show("��ִ��է���");// ���յ���

            Thread.Sleep(500);



        }

        private void button38_Click(object sender, EventArgs e)// ���ղĤG�հʧ@  D4 ���ĤG�եD�q�ϻ�  D5�ʧ@����
        {
            Amun = Convert.ToInt32(textBox28.Text);   //�O������
            Bmun = Convert.ToInt32(textBox29.Text);   //�ʧ@����
            TCount = 1000 * Convert.ToInt32(textBox30.Text); //�O�����ݮɶ�
            Wtime = 1000 * Convert.ToInt32(Wtime2.Text); //�ʧ@�ɶ�
            for (int j = 0; j <= Amun; j++) // �ĤG�իO������ D4�O��
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
                    MessageBox.Show("�ĤG�� �}�l��� �s������");
                }
                for (int i = 0; i <= Bmun; i++)//�짨�ʧ@ ���� D5����
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
                            MessageBox.Show("�ĤG��A��� �s�����Ѳ�" + i + "��");
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
                            MessageBox.Show("�ĤG��B��� �s�����Ѳ�" + i + "��");
                        }
                    }
                }

                if (Schang == "a")  //���k���� �짨 A B
                    Schang = "b";
                else Schang = "a";
                //�O���ʧ@ �ĤG�եD�q�ϻ�
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
                    MessageBox.Show("�ĤG�իO����� �s�����Ѳ�" + j + "���O����� �s�����Ѳ�" + j + "��");
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

            textBox27.Text = "���է���"; //B���ի~

            MessageBox.Show("B���ի~ ��ִ��է���");// ���յ���

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //�O���ɶ� ���
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) //�`������
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)  //�O������
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Amun = Convert.ToInt32(textBox31.Text);   //�O������
            Bmun = Convert.ToInt32(textBox32.Text);   //�ʧ@����
            TCount = 1000 * Convert.ToInt32(textBox33.Text); //�O�����ݮɶ�
            Wtime = 1000 * Convert.ToInt32(Wtime3.Text); //�O�����ݮɶ�

            for (int j = 1; j <= Amun; j++) // �ĤT�իO������ D8�O��
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
                       MessageBox.Show("�ĤT�ժ�l��� �s������");
                }
                for (int i = 1; i <= Bmun; i++)//�짨�ʧ@ ���� D1����
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
                            MessageBox.Show("�ĤG��A��� �s�����Ѳ�" + i + "��");
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
                            MessageBox.Show("�ĤG��A��� �s�����Ѳ�" + i + "��");
                        }
                    }
                }
                if (Schang == "a")  //���k���� �짨 A B
                    Schang = "b";
                else Schang = "a";
                //�O���ʧ@ �ĤT�եD�q�ϻ�
                int rss3 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                if (rss3 == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 8, 0);
                    zmcaux.ZAux_Close(ECI0064C);
                    Thread.Sleep(TCount);
                }
                else
                {
                    MessageBox.Show("�ĤT�իO����� �s�����Ѳ�" + j + "��");
                }
            }

            int rss4 = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C1);
            if (rss4 == 0)
            {
                zmcaux.ZAux_Direct_SetOp(ECI0064C1, 9, 0);
                zmcaux.ZAux_Direct_SetOp(ECI0064C1, 10, 0);
                zmcaux.ZAux_Close(ECI0064C1);
            }

            textBox9.Text = "���է���";//C���ի~

            //  MessageBox.Show("��ִ��է���");// ���յ���
            zmcaux.ZAux_Close(ECI0064C1);
            Thread.Sleep(500);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button37_Click(true, e);  //�Ĥ@��
            button38_Click(true, e);//�ĤG��
            button14_Click(true, e);//�ĤT��
            MessageBox.Show("��ִ��է���");// ���յ���        
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
                MessageBox.Show("���k�s���\");
            }
            else
            {
                MessageBox.Show("�k�s����");
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
            MessageBox.Show("�s�ʴ��է��� 2000��");
            zmcaux.ZAux_Close(ECI0064C);
            Thread.Sleep(500);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Amun = Convert.ToInt32(textBox24.Text);   //�O������
            Bmun = Convert.ToInt32(textBox23.Text);   //�ʧ@����
            TCount = 1000 * Convert.ToInt32(textBox22.Text); //�O�����ݮɶ�
            Wtime = 1000 * Convert.ToInt32(Wtime4.Text); //�O�����ݮɶ�

            for (int j = 1; j <= Amun; j++) // �ĤT�իO������ D8�O��
            {
                int rssult = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C);
                if (rssult == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 12, 1);
                    Thread.Sleep(50);
                      }
                else
                {
                    MessageBox.Show("D���ի~  ��l��� �s������");
                }
                for (int i = 0; i <= Bmun; i++)//�짨�ʧ@ ���� D1����
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
                            MessageBox.Show("D���ի~  A�ձ�� �s������");
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
                            MessageBox.Show("D���ի~  B�ձ�� �s������");
                        }
                    }
                }

                if (Schang == "a")  //���k���� �짨 A B
                    Schang = "b";
                else Schang = "a";
                //�O���ʧ@ �ĤT�եD�q�ϻ�
                int rss3 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                if (rss3 == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 12, 0);
                    zmcaux.ZAux_Close(ECI0064C);
                    Thread.Sleep(TCount);
                }
                else
                {
                    MessageBox.Show("�ĤT�իO����� �s�����Ѳ�" + j + "��");
                }
            }

            int rss4 = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C1);
            if (rss4 == 0)
            {
                zmcaux.ZAux_Direct_SetOp(ECI0064C1, 13, 0);
                zmcaux.ZAux_Direct_SetOp(ECI0064C1, 14, 0);
                zmcaux.ZAux_Close(ECI0064C1);
            }

            textBox13.Text = "���է���";//D���ի~

            //  MessageBox.Show("��ִ��է���");// ���յ���
            zmcaux.ZAux_Close(ECI0064C1);
            Thread.Sleep(500);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Amun = Convert.ToInt32(textBox37.Text);   //�O������
            Bmun = Convert.ToInt32(textBox36.Text);   //�ʧ@����
            TCount = 1000 * Convert.ToInt32(textBox35.Text); //�O�����ݮɶ�
            Wtime = 1000 * Convert.ToInt32(Wtime5.Text); //�O�����ݮɶ�

            for (int j = 0; j <= Amun; j++) // �ĤT�իO������ D8�O��
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

                    MessageBox.Show("E���ի~  ��l��� �s������");
                }
                for (int i = 0; i <= Bmun; i++)//�짨�ʧ@ ���� D1����
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
                            MessageBox.Show("E���ի~  A�ձ�� �s������");
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
                            MessageBox.Show("E���ի~  B�ձ�� �s������");
                        }
                    }
                }

                if (Schang == "a")  //���k���� �짨 A B
                    Schang = "b";
                else Schang = "a";
                //�O���ʧ@ �ĤT�եD�q�ϻ�
                int rss3 = zmcaux.ZAux_OpenEth(ipaddr, out ECI0064C);
                if (rss3 == 0)
                {
                    zmcaux.ZAux_Direct_SetOp(ECI0064C, 16, 0);
                    zmcaux.ZAux_Close(ECI0064C);
                    Thread.Sleep(TCount);
                }
                else
                {
                    MessageBox.Show("E���ի~  �O����� �s�����Ѳ�" + j + "��");
                }
            }

            int rss4 = zmcaux.ZAux_OpenEth(ipaddr, out IntPtr ECI0064C1);
            if (rss4 == 0)
            {
                zmcaux.ZAux_Direct_SetOp(ECI0064C1, 17, 0);
                zmcaux.ZAux_Direct_SetOp(ECI0064C1, 18, 0);
                zmcaux.ZAux_Close(ECI0064C1);
            }

            textBox13.Text = "���է���";//E���ի~

            //  MessageBox.Show("��ִ��է���");// ���յ���
            zmcaux.ZAux_Close(ECI0064C1);
            Thread.Sleep(500);
        }
    }
}
