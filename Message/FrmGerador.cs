using FoxLearn.License;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Configuration;//
using System.Net.Mime;//
using System.Threading;

namespace SistemaHotel.Message
{
    public partial class FrmGerador : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string product;

        string serial;
        string txtEmail = "projeto.zatec@gmail.com";
        string clinte = "pousadasonhoperfeito@gmail.com";

        public FrmGerador()
        {            
            InitializeComponent();            
        }
       
        //metodo que envia o serial pro email:
        private void Enviar()
        {
            //fonte: https://www.youtube.com/watch?v=k-z_q38zdgw            
            try
            {
                lblEnviar.Visible = true;
                if (txtEmail != "")
                {
                    //corpo da email
                    MailMessage mail = new MailMessage(txtEmail, "alex.zatec@gmail.com"); //quem recebe
                    mail.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                    mail.Subject = "Solicitação de Serial do Sistema Hoteleiro";
                    mail.BodyEncoding = Encoding.GetEncoding("UTF-8");
                    mail.IsBodyHtml = true;
                    mail.Body = "<p>"+"Identificação do cliente: "+ txtProdutoID.Text + "<p>"+"Cliente Sonho Perfeito: " + clinte+"</p>"+"Serial para enviar: " + serial+"</p>";
                    //fim

                    //QUEM ENVIA ---> DEVE CONFIGURAR NO PROVEDOR GMAIL ACESSO APP DE TERCEIRO
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.UseDefaultCredentials = false; //false pq nao iremos usar a credidencias padrao, iremos usar NetworkCredential com email e senha do proprio email remetente
                    smtp.Credentials = new NetworkCredential("cursos.zatec@gmail.com", "leo741852leo");
                    smtp.EnableSsl = true; //protocolo de criptografia
                    smtp.Send(mail); // enviar  
                }                
            }
            catch (Exception)
            {
                MessageBox.Show("Foi encontrado um erro no envio. Contate o administrador do sistema", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnGerar_Click(object sender, EventArgs e)
        {
            btnValidar.Enabled = true;
            lblEnviar.Visible = false;
            KeyManager km = new KeyManager(txtProdutoID.Text);
            KeyValuesClass kv;
            string productKey = string.Empty;
            if (cboTipoLicenca.SelectedIndex == 0)
            {
                kv = new KeyValuesClass()
                {
                    Type = LicenseType.FULL,
                    Header = Convert.ToByte(9),
                    Footer = Convert.ToByte(6),
                    ProductCode = (byte)ProductCode,
                    Edition = Edition.ENTERPRISE,
                    Version = 1
                };
                if (!km.GenerateKey(kv, ref productKey))
                    txtProdutoChave.Text = "ERRO";
            }
            else
            {
                kv = new KeyValuesClass()
                {
                    Type = LicenseType.TRIAL,
                    Header = Convert.ToByte(9),
                    Footer = Convert.ToByte(6),
                    ProductCode = (byte)ProductCode,
                    Edition = Edition.ENTERPRISE,
                    Version = 1,
                    Expiration = DateTime.Now.Date.AddDays(Convert.ToInt32(txtExpira.Text))
                };
                if (!km.GenerateKey(kv, ref productKey))
                    txtProdutoChave.Text = "ERRO";
            }
            txtProdutoChave.Text = productKey;
            serial = productKey;
            MessageBox.Show("Código gerado com sucesso! Clique em Solicitar Chave.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnGerar.Enabled = false;
        }

        const int ProductCode = 1;
        private void FrmGerador_Load(object sender, EventArgs e)
        {
            cboTipoLicenca.SelectedIndex = 1;
            txtProdutoID.Text = ComputerInfo.GetComputerId();// DLL da FoxLearn, 
        }
        
        private void btnValidar_Click(object sender, EventArgs e)
        {
            btnValidar.Enabled = false;
            lblEnviar.Visible = true;
            lblEnviar.Text = "ENVIANDO...";

            Enviar();
            lblEnviar.Text = "Solicitação enviada com sucesso!";
            lblEnviar.Visible = true;
            MessageBox.Show("Solicitação enviada com sucesso! Para acelerar o processo, avise ao administrador do sistema.", "Solicitação enviada com sucesso! ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }    
}
