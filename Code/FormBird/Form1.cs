using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormBird
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        Color birdColor = Color.Yellow;
        Color pipe = Color.Green;

        public List<Form> pipes = new List<Form>();

        Random random = new Random();
        Form bird;
        Form score;
        Label label;

        int scoreNum = 0;

        int jumpedFrom = 0;
        bool jumping = false;
        int jumpHeight = 150;

        int gravityAdder = 0;
        int jumpAdder = 0;

        private void bird_color_PictureBox_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    birdColor = colorDialog.Color; 
                    bird_color_PictureBox.BackColor = birdColor;
                }
            }
        }

        private void pipe_color_PictureBox_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    pipe = colorDialog.Color;
                    pipe_color_PictureBox.BackColor = pipe;
                }
            }
        }

        private void terminateGame()
        {
            try
            {
                foreach (Form f in pipes.ToList())
                {
                    if (f != null)
                    {
                        f.Close();
                    }
                }

                pipes.Clear();

                if (bird != null)
                {
                    bird.Close();
                    bird = null;
                }

                if (score != null)
                {
                    score.Close();
                    score = null;
                }

                timer1.Enabled = false;
                jumping = false;
                jumpAdder = 0;
                gravityAdder = 0;

                this.Focus();
                this.WindowState = FormWindowState.Normal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při ukončení hry: " + ex.Message);
            }
        }


        private void showScoreMerer()
        {
            score = new Form();
            score.Size = new Size(300, 150);
            score.StartPosition = FormStartPosition.Manual;
            score.Location = new Point(1920 - 300, 0);
            score.FormBorderStyle = FormBorderStyle.None;
            score.ControlBox = false;
            score.ShowInTaskbar = false;
            score.BackColor = Color.FromArgb(64, 64, 64);

            label = new Label();
            label.Size = new Size(300, 120);
            label.Text = "Score: 0";
            label.Font = new Font("Yu Gothic", 48, FontStyle.Bold);
            label.ForeColor = Color.White;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;

            score.Controls.Add(label);
            score.Show();

            score.TopMost = true;

        }



        private void spawnBird()
        {
            bird = new Form();
            bird.Size = new Size(100, 100);
            bird.StartPosition = FormStartPosition.Manual;
            bird.Location = new Point(200, 540);
            bird.BackColor = birdColor;
            bird.FormBorderStyle = FormBorderStyle.None;  
            bird.ControlBox = false;                      
            bird.TopMost = true;                         
            bird.ShowInTaskbar = false;                  
            bird.BackColor = birdColor;                   
            bird.KeyDown += Bird_KeyDown;
            bird.KeyPress += Bird_Click;
            bird.Show();
        }


        private void Bird_Click(object sender, EventArgs e)
        {

            timer1.Enabled = true;

        }

        private void Bird_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {

                gravityAdder = 0;
                jumpedFrom = bird.Location.Y;
                jumping = true;

            }
            else if (e.KeyCode == Keys.Escape)
            {

                terminateGame();

            }

        }

        private void moveBird()
        {
            if (jumping)
            {

                bird.Location = new Point(bird.Location.X, bird.Location.Y - jumpAdder * 2);
                jumpAdder++;




                if (bird.Location.Y < jumpedFrom - jumpHeight)
                {

                    jumping = false;
                    jumpAdder = 0;

                }

            }
            else
            {

                bird.Location = new Point(bird.Location.X, bird.Location.Y + gravityAdder);
                gravityAdder++;

            }

            if (bird.Location.Y > 1080) terminateGame();


        }

        private void createPipe(int vyska, int misto)
        {
            Form pipeDown = new Form();
            pipeDown.Size = new Size(150, vyska);
            pipeDown.StartPosition = FormStartPosition.Manual;
            pipeDown.Location = new Point(misto, 1080 - vyska);
            pipeDown.BackColor = pipe;
            pipeDown.FormBorderStyle = FormBorderStyle.None;
            pipeDown.ControlBox = false;                     
            pipeDown.ShowInTaskbar = false;                  
            pipeDown.TopMost = true;                         
            pipes.Add(pipeDown);
            pipeDown.Show();

            Form pipeTop = new Form();
            pipeTop.Size = new Size(150, 1080 - vyska - 400);
            pipeTop.StartPosition = FormStartPosition.Manual;
            pipeTop.Location = new Point(misto, 0);
            pipeTop.BackColor = pipe;
            pipeTop.FormBorderStyle = FormBorderStyle.None;  
            pipeTop.ControlBox = false;                      
            pipeTop.ShowInTaskbar = false;                   
            pipeTop.TopMost = true;                          
            pipes.Add(pipeTop);
            pipeTop.Show();
        }


        private void movePipe(Form pipe, int jakMoc)
        {

            pipe.Location = new Point(pipe.Location.X - jakMoc, pipe.Location.Y);


        }

        private void checkIfBirdHitPipe()
        {

            for (int i = 0; i < pipes.Count; i++)
            {

                if (bird.Bounds.IntersectsWith(pipes[i].Bounds))
                {

                    terminateGame();

                }

            }
        }

        private void isPipeInEnd(Form pipe, List<Form> pipes)
        {

            if (pipe.Location.X == 0)
            {
                pipes.Remove(pipe);
                pipe.Close();
                scoreNum++;

                label.Text = (scoreNum / 2).ToString();
            }

        }

        private void play_Button_Click(object sender, EventArgs e)
        {
            gravityAdder = 0;
            scoreNum = 0;

            this.WindowState = FormWindowState.Minimized;
            createPipe(random.Next(1, 4) * 100, 900);
            createPipe(random.Next(1, 4) * 100, 1300);
            createPipe(random.Next(1, 4) * 100, 1700);
            createPipe(random.Next(1, 4) * 100, 2100);
            showScoreMerer();
            spawnBird();
        }

        private void gitHub_PictureBox_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/PauliesCodes",
                UseShellExecute = true 
            });
        }

        private void url_PictureBox_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://paulas-michal.mzf.cz/",
                UseShellExecute = true 
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bird.Focus();

            for (int i = 0; i < pipes.Count; i++)
            {

                movePipe(pipes[i], 5);
                isPipeInEnd(pipes[i], pipes);

            }

            if (pipes.Count < 8)
            {

                createPipe(random.Next(1, 4) * 100, 1920 - 150);
                bird.Focus();

            }

            moveBird();
            checkIfBirdHitPipe();

        }

        private void clear_Button_Click(object sender, EventArgs e)
        {
            terminateGame();
        }
    }
}
