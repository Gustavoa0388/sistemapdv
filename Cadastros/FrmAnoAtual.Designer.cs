namespace SistemaHotel.Cadastros
{
    partial class FrmAnoVirgente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnoVirgente));
            this.labelAno = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblAlterar = new System.Windows.Forms.Label();
            this.lblGravarRegistro = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.panelBusca = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelBusca.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAno
            // 
            this.labelAno.AutoSize = true;
            this.labelAno.ForeColor = System.Drawing.Color.White;
            this.labelAno.Location = new System.Drawing.Point(7, 65);
            this.labelAno.Name = "labelAno";
            this.labelAno.Size = new System.Drawing.Size(30, 13);
            this.labelAno.TabIndex = 77;
            this.labelAno.Text = "ANO";
            // 
            // txtAno
            // 
            this.txtAno.Enabled = false;
            this.txtAno.Location = new System.Drawing.Point(46, 62);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(81, 20);
            this.txtAno.TabIndex = 76;
            this.txtAno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAno_KeyPress);
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
            this.grid.Location = new System.Drawing.Point(3, 94);
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
            this.grid.Size = new System.Drawing.Size(274, 243);
            this.grid.TabIndex = 181;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
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
            this.btnEditar.Location = new System.Drawing.Point(182, 343);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(35, 35);
            this.btnEditar.TabIndex = 183;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblAlterar
            // 
            this.lblAlterar.AutoSize = true;
            this.lblAlterar.ForeColor = System.Drawing.Color.White;
            this.lblAlterar.Location = new System.Drawing.Point(183, 378);
            this.lblAlterar.Name = "lblAlterar";
            this.lblAlterar.Size = new System.Drawing.Size(33, 13);
            this.lblAlterar.TabIndex = 186;
            this.lblAlterar.Text = "editar";
            // 
            // lblGravarRegistro
            // 
            this.lblGravarRegistro.AutoSize = true;
            this.lblGravarRegistro.ForeColor = System.Drawing.Color.White;
            this.lblGravarRegistro.Location = new System.Drawing.Point(63, 378);
            this.lblGravarRegistro.Name = "lblGravarRegistro";
            this.lblGravarRegistro.Size = new System.Drawing.Size(31, 13);
            this.lblGravarRegistro.TabIndex = 189;
            this.lblGravarRegistro.Text = "novo";
            // 
            // btnNovo
            // 
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnNovo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Image = global::SistemaHotel.Properties.Resources.add;
            this.btnNovo.Location = new System.Drawing.Point(57, 343);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(35, 35);
            this.btnNovo.TabIndex = 182;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
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
            this.btnSalvar.Location = new System.Drawing.Point(121, 343);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(35, 35);
            this.btnSalvar.TabIndex = 184;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(122, 378);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 188;
            this.label14.Text = "salvar";
            // 
            // panelBusca
            // 
            this.panelBusca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelBusca.Controls.Add(this.lblTitulo);
            this.panelBusca.Location = new System.Drawing.Point(0, 2);
            this.panelBusca.Name = "panelBusca";
            this.panelBusca.Size = new System.Drawing.Size(280, 50);
            this.panelBusca.TabIndex = 190;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(3, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(134, 26);
            this.lblTitulo.TabIndex = 72;
            this.lblTitulo.Text = "CADASTRO";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.txtAno);
            this.panel1.Controls.Add(this.labelAno);
            this.panel1.Controls.Add(this.panelBusca);
            this.panel1.Controls.Add(this.grid);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lblAlterar);
            this.panel1.Controls.Add(this.btnNovo);
            this.panel1.Controls.Add(this.lblGravarRegistro);
            this.panel1.Location = new System.Drawing.Point(399, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 401);
            this.panel1.TabIndex = 191;
            // 
            // FrmAnoVirgente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1130, 584);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAnoVirgente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar ano virgente";
            this.Load += new System.EventHandler(this.FrmAnoAtual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelBusca.ResumeLayout(false);
            this.panelBusca.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelAno;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblAlterar;
        private System.Windows.Forms.Label lblGravarRegistro;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panelBusca;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
    }
}