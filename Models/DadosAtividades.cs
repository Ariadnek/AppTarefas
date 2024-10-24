using System;
using System.Collections.Generic;

namespace AppTarefas.Models
{
    [Serializable]
    public class DadosAtividades
    {
        public List<Atividade> Atividades { get; set; }
        public List<Atividade> AtividadesConcluidas { get; set; }

        public DadosAtividades()
        {
            Atividades = new List<Atividade>();
            AtividadesConcluidas = new List<Atividade>();
        }
    }
}
