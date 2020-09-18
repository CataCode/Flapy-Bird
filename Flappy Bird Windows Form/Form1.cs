using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int pipeSpeed = 5;
        int gravity = 5;
        int score = 0;
        bool reset = false;
       

        public Form1()
        {
            InitializeComponent();
                                
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            flappyBird.Top += gravity;
            scoreText.Text = "Score: " + score ;
          
 
            if (pipeBottom.Left < -80)
            {
                pipeBottom.Left = 1000;
                score ++;
            }
            else if(pipeTop.Left < -95)
            {
                pipeTop.Left = 1100;
                score ++;
            }
            if(flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
               flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
               flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || flappyBird.Top < -25)
            {
                endGame();
                
            }   

           
            
            if(score > 5)
            {
               for (int i = 1; i < 20; i++)
                {
                    pipeSpeed = i;
                }
            }
        }

        private void restart_Click(object sender, EventArgs e)
        {
            score = 0;
            gameTimer.Start();
            flappyBird.Location = new Point(13, 200);
            pipeSpeed = 5;
            restart.Visible = false;
            restart.Enabled = false;            
        }
        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                jumping = true;
                gravity = -8;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = false;
                gravity = 8;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!!";
            restart.Visible = true;
            restart.Enabled = true;
            design.Visible = true;
        }       
       
    }
}
