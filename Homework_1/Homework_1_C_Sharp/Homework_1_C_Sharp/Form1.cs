using System.Windows.Forms;
using System.Text;

namespace Homework_1_C_Sharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        

        private void progressBar1_Click(object sender, EventArgs e)
        {
            if (this.progressBar1.Value != 100)
            {
                this.progressBar1.Value += 1;
            }
            if (this.progressBar1.Value == 20)
            {
                this.BackColor = Color.Red;
            }
            if (this.progressBar1.Value == 40)
            {
                this.BackColor = Color.Yellow;
            }
            if (this.progressBar1.Value == 60)
            {
                this.BackColor = Color.Blue;
            }
            if (this.progressBar1.Value == 80)
            {
                this.BackColor = Color.Violet;
            }
            if (this.progressBar1.Value == 100)
            {
                this.BackColor = Color.RosyBrown;
            }

        }

 



        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder stringB = new StringBuilder();
            foreach (var Item in listBox1.Items)
            {
                stringB.Append(Item.ToString());
                stringB.Append(" ");

            }
            MessageBox.Show(listBox1.SelectedItem.ToString());
        }


    }
}