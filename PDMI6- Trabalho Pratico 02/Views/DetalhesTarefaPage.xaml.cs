using TPMaui2.Models;

namespace TPMaui2.Views
{
    public partial class DetalhesTarefaPage : ContentPage
    {
        private Tarefa tarefa;

        public DetalhesTarefaPage(Tarefa tarefaSelecionada)
        {
            InitializeComponent();
            tarefa = tarefaSelecionada;
            LblTitulo.Text = tarefa.Titulo;
            LblDescricao.Text = tarefa.Descricao;
            LblDataCriacao.Text = tarefa.DataCriacao.ToString("dd/MM/yyyy");
            LblPrioridade.Text = tarefa.Prioridade;
        }

        private async void OnEditarClicked(object sender, EventArgs e)
        {
            // Navegar para a página de edição
            await Navigation.PushAsync(new AdicionarTarefaPage(tarefa));
        }

        private async void OnExcluirClicked(object sender, EventArgs e)
        {
            var confirmacao = await DisplayAlert("Excluir Tarefa", "Tem certeza que deseja excluir esta tarefa?", "Sim", "Não");
            if (confirmacao)
            {
                // Código para excluir a tarefa
                await Navigation.PopAsync();
            }
        }
    }
}
