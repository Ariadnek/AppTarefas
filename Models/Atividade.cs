using System.Collections.Generic;
using System;

namespace AppTarefas.Models
{
    [Serializable]
    public class Atividade
    {
        public string Titulo { get; set; }
        public DateTime Prazo { get; set; }
        public bool Concluida { get; set; }
        public List<Subtarefa> Subtarefas { get; set; }

        public Atividade() // Construtor padrão necessário para a serialização
        {
            Subtarefas = new List<Subtarefa>();
        }

        public Atividade(string titulo, DateTime prazo) : this()
        {
            Titulo = titulo;
            Prazo = prazo;
            Concluida = false;
        }

        public void AdicionarSubtarefa(Subtarefa subtarefa)
        {
            Subtarefas.Add(subtarefa);
        }
    }
}

