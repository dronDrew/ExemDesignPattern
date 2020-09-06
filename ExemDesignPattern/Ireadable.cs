using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemDesignPattern
{
    public interface Ireadable
    {
        ObservableCollection<TaskTodo> ReadFromHistoryFile();
        ObservableCollection<TaskTodo> ReadFromUserFile(string Path);
    }
}
