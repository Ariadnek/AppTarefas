using System.Collections.Generic;
using System;

namespace AppTarefas.Models
{
    [Serializable]
    public class Subtarefa
    {
        public string Titulo { get; set; }
        public bool Concluida { get; set; }
        public DateTime Prazo { get; set; }

        public Subtarefa(string titulo)
        {
            Titulo = titulo;
            Concluida = false;
            Prazo = DateTime.Now.AddDays(1);
        }

        public void MarcarComoConcluida()
        {
            Concluida = true;
        }
    }
}
