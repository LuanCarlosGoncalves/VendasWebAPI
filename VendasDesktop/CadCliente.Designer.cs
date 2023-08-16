namespace VendasDesktop
{
    partial class CadCliente
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
            btnSalvar = new Button();
            txtNome = new TextBox();
            txtEndereco = new TextBox();
            txtTelefone = new TextBox();
            txtProfissao = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(59, 272);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(138, 38);
            btnSalvar.TabIndex = 0;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(59, 60);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(371, 23);
            txtNome.TabIndex = 1;
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(59, 116);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(371, 23);
            txtEndereco.TabIndex = 2;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(59, 176);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(371, 23);
            txtTelefone.TabIndex = 3;
            // 
            // txtProfissao
            // 
            txtProfissao.Location = new Point(59, 221);
            txtProfissao.Name = "txtProfissao";
            txtProfissao.Size = new Size(371, 23);
            txtProfissao.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 41);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 5;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 98);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 6;
            label2.Text = "Endereco:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 158);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 7;
            label3.Text = "Telefone:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(59, 203);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 8;
            label4.Text = "Profissão:";
            // 
            // CadCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 483);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtProfissao);
            Controls.Add(txtTelefone);
            Controls.Add(txtEndereco);
            Controls.Add(txtNome);
            Controls.Add(btnSalvar);
            Name = "CadCliente";
            Text = "Cadastro de cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalvar;
        private TextBox txtNome;
        private TextBox txtEndereco;
        private TextBox txtTelefone;
        private TextBox txtProfissao;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}