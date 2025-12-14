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

namespace SistemaHotel.Message
{
    public partial class FrmBemVindo : Form
    {
        Conexao con = new Conexao();
        public FrmBemVindo()
        {
            InitializeComponent();
        }        

        private void FrmBemVindo_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition.ShowAsyc(this); //usado transição de cor c/ delay            
        }

        private void bunifuFormFadeTransition_TransitionEnd(object sender, EventArgs e)
        {
            timer.Start();
            pictureBoxIcone.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            pictureBoxIcone.Enabled = false;
            timer.Stop();
            lblTexto.Text = "Bem Vindo, " + Program.NomeUsuario;
            btnOk.Visible = true;
        }
        private void Entrar()
        {
            //bunifuFormFadeTransition.HideAsyc(this, true); //verdadeiro p/ fechar o form depois transicao 
            this.Close();
            FormMainMenu frm = new FormMainMenu();
            frm.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Entrar();       
        }

        private void btnOk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Entrar();
            }
        }

        //public static void SHowDialog(string message)
        //{
        //    FrmBemVindo cd = new SistemaHotel.Message.FrmBemVindo();
        //}
    }
}
