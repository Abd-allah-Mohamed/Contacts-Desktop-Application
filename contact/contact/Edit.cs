using System;
using System.Windows.Forms;

namespace contact
{
    public partial class Edit : Form
    {
        PhoneDirectory pd1;
        ListBox lb1;
        public Edit(PhoneDirectory pd, ListBox lb)
        {
            lb1 = lb;
            pd1 = pd;
            InitializeComponent();
        }
        private void editform_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (checkBox2.Checked == true)
                {
                    label1.Text = "name or number";
                    label2.Text = "new name";
                    label3.Text = "new number";
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                }
                else
                {
                    label1.Text = "name or number";
                    label2.Text = "new name";
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = false;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = false;
                }
            }
            else
            {
                if (checkBox2.Checked == true)
                {
                    label1.Text = "name or number";
                    label2.Text = "new number";
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = false;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = false;
                }
                else
                {
                    label1.Text = "name or number";
                    label2.Text = "new name";
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                }
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                if (checkBox1.Checked == true)
                {
                    label1.Text = "name or number";
                    label2.Text = "new name";
                    label3.Text = "new number";
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                }
                else
                {
                    label1.Text = "name or number";
                    label2.Text = "new number";
                    label1.Visible = true;
                    label2.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                }
            }
            else
            {
                if (checkBox1.Checked == true)
                {
                    label1.Text = "name or number";
                    label2.Text = "new name";
                    label3.Text = "";
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = false;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = false;
                }
                else
                {
                    label1.Text = "name or number";
                    label2.Text = "";
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" && textBox2.Visible == true)
            {
                MessageBox.Show("please enter data");
                return;
            }
            if (pd1.duplicate(textBox2.Text) && textBox2.Text != "")
            {
                MessageBox.Show("this name already exists!");
                return;
            }
            if (pd1.duplicate(textBox3.Text) && textBox3.Text != "")
            {
                MessageBox.Show("this number already exists!");
                return;
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                pd1.editcontact(textBox1.Text, textBox2.Text, textBox3.Text);
                pd1.show(lb1);
                this.Close();
                return;
            }
            pd1.editcontact(textBox1.Text, textBox2.Text, checkBox1.Checked);
            pd1.show(lb1);
            this.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
