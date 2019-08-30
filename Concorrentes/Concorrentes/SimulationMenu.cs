using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concorrentes
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int nFrog, nFly, nSugar, nCal;
            int.TryParse(textBoxFrog.Text, out nFrog);
            int.TryParse(textBoxFly.Text, out nFly);
            int.TryParse(textBoxSugar.Text, out nSugar);
            int.TryParse(textBox2.Text, out nCal);
            var form = new Ambience(nFrog, nFly, nSugar, nCal);
            form.Show();
        }

       
    }
}
