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
    /// Interaction logic for SearchingWindow.xaml
    /// </summary>
    public partial class SearchingWindow : Window
    {
        MainWindow windowconection;
        public SearchingWindow(MainWindow generalWindow)
        {
            InitializeComponent();
            windowconection = generalWindow;
        }
        // for all others type for search methodology of interact will be the same.
        //for searching by tag ,by description and others

        private void NameSearch_Click(object sender, RoutedEventArgs e)
        {
            List<ITaskAble> tasks = new List<ITaskAble>();
            if (NameInHist.IsChecked == true)
            {
                tasks = windowconection.GeneralListFromDataBase.GetTaskByNameFromHistory(KeywordName.Text);
            }
            else if (NameInActive.IsChecked == true)
            {
                tasks = windowconection.GeneralListFromDataBase.GetTaskByNameFromActiveList(KeywordName.Text);
            }
            if (tasks.Count > 0)
            {
                windowconection.GeneralListFromDataBase.ClearActiveList();
                foreach (var task in tasks)
                {
                    var temp = task as TaskTodo;
                    if (temp != null)
                    {
                        windowconection.GeneralListFromDataBase.Add(temp);
                    }
                }
            }
            this.Close();

        }

        private void NameInHist_Checked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(KeywordName.Text) && !string.IsNullOrWhiteSpace(KeywordName.Text))
            {


                NameSearch.IsEnabled = true;

            }
            else
            {
                NameSearch.IsEnabled = false;
            }
        }

        private void NameInActive_Checked(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(KeywordName.Text) && !string.IsNullOrWhiteSpace(KeywordName.Text))
            {


                NameSearch.IsEnabled = true;

            }
            else
            {
                NameSearch.IsEnabled = false;
            }
        }
    }
}
