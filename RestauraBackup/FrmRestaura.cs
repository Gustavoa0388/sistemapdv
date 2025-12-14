using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.RestauraBackup
{
    public partial class FrmRestaura : Form
    {
        Conexao con = new Conexao();
        public FrmRestaura()
        {
            InitializeComponent();
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
            //labelCaminho.ForeColor = ThemeColor.PrimaryColor;
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog selecionar = new OpenFileDialog();
            selecionar.Filter = "Arquivos SQL (*.sql) | *.sql";
            selecionar.Title = "Selecionar caminho";
            selecionar.InitialDirectory = @"C:\";

            //a caixa de diálogo restaura o diretório atual antes de ser fechada.
            selecionar.RestoreDirectory = true;
            //A propriedade DefaultExtn representa a extensão de nome de arquivo padrão.
            selecionar.DefaultExt = "sql";

            if (selecionar.ShowDialog() == DialogResult.OK)
            {
               txtBuscar.Text = selecionar.FileName;
            }
        }

        private void FrmRestaura_Load(object sender, EventArgs e)
        {
            lblPercente.Visible = false;
            progressBar.Visible = false;
            pictureBox.Visible = false;
            timer.Enabled = false;

            LoadTheme();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text != "" && Path.GetExtension(txtBuscar.Text) == ".sql")
                {
                    timer.Enabled = true;
                    lblPercente.Visible = true;
                    progressBar.Visible = true;
                    pictureBox.Visible = true;
                    timer.Start();

                    string constring = con.conec;

                    MySqlConnection conn = new MySqlConnection(constring);
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlBackup mb = new MySqlBackup(cmd);

                    cmd.Connection = conn;
                    conn.Open();
                    mb.ImportFromFile(txtBuscar.Text);
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Não foi possível fazer restauração ", "Sistema Hotel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBuscar.Text = "";
                }
            }
            catch (Exception )
            {
                
            }
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void time()
        {
            lblPercente.Text = progressBar.Value + "%";
            if (progressBar.Value < 100)
            {
                progressBar.Value = progressBar.Value + 1;
                pictureBox.Visible = false;
            }
            else
            {
                timer.Stop();
                timer.Enabled = false;
                MessageBox.Show("Restauração realizada com sucesso", "Sistema Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBuscar.Text = "";
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            time();
        }
    }
}
