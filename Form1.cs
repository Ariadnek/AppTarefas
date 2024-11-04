using AppTarefas.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace AppTarefas
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private List<Atividade> atividades; // Lista para armazenar atividades
        private List<Atividade> atividadesConcluidas; // Lista para armazenar atividades concluídas
        private const string arquivoAtividades = "Atividades.bin"; 
        public Form1()
        {
            InitializeComponent();
            atividades = new List<Atividade>(); // Inicializa a lista de atividades
            atividadesConcluidas = new List<Atividade>(); // Inicializa a lista de atividades concluídas
            CarregarAtividades(); // Carrega as atividades ao iniciar
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarSaudacao();
            AtualizarHora();
            IniciarTemporizador();
        }
        private void btnIntegrateGoogleCalendar_Click(object sender, EventArgs e)
        {
            try
            {
                Program.IntegrateWithGoogleCalendar(); // Chama o novo método de integração
                MessageBox.Show("Integração com Google Calendar realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao integrar com o Google Calendar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalvarAtividades()
        {
            try
            {
                using (FileStream fs = new FileStream(arquivoAtividades, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    DadosAtividades dados = new DadosAtividades
                    {
                        Atividades = atividades,
                        AtividadesConcluidas = atividadesConcluidas
                    };
                    formatter.Serialize(fs, dados);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar atividades: {ex.Message}");
            }
        }
        private void CarregarAtividades()
        {
            if (File.Exists(arquivoAtividades))
            {
                try
                {
                    using (FileStream fs = new FileStream(arquivoAtividades, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        DadosAtividades dados = (DadosAtividades)formatter.Deserialize(fs);
                        atividades = dados.Atividades;
                        atividadesConcluidas = dados.AtividadesConcluidas;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar atividades: {ex.Message}");
                }
            }
        }

        private void AtualizarSaudacao()
        {
            int horaAtual = DateTime.Now.Hour;

            if (horaAtual >= 5 && horaAtual < 12)
            {
                labelSaudacao.Text = "Bom dia!";
            }
            else if (horaAtual >= 12 && horaAtual < 18)
            {
                labelSaudacao.Text = "Boa tarde!";
            }
            else
            {
                labelSaudacao.Text = "Boa noite!";
            }
        }

        private void AtualizarHora()
        {
            labelHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void IniciarTemporizador()
        {
            timer = new Timer();
            timer.Interval = 1000; // Atualiza a cada segundo
            timer.Tick += (s, e) => { AtualizarHora(); };
            timer.Start();
        }

        private void btnAdicionarAtividade_Click(object sender, EventArgs e)
        {
            string titulo = textBoxTitulo.Text;
            DateTime prazo = dateTimePickerPrazo.Value; // Obtém a data e hora selecionadas

            if (!string.IsNullOrEmpty(titulo))
            {
                Atividade novaAtividade = new Atividade(titulo, prazo);
                atividades.Add(novaAtividade); // Adiciona a nova atividade à lista
                AtualizarListaAtividades(); // Atualiza a exibição da lista de atividades
                textBoxTitulo.Clear(); // Limpa o TextBox
                SalvarAtividades(); // Salva as atividades após adicionar uma nova
            }
            else
            {
                MessageBox.Show("Por favor, insira um título para a tarefa.");
            }
        }

        private void AtualizarListaAtividades()
        {
            listBoxAtividades.Items.Clear(); // Limpa a lista antes de atualizar

            foreach (var atividade in atividades)
            {
                // Verifica o estado da atividade e adiciona um indicador [Concluída] ou [Em andamento]
                string status = atividade.Concluida ? "[Concluída]" : "[Em andamento]";
                string prazoFormatado = atividade.Prazo.ToString("dd/MM/yyyy HH:mm"); // Formata o prazo
                listBoxAtividades.Items.Add($"{atividade.Titulo} (Prazo: {prazoFormatado}) - {status}"); // Exibe o prazo e o status na lista
            }
        }


        private void AtualizarListaAtividadesConcluidas()
        {
            listBoxAtividadesConcluidas.Items.Clear(); // Limpa a lista de atividades concluídas

            foreach (var atividade in atividadesConcluidas)
            {
                // Exibe a atividade com o título e o status [Concluída]
                listBoxAtividadesConcluidas.Items.Add($"{atividade.Titulo} - [Concluída]");
            }
        }

        private void listBoxAtividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceSelecionado = listBoxAtividades.SelectedIndex;
            if (indiceSelecionado >= 0)
            {
                AtualizarListaSubtarefas(indiceSelecionado); // Atualiza a lista de subtarefas quando a atividade é selecionada
            }
        }

        private void btnEditarAtividade_Click(object sender, EventArgs e)
        {
            int indiceSelecionado = listBoxAtividades.SelectedIndex;
            if (indiceSelecionado >= 0)
            {
                // Edita o título da atividade
                string novoTitulo = Microsoft.VisualBasic.Interaction.InputBox("Insira o novo título da atividade:", "Editar Atividade", atividades[indiceSelecionado].Titulo);

                // Edita o prazo da atividade
                DateTime novoPrazo;
                string prazoInput = Microsoft.VisualBasic.Interaction.InputBox("Insira o novo prazo da atividade (dd/MM/yyyy HH:mm):", "Editar Prazo", atividades[indiceSelecionado].Prazo.ToString("dd/MM/yyyy HH:mm"));
                if (!DateTime.TryParse(prazoInput, out novoPrazo))
                {
                    MessageBox.Show("Prazo inválido. Por favor, insira uma data válida.");
                    return;
                }

                if (!string.IsNullOrEmpty(novoTitulo))
                {
                    atividades[indiceSelecionado].Titulo = novoTitulo;
                    atividades[indiceSelecionado].Prazo = novoPrazo; // Atualiza o prazo
                    AtualizarListaAtividades(); // Atualiza a exibição da lista de atividades
                    SalvarAtividades(); // Salva as alterações
                }
                else
                {
                    MessageBox.Show("Por favor, insira um título válido.");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma atividade para editar.");
            }
        }


        private void btnExcluirAtividade_Click(object sender, EventArgs e)
        {
            // Implementação para excluir uma atividade
            int indiceSelecionado = listBoxAtividades.SelectedIndex;
            if (indiceSelecionado >= 0)
            {
                // Remove a atividade da lista
                atividades.RemoveAt(indiceSelecionado);
                // Atualiza a exibição da lista de atividades
                AtualizarListaAtividades();
                // Limpa a lista de subtarefas, pois a atividade foi excluída
                listBoxSubtarefas.Items.Clear();
            }
            else
            {
                MessageBox.Show("Selecione uma atividade para excluir.");
            }
        }
        private void btnMarcarAtividadeConcluida_Click(object sender, EventArgs e)
        {
            if (listBoxAtividades.SelectedIndex != -1) // Verifica se algo está selecionado
            {
                // Pega a atividade correspondente ao índice selecionado
                Atividade atividadeSelecionada = atividades[listBoxAtividades.SelectedIndex];

                // Marca a atividade como concluída
                atividadeSelecionada.Concluida = true;

                // Remove a atividade da lista de atividades em andamento e move para a lista de atividades concluídas
                atividades.Remove(atividadeSelecionada);
                atividadesConcluidas.Add(atividadeSelecionada);

                // Atualiza a lista de atividades e atividades concluídas
                AtualizarListaAtividades();
                AtualizarListaAtividadesConcluidas();

                SalvarAtividades(); // Salva as atividades após concluir uma
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma atividade para marcar como concluída.");
            }
        }
        private void btnAdicionarSubtarefa_Click(object sender, EventArgs e)
        {
            int indiceSelecionado = listBoxAtividades.SelectedIndex; // Obtém a atividade selecionada
            if (indiceSelecionado >= 0) // Verifica se uma atividade está selecionada
            {
                string subtarefaTitulo = Microsoft.VisualBasic.Interaction.InputBox("Insira o título da subtarefa:", "Adicionar Subtarefa");
                if (!string.IsNullOrEmpty(subtarefaTitulo))
                {
                    // Solicita a data de prazo para a subtarefa
                    DateTime subtarefaPrazo = dateTimePickerPrazo.Value;

                    var subtarefa = new Subtarefa(subtarefaTitulo)
                    {
                        Prazo = subtarefaPrazo // Define o prazo da subtarefa
                    };

                    atividades[indiceSelecionado].AdicionarSubtarefa(subtarefa); // Adiciona a subtarefa à atividade
                    AtualizarListaSubtarefas(indiceSelecionado); // Atualiza a exibição das subtarefas
                }
                else
                {
                    MessageBox.Show("Por favor, insira um título para a subtarefa.");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma atividade antes de adicionar uma subtarefa.");
            }
        }

        private void AtualizarListaSubtarefas(int indiceAtividade)
        {
            listBoxSubtarefas.Items.Clear();
            var atividadeSelecionada = atividades[indiceAtividade];

            foreach (var subtarefa in atividadeSelecionada.Subtarefas)
            {
                string status = subtarefa.Concluida ? "[Concluída]" : "[Em andamento]";
                listBoxSubtarefas.Items.Add($"{subtarefa.Titulo} - Prazo: {subtarefa.Prazo:dd/MM/yyyy HH:mm} - Status: {status}");
            }
        }

        private void btnEditarSubtarefa_Click(object sender, EventArgs e)
        {
            int indiceAtividade = listBoxAtividades.SelectedIndex;
            int indiceSubtarefa = listBoxSubtarefas.SelectedIndex;

            if (indiceAtividade >= 0 && indiceSubtarefa >= 0)
            {
                // Edita o título da subtarefa
                string novoTitulo = Microsoft.VisualBasic.Interaction.InputBox("Insira o novo título da subtarefa:", "Editar Subtarefa", atividades[indiceAtividade].Subtarefas[indiceSubtarefa].Titulo);

                // Edita o prazo da subtarefa
                DateTime novoPrazo;
                string prazoInput = Microsoft.VisualBasic.Interaction.InputBox("Insira o novo prazo da subtarefa (dd/MM/yyyy HH:mm):", "Editar Prazo", atividades[indiceAtividade].Subtarefas[indiceSubtarefa].Prazo.ToString("dd/MM/yyyy HH:mm"));
                if (!DateTime.TryParse(prazoInput, out novoPrazo))
                {
                    MessageBox.Show("Prazo inválido. Por favor, insira uma data válida.");
                    return;
                }

                // Edita o status de conclusão da subtarefa
                DialogResult resultadoConcluida = MessageBox.Show("A subtarefa foi concluída?", "Editar Status", MessageBoxButtons.YesNo);
                bool subtarefaConcluida = (resultadoConcluida == DialogResult.Yes);

                if (!string.IsNullOrEmpty(novoTitulo))
                {
                    atividades[indiceAtividade].Subtarefas[indiceSubtarefa].Titulo = novoTitulo;
                    atividades[indiceAtividade].Subtarefas[indiceSubtarefa].Prazo = novoPrazo; // Atualiza o prazo
                    atividades[indiceAtividade].Subtarefas[indiceSubtarefa].Concluida = subtarefaConcluida; // Atualiza o status de conclusão

                    AtualizarListaSubtarefas(indiceAtividade); // Atualiza a exibição da lista de subtarefas
                    SalvarAtividades(); // Salva as alterações
                }
                else
                {
                    MessageBox.Show("Por favor, insira um título válido.");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma atividade e uma subtarefa para editar.");
            }
        }


        private void btnExcluirSubtarefa_Click(object sender, EventArgs e)
        {
            int indiceAtividade = listBoxAtividades.SelectedIndex;
            int indiceSubtarefa = listBoxSubtarefas.SelectedIndex;

            if (indiceAtividade >= 0 && indiceSubtarefa >= 0)
            {
                atividades[indiceAtividade].Subtarefas.RemoveAt(indiceSubtarefa);
                AtualizarListaSubtarefas(indiceAtividade); // Atualiza a exibição da lista de subtarefas
            }
            else
            {
                MessageBox.Show("Selecione uma subtarefa para excluir.");
            }
        }
        private void btnMarcarSubtarefaConcluida_Click(object sender, EventArgs e)
        {
            int indiceAtividade = listBoxAtividades.SelectedIndex;
            int indiceSubtarefa = listBoxSubtarefas.SelectedIndex;

            if (indiceAtividade >= 0 && indiceSubtarefa >= 0)
            {
                atividades[indiceAtividade].Subtarefas[indiceSubtarefa].MarcarComoConcluida(); // Marca a subtarefa como concluída
                AtualizarListaSubtarefas(indiceAtividade); // Atualiza a lista de subtarefas
            }
            else
            {
                MessageBox.Show("Selecione uma atividade e uma subtarefa para marcar como concluída.");
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SalvarAtividades();// Salva as atividades ao fechar
        }

        private void listBoxSubtarefas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
