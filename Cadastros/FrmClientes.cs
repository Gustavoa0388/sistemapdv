using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace SistemaHotel.Cadastros
{
    public partial class FrmClientes : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;

        string id;
        string cpfAntigo;
        string foto;
        string alterouImagem = "nao";
        //messagem do RADIOBUTTON ao adiconar ou editar 
        string radButton = "";
        //AO SELECIONAR NA GRID mostra o radioButton
        String desbloqueado, inadiplente;
        bool emailAdress=false;

        int codCliente, IdAnterior;

        public FrmClientes()
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
            //label5.ForeColor = ThemeColor.PrimaryColor;           
            
            txtBuscarNome.ForeColor = ThemeColor.SecondaryColor;
        }

        private void FormatarGD()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Código";
            grid.Columns[2].HeaderText = "Nome";
            grid.Columns[3].HeaderText = "Cpf";
            grid.Columns[4].HeaderText = "Em Aberto";
            grid.Columns[5].HeaderText = "Telefone";
            grid.Columns[6].HeaderText = "Email";
            grid.Columns[7].HeaderText = "Desbloqueado";
            grid.Columns[8].HeaderText = "Status";
            grid.Columns[9].HeaderText = "Endereço";
            grid.Columns[10].HeaderText = "Fucionário";
            grid.Columns[11].HeaderText = "igm";
            grid.Columns[12].HeaderText = "Data";
            //grid.Columns[0].Width = 50;
            grid.Columns[0].Visible = false;
            grid.Columns[11].Visible = false;
            grid.Columns[4].DefaultCellStyle.Format = "c2";

        }
        private void Listar()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM clientes ORDER BY nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharConexao();

            FormatarGD();
        }
        private void BuscarNome()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM clientes WHERE nome LIKE @nome ORDER BY nome asc"; //LIKE, busca nome por aproximacao
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtBuscarNome.Text + "%");  //"%" - operador LIKE, busca nome por aproximacao
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharConexao();

            FormatarGD();
        }
        private void BuscarCpf()
        {
            con.AbrirConexao();
            sql = "SELECT * FROM clientes WHERE cpf=@cpf ORDER BY nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@cpf", txtBuscarCpf.Text);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharConexao();
            FormatarGD();
        }
        
        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtCpf.Enabled = true;
            txtEndereco.Enabled = true;
            txtTelefone.Enabled = true;
            txtEmail.Enabled = true;
            cbInadiplente.Enabled = true;
            txtValorAberto.Enabled = true;
            txtNome.Focus();
        }
        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCpf.Enabled = false;
            txtEndereco.Enabled = false;
            txtTelefone.Enabled = false;
            txtEmail.Enabled = false;
            cbInadiplente.Enabled = false;
            txtValorAberto.Enabled = false;
        }
        private void LimparCampos()
        {
            txtNome.Text = "";
            txtCpf.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            cbInadiplente.SelectedIndex = 0;
        }
        private void FrmHospedes_Load(object sender, EventArgs e)
        {
            rbNome.Checked = true;
            cbInadiplente.SelectedItem = 0;
            LoadTheme();
            LimparFoto();
        }

        private void rbNome_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = true;
            txtBuscarCpf.Visible = false;
            txtBuscarCpf.Text = "";
            txtBuscarNome.Text = "";
        }

        private void rbCpf_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = false;
            txtBuscarCpf.Visible = true;
            txtBuscarCpf.Text = "";
            txtBuscarNome.Text = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {            
            HabilitarCampos();
            LimparCampos();
            LimparFoto();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnImg.Enabled = true;
        }
        private void Status()
        {
            //será exibido ao SALVAR ou EDITAR, NO MESSAGEbox se LIBERADO ou INTERDITADO.

            // minha variavel 'radButton' recebe meu 'grupoBox' controle do tipo 'OfType<RadioButton>()' qual tipo q tenho? o 'radiobutton' e agora chama um METODO SingleOrDefault() que retorna o unico elemento de uma sequencia... (q vamos determinar este elemeto, neste caso que tiver Checked, ou seja marcado)
            radButton = grupoBox.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;
            //////////////////////////////////////////////////SingleOrDefault(RadioButton => rbLiberado.Checked).Text; aqui do tipo radio button passando com apontandopara 'rbLiberado.Checked' isso .TEXT pq desejo obter o nome 'Liberado'

        }
        //verificar email
        private void verificarEmail()
        {
            string email = txtEmail.Text;

            Regex rg = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

            if (rg.IsMatch(email))
            {
                emailAdress = true;
                btnSalvar.Enabled = true;                
                imgEmail.Image = Properties.Resources.OK;
            }
            else
            {
                emailAdress = false;
                btnSalvar.Enabled = false;
                imgEmail.Image = Properties.Resources.ocupado;
            }
        }
        private void ultimoIdCliente()
        {
            //recuperar ultimo id da reserva
            con.AbrirConexao();
            MySqlCommand cmdVerificar;
            MySqlDataReader reader; //com o reader vou conseguir extrair dados da tabela e usar em outros form
            cmdVerificar = new MySqlCommand("SELECT id FROM clientes ORDER BY id DESC LIMIT 1", con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            reader = cmdVerificar.ExecuteReader();
            if (reader.HasRows)
            {
                //extraíndo dados do id
                while (reader.Read())
                {
                    //codReserva = Convert.ToString(reader["id"]);
                    IdAnterior = Convert.ToInt32(reader["id"]);
                    codCliente = IdAnterior + 1;
                }
            }
            //fim recuperar ultimo id da reserva
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ultimoIdCliente();
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo nome", "Cadastro clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            if (txtCpf.Text == "   .   .   -" || txtCpf.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo CPF", "Cadastro clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpf.Focus();
                return;
            }
            if (emailAdress == false)
            {
                MessageBox.Show("email inválido!");
                txtEmail.Focus();
                return;
            }
            if (rbAtivado.Checked == true)
            {
                //botao salvar
                con.AbrirConexao();
                sql = "INSERT INTO clientes(codigo, nome, cpf, valorAberto, tel, email, desbloqueado, Inadiplente, endereco, funcionario, imagem, data) VALUES(@codigo, @nome, @cpf, @valorAberto, @tel, @email, @desbloqueado, @Inadiplente, @endereco, @funcionario, @imagem, curDate())";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@codigo", codCliente);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmd.Parameters.AddWithValue("@valorAberto", 0);
                cmd.Parameters.AddWithValue("@tel", txtTelefone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@desbloqueado", "Sim");
                cmd.Parameters.AddWithValue("@Inadiplente", "Não");
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);               
                cmd.Parameters.AddWithValue("@imagem", img()); //img() é o metodo criado p/ tratar imagem p/ o bd.                
            }
            else if (rbAtivado.Checked == false)
            {
                //botao salvar
                con.AbrirConexao();
                sql = "INSERT INTO clientes(codigo, nome, cpf, valorAberto, tel, email, desbloqueado, Inadiplente, endereco, funcionario, imagem, data) VALUES(@codigo, @nome, @cpf, @valorAberto, @tel, @email, @desbloqueado, @Inadiplente, @endereco, @funcionario, @imagem, curDate())";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@codigo", codCliente);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmd.Parameters.AddWithValue("@valorAberto", 0);
                cmd.Parameters.AddWithValue("@tel", txtTelefone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@desbloqueado", "Não");
                cmd.Parameters.AddWithValue("@Inadiplente", "Não");
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
                cmd.Parameters.AddWithValue("@imagem", img()); //img() é o metodo criado p/ tratar imagem p/ o bd. 
            }
            //Verificar se cpf ja existe  
            MySqlCommand cmdVerificar;
            cmdVerificar = new MySqlCommand("SELECT * FROM clientes WHERE cpf = @cpf", con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmdVerificar;
            cmdVerificar.Parameters.AddWithValue("@cpf", txtCpf.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("CPF já registrado", "Cadastro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCpf.Text = "";
                txtCpf.Focus();
                return;
            }

            cmd.ExecuteNonQuery();
            con.FecharConexao();

            LimparFoto();            
            Status();
            MessageBox.Show("Clientes " + txtNome.Text + " estar "+ radButton+ " e salvo com sucesso!", "Cadastro clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listar();
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            DesabilitarCampos();
            LimparCampos();
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnImg.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo nome", "Cadastro clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            if (txtCpf.Text == "   .   .   -" || txtCpf.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo CPF", "Cadastro clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpf.Focus();
                return;
            }
            if (emailAdress == false)
            {
                MessageBox.Show("email inválido!");
                txtEmail.Focus();
                return;
            }

            //botao editar
            con.AbrirConexao();

            if (alterouImagem == "sim")
            {
                if (rbAtivado.Checked == true)
                {
                    sql = "UPDATE clientes SET nome=@nome, cpf=@cpf, valorAberto=@valorAberto, tel=@tel, email=@email, desbloqueado=@desbloqueado, Inadiplente=@Inadiplente, endereco=@endereco, funcionario=@funcionario, imagem=@imagem WHERE id=@id";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@id", id); //where
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                    cmd.Parameters.AddWithValue("@valorAberto", Convert.ToDouble(txtValorAberto.Text));                    
                    cmd.Parameters.AddWithValue("@tel", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@desbloqueado", "Sim");
                    cmd.Parameters.AddWithValue("@Inadiplente", cbInadiplente.Text);
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                    cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
                    cmd.Parameters.AddWithValue("@imagem", img());
                    
                }
                else if (rbAtivado.Checked == false)
                {
                    sql = "UPDATE clientes SET nome=@nome, cpf=@cpf, valorAberto=@valorAberto, tel=@tel, email=@email, desbloqueado=@desbloqueado, Inadiplente=@Inadiplente, endereco=@endereco, funcionario=@funcionario, imagem=@imagem WHERE id=@id";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@id", id); //where
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                    cmd.Parameters.AddWithValue("@valorAberto", Convert.ToDouble(txtValorAberto.Text));
                    cmd.Parameters.AddWithValue("@tel", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@desbloqueado", "Não");
                    cmd.Parameters.AddWithValue("@Inadiplente", cbInadiplente.Text);
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                    cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
                    cmd.Parameters.AddWithValue("@imagem", img());

                }
            }
            else if (alterouImagem == "nao")
            {
                if (rbAtivado.Checked == true)
                {
                    sql = "UPDATE clientes SET nome=@nome, cpf=@cpf, valorAberto=@valorAberto, tel=@tel, email=@email, desbloqueado=@desbloqueado, Inadiplente=@Inadiplente, endereco=@endereco, funcionario=@funcionario WHERE id=@id";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@id", id); //where
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                    cmd.Parameters.AddWithValue("@valorAberto", Convert.ToDouble(txtValorAberto.Text));
                    cmd.Parameters.AddWithValue("@tel", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@desbloqueado", "Sim");
                    cmd.Parameters.AddWithValue("@Inadiplente", cbInadiplente.Text);
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                    cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);

                }
                else if (rbAtivado.Checked == false)
                {
                    sql = "UPDATE clientes SET nome=@nome, cpf=@cpf, valorAberto=@valorAberto, tel=@tel, email=@email, desbloqueado=@desbloqueado, Inadiplente=@Inadiplente, endereco=@endereco, funcionario=@funcionario WHERE id=@id";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@id", id); //where
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                    cmd.Parameters.AddWithValue("@valorAberto", Convert.ToDouble(txtValorAberto.Text));
                    cmd.Parameters.AddWithValue("@tel", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@desbloqueado", "Não");
                    cmd.Parameters.AddWithValue("@Inadiplente", cbInadiplente.Text);
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                    cmd.Parameters.AddWithValue("@funcionario", Program.NomeUsuario);
                }
            }

            //Verificar se cpf ja existe
            if (txtCpf.Text != cpfAntigo)
            {
                MySqlCommand cmdVerificar;
                cmdVerificar = new MySqlCommand("SELECT * FROM clientes WHERE cpf = @cpf", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                cmdVerificar.Parameters.AddWithValue("@cpf", txtCpf.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("CPF já registrado", "Cadastro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCpf.Text = "";
                    txtCpf.Focus();
                    return;
                }

            }
            cmd.ExecuteNonQuery();
            con.FecharConexao();            
            Status();
            MessageBox.Show("Registro Editado com sucesso: Clientes " +txtNome.Text+ " " + radButton, "Cadastro Hóspedes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            Listar();
            DesabilitarCampos();
            LimparCampos();
            LimparFoto();
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnImg.Enabled = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Deseja realmente excluir o registro!", "Cadastro clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //botao excluir
                con.AbrirConexao();
                sql = "DELETE FROM clientes WHERE id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharConexao();

                btnSalvar.Enabled = false;
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnImg.Enabled = false;

                DesabilitarCampos();
                LimparCampos();
                LimparFoto();                
                MessageBox.Show("Registro Excluído com sucesso!", "Cadastro clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                LimparFoto();               
                HabilitarCampos();                
                id = grid.CurrentRow.Cells[0].Value.ToString();
                txtCod.Text = grid.CurrentRow.Cells[1].Value.ToString();
                txtNome.Text = grid.CurrentRow.Cells[2].Value.ToString();
                cpfAntigo = grid.CurrentRow.Cells[3].Value.ToString();
                txtCpf.Text = grid.CurrentRow.Cells[3].Value.ToString();
                txtValorAberto.Text = grid.CurrentRow.Cells[4].Value.ToString();
                txtTelefone.Text = grid.CurrentRow.Cells[5].Value.ToString();
                txtEmail.Text = grid.CurrentRow.Cells[6].Value.ToString();
                desbloqueado = grid.CurrentRow.Cells[7].Value.ToString();
                cbInadiplente.Text = grid.CurrentRow.Cells[8].Value.ToString();
                txtEndereco.Text = grid.CurrentRow.Cells[9].Value.ToString();
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                btnImg.Enabled = true;
                btnNovo.Enabled = false;
                if (desbloqueado == "Sim")
                {
                    rbAtivado.Checked = true;
                    rbInativado.Checked = false;
                }
                else if (desbloqueado == "Não")
                {
                    rbAtivado.Checked = false;
                    rbInativado.Checked = true;
                }
                //imagem
                if (grid.CurrentRow.Cells[11].Value != DBNull.Value) //DBNull.Value campo quem do Banco de dado
                {
                    byte[] imagem = (byte[])grid.Rows[e.RowIndex].Cells[11].Value; //criada var byte[] imagem p/ receber convetido em byte[] o que vem da grid
                    MemoryStream ms = new MemoryStream(imagem); //recebe a var byte[] q já contem o valor da grid (decodificao/ covertido)

                    //o componete 'Image' sempre pede um 'System.Drawing' entao...
                    image.Image = System.Drawing.Image.FromStream(ms); //passando o memorystream no objeto q ele recebe um System.Drawing e seu parametor  FromStream() q vai receber o memorystream
                }
                else
                {
                    image.Image = Properties.Resources.sem_foto; //aqui coloca a imagem sem_foto na picture do form
                }
            }
            else
            {
                return;
            }           

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
        private byte[] img() //este metodo é padrao,  serve sempre q deseja enviar uma imagem para p bando de dado
        {
            byte[] imagem_byte = null; //*essa var vou usar p/ enviar o comprimento da imagem 
            if (foto == "") //a string foto, nunca vai estar vazia, pq no metodo LimparFoto() foi passado o caminho de uma imagem 'sem_foto' 
            {
                return null;
            }

            //usar o FileStream p/ enviar imagem p/ o BD e tres paramento 'local(foto), tipo de imagem(FileMode), tipo de acesso(FileAcess)'
            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read); //isso aqui é padrao, 

            BinaryReader br = new BinaryReader(fs); //serve para trabalhar com o FileStream

            imagem_byte = br.ReadBytes((int)fs.Length); //*pegAndo o comprimento de FileStream jogando dentro  de uma tipo IMAGEM BYTE

            return imagem_byte;
        }
        private void LimparFoto()
        {
            image.Image = Properties.Resources.perfil; //aqui coloca a imagem sem_foto na picture do form
            foto = "img/perfil.jpg"; //atribuindo um camiho de foto (assim este imagem tem q estar na pasta debug)
        }

        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarNome.TextLength > 0)
            {
                BuscarNome();
            }
            else if (txtBuscarNome.TextLength == 0)
            {
                Listar();
            }
        }

        private void txtBuscarCpf_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarCpf.Text == "   .   .   -")
            {
                Listar();
            }
            else 
            { 
                BuscarCpf();
            }
        }       

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (Program.chamadaHospede == "hospede")
            //{
            //    Program.nomeHospede = grid.CurrentRow.Cells[1].Value.ToString();

            //    Movimentacoes.FrmServicos form = new Movimentacoes.FrmServicos();                                
            //    form.cbHospedes.Text = Program.nomeHospede;
            //    form.lblHospede.Text = Program.nomeHospede;
                

            //    Close();               
            //}
        }

        private void rbNome_Click(object sender, EventArgs e)
        {
            rbNome.Focus();
            LimparFoto();
            LimparCampos();
        }

        private void rbCpf_Click(object sender, EventArgs e)
        {
            rbCpf.Focus();
            LimparFoto();
            LimparCampos();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            verificarEmail();
        }

        private void txtValorAberto_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatarTextNumero(sender, e);
        }

        private void txtValorAberto_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorAberto);
        }

        private void cbInadiplente_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            LimparFoto();
            DesabilitarCampos();
            grid.ClearSelection();
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnImg.Enabled = false;

        }

        //APENAS NUMEROS
        private void formatarTextNumero(object sender, KeyPressEventArgs e)
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
    }
}
