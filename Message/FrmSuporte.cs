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

namespace SistemaHotel.Message
{
    public partial class FrmSuporte : Form
    {       
        public FrmSuporte()
        {
            InitializeComponent();
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            lblTitulo.ForeColor = ThemeColor.SecondaryColor;
            
        }

        private void Enviar()
        {
            //fonte: https://www.youtube.com/watch?v=k-z_q38zdgw
            try
            {
                if (txtEmail.Text.Trim() != "")
                {
                    //corpo da email
                    MailMessage mail = new MailMessage(txtEmail.Text, "alex.zatec@gmail.com");
                    mail.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                    mail.Subject = txtTitulo.Text;
                    mail.BodyEncoding = Encoding.GetEncoding("UTF-8");
                    mail.IsBodyHtml = true;
                    mail.Body = "<p>" + txtNome.Text + "<br></br>"+txtEmail.Text +"<br></br>"+ txtMessagem.Text + "</p>";
                    //fim

                    //envio
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.UseDefaultCredentials = false; //false pq nao iremos usar a credidencias padrao, iremos usar NetworkCredential com email e senha do proprio email remetente
                    smtp.Credentials = new NetworkCredential("cursos.zatec@gmail.com", "leo741852leo");
                    smtp.EnableSsl = true; //protocolo de criptografia
                    smtp.Send(mail); // enviar
                                     //fimm
                    MessageBox.Show("Mensagem enviada com sucesso!", "Confirmação de envio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNome.Text = "NOME";
                    txtEmail.Text = "EMAIL";
                    txtTitulo.Text = "TÍTULO DA MENSAGEM";
                    txtMessagem.Text = "MENSAGEM";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Foi encontrado um erro ao enviar. Todos os campos são obrigatório.", "Erro no envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //finally
            //{
            //    this.Close();
            //}
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtTitulo.Text.Trim() == "")
            {                
                return;
            }
            if (txtNome.Text.Trim() == "")
            {
                return;
            }
            if (txtEmail.Text.Trim() == "")
            {
                return;
            }
            Enviar();
        }
        //private void txtsenha_Enter(object sender, EventArgs e)
        //{
        //    if (txtsenha.Text == "SENHA")
        //    {
        //        txtsenha.Text = "";
        //        txtsenha.ForeColor = Color.Black;
        //        txtsenha.UseSystemPasswordChar = true;

        //    }
        //}

        //private void txtsenha_Leave(object sender, EventArgs e)
        //{
        //    if (txtsenha.Text == "")
        //    {
        //        txtsenha.Text = "SENHA";
        //        txtsenha.ForeColor = Color.DimGray;
        //        txtsenha.UseSystemPasswordChar = false;

        //    }
        //}

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "EMAIL")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
                //txtsenha.Visible = true;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "EMAIL";
                txtEmail.ForeColor = Color.DimGray;
                //txtsenha.Visible = true;
            }
        }

        private void txtTitulo_Enter(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "TÍTULO DA MENSAGEM")
            {
                txtTitulo.Text = "";
                txtTitulo.ForeColor = Color.Black;
            }
        }

        private void txtTitulo_Leave(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "")
            {
                txtTitulo.Text = "TÍTULO DA MENSAGEM";
                txtTitulo.ForeColor = Color.DimGray;
            }
        }
        private void txtNome_Enter(object sender, EventArgs e)
        {
            if (txtNome.Text == "NOME")
            {
                txtNome.Text = "";
                txtNome.ForeColor = Color.Black;
                //txtsenha.Visible = true;
            }
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                txtNome.Text = "NOME";
                txtNome.ForeColor = Color.DimGray;
            }
        }

        private void txtMessagem_Enter(object sender, EventArgs e)
        {
            if (txtMessagem.Text == "MENSAGEM")
            {
                txtMessagem.Text = "";
                txtMessagem.ForeColor = Color.Black;
            }
        }
        private void txtMessagem_Leave(object sender, EventArgs e)
        {

            if (txtMessagem.Text == "")
            {
                txtMessagem.Text = "MENSAGEM";
                txtMessagem.ForeColor = Color.DimGray;
            }
        }

        private void FrmSuporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
             Enviar();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //txtsenha.Text = "SENHA";
            txtNome.Text = "NOME";
            txtEmail.Text = "EMAIL";
            txtTitulo.Text = "TÍTULO DA MENSAGEM";
            txtMessagem.Text = "MENSAGEM";
        }        
    }
        
}
