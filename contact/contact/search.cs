using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contact
{
    public partial class search : Form
    {
        PhoneDirectory pd1;
        public search(PhoneDirectory pd)
        {
            InitializeComponent();
            pd1 = pd;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pd1.searchcontact(textBox1.Text, label2);
        }
    }
}
