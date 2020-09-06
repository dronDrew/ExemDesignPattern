using System.Windows;
using System.Windows.Media;



namespace ExemDesignPattern
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    
    public partial class EditWindow : Window
    {
        MainWindow initial;
        TaskAbleEditor editor = new TaskAbleEditor();
        TaskTodo elemGen;
        public EditWindow( MainWindow init)
        {
            InitializeComponent();
            initial = init;
            elemGen = initial.SelectedTask;
            MainPanel.DataContext = elemGen;
            Dateinfo.SelectedDate = elemGen.DueTo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskName.Text) && !string.IsNullOrWhiteSpace(Desc.Text) && !string.IsNullOrWhiteSpace(PriorRate.Value.ToString()) && !string.IsNullOrWhiteSpace(TagInfo.Text) && !string.IsNullOrWhiteSpace(Dateinfo.SelectedDate.ToString()))
            {
                Labname.Foreground = Brushes.Black; Labname.FontSize = 14;
                LabDecs.Foreground = Brushes.Black; LabDecs.FontSize = 14;
                LabPrior.Foreground = Brushes.Black; LabPrior.FontSize = 14; 
                LabTag.Foreground = Brushes.Black; LabTag.FontSize = 14;
                LabTime.Foreground = Brushes.Black; LabTime.FontSize = 14;
                editor.ChangeName(elemGen, TaskName.Text);
                editor.ChangeDescription(elemGen, Desc.Text);
                var tempValue = 0;
                int.TryParse(PriorRate.Value.ToString(), out tempValue);
                editor.ChangePriority(elemGen, tempValue);
                editor.ChangeTag(elemGen, TagInfo.Text);
                editor.ChangeDateDue(elemGen, Dateinfo.SelectedDate.Value);
                initial.SelectedTask = elemGen;
                this.Close();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(TaskName.Text)) { TaskName.Focus(); Labname.Foreground = Brushes.Red;Labname.FontSize = 18; }
                if (string.IsNullOrWhiteSpace(Desc.Text)) { Desc.Focus(); LabDecs.Foreground = Brushes.Red; LabDecs.FontSize = 18; }
                if (string.IsNullOrWhiteSpace(PriorRate.Value.ToString())) { PriorRate.Focus();  LabPrior.Foreground = Brushes.Red; LabPrior.FontSize = 18; }
                if (string.IsNullOrWhiteSpace(TagInfo.Text)) { TagInfo.Focus(); LabTag.Foreground = Brushes.Red; LabTag.FontSize = 18;  }
                if (string.IsNullOrWhiteSpace(Dateinfo.SelectedDate.ToString())) { Dateinfo.Focus(); LabTime.Foreground = Brushes.Red; LabTime.FontSize = 18; }
            }
        }
    }
}
