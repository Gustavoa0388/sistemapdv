
namespace SistemaHotel.Message
{
    partial class FrmGerador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGerador));
            this.btnGerar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProdutoID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExpira = new System.Windows.Forms.TextBox();
            this.txtProdutoChave = new System.Windows.Forms.TextBox();
            this.cboTipoLicenca = new System.Windows.Forms.ComboBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.lblEnviar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGerar
            // 
            this.btnGerar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerar.FlatAppearance.BorderSize = 0;
            this.btnGerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerar.ForeColor = System.Drawing.Color.Black;
            this.btnGerar.Location = new System.Drawing.Point(69, 62);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(106, 23);
            this.btnGerar.TabIndex = 0;
            this.btnGerar.Text = "&Gerar Código";
            this.btnGerar.UseVisualStyleBackColor = false;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID Sistema";
            // 
            // txtProdutoID
            // 
            this.txtProdutoID.Location = new System.Drawing.Point(69, 9);
            this.txtProdutoID.Name = "txtProdutoID";
            this.txtProdutoID.ReadOnly = true;
            this.txtProdutoID.Size = new System.Drawing.Size(236, 20);
            this.txtProdutoID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Licença";
            // 
            // txtExpira
            // 
            this.txtExpira.Location = new System.Drawing.Point(12, 64);
            this.txtExpira.Name = "txtExpira";
            this.txtExpira.ReadOnly = true;
            this.txtExpira.Size = new System.Drawing.Size(35, 20);
            this.txtExpira.TabIndex = 6;
            this.txtExpira.Text = "30";
            this.txtExpira.Visible = false;
            // 
            // txtProdutoChave
            // 
            this.txtProdutoChave.Location = new System.Drawing.Point(177, 36);
            this.txtProdutoChave.Name = "txtProdutoChave";
            this.txtProdutoChave.ReadOnly = true;
            this.txtProdutoChave.Size = new System.Drawing.Size(128, 20);
            this.txtProdutoChave.TabIndex = 7;
            this.txtProdutoChave.Visible = false;
            // 
            // cboTipoLicenca
            // 
            this.cboTipoLicenca.Enabled = false;
            this.cboTipoLicenca.FormattingEnabled = true;
            this.cboTipoLicenca.Items.AddRange(new object[] {
            "TRIAL",
            "FULL"});
            this.cboTipoLicenca.Location = new System.Drawing.Point(69, 35);
            this.cboTipoLicenca.Name = "cboTipoLicenca";
            this.cboTipoLicenca.Size = new System.Drawing.Size(95, 21);
            this.cboTipoLicenca.TabIndex = 8;
            // 
            // btnValidar
            // 
            this.btnValidar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnValidar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValidar.Enabled = false;
            this.btnValidar.FlatAppearance.BorderSize = 0;
            this.btnValidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.Location = new System.Drawing.Point(196, 62);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(109, 23);
            this.btnValidar.TabIndex = 9;
            this.btnValidar.Text = "&Solicitar Chave";
            this.btnValidar.UseVisualStyleBackColor = false;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // lblEnviar
            // 
            this.lblEnviar.AutoSize = true;
            this.lblEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnviar.ForeColor = System.Drawing.Color.Yellow;
            this.lblEnviar.Location = new System.Drawing.Point(66, 92);
            this.lblEnviar.Name = "lblEnviar";
            this.lblEnviar.Size = new System.Drawing.Size(200, 13);
            this.lblEnviar.TabIndex = 10;
            this.lblEnviar.Text = "Solicitação enviada com sucesso!";
            this.lblEnviar.Visible = false;
            // 
            // FrmGerador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(66)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(327, 117);
            this.Controls.Add(this.lblEnviar);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.cboTipoLicenca);
            this.Controls.Add(this.txtProdutoChave);
            this.Controls.Add(this.txtExpira);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProdutoID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGerar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGerador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solicitar Licença de Ativação";
            this.Load += new System.EventHandler(this.FrmGerador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProdutoID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExpira;
        private System.Windows.Forms.TextBox txtProdutoChave;
        private System.Windows.Forms.ComboBox cboTipoLicenca;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Label lblEnviar;
    }
}