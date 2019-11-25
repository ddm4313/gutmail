using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S22.Imap;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox2.Visible = false;
            label3.Visible = false;
        }
        private void Login(string username, string password)
        {
            try
            {
                using (ImapClient Client = new ImapClient("imap.gmail.com", 993, username, password, AuthMethod.Login, true))
                {
                    label2.Text = username;
                    pictureBox1.Load("user_80px.png");
                    int messages = 0;
                    IEnumerable<uint> uids = Client.Search(SearchCondition.All());
                    foreach (uint message in uids)
                    {
                        messages++;
                    }
                    CountMessages(messages);
                }
            }
            catch (S22.Imap.InvalidCredentialsException)
            {
                MessageBox.Show("Invalid credentials.");
            }
        }

        private void CountMessages(int messages)
        {
            pictureBox2.Visible = true;
            label3.Visible = true;
            label3.Text = messages.ToString() + " messages";
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            var formPopup = new Form(); 
            formPopup.Show(this); // if you need non-modal window
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Contains("username")) {
                richTextBox1.Text = "";
            }
        }
        private void richTextBox2_TextChanged_2(object sender, EventArgs e)
        {
            if (richTextBox2.Text.Contains("password"))
            {
                richTextBox2.Text = "";
            }
        }

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (richTextBox2.Text.Contains("password"))
            {
                richTextBox2.Text = "";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = richTextBox1.Text;
            string password = richTextBox2.Text;
            Login(username, password);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }
    }
}
