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
using System.IO;

namespace SistemaHotel.RestauraBackup
{
    public partial class FrmBackup : Form
    {   
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        public FrmBackup()
        {
            InitializeComponent();
        }
        private void time()
        {            
            if (progressBar.Value < 100)
            {
                progressBar.Value = progressBar.Value + 1;
            }
            else
            {
                timer.Stop();
                timer.Enabled = false;
                MessageBox.Show("Backup realizado com sucesso", "Sistema Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar.Visible = false;
                btnok.Enabled = true;
            }
        }


        private void btnok_Click(object sender, EventArgs e)
        {
            //string constring = "server=localhost;user=root;pwd=;database=hotel;"; //usar opcao abaixo 

            if (MessageBox.Show(Program.NomeUsuario + ", deseja realizar o backUp total do Sistema? ", "Cópia de segurança", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                timer.Enabled = true;                
                progressBar.Visible = true;
                timer.Start();
                btnok.Enabled = false;

                // Specify the directory you want to manipulate.
                string path = @"c:\Backup\";
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                    //// Delete the directory.
                    //di.Delete();
                    //Console.WriteLine("The directory was deleted successfully.");
                }
                string constring = con.conec;
                // Important Additional Connection Options
                constring += "charset=utf8;convertzerodatetime=true;";
                string data = DateTime.Now.ToString("dd-MM-yyyy-ss");
                string file = path+"backup-" + data + ".sql"; //caminho... optei criar uma pasta em C chamada Backup (nome 'backup'+data)
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
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmBackup_Load(object sender, EventArgs e)
        {            
            progressBar.Visible = false;
            timer.Enabled = false;
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
            labelTexto.ForeColor = ThemeColor.SecondaryColor;
            //label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time();
        }
    }
}