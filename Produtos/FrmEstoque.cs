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

namespace SistemaHotel.Produtos
{
    public partial class FrmEstoque : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;

        string id;
        string ultimoIdGasto;

        public FrmEstoque()
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
            
            label2.ForeColor = ThemeColor.PrimaryColor;
            
            label3.ForeColor = ThemeColor.PrimaryColor;
            
        }

        private void CarregarCampos()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM fornecedores ORDER BY nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbFornecedor.DataSource = dt;
            cbFornecedor.ValueMember = "id"; //vou usar o ID para relacionar o Produto com o Fornecedor
            cbFornecedor.DisplayMember = "nome"; //aqui mostrar o nome no comboBox
            con.FecharConexao();
        }
        private void HabilitarCampos()
        {
            
            //txtProduto.Enabled = true;
            txtValor.Enabled = true;
           //txtEstoque.Enabled = true;
            txtQuantidade.Enabled = true;
            cbFornecedor.Enabled = true;
            btnProduto.Enabled = true;
            txtQuantidade.Focus();
            btnSalvar.Enabled = true;
        }
        private void DesabilitarCampos()
        {
            txtProduto.Enabled = false;
            txtValor.Enabled = false;
            txtEstoque.Enabled = false;
            txtQuantidade.Enabled = false;
            cbFornecedor.Enabled = false;
            btnSalvar.Enabled = false;


        }
        private void LimparCampos()
        {
            txtProduto.Text = "";
            txtValor.Text = "";
            txtEstoque.Text = "";
            txtQuantidade.Text = "";
            btnSalvar.Enabled = true;
           

        }

        private void FrmEstoque_Load(object sender, EventArgs e)
        {
            CarregarCampos();
            HabilitarCampos();
            LoadTheme();
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            Program.ChamadaProdutos = "estoque";
            HabilitarCampos();
            LimparCampos();
            Produtos.FrmProdutos frm = new Produtos.FrmProdutos();
            frm.ShowDialog();
        }       

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtProduto.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo produto", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProduto.Text = "";
                txtProduto.Focus();
                return;
            }
            if (txtQuantidade.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo quantidade", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantidade.Text = "";
                txtQuantidade.Focus();
                return;
            }
            if (txtValor.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo Valor", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValor.Focus();
                return;
            }
            //botao editar
            con.AbrirConexao();
            sql = "UPDATE produtos SET estoque = @estoque, fornecedor = @fornecedor, valor_compra = @valor_compra where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", Program.IdProduto);
            cmd.Parameters.AddWithValue("@estoque", Convert.ToDouble(txtQuantidade.Text) + Convert.ToDouble(txtEstoque.Text));
            cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.SelectedValue);
            cmd.Parameters.AddWithValue("@valor_compra", txtValor.Text.Replace(",", "."));

            ////Verificar se códigp ja existe
            //if (txtCodBarra.Text != codAntigo)
            //{
            //    MySqlCommand cmdVerificar;
            //    cmdVerificar = new MySqlCommand("SELECT * FROM produtos WHERE cod = @cod", con.con);
            //    MySqlDataAdapter da = new MySqlDataAdapter();
            //    da.SelectCommand = cmdVerificar;
            //    cmdVerificar.Parameters.AddWithValue("@cod", txtCodBarra.Text);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        MessageBox.Show("Código já registrado", "Cadastro de produtos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //        txtCodBarra.Text = "";
            //        txtCodBarra.Focus();
            //        return;
            //    }

            //}
            cmd.ExecuteNonQuery();
            con.FecharConexao();
            
            MessageBox.Show("Registro lançado com sucesso!", "Cadastro estoque", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //IMPORTANTE, 1º vem a tabela de gastos, para que possa ter o id do gasto e usar na movimentacoes
            //lançar tab de Gastos
            con.AbrirConexao();
            sql = "INSERT INTO gastos(descricao, valor, funcionario, data) VALUES(@descricao, @valor, @funcionario, curDate())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@descricao", "Compra de Produtos");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtValor.Text) * Convert.ToDouble(txtQuantidade.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            cmd.ExecuteNonQuery();
            con.FecharConexao();
            // fim Gastos

            //recuperar ultimo id do GASTO
            con.AbrirConexao();
            MySqlCommand cmdVerificar;
            MySqlDataReader reader; //com o reader vou conseguir extrair dados da tabela e usar em outros form

            cmdVerificar = new MySqlCommand("SELECT id FROM gastos ORDER BY id DESC LIMIT 1", con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            reader = cmdVerificar.ExecuteReader();
            if (reader.HasRows)
            {
                //extraíndo dados do id
                while (reader.Read())
                {
                    ultimoIdGasto = Convert.ToString(reader["id"]);
                }
            }
            //fim recuperar ultimo id do GASTO

            //lançar valor do pedido nas movimentacoes
            con.AbrirConexao();
            sql = "INSERT INTO movimentacoes(tipo, movimento, valor, funcionario, data, id_movimento) VALUES(@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@tipo", "Saída");
            cmd.Parameters.AddWithValue("@movimento", "Gastos");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtValor.Text) * Convert.ToDouble(txtQuantidade.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
            //cmd.Parameters.AddWithValue("@id_movimento", "0"); //se nao precisar desse id_movimento, coloca zero
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIdGasto);
            cmd.ExecuteNonQuery();
            con.FecharConexao();
            //fim lançar valor do pedido nas movimentacoes

            DesabilitarCampos();
            LimparCampos();           

        }

        private void FrmEstoque_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmProdutos produto = new FrmProdutos();
            produto.ShowDialog();
        }
    }
}
