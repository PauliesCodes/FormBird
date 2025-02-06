using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FormBird
{
    internal class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            this.Text = "Score Saved!";
            this.Size = new Size(350, 180);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label messageLabel = new Label();
            messageLabel.Text = "Your score was saved!";
            messageLabel.Font = new Font("Yu Gothic", 12, FontStyle.Bold);
            messageLabel.AutoSize = true;
            messageLabel.Location = new Point(20, 20);
            this.Controls.Add(messageLabel);

            LinkLabel link = new LinkLabel();
            link.Text = "Click here to view leaderboard";
            link.Font = new Font("Yu Gothic", 10, FontStyle.Bold);
            link.AutoSize = true;
            link.Location = new Point(20, 60);
            link.LinkClicked += (sender, e) =>
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://paulas-michal.mzf.cz/",
                    UseShellExecute = true
                });
            };
            this.Controls.Add(link);

            Button closeButton = new Button();
            closeButton.Text = "OK";
            closeButton.Size = new Size(80, 30);
            closeButton.Location = new Point(120, 100);
            closeButton.Click += (sender, e) => this.Close();
            this.Controls.Add(closeButton);
        }

        public static void ShowMessage()
        {
            CustomMessageBox box = new CustomMessageBox();
            box.ShowDialog();
        }

    }
}
