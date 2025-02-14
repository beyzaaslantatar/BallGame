﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ucanTop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int yerX = 10 , yerY = 10 , can = 3;

        private void Walls()
        {
            if(ball.Top <= label2.Bottom)
            {
                yerY = yerY * -1;
            }
            if(ball.Bottom >= kontrol.Top && ball.Left>= kontrol.Left && ball.Right <= kontrol.Right)
            {
                yerY = yerY * -1;
            }
            if (ball.Right >= label4.Left)
            {
                yerX = yerX * -1;
            }
            if (ball.Left <= label1.Right)
            {
                yerX = yerX * -1;
            }
        }

        private void Fail(object sender, EventArgs e)
        {
            if (ball.Top >= label4.Bottom)
            {
                if(can > 0)
                {
                    timer1.Stop();
                    can--;
                    MessageBox.Show("Kalan can =" + can.ToString());
                    Form1_Load(sender, e);
                }
                if(can == 0)
                {
                    timer1.Stop();
                    MessageBox.Show("Oyun Bitti." , " ", MessageBoxButtons.OK);
                    can = 3;
                    Form1_Load(sender, e);
                }
            }
            label3.Text = can.ToString();
        }
        private void BallReset()
        {
            ball.Location = new Point(152,129);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            kontrol.Left = e.X;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BallReset();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Walls();
            Fail(sender,e);
            ball.Location = new Point(ball.Location.X + yerX, ball.Location.Y + yerY);
        }
    }
}
