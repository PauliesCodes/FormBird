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

        Color bird = Color.Yellow;
        Color pipe = Color.Green;

        private void bird_color_PictureBox_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    bird = colorDialog.Color; 
                    bird_color_PictureBox.BackColor = bird;
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

        private void play_Button_Click(object sender, EventArgs e)
        {

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
    }
}
