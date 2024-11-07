using AppTarefas.Models;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace AppTarefas
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private List<Atividade> atividades; 
        private List<Atividade> atividadesConcluidas;
        private const string arquivoAtividades = "Atividades.bin";

        public Form1()
        {
            InitializeComponent();
            atividades = new List<Atividade>(); 
            atividadesConcluidas = new List<Atividade>(); 
            CarregarAtividades(); 

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
                GoogleCalendarHelper.IntegrateWithGoogleCalendar();
                MessageBox.Show("Integração com Google Calendar realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Erro ao integrar com o Google Calendar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

        private void AdicionarTarefaNoGoogleCalendar(Atividade novaAtividade)
        {
            // Verifica se a integração com o Google Calendar foi configurada
            var service = GoogleCalendarHelper.GetCalendarService();
            if (service == null)
            {
                MessageBox.Show("Não foi possível integrar com o Google Calendar.");
                return;
            }

           
            DateTimeOffset startDateTime = new DateTimeOffset(novaAtividade.Prazo, TimeZoneInfo.Local.GetUtcOffset(novaAtividade.Prazo));
            DateTimeOffset endDateTime = startDateTime.AddHours(1);

            // Cria um novo evento no Google Calendar
            Event newEvent = new Event
            {
                Summary = novaAtividade.Titulo,
                Start = new EventDateTime
                {
                    DateTime = novaAtividade.Prazo,
                    TimeZone = "America/Sao_Paulo"
                },
                End = new EventDateTime
                {
                    DateTime = novaAtividade.Prazo.AddHours(1),
                    TimeZone = "America/Sao_Paulo"
                }
,
            };

            try
            {
                // Adiciona o evento ao Google Calendar
                service.Events.Insert(newEvent, "primary").Execute();
                MessageBox.Show("Evento adicionado ao Google Calendar!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar evento: " + ex.Message);
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
        private void ExcluirHistoricoConcluidas()
        {
            atividadesConcluidas.Clear();

            SalvarAtividades();

            MessageBox.Show("Histórico de atividades concluídas foi excluído.");
        }
        private void btnExcluirHistoricoConcluidas_Click(object sender, EventArgs e)
        {
            ExcluirHistoricoConcluidas();
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
            timer.Interval = 1000; 
            timer.Tick += (s, e) => { AtualizarHora(); };
            timer.Start();
        }

        private void btnAdicionarAtividade_Click(object sender, EventArgs e)
        {
            string titulo = textBoxTitulo.Text;
            DateTime prazo = dateTimePickerPrazo.Value;

            if (!string.IsNullOrEmpty(titulo))
            {
                Atividade novaAtividade = new Atividade(titulo, prazo); // Cria a nova atividade
                atividades.Add(novaAtividade); // Adiciona a nova atividade à lista local
                AtualizarListaAtividades(); // Atualiza a exibição da lista de atividades
                textBoxTitulo.Clear();  // Limpa o TextBox de título
                SalvarAtividades(); // Salva as atividades no arquivo
                AdicionarTarefaNoGoogleCalendar(novaAtividade); //  adicionar atividade no Google Calendar
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
      
                string status = atividade.Concluida ? "[Concluída]" : "[Em andamento]";
                string prazoFormatado = atividade.Prazo.ToString("dd/MM/yyyy HH:mm"); 
                listBoxAtividades.Items.Add($"{atividade.Titulo} (Prazo: {prazoFormatado}) - {status}"); 
            }
        }


        private void AtualizarListaAtividadesConcluidas()
        {
            listBoxAtividadesConcluidas.Items.Clear(); 

            foreach (var atividade in atividadesConcluidas)
            {

                listBoxAtividadesConcluidas.Items.Add($"{atividade.Titulo} - [Concluída]");
            }
        }

        private void listBoxAtividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indiceSelecionado = listBoxAtividades.SelectedIndex;
            if (indiceSelecionado >= 0)
            {
                AtualizarListaSubtarefas(indiceSelecionado); 
            }
        }

        private void btnEditarAtividade_Click(object sender, EventArgs e)
        {
            int indiceSelecionado = listBoxAtividades.SelectedIndex;
            if (indiceSelecionado >= 0)
            {
               
                string novoTitulo = Microsoft.VisualBasic.Interaction.InputBox("Insira o novo título da atividade:", "Editar Atividade", atividades[indiceSelecionado].Titulo);

              
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
                    atividades[indiceSelecionado].Prazo = novoPrazo; 
                    AtualizarListaAtividades(); 
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
           
            int indiceSelecionado = listBoxAtividades.SelectedIndex;
            if (indiceSelecionado >= 0)
            {
            
                atividades.RemoveAt(indiceSelecionado);

                AtualizarListaAtividades();

                listBoxSubtarefas.Items.Clear();
            }
            else
            {
                MessageBox.Show("Selecione uma atividade para excluir.");
            }
        }
        private void btnMarcarAtividadeConcluida_Click(object sender, EventArgs e)
        {
            if (listBoxAtividades.SelectedIndex != -1) 
            {

                Atividade atividadeSelecionada = atividades[listBoxAtividades.SelectedIndex];

  
                bool todasSubtarefasConcluidas = atividadeSelecionada.Subtarefas.All(sub => sub.Concluida);

                if (todasSubtarefasConcluidas)
                {
                  
                    atividadeSelecionada.Concluida = true;


                    atividades.Remove(atividadeSelecionada);
                    atividadesConcluidas.Add(atividadeSelecionada);


                    AtualizarListaAtividades();
                    AtualizarListaAtividadesConcluidas();

                    SalvarAtividades(); 
                }
                else
                {
               
                    MessageBox.Show("Para concluir esta atividade, todas as subtarefas devem estar concluídas.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma atividade para marcar como concluída.");
            }
        }

        private void btnAdicionarSubtarefa_Click(object sender, EventArgs e)
        {
            int indiceSelecionado = listBoxAtividades.SelectedIndex; 
            if (indiceSelecionado >= 0) 
            {
                string subtarefaTitulo = Microsoft.VisualBasic.Interaction.InputBox("Insira o título da subtarefa:", "Adicionar Subtarefa");
                if (!string.IsNullOrEmpty(subtarefaTitulo))
                {
                   
                    DateTime subtarefaPrazo = dateTimePickerPrazo.Value;

                    var subtarefa = new Subtarefa(subtarefaTitulo)
                    {
                        Prazo = subtarefaPrazo 
                    };

                    atividades[indiceSelecionado].AdicionarSubtarefa(subtarefa); 
                    AtualizarListaSubtarefas(indiceSelecionado); 
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
               
                string novoTitulo = Microsoft.VisualBasic.Interaction.InputBox("Insira o novo título da subtarefa:", "Editar Subtarefa", atividades[indiceAtividade].Subtarefas[indiceSubtarefa].Titulo);

                
                DateTime novoPrazo;
                string prazoInput = Microsoft.VisualBasic.Interaction.InputBox("Insira o novo prazo da subtarefa (dd/MM/yyyy HH:mm):", "Editar Prazo", atividades[indiceAtividade].Subtarefas[indiceSubtarefa].Prazo.ToString("dd/MM/yyyy HH:mm"));
                if (!DateTime.TryParse(prazoInput, out novoPrazo))
                {
                    MessageBox.Show("Prazo inválido. Por favor, insira uma data válida.");
                    return;
                }

               
                DialogResult resultadoConcluida = MessageBox.Show("A subtarefa foi concluída?", "Editar Status", MessageBoxButtons.YesNo);
                bool subtarefaConcluida = (resultadoConcluida == DialogResult.Yes);

                if (!string.IsNullOrEmpty(novoTitulo))
                {
                    atividades[indiceAtividade].Subtarefas[indiceSubtarefa].Titulo = novoTitulo;
                    atividades[indiceAtividade].Subtarefas[indiceSubtarefa].Prazo = novoPrazo;
                    atividades[indiceAtividade].Subtarefas[indiceSubtarefa].Concluida = subtarefaConcluida; 

                    AtualizarListaSubtarefas(indiceAtividade); 
                    SalvarAtividades(); 
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
                AtualizarListaSubtarefas(indiceAtividade); 
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
                
                atividades[indiceAtividade].Subtarefas[indiceSubtarefa].MarcarComoConcluida();

              
                AtualizarListaSubtarefas(indiceAtividade);

             
                bool todasSubtarefasConcluidas = atividades[indiceAtividade].Subtarefas.All(sub => sub.Concluida);

                if (todasSubtarefasConcluidas)
                {
                   
                    atividades[indiceAtividade].Concluida = true;

                    
                    AtualizarListaAtividades();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma atividade e uma subtarefa para marcar como concluída.");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SalvarAtividades();
        }

        private void listBoxSubtarefas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
