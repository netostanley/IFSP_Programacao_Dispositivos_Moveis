using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMaui2.Models
{
    public class TarefaRepository
    {
        public TarefaRepository() { _tarefas = new List<Tarefa>();  }

        public static List<Tarefa> _tarefas;

        public async Task<bool> SaveTarefaAsync(Tarefa tarefa)
        {
            if (tarefa == null)
                return false;

            // Se tarefa já tiver um Titulo, atualiza, caso contrário adiciona uma nova
            if (!string.IsNullOrEmpty(tarefa.Titulo))
            {
                var existingTarefa = _tarefas.FirstOrDefault(t => t.Titulo == tarefa.Titulo);
                if (existingTarefa != null)
                {
                    existingTarefa.Descricao = tarefa.Descricao;
                    existingTarefa.DataCriacao = tarefa.DataCriacao;
                    existingTarefa.Prioridade = tarefa.Prioridade;
                }
                else
                {
                    _tarefas.Add(tarefa);
                }
            }

            // Simulando um salvamento assíncrono
            await Task.CompletedTask; // Remova isto se você estiver acessando um banco de dados
            return true; // Retorna true se a operação foi bem-sucedida
        }

        public async Task<List<Tarefa>> GetAllTarefasAsync()
        {
            return await Task.FromResult(_tarefas); // Retorna a lista de tarefas
        }
    }


}
