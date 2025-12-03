using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppAgendaDeTarefas;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string descricao;
    private List<String> listaTarefas = new List<String>();
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// funcionalidade inicial 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Adicionar_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TxtTarefa.Text))
        {
            ListaTarefas.Items.Add(TxtTarefa.Text);
            AdicionarTarefas();
            TxtTarefa.Clear();
        }
        else
        {
            MessageBox.Show("Digite uma tarefa válida!");
        }
    }
    private void Limpar_lista_Click(object sender, RoutedEventArgs e)
    {
        if (ListaTarefas.Items.Count > 0)
        {
            
            ListaTarefas.Items.Clear(); 
            
            MessageBox.Show("A lista foi limpa com sucesso!", "Limpeza");
        }
    }
    private void AdicionarTarefas()
    {
         descricao = TxtTarefa.Text.Trim();

        if (!string.IsNullOrWhiteSpace(descricao))
        {
            listaTarefas.Add(descricao);
        }
    }
    
    private void Editartarefa_OnClick(object sender, RoutedEventArgs e)
    {
        // Verifica se existe uma tarefa selecionada
        if (ListaTarefas.SelectedItem != null)
        {
            // Pega o índice do item selecionado
            int index = ListaTarefas.SelectedIndex;

            // Edita a tarefa no ListBox usando o texto do TextBox de edição
            ListaTarefas.Items[index] = TxtTarefa.Text;

            MessageBox.Show("Tarefa editada com sucesso!");
        }
        else
        {
            MessageBox.Show("Selecione uma tarefa para editar!");
        }
    }

    //Botão de duplicar tarefa selecionada
    private void BtnDuplicar(object sender, RoutedEventArgs e)
    {
        if (ListaTarefas.SelectedItem != null)
        {
            string duplicata = ListaTarefas.SelectedItem.ToString();
            ListaTarefas.Items.Add(duplicata);
            
            MessageBox.Show("Tarefa Duplicada com sucesso!", "Duplicar",MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            MessageBox.Show("Selecione uma tarefa para duplicar!", "Duplicar",MessageBoxButton.OK, MessageBoxImage.Information);

        }
       

    }
    
}