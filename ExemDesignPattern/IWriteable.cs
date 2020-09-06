using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemDesignPattern
{
    public interface IWriteable
    {
        void WriteToStoryFile(ObservableCollection<TaskTodo> ListofTasks);
        void WriteTaskListToUserFile(string path, ObservableCollection<TaskTodo> ListofTasks);
    }
}
