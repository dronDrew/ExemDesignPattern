using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemDesignPattern
{
    interface IListContolable
    {
        void Add(TaskTodo task);
        void Remove(TaskTodo task);

        void Clear(ObservableCollection<TaskTodo> task);
    }
}
