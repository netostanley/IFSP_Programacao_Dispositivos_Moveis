using TPMaui2.Models;

namespace TPMaui2.Views
{
    public partial class PaginaInicial : ContentPage
    {
        // Instância do repositório de tarefas
        private TarefaRepository _repository;

        public PaginaInicial()
        {
            InitializeComponent();
            _repository = App.TarefaRepo; // Obtém o repositório de tarefas

            CarregarTarefas();
        }

        // Método para carregar as tarefas na lista
        public async void CarregarTarefas()
        {
            ListaTarefas.ItemsSource = null;
            var tarefas = await _repository.GetAllTarefasAsync(); // Pega todas as tarefas
            ListaTarefas.ItemsSource = tarefas; // Atualiza a fonte de dados da lista
        }

        // Método para adicionar uma nova tarefa
        private async void OnAdicionarTarefaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdicionarTarefaPage());
        }

        // Método para selecionar uma tarefa
        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                var tarefaSelecionada = e.CurrentSelection[0] as Tarefa;
                await Navigation.PushAsync(new DetalhesTarefaPage(tarefaSelecionada));
            }
        }

        // Método para receber de volta a tarefa salva ou editada
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CarregarTarefas(); // Carrega novamente as tarefas ao retornar para a página
        }
    }
}
