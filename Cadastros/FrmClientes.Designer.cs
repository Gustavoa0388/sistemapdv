namespace SistemaHotel.Cadastros
{
    partial class FrmClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rbCpf = new System.Windows.Forms.RadioButton();
            this.rbNome = new System.Windows.Forms.RadioButton();
            this.txtBuscarCpf = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCpf = new System.Windows.Forms.MaskedTextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscarNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.panelBusca = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblAlterar = new System.Windows.Forms.Label();
            this.lblGravarRegistro = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.PictureBox();
            this.labelescolher = new System.Windows.Forms.Label();
            this.btnImg = new System.Windows.Forms.Button();
            this.grupoBox = new System.Windows.Forms.GroupBox();
            this.rbAtivado = new System.Windows.Forms.RadioButton();
            this.rbInativado = new System.Windows.Forms.RadioButton();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.imgEmail = new System.Windows.Forms.PictureBox();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorAberto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbInadiplente = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelBusca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.grupoBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // rbCpf
            // 
            this.rbCpf.AutoSize = true;
            this.rbCpf.Location = new System.Drawing.Point(485, 16);
            this.rbCpf.Name = "rbCpf";
            this.rbCpf.Size = new System.Drawing.Size(45, 17);
            this.rbCpf.TabIndex = 53;
            this.rbCpf.TabStop = true;
            this.rbCpf.Text = "CPF";
            this.rbCpf.UseVisualStyleBackColor = true;
            this.rbCpf.CheckedChanged += new System.EventHandler(this.rbCpf_CheckedChanged);
            this.rbCpf.Click += new System.EventHandler(this.rbCpf_Click);
            // 
            // rbNome
            // 
            this.rbNome.AutoSize = true;
            this.rbNome.Location = new System.Drawing.Point(426, 16);
            this.rbNome.Name = "rbNome";
            this.rbNome.Size = new System.Drawing.Size(53, 17);
            this.rbNome.TabIndex = 52;
            this.rbNome.TabStop = true;
            this.rbNome.Text = "Nome";
            this.rbNome.UseVisualStyleBackColor = true;
            this.rbNome.CheckedChanged += new System.EventHandler(this.rbNome_CheckedChanged);
            this.rbNome.Click += new System.EventHandler(this.rbNome_Click);
            // 
            // txtBuscarCpf
            // 
            this.txtBuscarCpf.Location = new System.Drawing.Point(591, 15);
            this.txtBuscarCpf.Mask = "000,000,000-00";
            this.txtBuscarCpf.Name = "txtBuscarCpf";
            this.txtBuscarCpf.Size = new System.Drawing.Size(100, 20);
            this.txtBuscarCpf.TabIndex = 51;
            this.txtBuscarCpf.Visible = false;
            this.txtBuscarCpf.TextChanged += new System.EventHandler(this.txtBuscarCpf_TextChanged);
            // 
            // txtTelefone
            // 
            this.txtTelefone.Enabled = false;
            this.txtTelefone.Location = new System.Drawing.Point(711, 60);
            this.txtTelefone.Mask = "(99) 00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(87, 20);
            this.txtTelefone.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(683, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Tel.";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Enabled = false;
            this.txtEndereco.Location = new System.Drawing.Point(62, 85);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(493, 20);
            this.txtEndereco.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Endereço";
            // 
            // txtCpf
            // 
            this.txtCpf.Enabled = false;
            this.txtCpf.Location = new System.Drawing.Point(594, 60);
            this.txtCpf.Mask = "000,000,000-00";
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(87, 20);
            this.txtCpf.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Location = new System.Drawing.Point(62, 60);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(380, 20);
            this.txtNome.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(561, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "CPF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Nome";
            // 
            // txtBuscarNome
            // 
            this.txtBuscarNome.Location = new System.Drawing.Point(591, 16);
            this.txtBuscarNome.Name = "txtBuscarNome";
            this.txtBuscarNome.Size = new System.Drawing.Size(453, 20);
            this.txtBuscarNome.TabIndex = 44;
            this.txtBuscarNome.TextChanged += new System.EventHandler(this.txtBuscarNome_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(544, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Busca";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 30;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.GridColor = System.Drawing.Color.SteelBlue;
            this.grid.Location = new System.Drawing.Point(3, 209);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(1121, 305);
            this.grid.TabIndex = 132;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // panelBusca
            // 
            this.panelBusca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelBusca.Controls.Add(this.txtBuscarCpf);
            this.panelBusca.Controls.Add(this.lblTitulo);
            this.panelBusca.Controls.Add(this.txtBuscarNome);
            this.panelBusca.Controls.Add(this.label1);
            this.panelBusca.Controls.Add(this.rbNome);
            this.panelBusca.Controls.Add(this.rbCpf);
            this.panelBusca.Location = new System.Drawing.Point(1, 4);
            this.panelBusca.Name = "panelBusca";
            this.panelBusca.Size = new System.Drawing.Size(1123, 50);
            this.panelBusca.TabIndex = 149;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(6, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(269, 26);
            this.lblTitulo.TabIndex = 72;
            this.lblTitulo.Text = "CADASTRO DE CLIENTE";
            // 
            // btnEditar
            // 
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Enabled = false;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Image = global::SistemaHotel.Properties.Resources.editar_property;
            this.btnEditar.Location = new System.Drawing.Point(250, 519);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(35, 35);
            this.btnEditar.TabIndex = 163;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblAlterar
            // 
            this.lblAlterar.AutoSize = true;
            this.lblAlterar.ForeColor = System.Drawing.Color.White;
            this.lblAlterar.Location = new System.Drawing.Point(237, 561);
            this.lblAlterar.Name = "lblAlterar";
            this.lblAlterar.Size = new System.Drawing.Size(57, 13);
            this.lblAlterar.TabIndex = 166;
            this.lblAlterar.Text = "ALTERAR";
            // 
            // lblGravarRegistro
            // 
            this.lblGravarRegistro.AutoSize = true;
            this.lblGravarRegistro.ForeColor = System.Drawing.Color.White;
            this.lblGravarRegistro.Location = new System.Drawing.Point(41, 561);
            this.lblGravarRegistro.Name = "lblGravarRegistro";
            this.lblGravarRegistro.Size = new System.Drawing.Size(38, 13);
            this.lblGravarRegistro.TabIndex = 169;
            this.lblGravarRegistro.Text = "NOVO";
            // 
            // btnNovo
            // 
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnNovo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Image = global::SistemaHotel.Properties.Resources.add;
            this.btnNovo.Location = new System.Drawing.Point(43, 519);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(35, 35);
            this.btnNovo.TabIndex = 162;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnExcluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Image = global::SistemaHotel.Properties.Resources.excluir;
            this.btnExcluir.Location = new System.Drawing.Point(342, 519);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(35, 35);
            this.btnExcluir.TabIndex = 165;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(335, 561);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 167;
            this.label13.Text = "EXCLUIR";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Image = global::SistemaHotel.Properties.Resources.save_2;
            this.btnSalvar.Location = new System.Drawing.Point(148, 519);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(35, 35);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(142, 561);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 168;
            this.label14.Text = "SALVAR";
            // 
            // image
            // 
            this.image.Image = global::SistemaHotel.Properties.Resources.perfil;
            this.image.Location = new System.Drawing.Point(976, 60);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(148, 145);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 170;
            this.image.TabStop = false;
            // 
            // labelescolher
            // 
            this.labelescolher.AutoSize = true;
            this.labelescolher.ForeColor = System.Drawing.Color.White;
            this.labelescolher.Location = new System.Drawing.Point(938, 160);
            this.labelescolher.Name = "labelescolher";
            this.labelescolher.Size = new System.Drawing.Size(28, 13);
            this.labelescolher.TabIndex = 172;
            this.labelescolher.Text = "Foto";
            // 
            // btnImg
            // 
            this.btnImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.btnImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImg.Enabled = false;
            this.btnImg.FlatAppearance.BorderSize = 0;
            this.btnImg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnImg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.btnImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImg.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnImg.Image = global::SistemaHotel.Properties.Resources.image;
            this.btnImg.Location = new System.Drawing.Point(931, 168);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(43, 37);
            this.btnImg.TabIndex = 171;
            this.btnImg.UseVisualStyleBackColor = false;
            this.btnImg.Click += new System.EventHandler(this.btnImg_Click);
            // 
            // grupoBox
            // 
            this.grupoBox.Controls.Add(this.rbAtivado);
            this.grupoBox.Controls.Add(this.rbInativado);
            this.grupoBox.ForeColor = System.Drawing.Color.White;
            this.grupoBox.Location = new System.Drawing.Point(803, 60);
            this.grupoBox.Name = "grupoBox";
            this.grupoBox.Size = new System.Drawing.Size(169, 75);
            this.grupoBox.TabIndex = 173;
            this.grupoBox.TabStop = false;
            this.grupoBox.Text = "Status do cliente?";
            // 
            // rbAtivado
            // 
            this.rbAtivado.AutoSize = true;
            this.rbAtivado.Checked = true;
            this.rbAtivado.ForeColor = System.Drawing.Color.White;
            this.rbAtivado.Location = new System.Drawing.Point(14, 28);
            this.rbAtivado.Name = "rbAtivado";
            this.rbAtivado.Size = new System.Drawing.Size(94, 17);
            this.rbAtivado.TabIndex = 80;
            this.rbAtivado.TabStop = true;
            this.rbAtivado.Text = "Desbloqueado";
            this.rbAtivado.UseVisualStyleBackColor = true;
            // 
            // rbInativado
            // 
            this.rbInativado.AutoSize = true;
            this.rbInativado.ForeColor = System.Drawing.Color.White;
            this.rbInativado.Location = new System.Drawing.Point(14, 52);
            this.rbInativado.Name = "rbInativado";
            this.rbInativado.Size = new System.Drawing.Size(76, 17);
            this.rbInativado.TabIndex = 76;
            this.rbInativado.Text = "Bloqueado";
            this.rbInativado.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(62, 112);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(493, 20);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 175;
            this.label8.Text = "Email";
            // 
            // imgEmail
            // 
            this.imgEmail.Image = global::SistemaHotel.Properties.Resources.adevertencia;
            this.imgEmail.Location = new System.Drawing.Point(557, 110);
            this.imgEmail.Name = "imgEmail";
            this.imgEmail.Size = new System.Drawing.Size(25, 22);
            this.imgEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgEmail.TabIndex = 176;
            this.imgEmail.TabStop = false;
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(472, 60);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(83, 20);
            this.txtCod.TabIndex = 177;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(446, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 178;
            this.label6.Text = "Cód";
            // 
            // txtValorAberto
            // 
            this.txtValorAberto.Enabled = false;
            this.txtValorAberto.Location = new System.Drawing.Point(712, 88);
            this.txtValorAberto.Name = "txtValorAberto";
            this.txtValorAberto.Size = new System.Drawing.Size(86, 20);
            this.txtValorAberto.TabIndex = 179;
            this.txtValorAberto.Text = "0";
            this.txtValorAberto.TextChanged += new System.EventHandler(this.txtValorAberto_TextChanged);
            this.txtValorAberto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorAberto_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(644, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 180;
            this.label7.Text = "Valor Aberto";
            // 
            // cbInadiplente
            // 
            this.cbInadiplente.Enabled = false;
            this.cbInadiplente.FormattingEnabled = true;
            this.cbInadiplente.Items.AddRange(new object[] {
            "Não",
            "Sim"});
            this.cbInadiplente.Location = new System.Drawing.Point(711, 112);
            this.cbInadiplente.Name = "cbInadiplente";
            this.cbInadiplente.Size = new System.Drawing.Size(86, 21);
            this.cbInadiplente.TabIndex = 181;
            this.cbInadiplente.Text = "Não";
            this.cbInadiplente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbInadiplente_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(650, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 182;
            this.label9.Text = "Inadiplente";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::SistemaHotel.Properties.Resources.cancel;
            this.btnCancelar.Location = new System.Drawing.Point(437, 519);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(35, 35);
            this.btnCancelar.TabIndex = 183;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(420, 561);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 184;
            this.label10.Text = "CANCELAR";
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(1130, 584);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbInadiplente);
            this.Controls.Add(this.txtValorAberto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.image);
            this.Controls.Add(this.labelescolher);
            this.Controls.Add(this.btnImg);
            this.Controls.Add(this.imgEmail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.grupoBox);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblAlterar);
            this.Controls.Add(this.lblGravarRegistro);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panelBusca);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Clientes";
            this.Load += new System.EventHandler(this.FrmHospedes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelBusca.ResumeLayout(false);
            this.panelBusca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.grupoBox.ResumeLayout(false);
            this.grupoBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgEmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbCpf;
        private System.Windows.Forms.RadioButton rbNome;
        private System.Windows.Forms.MaskedTextBox txtBuscarCpf;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtCpf;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscarNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panelBusca;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblAlterar;
        private System.Windows.Forms.Label lblGravarRegistro;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Label labelescolher;
        private System.Windows.Forms.Button btnImg;
        private System.Windows.Forms.GroupBox grupoBox;
        private System.Windows.Forms.RadioButton rbAtivado;
        private System.Windows.Forms.RadioButton rbInativado;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox imgEmail;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValorAberto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbInadiplente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label10;
    }
}