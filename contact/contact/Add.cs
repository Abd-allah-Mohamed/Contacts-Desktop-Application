using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace contact
{
    public partial class Add : Form
    {
        PhoneDirectory pd1;
        ListBox lb1;
        public Add(PhoneDirectory pd,ListBox lb)
        {
            lb1 = lb;
            pd1 = pd;
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("please enter the name");
                return;
            }
            if (pd1.duplicate(textBox1.Text))
            {
                MessageBox.Show("this name already exists!");
                return;
            }
            if (pd1.duplicate(textBox2.Text)&& textBox2.Text!="")
            {
                MessageBox.Show("this number already exists!");
                return;
            }
            pd1.addcontact(textBox1.Text, textBox2.Text);
            pd1.show(lb1);
            this.Close();
        }
        private void addform_Load(object sender, EventArgs e)
        {
   
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
