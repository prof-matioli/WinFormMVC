
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
            this.grpDadosCliente = new System.Windows.Forms.GroupBox();
            this.txtCnpjCpf = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cnpj_cpf = new System.Windows.Forms.Label();
            this.Nome = new System.Windows.Forms.Label();
            this.idCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.grpLstClientes = new System.Windows.Forms.GroupBox();
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.grpDadosCliente.SuspendLayout();
            this.grpLstClientes.SuspendLayout();
            this.SuspendLayout();
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
            this.grpDadosCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDadosCliente.Location = new System.Drawing.Point(275, 1);
            this.grpDadosCliente.Name = "grpDadosCliente";
            this.grpDadosCliente.Size = new System.Drawing.Size(404, 197);
            this.grpDadosCliente.TabIndex = 2;
            this.grpDadosCliente.TabStop = false;
            this.grpDadosCliente.Text = "Dados Cadastrais";
            // 
            // txtCnpjCpf
            // 
            this.txtCnpjCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnpjCpf.ForeColor = System.Drawing.Color.Blue;
            this.txtCnpjCpf.Location = new System.Drawing.Point(11, 134);
            this.txtCnpjCpf.Name = "txtCnpjCpf";
            this.txtCnpjCpf.Size = new System.Drawing.Size(209, 29);
            this.txtCnpjCpf.TabIndex = 5;
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.ForeColor = System.Drawing.Color.Blue;
            this.txtNome.Location = new System.Drawing.Point(10, 71);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(385, 29);
            this.txtNome.TabIndex = 4;
            // 
            // cnpj_cpf
            // 
            this.cnpj_cpf.AutoSize = true;
            this.cnpj_cpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnpj_cpf.Location = new System.Drawing.Point(6, 107);
            this.cnpj_cpf.Name = "cnpj_cpf";
            this.cnpj_cpf.Size = new System.Drawing.Size(115, 24);
            this.cnpj_cpf.TabIndex = 3;
            this.cnpj_cpf.Text = "CNPJ / CPF:";
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nome.Location = new System.Drawing.Point(6, 44);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(67, 24);
            this.Nome.TabIndex = 2;
            this.Nome.Text = "Nome:";
            // 
            // idCliente
            // 
            this.idCliente.AutoSize = true;
            this.idCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idCliente.ForeColor = System.Drawing.Color.Blue;
            this.idCliente.Location = new System.Drawing.Point(129, 20);
            this.idCliente.Name = "idCliente";
            this.idCliente.Size = new System.Drawing.Size(0, 24);
            this.idCliente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID CLIENTE:";
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Location = new System.Drawing.Point(11, 204);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(111, 36);
            this.btnNovo.TabIndex = 3;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.cmdNovo);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(246, 204);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(111, 36);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.cmdExcluir);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(363, 204);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(111, 36);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.cmdSalvar);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(480, 204);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 36);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.cmdCancelar);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(128, 204);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(111, 36);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.cmdEditar);
            // 
            // grpLstClientes
            // 
            this.grpLstClientes.Controls.Add(this.lstClientes);
            this.grpLstClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpLstClientes.Location = new System.Drawing.Point(4, 1);
            this.grpLstClientes.Name = "grpLstClientes";
            this.grpLstClientes.Size = new System.Drawing.Size(265, 197);
            this.grpLstClientes.TabIndex = 4;
            this.grpLstClientes.TabStop = false;
            this.grpLstClientes.Text = "Clientes";
            // 
            // lstClientes
            // 
            this.lstClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.ItemHeight = 24;
            this.lstClientes.Location = new System.Drawing.Point(6, 13);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(253, 172);
            this.lstClientes.TabIndex = 2;
            this.lstClientes.SelectedIndexChanged += new System.EventHandler(this.cmdSelecionou);
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 251);
            this.Controls.Add(this.grpLstClientes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.grpDadosCliente);
            this.Name = "frmCliente";
            this.Text = "Cadastro de CLIENTES";
            this.grpDadosCliente.ResumeLayout(false);
            this.grpDadosCliente.PerformLayout();
            this.grpLstClientes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpDadosCliente;
        private System.Windows.Forms.TextBox txtCnpjCpf;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label cnpj_cpf;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.Label idCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.GroupBox grpLstClientes;
        private System.Windows.Forms.ListBox lstClientes;
    }
}

