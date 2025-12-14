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

namespace SistemaHotel.Movimentacoes
{
    public partial class FrmLimparDadosMovimentacoes : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;

        string bkpFeito;

        public FrmLimparDadosMovimentacoes()
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
            
        }

        private void FrmLimparDadosMovimentacoes_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        //metodo BackUp
        private void BackUp()
        {
            //string constring = "server=localhost;user=root;pwd=;database=hotel;"; //usar opcao abaixo 
            string constring = con.conec;

            // Important Additional Connection Options
            constring += "charset=utf8;convertzerodatetime=true;";
            string data = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            string file = "backup/backup-" + data + ".sql"; //caminho... optei criar uma pasta em BIN, DEBUG chamada backup (nome pro backup vai ser 'backup')
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd)) //instalar o pacote NuGet MySqlBackup.NET
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }
            MessageBox.Show("Back-Up " + file + ", foi realizado com sucesso", "Sistema Hotel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void LimparDados()
        {
            //formulario p/ selecionar intervalo de data para limpar do sistem            
            //MessageBox.Show(ano.ToString());
            if (bkpFeito == "Sim")
            {
                var res = MessageBox.Show("Deseja realmente LIMPAR todas as movimentações desde de " + dtInicial.Text + " até " + dtFinal.Text + " ?", " Sistema Hotel ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                //botao excluir
                con.AbrirConexao();
                sql = "DELETE FROM movimentacoes WHERE data >= @dataInicial AND data <= @dataFinal";

                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@dataInicial", Convert.ToDateTime(dtInicial.Text));
                cmd.Parameters.AddWithValue("@dataFinal", Convert.ToDateTime(dtFinal.Text));
                cmd.ExecuteNonQuery();
                con.FecharConexao();
                MessageBox.Show("Movimentações de limpa com sucesso!", "Sistema Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("NECESSÁRIO FAZER O BACKUP ANTES !!!", "Sistema Hotel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bkpFeito = "";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            LimparDados();
            visto.Visible = false;
            //this.Close();
        }

        private void btnBkp_Click(object sender, EventArgs e)
        {
            bkpFeito = "Sim";
            visto.Visible = true;
            BackUp();
        }
    }
}
