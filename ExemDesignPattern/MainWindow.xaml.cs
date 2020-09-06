using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExemDesignPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal TodoList GeneralListFromDataBase = new TodoList();
        internal TaskTodo SelectedTask;
        private void UpdateListView() {
            elem.ItemsSource = null;
            elem.ItemsSource = GeneralListFromDataBase.Listobsorv.TaskTodo;
        }
        public MainWindow()
        {
            InitializeComponent();
            UpdateListView();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            ToDoListConstructWindow elem = new ToDoListConstructWindow(this);
            var task = new TaskTodo();
            if (elem.ShowDialog() == true) {
            
            }
        }

        private void Edit_Task_Click(object sender, RoutedEventArgs e)
        {
            if (new EditWindow(this).ShowDialog() == false) {
                UpdateListView();
                Edit_Task.IsEnabled = false;
                SelectedTask = null;
                
            }

        }

        private void elem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedTask == null)
            {

                var temp = sender as ListView;
                SelectedTask=temp.SelectedItem as TaskTodo;
                Edit_Task.IsEnabled = true;
                Delete_Task.IsEnabled = true;
            }
            else
            {
                var temp = sender as ListView;
                SelectedTask = temp.SelectedItem as TaskTodo;
            }
        }

        private void Delete_Task_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTask != null) {
                GeneralListFromDataBase.Remove(SelectedTask);
                SelectedTask = null;
                UpdateListView();
                Delete_Task.IsEnabled = false;
                Edit_Task.IsEnabled = false;
            }
        }

        private void ReadfromPdf_Click(object sender, RoutedEventArgs e)
        {
            var fileinfo = new OpenFileDialog();
            if (fileinfo.ShowDialog()==true) {
                GeneralListFromDataBase.Listobsorv.TaskTodo=GeneralListFromDataBase.ReadFromPdf(fileinfo.FileName);
                UpdateListView();
            }

        }

        private void Write_task_List_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "pdf_files|*.pdf";
            saveFileDialog.DefaultExt = ".pdf";
            if (saveFileDialog.ShowDialog() == true) {
                GeneralListFromDataBase.SaveToFilePdf(saveFileDialog.FileName, GeneralListFromDataBase.Listobsorv.TaskTodo);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GeneralListFromDataBase.SaveToHistory();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchingWindow searchwindow = new SearchingWindow(this);
            if (searchwindow.ShowDialog()==true) { }
            UpdateListView();
        }

        private void CleareactiveList_Click(object sender, RoutedEventArgs e)
        {
            GeneralListFromDataBase.ClearActiveList();
            UpdateListView();
        }

        private void CleareHisr_Click(object sender, RoutedEventArgs e)
        {
            GeneralListFromDataBase.ClearHistory();
        }

        private void TodoListOfToday_Click(object sender, RoutedEventArgs e)
        {
            var temp = GeneralListFromDataBase.GetTodayCreatingTask();
            GeneralListFromDataBase.Listobsorv.TaskTodo.Clear();
            foreach(var task in temp)
            {
                var downcast = task as TaskTodo;
                if (downcast != null)
                {
                    GeneralListFromDataBase.Listobsorv.TaskTodo.Add(downcast);
                }
            }
            UpdateListView();
        }
    }
}
