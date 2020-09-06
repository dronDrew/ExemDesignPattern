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
using System.Windows.Shapes;

namespace ExemDesignPattern
{
    /// <summary>
    /// Interaction logic for ToDoListConstructWindow.xaml
    /// </summary>
    public partial class ToDoListConstructWindow : Window
    {
        MainWindow reference;
        public ToDoListConstructWindow(MainWindow init)
        {
            InitializeComponent();
            reference = init;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskName.Text) && !string.IsNullOrWhiteSpace(Desc.Text) && !string.IsNullOrWhiteSpace(PriorRate.Value.ToString()) && !string.IsNullOrWhiteSpace(TagInfo.Text)&& !string.IsNullOrWhiteSpace(Dateinfo.SelectedDate.ToString()))
            {

                if (int.TryParse(PriorRate.Value.ToString(), out int result))
                {
                    Labname.Foreground = Brushes.Black; Labname.FontSize = 14;
                    LabDecs.Foreground = Brushes.Black; LabDecs.FontSize = 14;
                    LabPrior.Foreground = Brushes.Black; LabPrior.FontSize = 14;
                    LabTag.Foreground = Brushes.Black; LabTag.FontSize = 14;
                    LabTime.Foreground = Brushes.Black; LabTime.FontSize = 14;
                    reference.GeneralListFromDataBase.Add(new TaskTodo() { Name = TaskName.Text, Description = Desc.Text, Prioriti = result, Tag = TagInfo.Text, DueTo = Dateinfo.SelectedDate.Value });
                    this.Close();
                }
                else
                {
                    PriorRate.Focus();
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(TaskName.Text)) { TaskName.Focus(); Labname.Foreground = Brushes.Red; Labname.FontSize = 18; }
                if (string.IsNullOrWhiteSpace(Desc.Text)) { Desc.Focus(); LabDecs.Foreground = Brushes.Red; LabDecs.FontSize = 18; }
                if (string.IsNullOrWhiteSpace(PriorRate.Value.ToString())) { PriorRate.Focus(); LabPrior.Foreground = Brushes.Red; LabPrior.FontSize = 18; }
                if (string.IsNullOrWhiteSpace(TagInfo.Text)) { TagInfo.Focus(); LabTag.Foreground = Brushes.Red; LabTag.FontSize = 18; }
                if (string.IsNullOrWhiteSpace(Dateinfo.SelectedDate.ToString())) { Dateinfo.Focus(); LabTime.Foreground = Brushes.Red; LabTime.FontSize = 18; }
            }
            
        }
    }
}
