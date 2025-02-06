using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace FormBird
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_MINIMIZE = 6; // Kód pro minimalizaci

        static void MinimizeAllWindows()
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowHandle != IntPtr.Zero) // Ověření, že okno existuje
                {
                    ShowWindow(p.MainWindowHandle, SW_MINIMIZE);
                }
            }
        }

        Color birdColor = Color.Yellow;
        Color pipe = Color.Green;

        public List<Form> pipes = new List<Form>();

        Random random = new Random();
        Form bird;
        Form score;
        Form deathScreen;

        Label label;
        Label label2;

        TextBox nameInput;

        int scoreNum = 0;

        int jumpedFrom = 0;
        bool jumping = false;
        int jumpHeight = 150;

        int gravityAdder = 0;
        int jumpAdder = 0;

        int speedFactor = 5;

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

        private void terminateGame(bool byEsc)
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

                if(!byEsc) showDeathScreen();

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

        private void showDeathScreen()
        {
            deathScreen = new Form();
            deathScreen.Size = new Size(400, 400);
            deathScreen.StartPosition = FormStartPosition.CenterScreen;
            deathScreen.FormBorderStyle = FormBorderStyle.None;
            deathScreen.ControlBox = false;
            deathScreen.ShowInTaskbar = false;
            deathScreen.BackColor = Color.FromArgb(64, 64, 64);

            Label label = new Label();
            label.Size = new Size(380, 80);
            label.Location = new Point(10, 10);
            label.Text = "You died!";
            label.Font = new Font("Yu Gothic", 32, FontStyle.Bold);
            label.ForeColor = Color.White;
            label.TextAlign = ContentAlignment.MiddleCenter;

            Label label2 = new Label();
            label2.Size = new Size(380, 50);
            label2.Location = new Point(10, 100);
            label2.Text = "Score: " + scoreNum/2;
            label2.Font = new Font("Yu Gothic", 24, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.TextAlign = ContentAlignment.MiddleCenter;

            nameInput = new TextBox();
            nameInput.Size = new Size(250, 40);
            nameInput.Location = new Point(75, 170);
            nameInput.Font = new Font("Yu Gothic", 18, FontStyle.Bold);
            nameInput.MaxLength = 16;
            nameInput.TextAlign = HorizontalAlignment.Center;

            // Povolené znaky: A-Z, a-z, 0-9, _, -
            nameInput.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) &&
                    !char.IsLetterOrDigit(e.KeyChar) &&
                    e.KeyChar != '_' &&
                    e.KeyChar != '-')
                {
                    e.Handled = true; 
                }
            };

            Button confirmButton = new Button();
            confirmButton.Size = new Size(250, 50);
            confirmButton.Location = new Point(75, 230);
            confirmButton.Text = "Upload!";
            confirmButton.Font = new Font("Yu Gothic", 18, FontStyle.Bold);
            confirmButton.BackColor = System.Drawing.SystemColors.Window;
            confirmButton.UseVisualStyleBackColor = false;
            confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            Button cancelButton = new Button();
            cancelButton.Size = new Size(250, 50);
            cancelButton.Location = new Point(75, 290);
            cancelButton.Text = "Exit";
            cancelButton.Font = new Font("Yu Gothic", 18, FontStyle.Bold);
            cancelButton.BackColor = System.Drawing.SystemColors.Window;
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            cancelButton.Click += CancelButton_Click;

            confirmButton.Click += ConfirmButton_Click;

            deathScreen.Controls.Add(label);
            deathScreen.Controls.Add(label2);
            deathScreen.Controls.Add(nameInput);
            deathScreen.Controls.Add(confirmButton);
            deathScreen.Controls.Add(cancelButton);

            deathScreen.TopMost = true;
            deathScreen.Show();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

            deathScreen.Close();

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            //  $servername = "localhost"; sql.endora.cz:3307
            //$username = "client";
            //$password = "12Client3";
            //$dbname = "formbirddata";

            if(nameInput.Text.Length > 3)
            {

                string connectionString = "Server=sql.endora.cz;Port=3307;Database=formbirddata;User Id=client;Password=12Client3;";

                string query = "INSERT INTO score (score, name, date) VALUES (@score, @name, @date)";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            // Nahraď tyto hodnoty skutečnými daty
                            cmd.Parameters.AddWithValue("@score", (scoreNum / 2));  // Například skóre 100
                            cmd.Parameters.AddWithValue("@name", nameInput.Text);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);

                            cmd.ExecuteNonQuery();

                            deathScreen.Close();
                            CustomMessageBox.ShowMessage();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something went wrong :( If the problem persists, contact me at email: paulasm.06@spst.eu\n\n",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }

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

                terminateGame(true);

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

            if (bird.Location.Y > 1080) terminateGame(false);


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
            pipes.Add(pipeTop);
            pipeTop.Show();
        }


        private void movePipe(Form pipe, int speedFactor)
        {

            pipe.Location = new Point(pipe.Location.X - speedFactor, pipe.Location.Y);

        }


        private void checkIfBirdHitPipe()
        {

            for (int i = 0; i < pipes.Count; i++)
            {

                if (bird.Bounds.IntersectsWith(pipes[i].Bounds))
                {

                    terminateGame(false);

                }

            }

            if(bird != null && bird.Location.Y <= 0)
            {

                terminateGame(false);

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

            if(deathScreen != null) deathScreen.Close();
            MinimizeAllWindows();

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
                FileName = "https://paulas-michal.mzf.cz/FormBird/",
                UseShellExecute = true 
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bird.Focus();

            if (scoreNum / 2 % 10 == 0 && scoreNum > 0) 
            {
                speedFactor++;  
            }

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
            terminateGame(true);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
