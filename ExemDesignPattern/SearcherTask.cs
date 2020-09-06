using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemDesignPattern
{
    public class SearcherTask : ISearchable
    {
        public List<ITaskAble> GetByDateCreating(ObservableCollection<TaskTodo> tasks, DateTime date)
        {
            List<ITaskAble> result = new List<ITaskAble>();
            foreach (var task in tasks)
            {
                if (task.CreatingDate.Date == date.Date)
                {
                    result.Add(task);
                }
            }
            return result;
        }

        public List<ITaskAble> GetByDateDue(ObservableCollection<TaskTodo> tasks, DateTime DueTo)
        {
            List<ITaskAble> result = new List<ITaskAble>();
            foreach (var task in tasks)
            {
                if (task.DueTo.Date == DueTo.Date)
                {
                    result.Add(task);
                }
            }
            return result;
        }

        public List<ITaskAble> GetByDesc(ObservableCollection<TaskTodo> tasks, string Description)
        {
            List<ITaskAble> result = new List<ITaskAble>();
            foreach (var task in tasks)
            {
                if (task.Description.Contains(Description))
                {
                    result.Add(task);
                }
            }
            return result;
        }

        public List<ITaskAble> GetByName(ObservableCollection<TaskTodo> tasks, string Name)
        {
            List<ITaskAble> result = new List<ITaskAble>();
            foreach (var task in tasks)
            {
                if (task.Name.Contains(Name))
                {
                    result.Add(task);
                }
            }
            return result;
        }

        public List<ITaskAble> GetByPriority(ObservableCollection<TaskTodo> tasks, int Priority)
        {
            List<ITaskAble> result = new List<ITaskAble>();
            foreach (var task in tasks)
            {
                if (task.Prioriti==Priority)
                {
                    result.Add(task);
                }
            }
            return result;
        }

        public List<ITaskAble> GetByStatus(ObservableCollection<TaskTodo> tasks, bool Status)
        {
            List<ITaskAble> result = new List<ITaskAble>();
            foreach (var task in tasks)
            {
                if (task.Finished == Status)
                {
                    result.Add(task);
                }
            }
            return result;
        }

        public List<ITaskAble> GetByTag(ObservableCollection<TaskTodo> tasks, string Tag)
        {
            List<ITaskAble> result = new List<ITaskAble>();
            foreach (var task in tasks)
            {
                if (task.Tag==Tag)
                {
                    result.Add(task);
                }
            }
            return result;
        }
    }
}
