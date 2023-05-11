using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace contact
{
    public partial class Contact : Form
    {
        PhoneDirectory pd1 = new PhoneDirectory();
        public Contact()
        {
            InitializeComponent();
        }
        public static void start(PhoneDirectory c, ListBox lb1)
        {
            if (File.Exists("data.txt") == false)
                using (File.CreateText("data.txt"))
                { }
            if (new FileInfo("data.txt").Length == 0)
            {
                return;
            }
            else
            {
                string[] OldData = File.ReadAllLines("data.txt");
                for (int i = 0; i < OldData.Length; i += 2)
                {
                    c.load(OldData[i], OldData[i + 1]);
                }
                c.show(lb1);
            }
        }
        public static void save(PhoneDirectory c)
        {
            File.WriteAllLines("data.txt", c.DataToSave());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Add add = new Add(pd1, listBox1);
            add.Show();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            button12.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            button1.Visible = true;
            button11.Visible = true;
            button5.Visible = true;
            button13.Visible = true;
            button6.Visible = true;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button1.Visible = false;
            button11.Visible = false;
            button13.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button12.Visible = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            start(pd1, listBox1);
            this.Icon = Icon.ExtractAssociatedIcon("contact.exe");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            pd1.clear();
            label3.Visible = false;
            label4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            panel1.Visible = false;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Visible = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            save(pd1);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            search f = new search(pd1);
            f.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Edit ef = new Edit(pd1, listBox1);
            label3.Visible = false;
            label4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            panel1.Visible = false;
            ef.Show();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;
            label4.Text = listBox1.SelectedItem.ToString();
            label3.Text = pd1.getnum(label4.Text);
            label3.Visible = true;
            label4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            panel1.Visible = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            pd1.deletecontact(listBox1.SelectedItem.ToString());
            label3.Visible = false;
            label4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            panel1.Visible = false;
            pd1.show(listBox1);
        }
    }
}