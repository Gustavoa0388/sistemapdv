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

namespace SistemaHotel.Message
{
    public partial class FrmRegistrar : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string KeyAtivar;

        public FrmRegistrar()
        {
            InitializeComponent();
        }
        private void Verificar()
        {
            MySqlCommand cmdVerificar;
            MySqlDataReader reader; //com o reader vou conseguir extrair dados da tabela e usar em outros form, neste caso quero o dinheiro e cartao de movimento
            con.AbrirConexao();
            cmdVerificar = new MySqlCommand("SELECT * FROM tela WHERE tipo=@tipo", con.con);
            cmdVerificar.Parameters.AddWithValue("@serial", txtProdutoChave);
            cmdVerificar.Parameters.AddWithValue("@tipo", "TRIAL"); // where
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            reader = cmdVerificar.ExecuteReader();
            if (reader.HasRows)
            {
                //extraíndo dados da tab quartos
                while (reader.Read())
                {
                    KeyAtivar = Convert.ToString(reader["serial"]);
                }
            }
            con.FecharConexao();
        }
        //metodo atualizar banco tela:
        private void GravarSerial()
        {
            con.AbrirConexao();
            sql = "INSERT INTO tela(serial, hide, old) VALUES(@serial, @hide, @old)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@serial", txtProdutoChave.Text);
            cmd.Parameters.AddWithValue("@hide", 1);
            cmd.Parameters.AddWithValue("@old", "s");
            //Verificar se serial ja existe  
            MySqlCommand cmdVerificar;
            cmdVerificar = new MySqlCommand("SELECT * FROM tela WHERE serial = @serial", con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            cmdVerificar.Parameters.AddWithValue("@serial", txtProdutoChave.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtProdutoChave.Text = "";
                txtProdutoChave.Focus();
                return;
            }
            cmd.ExecuteNonQuery();
            con.FecharConexao();            
        }
        const int ProductCode = 1;
        private void btnOk_Click(object sender, EventArgs e)
        {
            DateTime data1 = DateTime.Now;          
            if (data1.Day == 20)
            {
                MessageBox.Show("Esta chave é liberada para uma ativação apenas amanhã. ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (KeyAtivar == txtProdutoChave.Text)
            {
                MessageBox.Show("Essa é um chave já usada anteriomente, o uso de chave anteriores pode implicar no travamento de sistema", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProdutoChave.Text = "";
                txtProdutoChave.Focus();
                return;
            }
            GravarSerial();
            KeyManager km = new KeyManager(txtProdutoID.Text);
            string productKey = txtProdutoChave.Text;
            if (km.ValidKey(ref productKey))
            {               
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productKey, ref kv))
                {
                    LicenseInfo lic = new LicenseInfo();
                    lic.ProductKey = productKey;
                    lic.FullName = "Sistema Zatec";
                    if (kv.Type == LicenseType.TRIAL)
                    {
                        lic.Day = kv.Expiration.Day;
                        lic.Month = kv.Expiration.Month;
                        lic.Year = kv.Expiration.Year;
                    }
                    km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), lic);
                    MessageBox.Show("Obrigado por registrar! O Sistema agora será fechado, basta abrir-lo novamente.", "Registrado com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                //Program.statusAtivacao = "1";
            }
            else
            {
                MessageBox.Show("Esta licença é inválida!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void FrmRegistrar_Load(object sender, EventArgs e)
        {
            txtProdutoID.Text = ComputerInfo.GetComputerId();// DLL da FoxLearn,
            Verificar();
        }
    }
}
