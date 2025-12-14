using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Movimentacoes
{    
    public partial class FrmQtd : Form
    {
        public FrmQtd()
        {
            InitializeComponent();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtQTD.Text) < 1)
            {
                lblAviso2.Visible = true;
                txtQTD.Focus();
                return;
            }
            //Program.qtdServico = int.Parse(txtQTD.Text);
            lblAviso2.Visible = false;
            this.Close();
        }

        private void FrmQtd_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    if (int.Parse(txtQTD.Text) < 1)
            //    {
            //        Program.qtdServico = 1;                    
            //    }
            //    else
            //    {
            //        Program.qtdServico = int.Parse(txtQTD.Text);
            //    }

            //}
            //catch (Exception)
            //{                
            //}            
        }
    }
}
