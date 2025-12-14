using FoxLearn.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Message
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

       
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        const int ProductCode = 1;
        private void FrmAbout_Load(object sender, EventArgs e)
        {
            lblProdutoID.Text = ComputerInfo.GetComputerId();
            KeyManager km = new KeyManager(lblProdutoID.Text);
            LicenseInfo lic = new LicenseInfo();
            int value = km.LoadSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), ref lic);
            string productkey = lic.ProductKey;
            if (km.ValidKey(ref productkey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productkey, ref kv))
                {
                    lblNomeProduto.Text = "Sistema Hoteleiro Zatec ";
                    lblProdutoChave.Text = productkey;
                    if (kv.Type == LicenseType.TRIAL)
                        lblTipoLicenca.Text = string.Format("{0} dias", (kv.Expiration - DateTime.Now.Date).Days);
                    else
                        lblTipoLicenca.Text = "Full";
                }
            }
        }


    }
}
