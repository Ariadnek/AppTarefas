using System.Windows.Forms;

namespace AppTarefas
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelSaudacao = new System.Windows.Forms.Label();
            this.labelHora = new System.Windows.Forms.Label();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.btnAdicionarAtividade = new System.Windows.Forms.Button();
            this.dateTimePickerPrazo = new System.Windows.Forms.DateTimePicker();
            this.listBoxAtividades = new System.Windows.Forms.ListBox();
            this.btnAdicionarSubtarefa = new System.Windows.Forms.Button();
            this.listBoxSubtarefas = new System.Windows.Forms.ListBox();
            this.btnMarcarAtividadeConcluida = new System.Windows.Forms.Button();
            this.btnEditarAtividade = new System.Windows.Forms.Button();
            this.btnExcluirAtividade = new System.Windows.Forms.Button();
            this.btnMarcarSubtarefaConcluida = new System.Windows.Forms.Button();
            this.btnEditarSubtarefa = new System.Windows.Forms.Button();
            this.btnExcluirSubtarefa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxAtividadesConcluidas = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SuspendLayout();
            // 
            // labelSaudacao
            // 
            this.labelSaudacao.AutoSize = true;
            this.labelSaudacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelSaudacao.Location = new System.Drawing.Point(137, 9);
            this.labelSaudacao.Name = "labelSaudacao";
            this.labelSaudacao.Size = new System.Drawing.Size(117, 25);
            this.labelSaudacao.TabIndex = 0;
            this.labelSaudacao.Text = "Saudação";
            // 
            // labelHora
            // 
            this.labelHora.AutoSize = true;
            this.labelHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelHora.Location = new System.Drawing.Point(168, 34);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(44, 20);
            this.labelHora.TabIndex = 1;
            this.labelHora.Text = "Hora";
            // 
            // textBoxTitulo
            // 
            this.textBoxTitulo.Location = new System.Drawing.Point(12, 80);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.Size = new System.Drawing.Size(200, 20);
            this.textBoxTitulo.TabIndex = 2;
            // 
            // btnAdicionarAtividade
            // 
            this.btnAdicionarAtividade.Location = new System.Drawing.Point(220, 80);
            this.btnAdicionarAtividade.Name = "btnAdicionarAtividade";
            this.btnAdicionarAtividade.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarAtividade.TabIndex = 3;
            this.btnAdicionarAtividade.Text = "Adicionar";
            this.btnAdicionarAtividade.UseVisualStyleBackColor = true;
            this.btnAdicionarAtividade.Click += new System.EventHandler(this.btnAdicionarAtividade_Click);
            // 
            // dateTimePickerPrazo
            // 
            this.dateTimePickerPrazo.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerPrazo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPrazo.Location = new System.Drawing.Point(12, 121);
            this.dateTimePickerPrazo.Name = "dateTimePickerPrazo";
            this.dateTimePickerPrazo.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerPrazo.TabIndex = 4;
            // 
            // listBoxAtividades
            // 
            this.listBoxAtividades.FormattingEnabled = true;
            this.listBoxAtividades.Location = new System.Drawing.Point(12, 217);
            this.listBoxAtividades.Name = "listBoxAtividades";
            this.listBoxAtividades.Size = new System.Drawing.Size(280, 95);
            this.listBoxAtividades.TabIndex = 5;
            this.listBoxAtividades.SelectedIndexChanged += new System.EventHandler(this.listBoxAtividades_SelectedIndexChanged);
            // 
            // btnAdicionarSubtarefa
            // 
            this.btnAdicionarSubtarefa.Location = new System.Drawing.Point(298, 359);
            this.btnAdicionarSubtarefa.Name = "btnAdicionarSubtarefa";
            this.btnAdicionarSubtarefa.Size = new System.Drawing.Size(117, 23);
            this.btnAdicionarSubtarefa.TabIndex = 6;
            this.btnAdicionarSubtarefa.Text = "Adicionar Subtarefa";
            this.btnAdicionarSubtarefa.UseVisualStyleBackColor = true;
            this.btnAdicionarSubtarefa.Click += new System.EventHandler(this.btnAdicionarSubtarefa_Click);
            // 
            // listBoxSubtarefas
            // 
            this.listBoxSubtarefas.FormattingEnabled = true;
            this.listBoxSubtarefas.Location = new System.Drawing.Point(12, 359);
            this.listBoxSubtarefas.Name = "listBoxSubtarefas";
            this.listBoxSubtarefas.Size = new System.Drawing.Size(280, 95);
            this.listBoxSubtarefas.TabIndex = 7;
            // 
            // btnMarcarAtividadeConcluida
            // 
            this.btnMarcarAtividadeConcluida.Location = new System.Drawing.Point(298, 275);
            this.btnMarcarAtividadeConcluida.Name = "btnMarcarAtividadeConcluida";
            this.btnMarcarAtividadeConcluida.Size = new System.Drawing.Size(90, 23);
            this.btnMarcarAtividadeConcluida.TabIndex = 1;
            this.btnMarcarAtividadeConcluida.Text = "Concluir tarefa";
            this.btnMarcarAtividadeConcluida.UseVisualStyleBackColor = true;
            this.btnMarcarAtividadeConcluida.Click += new System.EventHandler(this.btnMarcarAtividadeConcluida_Click);
            // 
            // btnEditarAtividade
            // 
            this.btnEditarAtividade.Location = new System.Drawing.Point(298, 217);
            this.btnEditarAtividade.Name = "btnEditarAtividade";
            this.btnEditarAtividade.Size = new System.Drawing.Size(75, 23);
            this.btnEditarAtividade.TabIndex = 13;
            this.btnEditarAtividade.Text = "Editar Tarefa";
            this.btnEditarAtividade.UseVisualStyleBackColor = true;
            this.btnEditarAtividade.Click += new System.EventHandler(this.btnEditarAtividade_Click);
            // 
            // btnExcluirAtividade
            // 
            this.btnExcluirAtividade.Location = new System.Drawing.Point(298, 246);
            this.btnExcluirAtividade.Name = "btnExcluirAtividade";
            this.btnExcluirAtividade.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirAtividade.TabIndex = 14;
            this.btnExcluirAtividade.Text = "Excluir Tarefa";
            this.btnExcluirAtividade.UseVisualStyleBackColor = true;
            this.btnExcluirAtividade.Click += new System.EventHandler(this.btnExcluirAtividade_Click);
            // 
            // btnMarcarSubtarefaConcluida
            // 
            this.btnMarcarSubtarefaConcluida.Location = new System.Drawing.Point(298, 446);
            this.btnMarcarSubtarefaConcluida.Name = "btnMarcarSubtarefaConcluida";
            this.btnMarcarSubtarefaConcluida.Size = new System.Drawing.Size(90, 23);
            this.btnMarcarSubtarefaConcluida.TabIndex = 8;
            this.btnMarcarSubtarefaConcluida.Text = "Concluir Subtarefa";
            this.btnMarcarSubtarefaConcluida.UseVisualStyleBackColor = true;
            this.btnMarcarSubtarefaConcluida.Click += new System.EventHandler(this.btnMarcarSubtarefaConcluida_Click);
            // 
            // btnEditarSubtarefa
            // 
            this.btnEditarSubtarefa.Location = new System.Drawing.Point(298, 388);
            this.btnEditarSubtarefa.Name = "btnEditarSubtarefa";
            this.btnEditarSubtarefa.Size = new System.Drawing.Size(75, 23);
            this.btnEditarSubtarefa.TabIndex = 15;
            this.btnEditarSubtarefa.Text = "Editar Subtarefa";
            this.btnEditarSubtarefa.UseVisualStyleBackColor = true;
            this.btnEditarSubtarefa.Click += new System.EventHandler(this.btnEditarSubtarefa_Click);
            // 
            // btnExcluirSubtarefa
            // 
            this.btnExcluirSubtarefa.Location = new System.Drawing.Point(298, 417);
            this.btnExcluirSubtarefa.Name = "btnExcluirSubtarefa";
            this.btnExcluirSubtarefa.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirSubtarefa.TabIndex = 16;
            this.btnExcluirSubtarefa.Text = "Excluir Subtarefa";
            this.btnExcluirSubtarefa.UseVisualStyleBackColor = true;
            this.btnExcluirSubtarefa.Click += new System.EventHandler(this.btnExcluirSubtarefa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tarefas Atuais";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Subtarefas Atuais";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 466);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tarefas Concluídas";
            // 
            // listBoxAtividadesConcluidas
            // 
            this.listBoxAtividadesConcluidas.FormattingEnabled = true;
            this.listBoxAtividadesConcluidas.Location = new System.Drawing.Point(12, 482);
            this.listBoxAtividadesConcluidas.Name = "listBoxAtividadesConcluidas";
            this.listBoxAtividadesConcluidas.Size = new System.Drawing.Size(280, 95);
            this.listBoxAtividadesConcluidas.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tarefa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Definir prazo";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(450, 600);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelSaudacao);
            this.Controls.Add(this.labelHora);
            this.Controls.Add(this.textBoxTitulo);
            this.Controls.Add(this.btnAdicionarAtividade);
            this.Controls.Add(this.dateTimePickerPrazo);
            this.Controls.Add(this.listBoxAtividades);
            this.Controls.Add(this.btnAdicionarSubtarefa);
            this.Controls.Add(this.listBoxSubtarefas);
            this.Controls.Add(this.btnMarcarAtividadeConcluida);
            this.Controls.Add(this.btnEditarAtividade);
            this.Controls.Add(this.btnExcluirAtividade);
            this.Controls.Add(this.btnMarcarSubtarefaConcluida);
            this.Controls.Add(this.btnEditarSubtarefa);
            this.Controls.Add(this.btnExcluirSubtarefa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxAtividadesConcluidas);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelSaudacao;
        private System.Windows.Forms.Label labelHora;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.Button btnAdicionarAtividade;
        private System.Windows.Forms.DateTimePicker dateTimePickerPrazo;
        private System.Windows.Forms.ListBox listBoxAtividades;
        private System.Windows.Forms.Button btnAdicionarSubtarefa;
        private System.Windows.Forms.ListBox listBoxSubtarefas;
        private System.Windows.Forms.Button btnMarcarAtividadeConcluida;
        private System.Windows.Forms.Button btnEditarAtividade;
        private System.Windows.Forms.Button btnExcluirAtividade;
        private System.Windows.Forms.Button btnMarcarSubtarefaConcluida;
        private System.Windows.Forms.Button btnEditarSubtarefa;
        private System.Windows.Forms.Button btnExcluirSubtarefa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxAtividadesConcluidas;
        private Label label4;
        private Label label5;
    }
}
