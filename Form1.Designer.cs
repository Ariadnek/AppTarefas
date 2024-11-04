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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelSaudacao = new System.Windows.Forms.Label();
            this.labelHora = new System.Windows.Forms.Label();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.btnIntegrateGoogleCalendar = new System.Windows.Forms.Button();
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // labelSaudacao
            // 
            this.labelSaudacao.AutoSize = true;
            this.labelSaudacao.Font = new System.Drawing.Font("Bookman Old Style", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSaudacao.Location = new System.Drawing.Point(331, 21);
            this.labelSaudacao.Name = "labelSaudacao";
            this.labelSaudacao.Size = new System.Drawing.Size(184, 40);
            this.labelSaudacao.TabIndex = 0;
            this.labelSaudacao.Text = "Saudação";
            // 
            // labelHora
            // 
            this.labelHora.AutoSize = true;
            this.labelHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelHora.Location = new System.Drawing.Point(359, 63);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(54, 25);
            this.labelHora.TabIndex = 1;
            this.labelHora.Text = "Hora";
            // 
            // textBoxTitulo
            // 
            this.textBoxTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTitulo.Location = new System.Drawing.Point(29, 207);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.Size = new System.Drawing.Size(279, 22);
            this.textBoxTitulo.TabIndex = 2;
            // 
            // btnIntegrateGoogleCalendar
            // 
            this.btnIntegrateGoogleCalendar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnIntegrateGoogleCalendar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIntegrateGoogleCalendar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnIntegrateGoogleCalendar.Location = new System.Drawing.Point(29, 53);
            this.btnIntegrateGoogleCalendar.Name = "btnIntegrateGoogleCalendar";
            this.btnIntegrateGoogleCalendar.Size = new System.Drawing.Size(210, 48);
            this.btnIntegrateGoogleCalendar.TabIndex = 0;
            this.btnIntegrateGoogleCalendar.Text = "Integrar com Google Calendar";
            this.btnIntegrateGoogleCalendar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnIntegrateGoogleCalendar.UseVisualStyleBackColor = false;
            this.btnIntegrateGoogleCalendar.Click += new System.EventHandler(this.btnIntegrateGoogleCalendar_Click);
            // 
            // btnAdicionarAtividade
            // 
            this.btnAdicionarAtividade.Location = new System.Drawing.Point(314, 206);
            this.btnAdicionarAtividade.Name = "btnAdicionarAtividade";
            this.btnAdicionarAtividade.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarAtividade.TabIndex = 3;
            this.btnAdicionarAtividade.Text = "Adicionar";
            this.btnAdicionarAtividade.UseVisualStyleBackColor = true;
            this.btnAdicionarAtividade.Click += new System.EventHandler(this.btnAdicionarAtividade_Click);
            // 
            // dateTimePickerPrazo
            // 
            this.dateTimePickerPrazo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerPrazo.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerPrazo.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePickerPrazo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPrazo.Location = new System.Drawing.Point(462, 207);
            this.dateTimePickerPrazo.Name = "dateTimePickerPrazo";
            this.dateTimePickerPrazo.Size = new System.Drawing.Size(255, 22);
            this.dateTimePickerPrazo.TabIndex = 4;
            // 
            // listBoxAtividades
            // 
            this.listBoxAtividades.FormattingEnabled = true;
            this.listBoxAtividades.ItemHeight = 16;
            this.listBoxAtividades.Location = new System.Drawing.Point(28, 372);
            this.listBoxAtividades.Name = "listBoxAtividades";
            this.listBoxAtividades.Size = new System.Drawing.Size(280, 100);
            this.listBoxAtividades.TabIndex = 5;
            this.listBoxAtividades.SelectedIndexChanged += new System.EventHandler(this.listBoxAtividades_SelectedIndexChanged);
            // 
            // btnAdicionarSubtarefa
            // 
            this.btnAdicionarSubtarefa.Location = new System.Drawing.Point(748, 358);
            this.btnAdicionarSubtarefa.Name = "btnAdicionarSubtarefa";
            this.btnAdicionarSubtarefa.Size = new System.Drawing.Size(92, 27);
            this.btnAdicionarSubtarefa.TabIndex = 6;
            this.btnAdicionarSubtarefa.Text = "Adicionar Subtarefa";
            this.btnAdicionarSubtarefa.UseVisualStyleBackColor = true;
            this.btnAdicionarSubtarefa.Click += new System.EventHandler(this.btnAdicionarSubtarefa_Click);
            // 
            // listBoxSubtarefas
            // 
            this.listBoxSubtarefas.FormattingEnabled = true;
            this.listBoxSubtarefas.ItemHeight = 16;
            this.listBoxSubtarefas.Location = new System.Drawing.Point(462, 372);
            this.listBoxSubtarefas.Name = "listBoxSubtarefas";
            this.listBoxSubtarefas.Size = new System.Drawing.Size(280, 100);
            this.listBoxSubtarefas.TabIndex = 7;
            this.listBoxSubtarefas.SelectedIndexChanged += new System.EventHandler(this.listBoxSubtarefas_SelectedIndexChanged);
            // 
            // btnMarcarAtividadeConcluida
            // 
            this.btnMarcarAtividadeConcluida.Location = new System.Drawing.Point(314, 433);
            this.btnMarcarAtividadeConcluida.Name = "btnMarcarAtividadeConcluida";
            this.btnMarcarAtividadeConcluida.Size = new System.Drawing.Size(90, 23);
            this.btnMarcarAtividadeConcluida.TabIndex = 1;
            this.btnMarcarAtividadeConcluida.Text = "Concluir tarefa";
            this.btnMarcarAtividadeConcluida.UseVisualStyleBackColor = true;
            this.btnMarcarAtividadeConcluida.Click += new System.EventHandler(this.btnMarcarAtividadeConcluida_Click);
            // 
            // btnEditarAtividade
            // 
            this.btnEditarAtividade.Location = new System.Drawing.Point(314, 372);
            this.btnEditarAtividade.Name = "btnEditarAtividade";
            this.btnEditarAtividade.Size = new System.Drawing.Size(75, 23);
            this.btnEditarAtividade.TabIndex = 13;
            this.btnEditarAtividade.Text = "Editar Tarefa";
            this.btnEditarAtividade.UseVisualStyleBackColor = true;
            this.btnEditarAtividade.Click += new System.EventHandler(this.btnEditarAtividade_Click);
            // 
            // btnExcluirAtividade
            // 
            this.btnExcluirAtividade.Location = new System.Drawing.Point(314, 401);
            this.btnExcluirAtividade.Name = "btnExcluirAtividade";
            this.btnExcluirAtividade.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirAtividade.TabIndex = 14;
            this.btnExcluirAtividade.Text = "Excluir Tarefa";
            this.btnExcluirAtividade.UseVisualStyleBackColor = true;
            this.btnExcluirAtividade.Click += new System.EventHandler(this.btnExcluirAtividade_Click);
            // 
            // btnMarcarSubtarefaConcluida
            // 
            this.btnMarcarSubtarefaConcluida.Location = new System.Drawing.Point(748, 449);
            this.btnMarcarSubtarefaConcluida.Name = "btnMarcarSubtarefaConcluida";
            this.btnMarcarSubtarefaConcluida.Size = new System.Drawing.Size(90, 23);
            this.btnMarcarSubtarefaConcluida.TabIndex = 8;
            this.btnMarcarSubtarefaConcluida.Text = "Concluir Subtarefa";
            this.btnMarcarSubtarefaConcluida.UseVisualStyleBackColor = true;
            this.btnMarcarSubtarefaConcluida.Click += new System.EventHandler(this.btnMarcarSubtarefaConcluida_Click);
            // 
            // btnEditarSubtarefa
            // 
            this.btnEditarSubtarefa.Location = new System.Drawing.Point(748, 391);
            this.btnEditarSubtarefa.Name = "btnEditarSubtarefa";
            this.btnEditarSubtarefa.Size = new System.Drawing.Size(75, 23);
            this.btnEditarSubtarefa.TabIndex = 15;
            this.btnEditarSubtarefa.Text = "Editar Subtarefa";
            this.btnEditarSubtarefa.UseVisualStyleBackColor = true;
            this.btnEditarSubtarefa.Click += new System.EventHandler(this.btnEditarSubtarefa_Click);
            // 
            // btnExcluirSubtarefa
            // 
            this.btnExcluirSubtarefa.Location = new System.Drawing.Point(748, 420);
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
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tarefas Atuais";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(459, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Subtarefas Atuais";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 530);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tarefas Concluídas";
            // 
            // listBoxAtividadesConcluidas
            // 
            this.listBoxAtividadesConcluidas.FormattingEnabled = true;
            this.listBoxAtividadesConcluidas.ItemHeight = 16;
            this.listBoxAtividadesConcluidas.Location = new System.Drawing.Point(29, 553);
            this.listBoxAtividadesConcluidas.Name = "listBoxAtividadesConcluidas";
            this.listBoxAtividadesConcluidas.Size = new System.Drawing.Size(280, 100);
            this.listBoxAtividadesConcluidas.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tarefa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(459, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Definir prazo";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Black;
            this.imageList1.Images.SetKeyName(0, "Google_Calendar_icon_(2020).svg (1).png");
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(856, 667);
            this.Controls.Add(this.btnIntegrateGoogleCalendar);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelSaudacao;
        private System.Windows.Forms.Label labelHora;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.Button btnIntegrateGoogleCalendar;
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
        private ImageList imageList1;
    }
}
