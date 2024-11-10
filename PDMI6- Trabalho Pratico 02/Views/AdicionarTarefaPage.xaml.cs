using TPMaui2.Models;

namespace TPMaui2.Views
{
    public partial class AdicionarTarefaPage : ContentPage
    {
        private Tarefa tarefaEdicao;

        public AdicionarTarefaPage(Tarefa tarefa = null)
        {
            InitializeComponent();

            if (tarefa != null)
            {
                tarefaEdicao = tarefa;
                EntryTitulo.Text = tarefa.Titulo;
                EditorDescricao.Text = tarefa.Descricao;
                DatePickerDataCriacao.Date = tarefa.DataCriacao;
                PickerPrioridade.SelectedItem = tarefa.Prioridade;
            }
            else
            {
                tarefaEdicao = new Tarefa();
            }
        }

        private async void OnSalvarClicked(object sender, EventArgs e)
        {
            // Atualizando os dados da tarefa
            tarefaEdicao.Titulo = EntryTitulo.Text;
            tarefaEdicao.Descricao = EditorDescricao.Text;
            tarefaEdicao.DataCriacao = DatePickerDataCriacao.Date;
            tarefaEdicao.Prioridade = PickerPrioridade.SelectedItem.ToString();

            // Usando o repositório existente
            var repository = App.TarefaRepo; // Use a instância existente do repositório
            var sucesso = await repository.SaveTarefaAsync(tarefaEdicao);

            if (sucesso)
            {
                await Navigation.PopToRootAsync(); // Fecha a página modal
            }
            else
            {
                await DisplayAlert("Erro", "Ocorreu um erro ao salvar a tarefa.", "OK");
            }
        }

    }
}
