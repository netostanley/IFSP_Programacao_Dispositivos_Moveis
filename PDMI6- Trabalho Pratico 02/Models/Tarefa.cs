using System;

namespace TPMaui2.Models
{
    public class Tarefa
    {
        // Construtor para inicializar Titulo e Descricao
        public Tarefa()
        {
            Titulo = "ADICIONE UMA TAREFA";
            Descricao = "";
            DataCriacao = DateTime.Now; // Definindo a DataCriacao como a data e hora atual
            Prioridade = "Baixa"; // Definindo a prioridade como "Normal" por padrão
        }

        // Propriedades da tarefa
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Prioridade { get; set; }
    }
}
