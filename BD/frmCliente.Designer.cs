
namespace BD
{
    partial class frmCliente
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.grpDadosCliente = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idCliente = new System.Windows.Forms.Label();
            this.Nome = new System.Windows.Forms.Label();
            this.cnpj_cpf = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCnpjCpf = new System.Windows.Forms.TextBox();
            this.grpDadosCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(331, 84);
            this.button1.TabIndex = 0;
            this.button1.Text = "Carregar Clientes (SELECT)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cmdSelect);
            // 
            // lstClientes
            // 
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.Location = new System.Drawing.Point(12, 114);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(266, 173);
            this.lstClientes.TabIndex = 1;
            this.lstClientes.SelectedIndexChanged += new System.EventHandler(this.cmdSelecionou);
            // 
            // grpDadosCliente
            // 
            this.grpDadosCliente.Controls.Add(this.txtCnpjCpf);
            this.grpDadosCliente.Controls.Add(this.txtNome);
            this.grpDadosCliente.Controls.Add(this.cnpj_cpf);
            this.grpDadosCliente.Controls.Add(this.Nome);
            this.grpDadosCliente.Controls.Add(this.idCliente);
            this.grpDadosCliente.Controls.Add(this.label1);
            this.grpDadosCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpDadosCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDadosCliente.Location = new System.Drawing.Point(284, 102);
            this.grpDadosCliente.Name = "grpDadosCliente";
            this.grpDadosCliente.Size = new System.Drawing.Size(406, 185);
            this.grpDadosCliente.TabIndex = 2;
            this.grpDadosCliente.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID CLIENTE:";
            // 
            // idCliente
            // 
            this.idCliente.AutoSize = true;
            this.idCliente.Location = new System.Drawing.Point(129, 20);
            this.idCliente.Name = "idCliente";
            this.idCliente.Size = new System.Drawing.Size(0, 24);
            this.idCliente.TabIndex = 1;
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Location = new System.Drawing.Point(6, 44);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(67, 24);
            this.Nome.TabIndex = 2;
            this.Nome.Text = "Nome:";
            // 
            // cnpj_cpf
            // 
            this.cnpj_cpf.AutoSize = true;
            this.cnpj_cpf.Location = new System.Drawing.Point(6, 107);
            this.cnpj_cpf.Name = "cnpj_cpf";
            this.cnpj_cpf.Size = new System.Drawing.Size(115, 24);
            this.cnpj_cpf.TabIndex = 3;
            this.cnpj_cpf.Text = "CNPJ / CPF:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(10, 71);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(385, 29);
            this.txtNome.TabIndex = 4;
            // 
            // txtCnpjCpf
            // 
            this.txtCnpjCpf.Location = new System.Drawing.Point(6, 134);
            this.txtCnpjCpf.Name = "txtCnpjCpf";
            this.txtCnpjCpf.Size = new System.Drawing.Size(209, 29);
            this.txtCnpjCpf.TabIndex = 5;
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 300);
            this.Controls.Add(this.grpDadosCliente);
            this.Controls.Add(this.lstClientes);
            this.Controls.Add(this.button1);
            this.Name = "frmCliente";
            this.Text = "Cadastro de CLIENTES";
            this.grpDadosCliente.ResumeLayout(false);
            this.grpDadosCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.GroupBox grpDadosCliente;
        private System.Windows.Forms.TextBox txtCnpjCpf;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label cnpj_cpf;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.Label idCliente;
        private System.Windows.Forms.Label label1;
    }
}

