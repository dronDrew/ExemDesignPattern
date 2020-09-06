using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExemDesignPattern
{
    interface ISearchable
    {
        List<ITaskAble> GetByName(ObservableCollection<TaskTodo> tasks,string Name);
        List<ITaskAble> GetByDesc(ObservableCollection<TaskTodo> tasks,string Description);

        List<ITaskAble> GetByTag(ObservableCollection<TaskTodo> tasks,string Tag);

        List<ITaskAble> GetByPriority(ObservableCollection<TaskTodo> tasks,int Priority);

        List<ITaskAble> GetByDateDue(ObservableCollection<TaskTodo> tasks,DateTime date);
        List<ITaskAble> GetByDateCreating(ObservableCollection<TaskTodo> tasks, DateTime DueTo);

        List<ITaskAble> GetByStatus(ObservableCollection<TaskTodo> tasks, bool Status);


    }
}
