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
    public partial class FrmEstoqueBaixo : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;

        Int32 ValorMini;
        Int32 ValorEstoque;

        public FrmEstoqueBaixo()
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
        private void FormatarGD()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Código";
            grid.Columns[2].HeaderText = "Produto";
            grid.Columns[3].HeaderText = "Descrição";
            grid.Columns[4].HeaderText = "Estoque";
            grid.Columns[5].HeaderText = "Fornecedor";
            grid.Columns[6].HeaderText = "Entrada";
            grid.Columns[7].HeaderText = "V. Pago";
            grid.Columns[8].HeaderText = "Venda";
            grid.Columns[9].HeaderText = "Custo Unit";
            grid.Columns[10].HeaderText = "Data";
            grid.Columns[11].HeaderText = "Imagem";
            //grid.Columns[12].HeaderText = "Id fornecedor";
            grid.Columns[13].HeaderText = "Mínimo";
            grid.Columns[14].HeaderText = "N. Doc";

            //gridum.Width[2] = "300";
            //formatar coluna  moeda
            grid.Columns[7].DefaultCellStyle.Format = "c2";
            grid.Columns[8].DefaultCellStyle.Format = "c2";
            grid.Columns[9].DefaultCellStyle.Format = "c2";
            grid.Columns[0].Visible = false;
            grid.Columns[11].Visible = false;
            grid.Columns[12].Visible = false;

        }
        //private void ValorMinimo()
        //{
        //    //recuperar ultimo id da reserva
        //    con.AbrirConexao();
        //    MySqlCommand cmdVerificar;
        //    MySqlDataReader reader; //com o reader vou conseguir extrair dados da tabela e usar em outros form

        //    cmdVerificar = new MySqlCommand("SELECT * FROM produtos", con.con);
        //    MySqlDataAdapter da = new MySqlDataAdapter();
        //    da.SelectCommand = cmdVerificar;
        //    reader = cmdVerificar.ExecuteReader();

        //    if (reader.HasRows)
        //    {
        //        //extraíndo dados do id
        //        while (reader.Read())
        //        {
        //            ValorMini = Convert.ToInt32(reader["minimo"]);
        //            ValorEstoque = Convert.ToInt32(reader["estoque"]);
        //        }
        //        lblMinimo.Text = Convert.ToString(ValorMini);
        //        lblEstoque.Text = Convert.ToString(ValorEstoque);
        //    }
        //}

        private void Listar()//resolvido --> WHERE estoque < pro.minimo
        {
            // inner join 
            // comparar o estoque com  o minimo declarado na entrada do produto.            

            con.AbrirConexao();
            //sql = "SELECT pro.id, pro.cod, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.entrada, pro.total_compra, pro.valor_compra, pro.valor_venda, pro.data, pro.imagem, pro.fornecedor, pro.minimo, pro.nota  FROM produtos as pro INNER JOIN fornecedores as forn  ON pro.fornecedor = forn.id WHERE estoque < @estoque ORDER BY pro.nome asc"; //LIKE, busca nome por aproximacao
            sql = "SELECT pro.id, pro.cod, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.entrada, pro.total_compra, pro.valor_compra, pro.valor_venda, pro.data, pro.imagem, pro.fornecedor, pro.minimo, pro.nota  FROM produtos as pro INNER JOIN fornecedores as forn  ON pro.fornecedor = forn.id WHERE estoque < pro.minimo ORDER BY pro.nome asc";

            cmd = new MySqlCommand(sql, con.con);
            //cmd.Parameters.AddWithValue("@estoque", 15);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharConexao();
            FormatarGD();
        }

        private void FrmEstoqueBaixo_Load(object sender, EventArgs e)
        {            
            Listar();
            LoadTheme();
            //ValorMinimo();
        }

        private void FrmEstoqueBaixo_Activated(object sender, EventArgs e)
        {
            Listar();
        }

        //private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    Program.estoqueBaixo = true;

        //    Program.IdProduto = grid.CurrentRow.Cells[0].Value.ToString();
        //    Program.NomeProduto = grid.CurrentRow.Cells[2].Value.ToString();
        //    Program.EstoqueProduto = grid.CurrentRow.Cells[4].Value.ToString();
        //    Program.EstoqueMinimo = grid.CurrentRow.Cells[12].Value.ToString();
            
        //    Produtos.FrmProdutos frm = new FrmProdutos();
        //    frm.ShowDialog();
        //}
    }
}
