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

namespace ToDoAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToDoList _todolist;
        public MainWindow()
        {
            InitializeComponent();
            _todolist = new ToDoList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string task = TaskTextBox.Text;
            if (!string.IsNullOrEmpty(task))
            {
                _todolist.AddTask(task);
                UpdateTaskListBox();
                TaskTextBox.Clear();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if(TaskListBox.SelectedIndex >= 0)
            {
                _todolist.RemoveTask(TaskListBox.SelectedIndex);
                UpdateTaskListBox();
            }
        }

        private void UpdateTaskListBox()
        {
            TaskListBox.Items.Clear();
            foreach (var task in _todolist.GetAllTasks())
            {
                TaskListBox.Items.Add(task);
            }
        }
    }
}