namespace PetShopSistema.UI
{
    partial class FormCliente
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
            this.label_usuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPets = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbServicos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDataHora = new System.Windows.Forms.DateTimePicker();
            this.btnAgendar = new System.Windows.Forms.Button();
            this.dgvAgendamentos = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgendamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // label_usuario
            // 
            this.label_usuario.AutoSize = true;
            this.label_usuario.Font = new System.Drawing.Font("Segoe UI Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_usuario.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_usuario.Location = new System.Drawing.Point(12, 9);
            this.label_usuario.Name = "label_usuario";
            this.label_usuario.Size = new System.Drawing.Size(281, 81);
            this.label_usuario.TabIndex = 13;
            this.label_usuario.Text = "PetShop";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(387, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 54);
            this.label1.TabIndex = 14;
            this.label1.Text = "Agendamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(318, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Escolha o pet";
            // 
            // cmbPets
            // 
            this.cmbPets.FormattingEnabled = true;
            this.cmbPets.Location = new System.Drawing.Point(425, 137);
            this.cmbPets.Name = "cmbPets";
            this.cmbPets.Size = new System.Drawing.Size(121, 24);
            this.cmbPets.TabIndex = 17;
            this.cmbPets.SelectedIndexChanged += new System.EventHandler(this.cmbPets_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Escolha o serviço";
            // 
            // cmbServicos
            // 
            this.cmbServicos.FormattingEnabled = true;
            this.cmbServicos.Location = new System.Drawing.Point(425, 180);
            this.cmbServicos.Name = "cmbServicos";
            this.cmbServicos.Size = new System.Drawing.Size(121, 24);
            this.cmbServicos.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(263, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Escolha a data e hora";
            // 
            // dtpDataHora
            // 
            this.dtpDataHora.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDataHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataHora.Location = new System.Drawing.Point(425, 222);
            this.dtpDataHora.Name = "dtpDataHora";
            this.dtpDataHora.Size = new System.Drawing.Size(200, 22);
            this.dtpDataHora.TabIndex = 21;
            // 
            // btnAgendar
            // 
            this.btnAgendar.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgendar.Location = new System.Drawing.Point(425, 274);
            this.btnAgendar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgendar.Name = "btnAgendar";
            this.btnAgendar.Size = new System.Drawing.Size(200, 62);
            this.btnAgendar.TabIndex = 33;
            this.btnAgendar.Text = "Confirmar o agendamento";
            this.btnAgendar.UseVisualStyleBackColor = true;
            this.btnAgendar.Click += new System.EventHandler(this.btnAgendar_Click_1);
            // 
            // dgvAgendamentos
            // 
            this.dgvAgendamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgendamentos.Location = new System.Drawing.Point(12, 105);
            this.dgvAgendamentos.Name = "dgvAgendamentos";
            this.dgvAgendamentos.RowHeadersWidth = 51;
            this.dgvAgendamentos.RowTemplate.Height = 24;
            this.dgvAgendamentos.Size = new System.Drawing.Size(240, 150);
            this.dgvAgendamentos.TabIndex = 34;
            this.dgvAgendamentos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAgendamentos_CellContentClick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkRed;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(718, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 33);
            this.button4.TabIndex = 36;
            this.button4.Text = "Fechar";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dgvAgendamentos);
            this.Controls.Add(this.btnAgendar);
            this.Controls.Add(this.dtpDataHora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbServicos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_usuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCliente";
            this.Text = "FormCliente";
            this.Load += new System.EventHandler(this.FormCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgendamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_usuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbServicos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDataHora;
        private System.Windows.Forms.Button btnAgendar;
        private System.Windows.Forms.DataGridView dgvAgendamentos;
        private System.Windows.Forms.Button button4;
    }
}