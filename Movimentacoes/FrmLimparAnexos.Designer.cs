
namespace SistemaHotel.Movimentacoes
{
    partial class FrmLimparAnexos
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
            this.dtInicial = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panelBusca = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnBkp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.visto = new System.Windows.Forms.Button();
            this.panelBusca.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtInicial
            // 
            this.dtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicial.Location = new System.Drawing.Point(33, 36);
            this.dtInicial.Name = "dtInicial";
            this.dtInicial.Size = new System.Drawing.Size(100, 20);
            this.dtInicial.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "De";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selecione o intervalo de data ";
            // 
            // dtFinal
            // 
            this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFinal.Location = new System.Drawing.Point(177, 36);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(100, 20);
            this.dtFinal.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(148, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Até";
            // 
            // panelBusca
            // 
            this.panelBusca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelBusca.Controls.Add(this.lblTitulo);
            this.panelBusca.Location = new System.Drawing.Point(1, 2);
            this.panelBusca.Name = "panelBusca";
            this.panelBusca.Size = new System.Drawing.Size(1123, 50);
            this.panelBusca.TabIndex = 189;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(6, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(193, 26);
            this.lblTitulo.TabIndex = 72;
            this.lblTitulo.Text = "LIMPAR ANEXOS";
            // 
            // btnBkp
            // 
            this.btnBkp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBkp.ForeColor = System.Drawing.Color.White;
            this.btnBkp.Location = new System.Drawing.Point(424, 122);
            this.btnBkp.Name = "btnBkp";
            this.btnBkp.Size = new System.Drawing.Size(291, 23);
            this.btnBkp.TabIndex = 188;
            this.btnBkp.Text = "Efetue o backup!!!";
            this.btnBkp.UseVisualStyleBackColor = true;
            this.btnBkp.Click += new System.EventHandler(this.btnBkp_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.dtInicial);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtFinal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(424, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 108);
            this.panel1.TabIndex = 187;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(535, 288);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 186;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(421, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 13);
            this.label5.TabIndex = 191;
            this.label5.Text = "Necessário cópia de segurança antes.";
            // 
            // visto
            // 
            this.visto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.visto.Enabled = false;
            this.visto.FlatAppearance.BorderSize = 0;
            this.visto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.visto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.visto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.visto.Image = global::SistemaHotel.Properties.Resources.checado;
            this.visto.Location = new System.Drawing.Point(721, 114);
            this.visto.Name = "visto";
            this.visto.Size = new System.Drawing.Size(36, 31);
            this.visto.TabIndex = 190;
            this.visto.UseVisualStyleBackColor = true;
            this.visto.Visible = false;
            // 
            // FrmLimparAnexos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(1130, 584);
            this.Controls.Add(this.panelBusca);
            this.Controls.Add(this.btnBkp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.visto);
            this.Name = "FrmLimparAnexos";
            this.Text = "Limpar Anexos";
            this.Load += new System.EventHandler(this.FrmLimparAnexos_Load);
            this.panelBusca.ResumeLayout(false);
            this.panelBusca.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtInicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelBusca;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnBkp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button visto;
    }
}