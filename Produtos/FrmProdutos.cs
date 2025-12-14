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
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Data.SqlTypes;
using System.Globalization;

namespace SistemaHotel.Produtos
{
    public partial class FrmProdutos : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;

        string foto;
        string alterouImagem ="nao"; //quando clica no botao btnImg p/ uso de editar imagem
        string id;
        string codAntigo;
              
        double vCompra, vVenda, lucroT; // p incluir
        double eCompra, eVenda, eLucro;//para editar
        bool calcLucro = false;
        //bool lucroMod = false;
        
        int Entrada;
        //string ultimoIdGasto;        


        public FrmProdutos()
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
            //lblBuscaProduto.ForeColor = ThemeColor.SecondaryColor;
            lblTituloProdutos.ForeColor = ThemeColor.PrimaryColor;            
        }
        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            picDiversos.Location = new Point(1, 54);
            LimparFoto();
            CarregarCampos();
            Listarum();
            LoadTheme();
            cbFornecedor.SelectedIndex = 0;
            picDiversos.Location = new Point(1, 54);
            desabilitarTxt();
        }
        private void desabilitarTxt()
        {
            if (Program.DesabilitarTxt == true)
            {
                txtCodBarra.Enabled = false;
                picDiversos.Visible = true;
                lblProdutoVenda.Visible = true;
            }
            else
            { 
                txtCodBarra.Enabled = true;
                picDiversos.Visible = false;
                lblProdutoVenda.Visible = false;
            }
        }

        private void LimparFoto()
        {
            image.Image = Properties.Resources.sem_foto; //aqui coloca a imagem sem_foto na picture do form
            foto = "img/sem_foto.jpg"; //atribuindo um camiho de foto (assim este imagem tem q estar na pasta debug)
        }
        
        private void Formatargridum()
        {
            gridum.Columns[0].HeaderText = "ID";
            gridum.Columns[1].HeaderText = "Código";
            gridum.Columns[2].HeaderText = "Produto";
            gridum.Columns[3].HeaderText = "Embalagem";
            gridum.Columns[4].HeaderText = "Estoque";
            gridum.Columns[5].HeaderText = "Fornecedor";
            gridum.Columns[6].HeaderText = "Entrada";
            gridum.Columns[7].HeaderText = "V.Pago";
            gridum.Columns[8].HeaderText = "Venda";
            gridum.Columns[9].HeaderText = "CustoUnit";
            gridum.Columns[10].HeaderText = "Data";
            gridum.Columns[11].HeaderText = "Imagem";
            //gridum.Columns[12].HeaderText = "Id fornecedor";
            gridum.Columns[12].HeaderText = "Mínimo";
            gridum.Columns[13].HeaderText = "N.Doc";
            gridum.Columns[14].HeaderText = "Lucro";
            //gridum.Width[2] = "300";
            //formatar coluna  moeda
            gridum.Columns[7].DefaultCellStyle.Format = "c2";
            gridum.Columns[8].DefaultCellStyle.Format = "c2";
            gridum.Columns[9].DefaultCellStyle.Format = "c2";
            gridum.Columns[14].DefaultCellStyle.Format = "c2";
            gridum.Columns[0].Visible = false;
            gridum.Columns[11].Visible = false;
            gridum.Columns[7].Visible = false;
        }
        private void Listarum()
        {
            // inner join             // adicionar uma nova coluna na grid sem ter criar a coluna na tabela, essa nova coluna é o nome do forncedor, poderia ser telefone ou outras.
            con.AbrirConexao();
            sql = "SELECT pro.id, pro.cod, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.entrada, pro.total_compra, pro.valor_venda, pro.valor_compra, pro.data, pro.imagem, pro.minimo, pro.nota, pro.lucro FROM produtos as pro INNER JOIN fornecedores as forn  ON pro.fornecedor = forn.id ORDER BY pro.nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridum.DataSource = dt;
            con.FecharConexao();
            Formatargridum();   
        }
        private void BuscarNome()
        {
            //sql = "SELECT pro.id, pro.cod, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.entrada, pro.total_compra, pro.valor_compra, pro.valor_venda, pro.data, pro.imagem, pro.minimo, pro.nota, pro.lucro FROM produtos as pro INNER JOIN fornecedores as forn  ON pro.fornecedor = forn.id WHERE pro.nome LIKE @nome ORDER BY pro.nome asc"; //LIKE, busca nome por aproximacao

            con.AbrirConexao();
            sql = "SELECT pro.id, pro.cod, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.entrada, pro.total_compra, pro.valor_venda, pro.valor_compra, pro.data, pro.imagem, pro.minimo, pro.nota, pro.lucro FROM produtos as pro INNER JOIN fornecedores as forn  ON pro.fornecedor = forn.id WHERE pro.nome LIKE @nome ORDER BY pro.nome asc"; //LIKE, busca nome por aproximacao
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtBuscarNome.Text + "%");  //"%" - operador LIKE, busca nome por aproximacao
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridum.DataSource = dt;
            con.FecharConexao();
            Formatargridum();
        }
        private void BuscarCod()
        {
            //sql = "SELECT pro.id, pro.cod, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.entrada, pro.total_compra, pro.valor_compra, pro.valor_venda, pro.data, pro.imagem, pro.minimo, pro.nota, pro.lucro FROM produtos as pro INNER JOIN fornecedores as forn  ON pro.fornecedor = forn.id WHERE pro.cod = @cod ORDER BY pro.nome asc";

            con.AbrirConexao();
            sql = "SELECT pro.id, pro.cod, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.entrada, pro.total_compra, pro.valor_venda, pro.valor_compra, pro.data, pro.imagem, pro.minimo, pro.nota, pro.lucro FROM produtos as pro INNER JOIN fornecedores as forn  ON pro.fornecedor = forn.id WHERE pro.cod = @cod ORDER BY pro.nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@cod", txtBuscarCod.Text);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridum.DataSource = dt;
            con.FecharConexao();
            Formatargridum();
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
            txtCodBarra.Enabled = true;
            btnImg.Enabled = true;
            txtCodBarra.Focus();
        }
        private void DesabilitarCampos()
        {
            btnImg.Enabled = false;            
        }
        private void LimparCampos()
        {
            txtCodBarra.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtBuscarNome.Text = "";
            txtBuscarCod.Text = "";
            txtUnitario.Text = "0";
            txtEntrada.Text = "0";           
            txtCompra.Text = "0";
            txtValorVenda.Text = "0";
            txtEstoque.Text = "0";
            txtMinimo.Text = "0";
            txtNota.Text = "0";
            txtLucro.Text = "0";
            cbFornecedor.SelectedIndex = 0;

            lblUltimaEntrada.Text = "0";
            lblValorCompra.Text = "0,00";
            lblValorVenda.Text = "0,00";
            lblValorUnit.Text = "0,00";
            lblLucro.Text = "0,00";

            LimparFoto();
        }
        private void Cancelar()
        {
            btnIncluir.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;
            
            DesabilitarCampos();
            LimparCampos();
            Listarum();
            
        }
        
        //
        //METODO que verifica se ocodigo de barra existe. aparti disso, inclui, dá entrada ou edita
        //
        private void Produtos()
        {
            if (txtCodBarra.Text.Trim() != "")
            {                
                con.AbrirConexao();                

                //aqui p/ jogar no TEXTBOX os dados de produto
                MySqlCommand Cmm = new MySqlCommand("SELECT * FROM produtos WHERE cod = @cod", con.con);
                Cmm.CommandText = "SELECT  * from produtos where cod =  " + txtCodBarra.Text;
                Cmm.CommandType = CommandType.Text;
                Cmm.Connection = con.con;
                MySqlDataReader DR;
                DR = Cmm.ExecuteReader();
                DR.Read();

                //if (dt.Rows.Count > 0) 
                if (DR.HasRows) //existe
                {
                    calcLucro = true;
                    Program.modLucro = Convert.ToString(DR.GetMySqlDecimal(9)); //recebe valor de venda atual, p/ calcular nono lucro
                    lblL.Text = Program.modLucro;
                    

                    btnIncluir.Enabled = false;

                    btnEditar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnExcluir.Enabled = true;
                    
                    HabilitarCampos();
                    txtEstoque.Enabled = false;

                    id = Convert.ToString(DR.GetInt64(0));
                    codAntigo = Convert.ToString(DR.GetInt64(1));                    
                    txtCodBarra.Text = DR.GetString(1);
                    txtNome.Text = DR.GetString(2);
                    txtDescricao.Text = DR.GetString(3);
                    txtEstoque.Text = Convert.ToString(DR.GetInt32(4));
                    cbFornecedor.SelectedValue = Convert.ToString(DR.GetInt32(5));
                    txtEntrada.Text = "0";
                    txtCompra.Text = "0";
                    txtValorVenda.Text = "0";
                    txtUnitario.Text = "0";
                    //txtCompra.Text = Convert.ToString(DR.GetMySqlDecimal(7));
                    //txtValorVenda.Text = Convert.ToString(DR.GetMySqlDecimal(8));
                    //txtUnitario.Text = Convert.ToString(DR.GetMySqlDecimal(9));
                    data.Text = Convert.ToString(DR.GetDateTime(10));
                    txtMinimo.Text = Convert.ToString(DR.GetInt32(12));
                    txtNota.Text = Convert.ToString(DR.GetInt64(13));
                    txtLucro.Text = "0";
                    lblUltimaEntrada.Text = Convert.ToString(DR.GetDouble(6));
                    lblValorCompra.Text = Convert.ToString(DR.GetMySqlDecimal(7));
                    lblValorVenda.Text = Convert.ToString(DR.GetMySqlDecimal(8));
                    lblValorUnit.Text = Convert.ToString(DR.GetMySqlDecimal(9));
                    lblLucro.Text = Convert.ToString(DR.GetMySqlDecimal(14));
                    //numeroNotaTextBox.Text = DR.GetString(6);
                    //valorMaoObraTextBox.Text = Convert.ToString(DR.GetSqlMoney(7));
                    //idTipoPecaCombo.SelectedValue = Convert.ToString(DR.GetInt32(10));
                    //diaManutDateTimePicker.Text = Convert.ToString(DR.GetDateTime(12));                                            


                    txtCodBarra.Enabled = false;

                    //recuperando imagem do banco de dado para a picturebox, fazendo a devida conversao      
                    //testando o campo imagem se é nulo antes
                    if (gridum.CurrentRow.Cells[11].Value != DBNull.Value)
                    {
                        string img = Convert.ToString(DateTime.Now.ToFileTime());
                        byte[] bimage = (byte[])DR["imagem"];
                        FileStream fs = new FileStream(img, FileMode.CreateNew, FileAccess.Write);
                        fs.Write(bimage, 0, bimage.Length - 1);
                        fs.Close();
                        image.Image = Image.FromFile(img);
                    }
                    else
                    {
                        image.Image = Properties.Resources.sem_foto; //aqui coloca a imagem sem_foto na picture do form
                    }
                    con.FecharConexao();
                }
                else
                {
                    //nao existe                        
                    var nd = MessageBox.Show("Registro não encontrado, deseja cadastrar?", "Entrada de Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (nd == DialogResult.Yes)
                    {
                        calcLucro = false;
                        lblL.Text = "sem";
                        

                        txtNome.Text = "";
                        txtDescricao.Text = "";
                        txtUnitario.Text = "0";
                        txtEntrada.Text = "0";
                        txtCompra.Text = "0";
                        txtValorVenda.Text = "0";
                        txtEstoque.Text = "0";
                        txtMinimo.Text = "0";
                        txtNota.Text = "0";
                        txtLucro.Text = "0";
                        btnImg.Enabled = true;
                        txtCodBarra.Enabled = false;
                        txtNome.Focus();

                        LimparFoto();
                       
                        btnIncluir.Enabled = true;
                        btnEditar.Enabled = false;
                        btnCancelar.Enabled = true;
                        btnExcluir.Enabled = false;
                       
                        txtEstoque.Enabled = false;

                    }
                    else
                    {
                        LimparCampos();
                        txtCodBarra.Focus();
                        return;
                    }

                }
            }
        } 
        // Ao dá enter, verifica se ocodigo de barra existe. aparti disso, inclui, dá entrada ou edita
        private void txtCodBarra_KeyPress(object sender, KeyPressEventArgs e) //-- em execusao 31/03
        {
            formatarTextNumero(sender, e);

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnCancelar.Enabled = true;
                txtNome.Focus();
            }
        }

        // Ao pressionar TAB, verifica se ocodigo de barra existe. aparti disso, inclui, dá entrada ou edita 
        private void txtCodBarra_Validated(object sender, EventArgs e)
        {   
            btnCancelar.Enabled = true;
            Produtos();
        }

        // *** Incluir  o produto *** 
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            txtCodBarra.Enabled = true;

            if (txtCodBarra.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo Código de barra", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodBarra.Focus();
                return;
            }
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo nome", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            if (int.Parse(txtEntrada.Text) < 1)
            {
                MessageBox.Show("Preencha quantidade de Entrada", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEntrada.Text = "0";
                txtEntrada.Focus();
                return;
            }
            if (vCompra < 0.01)
            {
                MessageBox.Show("Preencha o valor total da compra", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompra.Focus();
                return;
            }
            if (Convert.ToDouble(txtValorVenda.Text) < 0.01)
            {
                MessageBox.Show("Preencha o valor da venda", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorVenda.Focus();
                return;
            }
            if (txtValorVenda.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o valor de venda", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorVenda.Focus();
                return;
            }
            vCompra = Convert.ToDouble(txtCompra.Text);
            vVenda = Convert.ToDouble(txtValorVenda.Text);
            Entrada = int.Parse(txtEntrada.Text);

            //botao salvar
            con.AbrirConexao();
            sql = "INSERT INTO produtos(cod, nome, descricao, estoque, fornecedor, entrada, total_compra, valor_venda, valor_compra, data, imagem, minimo, nota, lucro) VALUES(@cod, @nome, @descricao, @estoque, @fornecedor, @entrada, @total_compra, @valor_venda, @valor_compra, curDate(), @imagem, @minimo, @nota, @lucro)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@cod", txtCodBarra.Text);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
            cmd.Parameters.AddWithValue("@estoque", txtEntrada.Text);
            cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.SelectedValue); //aqui eu quero o valor selecionado que é o ID. p/ fazer o relacionamento.
            cmd.Parameters.AddWithValue("@entrada", txtEntrada.Text);
            cmd.Parameters.AddWithValue("@total_compra", Convert.ToDouble(txtCompra.Text));
            cmd.Parameters.AddWithValue("@valor_compra", Convert.ToDouble(txtUnitario.Text));
            cmd.Parameters.AddWithValue("@valor_venda", Convert.ToDouble(txtValorVenda.Text));
            cmd.Parameters.AddWithValue("@imagem", img()); //img() é o metodo criado p/ tratar imagem p/ o bd.
            cmd.Parameters.AddWithValue("@minimo", Convert.ToInt32(txtMinimo.Text));
            cmd.Parameters.AddWithValue("@nota", Convert.ToInt32(txtNota.Text));
            cmd.Parameters.AddWithValue("@lucro", Convert.ToDouble(txtValorVenda.Text) - Convert.ToDouble(txtUnitario.Text));
            //verificar();
            cmd.ExecuteNonQuery();
            con.FecharConexao();

            btnIncluir.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            btnExcluir.Enabled = false;

            gridum.Enabled = true;
            LimparCampos();
            gridum.Visible = true;
            //txtNota.Text = txtNota.Text;
            Listarum();
            txtCodBarra.Clear();           
            
            
            MessageBox.Show("Registro Salvo com sucesso!", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }
        // 
        // edita o produto 
        //
        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            txtCodBarra.Enabled = true; 

            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo nome", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtValorVenda.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo Valor", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtEntrada.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Verifique o campo Entrada ", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEntrada.Text = "0";
                return;
            }
            if (Convert.ToDouble(txtLucro.Text) < 0)
            {
                MessageBox.Show("Verifique os preenchimentos dos campos ENTRADA, VENDA e COMPRA se estão corretos", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLucro.Text = "0";
                return;
            }
            
            if (int.Parse(txtEntrada.Text) > 0 && Convert.ToDouble(txtCompra.Text) > 0 && Convert.ToDouble(txtValorVenda.Text) < 0.01)
            {
                MessageBox.Show("Ops, se temos a quantidade da mercadoria e temos valor de compra, especifique o valor de venda...  ", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtValorVenda.Focus();
                return;
            }

            //botao editar
            con.AbrirConexao();

            ////////////////////*********  caso 1 *************////////////////////////////
            //SEM entrada, SEM compra, SEM valor de venda
            if (alterouImagem == "sim" && int.Parse(txtEntrada.Text) < 0.01 && Convert.ToDouble(txtCompra.Text) < 0.01 && Convert.ToDouble(txtValorVenda.Text) < 0.01)
            {
                sql = "UPDATE produtos SET cod = @cod, nome = @nome, descricao = @descricao, estoque = @estoque, fornecedor = @fornecedor, entrada = @entrada, imagem = @imagem, minimo = @minimo, nota = @nota where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cod", txtCodBarra.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) + Convert.ToInt32(txtEntrada.Text));
                cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.SelectedValue);
                cmd.Parameters.AddWithValue("@entrada", txtEntrada.Text);
                cmd.Parameters.AddWithValue("@imagem", img());
                cmd.Parameters.AddWithValue("@minimo", txtMinimo.Text);
                cmd.Parameters.AddWithValue("@nota", Convert.ToInt32(txtNota.Text));

            }

            //SEM entrada, SEM compra, SEM valor de venda
            else if (alterouImagem == "nao" && int.Parse(txtEntrada.Text) < 0.01 && Convert.ToDouble(txtCompra.Text) < 0.01 && Convert.ToDouble(txtValorVenda.Text) < 0.01)
            {
                sql = "UPDATE produtos SET cod = @cod, nome = @nome, descricao = @descricao, estoque = @estoque, fornecedor = @fornecedor, entrada =@entrada, minimo = @minimo, nota = @nota where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cod", txtCodBarra.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) + Convert.ToInt32(txtEntrada.Text));
                cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.SelectedValue);
                cmd.Parameters.AddWithValue("@entrada", txtEntrada.Text);
                //cmd.Parameters.AddWithValue("@imagem", img());
                cmd.Parameters.AddWithValue("@minimo", txtMinimo.Text);
                cmd.Parameters.AddWithValue("@nota", Convert.ToInt32(txtNota.Text));

            }


            ////////////////////*********  caso 2 *************////////////////////////////

            //COM entrada, SEM compra, SEM valor de venda
            else if (alterouImagem == "sim" && int.Parse(txtEntrada.Text) > 0 && Convert.ToDouble(txtCompra.Text) < 0.01 && Convert.ToDouble(txtValorVenda.Text) < 0.01)
            {
                sql = "UPDATE produtos SET cod = @cod, nome = @nome, descricao = @descricao, estoque = @estoque, fornecedor = @fornecedor, entrada = @entrada, imagem = @imagem, minimo = @minimo, nota = @nota where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cod", txtCodBarra.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) + Convert.ToInt32(txtEntrada.Text));
                cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.SelectedValue);
                cmd.Parameters.AddWithValue("@entrada", txtEntrada.Text);
                cmd.Parameters.AddWithValue("@imagem", img());
                cmd.Parameters.AddWithValue("@minimo", txtMinimo.Text);
                cmd.Parameters.AddWithValue("@nota", Convert.ToInt32(txtNota.Text));


            }
            //COM entrada, SEM compra, SEM valor de venda
            else if (alterouImagem == "nao" && int.Parse(txtEntrada.Text) > 0 && Convert.ToDouble(txtCompra.Text) < 0.01 && Convert.ToDouble(txtValorVenda.Text) < 0.01)
            {
                sql = "UPDATE produtos SET cod = @cod, nome = @nome, descricao = @descricao, estoque = @estoque, fornecedor = @fornecedor, entrada = @entrada, minimo = @minimo, nota = @nota where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cod", txtCodBarra.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) + Convert.ToInt32(txtEntrada.Text));
                cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.SelectedValue);
                cmd.Parameters.AddWithValue("@entrada", txtEntrada.Text);
                //cmd.Parameters.AddWithValue("@imagem", img());
                cmd.Parameters.AddWithValue("@minimo", txtMinimo.Text);
                cmd.Parameters.AddWithValue("@nota", Convert.ToInt32(txtNota.Text));

            }


            ////////////////////*********  caso 3 *************////////////////////////////

            //COM entrada, COM compra, ENTAO vou ter valor unitario (terei q determinar valor de venda e o lucro automatico)
            else if (alterouImagem == "sim" && int.Parse(txtEntrada.Text) > 0 && Convert.ToDouble(txtCompra.Text) > 0 && Convert.ToDouble(txtValorVenda.Text) > 0)
            {
                if (Convert.ToDouble(txtUnitario.Text) < 1)
                {
                    MessageBox.Show("Verifique o valor de VENDA, se está correto", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCompra.Focus();
                    return;
                }
                if (int.Parse(txtValorVenda.Text) < 0.01)
                {
                    MessageBox.Show("Verifique o Valor de VENDA, se está correto", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValorVenda.Focus();
                    return;
                }                

                sql = "UPDATE produtos SET cod = @cod, nome = @nome, descricao = @descricao, estoque = @estoque, fornecedor = @fornecedor, entrada = @entrada, total_compra = @total_compra, valor_compra = @valor_compra, valor_venda = @valor_venda, imagem = @imagem, minimo = @minimo, nota = @nota, lucro = @lucro where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cod", txtCodBarra.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) + Convert.ToInt32(txtEntrada.Text) );
                cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.SelectedValue);
                cmd.Parameters.AddWithValue("@entrada", txtEntrada.Text);
                cmd.Parameters.AddWithValue("@total_compra", txtCompra.Text.Replace(",", "."));
                cmd.Parameters.AddWithValue("@valor_compra", txtUnitario.Text.Replace(",", "."));
                cmd.Parameters.AddWithValue("@valor_venda", txtValorVenda.Text.Replace(",", "."));
                cmd.Parameters.AddWithValue("@imagem", img());
                cmd.Parameters.AddWithValue("@minimo", txtMinimo.Text);
                cmd.Parameters.AddWithValue("@nota", Convert.ToInt32(txtNota.Text));
                cmd.Parameters.AddWithValue("@lucro", txtLucro.Text.Replace(",", "."));
                               
            }
            else if (alterouImagem == "nao" && int.Parse(txtEntrada.Text) > 0 && Convert.ToDouble(txtCompra.Text) > 0 && Convert.ToDouble(txtValorVenda.Text) > 0)
            {
                sql = "UPDATE produtos SET cod = @cod, nome = @nome, descricao = @descricao, estoque = @estoque, fornecedor = @fornecedor, entrada = @entrada, total_compra = @total_compra, valor_compra = @valor_compra, valor_venda = @valor_venda, minimo = @minimo, nota = @nota, lucro = @lucro where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cod", txtCodBarra.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) + Convert.ToInt32(txtEntrada.Text));
                cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.SelectedValue);
                cmd.Parameters.AddWithValue("@entrada", txtEntrada.Text);
                cmd.Parameters.AddWithValue("@total_compra", txtCompra.Text.Replace(",", "."));
                cmd.Parameters.AddWithValue("@valor_compra", txtUnitario.Text.Replace(",", "."));
                cmd.Parameters.AddWithValue("@valor_venda", txtValorVenda.Text.Replace(",", "."));
                //cmd.Parameters.AddWithValue("@imagem", img());
                cmd.Parameters.AddWithValue("@minimo", txtMinimo.Text);
                cmd.Parameters.AddWithValue("@nota", Convert.ToInt32(txtNota.Text));
                cmd.Parameters.AddWithValue("@lucro", txtLucro.Text.Replace(",", "."));

               
            }

            ////////////////////*********  caso 4 *************////////////////////////////

            //SEM entrada, SEM compra, COM valor de venda
            else if (alterouImagem == "sim" && int.Parse(txtEntrada.Text) < 1 && Convert.ToDouble(txtCompra.Text) < 0.01 && Convert.ToDouble(txtValorVenda.Text) >0)
            {
                

                sql = "UPDATE produtos SET cod = @cod, nome = @nome, descricao = @descricao, estoque = @estoque, fornecedor = @fornecedor, entrada = @entrada, valor_venda = @valor_venda, imagem = @imagem, minimo = @minimo, nota = @nota, lucro = @lucro where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cod", txtCodBarra.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) + Convert.ToInt32(txtEntrada.Text));
                cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.SelectedValue);
                cmd.Parameters.AddWithValue("@entrada", txtEntrada.Text);
                cmd.Parameters.AddWithValue("@valor_venda", txtValorVenda.Text.Replace(",", "."));
                cmd.Parameters.AddWithValue("@imagem", img());
                cmd.Parameters.AddWithValue("@minimo", txtMinimo.Text);
                cmd.Parameters.AddWithValue("@nota", Convert.ToInt32(txtNota.Text));
                cmd.Parameters.AddWithValue("@lucro", txtLucro.Text.Replace(",", "."));
                
                
            }
            //SEM entrada, SEM compra, COM valor de venda
            else if (alterouImagem == "nao" && int.Parse(txtEntrada.Text) < 1 && Convert.ToDouble(txtCompra.Text) < 0.01 && Convert.ToDouble(txtValorVenda.Text) >0)
            {
                

                sql = "UPDATE produtos SET cod = @cod, nome = @nome, descricao = @descricao, estoque = @estoque, fornecedor = @fornecedor, entrada = @entrada, valor_venda = @valor_venda, minimo = @minimo, nota = @nota, lucro = @lucro where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cod", txtCodBarra.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) + Convert.ToInt32(txtEntrada.Text));
                cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.SelectedValue);
                cmd.Parameters.AddWithValue("@entrada", txtEntrada.Text);
                cmd.Parameters.AddWithValue("@valor_venda", txtValorVenda.Text.Replace(",", "."));
                //cmd.Parameters.AddWithValue("@imagem", img());
                cmd.Parameters.AddWithValue("@minimo", txtMinimo.Text);
                cmd.Parameters.AddWithValue("@nota", Convert.ToInt32(txtNota.Text));
                cmd.Parameters.AddWithValue("@lucro", txtLucro.Text.Replace(",", "."));
                

            }

            //Verificar se códigp ja existe
            if (txtCodBarra.Text != codAntigo)
            {
                MySqlCommand cmdVerificar;
                cmdVerificar = new MySqlCommand("SELECT * FROM produtos WHERE cod = @cod", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                cmdVerificar.Parameters.AddWithValue("@cod", txtCodBarra.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Código já registrado", "Cadastro de produtos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCodBarra.Text = "";
                    txtCodBarra.Focus();
                    return;
                }
            }
            cmd.ExecuteNonQuery();
            con.FecharConexao();

            btnIncluir.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            btnExcluir.Enabled = false;
            gridum.Enabled = true;
            
            alterouImagem = "nao"; //p/ uso de editar imagem            
            txtCodBarra.Clear();
            MessageBox.Show("Mercadoria editado com sucesso!", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimparCampos();
            DesabilitarCampos();
            Listarum();

        }
        
        
        private void verificar()
        {
            //Verificar se cod ja existe  
            MySqlCommand cmdVerificar;
            cmdVerificar = new MySqlCommand("SELECT * FROM produtos WHERE cod = @cod", con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            cmdVerificar.Parameters.AddWithValue("@cod", txtCodBarra.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Código de barra já registrado", "Cadastro de produtos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCodBarra.Text = "";
                txtCodBarra.Focus();
                return;
            }
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Deseja realmente excluir o prooduto " + txtNome.Text+ "?", "Cadastro produtos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //botao excluir
                con.AbrirConexao();
                sql = "DELETE FROM produtos WHERE id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharConexao();
                Listarum();
                MessageBox.Show("Registro Excluído com sucesso!", "Cadastro produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cancelar();
                gridum.Enabled = true;
                txtCodBarra.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
            gridum.Enabled = true;
            btnIncluir.Enabled = false;

            txtBuscarCod.Text = "";
            txtBuscarNome.Text = "";

            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            txtCodBarra.Enabled = true;
            txtCodBarra.Focus();
            LimparFoto();
        }
        private void btnImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "Arquivos(*.jpg)|*.jpg | Arquivos(*.PNG)| *.png;| All (*.*) | *.*"; //mostra uma de cada vez
            dialog.Filter = "Imagens(*.jpg; *.png) | *.jpg;*.png"; //mostra jpg e png
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foto = dialog.FileName.ToString(); //pegando o caminho da imagem q selecionei e dei ok
                image.ImageLocation = foto; //jogando caminho da imagem p/ componete img p/ exibir no form
                alterouImagem = "sim"; //p/ uso editar alterando a imagem
            }
        }
        
        private void gridum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                LimparFoto();
                LimparCampos();
                //Cancelar();

                txtCodBarra.Text = gridum.Rows[e.RowIndex].Cells[1].Value.ToString(); //receber o código do prod.

                //txtCodBarra.Text = gridum.CurrentRow.Cells[1].Value.ToString();

                if (gridum.CurrentRow.Cells[11].Value != DBNull.Value) //DBNull.Value campo quem do Banco de dado
                {
                    byte[] imagem = (byte[])gridum.Rows[e.RowIndex].Cells[11].Value; //criada var byte[] imagem p/ receber convetido em byte[] o que vem da grid
                    MemoryStream ms = new MemoryStream(imagem); //recebe a var byte[] q já contem o valor da grid (decodificao/ covertido)

                    //o componete 'Image' sempre pede um 'System.Drawing' entao...
                    image.Image = System.Drawing.Image.FromStream(ms); //passando o memorystream no objeto q ele recebe um System.Drawing e seu parametor  FromStream() q vai receber o memorystream

                }
                else
                {
                    image.Image = Properties.Resources.sem_foto; //aqui coloca a imagem sem_foto na picture do form
                }
                txtCodBarra.Enabled = true;
                txtCodBarra.Focus();
                txtBuscarNome.Text = "";
                txtBuscarCod.Text = "";
            }
            else { return; }

        }

        private void gridum_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Program.ChamadaProdutos == "estoque")
                {
                    Program.IdProduto = gridum.CurrentRow.Cells[0].Value.ToString();
                    Program.NomeProduto = gridum.CurrentRow.Cells[2].Value.ToString();
                    Program.EstoqueProduto = gridum.CurrentRow.Cells[4].Value.ToString();
                    Program.ValorProduto = gridum.CurrentRow.Cells[8].Value.ToString(); //venda

                    //Movimentacoes.FrmVendas frm = new Movimentacoes.FrmVendas();

                    //frm.txtProduto.Text = Program.NomeProduto;
                    //frm.txtEstoque.Text = Program.EstoqueProduto;
                    //frm.txtValor.Text = Program.ValorProduto;
                    ////frm.txtQuantidade.SelectAll();
                    Close();
                }
                else
                {
                    //Produtos.FrmEstoque frm = new FrmEstoque();
                    //frm.ShowDialog();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
            gridum.Visible = true;
        }

        private void txtBuscarCod_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarCod.Text == "")
            {
                Listarum();
            }
            else
            {
                BuscarCod();
                gridum.ClearSelection();
                
                txtCodBarra.Text = txtBuscarCod.Text;
            }
        }

        
        private byte[] img() //este metodo é padrao,  serve sempre q deseja enviar uma imagem para p bando de dado
        {
            byte[] imagem_byte = null; //*essa var vou usar p/ enviar o comprimento da imagem 
            if (foto =="") //a string foto, nunca vai estar vazia, pq no metodo LimparFoto() foi passado o caminho de uma imagem 'sem_foto' 
            {
                return  null;
            }
            
            //usar o FileStream p/ enviar imagem p/ o BD e tres paramento 'local(foto), tipo de imagem(FileMode), tipo de acesso(FileAcess)'
            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read); //isso aqui é padrao, 

            BinaryReader br = new BinaryReader(fs); //serve para trabalhar com o FileStream

            imagem_byte = br.ReadBytes((int)fs.Length); //*pegAndo o comprimento de FileStream jogando dentro  de uma tipo IMAGEM BYTE

            return imagem_byte;
        } 

        //APENAS NUMEROS
        private void formatarTextNumero(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -2)
                {
                    e.Handled = true;
                }


                if (e.KeyChar == ','
                    && (sender as TextBox).Text.IndexOf(',') > -2)
                {
                    e.Handled = true;
                }

                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                                
            }
        }

        //TextBox ao digitar apresenta no formato moeda
        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;
            double v = 0;

            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(2, '0');

                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);

                v = Convert.ToDouble(n) / 100;

                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception)
            {
            }
        }        
        
        private void txtBuscarCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatarTextNumero(sender, e);           
            
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //Verificar se cod ja existe
                                
            }
        }

        private void txtCompra_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtCompra);

            if (Convert.ToDouble(txtCompra.Text) < 0.01)
            {
                txtUnitario.Text = "0";
            }
            else
            {               
                if (txtEntrada.Text.ToString().Trim() != "")
                {
                    vCompra = Convert.ToDouble(txtCompra.Text);
                    Entrada = Convert.ToInt32(txtEntrada.Text);
                    var rs = vCompra / Entrada;
                    //txtUnitario.Text = rs.ToString();
                    txtUnitario.Text = string.Format("{0:N}", rs);
                }
            }            

        }
        private void cbFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //bloqueia a digitação,
            e.Handled = true;
        }        

        private void txtMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatarTextNumero(sender, e);
        }
        private void txtEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatarTextNumero(sender, e);
            
        }
        private void txtCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatarTextNumero(sender, e);
        }

        private void txtEntrada_Validated(object sender, EventArgs e)
        {
            txtLucro.Text = "0";
            if(txtEntrada.Text.ToString().Trim() != "")
            {
                vCompra = Convert.ToDouble(txtCompra.Text);
                Entrada = Convert.ToInt32(txtEntrada.Text);
                var rs = vCompra / Entrada;
                //txtUnitario.Text = rs.ToString();
                txtUnitario.Text = string.Format("{0:N}", rs);
            }
            
        }

        private void txtEntrada_Click(object sender, EventArgs e)
        {            
            txtEntrada.Text = "";
            txtCompra.Text = "0";
            txtUnitario.Text = "0";
            txtValorVenda.Text = "0";
            txtLucro.Text = "0";  
        }
        
        private void txtEntrada_TextChanged(object sender, EventArgs e)
        {              
            if (calcLucro == true)
            {
                vVenda = Convert.ToDouble(txtValorVenda.Text);
                var tLucro = Convert.ToDouble(txtValorVenda.Text) - Convert.ToDouble(txtUnitario.Text);
                txtLucro.Text = String.Format("{0:N}", tLucro);
            }
            
        }        

        private void txtBuscarCod_Click(object sender, EventArgs e)
        {
            txtBuscarNome.Text = "";
            txtCodBarra.Enabled = true;
            LimparCampos();

        }

        private void txtBuscarNome_Click(object sender, EventArgs e)
        {
            txtBuscarCod.Text = "";
            txtCodBarra.Enabled = true;
            LimparCampos();
        }

        private void txtCompra_Click(object sender, EventArgs e)
        {
            txtCompra.Text = "";
        }

        private void txtValorVenda_Click(object sender, EventArgs e)
        {
            txtValorVenda.Text = "";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatarTextNumero(sender, e);            
        }        

        private void txtCodBarra_Click(object sender, EventArgs e)
        {
            txtBuscarNome.Text = "";
            txtBuscarCod.Text = "";
        }        

        private void txtNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatarTextNumero(sender, e);
        }
        private void txtValorVenda_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorVenda);              
            
            if (calcLucro == true) //registro existente, modificar o lucro baseado na label
            {                
                eVenda = Convert.ToDouble(txtValorVenda.Text);
                eCompra = Convert.ToDouble(Program.modLucro); //recebe valor de venda atual, p/ calcular nono lucro

                eLucro = (eVenda - (eCompra/100));
                txtLucro.Text = Convert.ToString(eLucro);
                lucro1.Text = Convert.ToString(eLucro);                

            }
            if (calcLucro == false)
            {
                vVenda = Convert.ToDouble(txtValorVenda.Text);
                var tLucro = Convert.ToDouble(txtValorVenda.Text) - Convert.ToDouble(txtUnitario.Text);
                txtLucro.Text = String.Format("{0:C2}", tLucro);
            }

        }
        
        

    }//fim
}
