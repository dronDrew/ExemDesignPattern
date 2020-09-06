using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace ExemDesignPattern
{
    public class TaskListController : IListContolable
    {
        private readonly TaskReadandWriteModule serialize = new TaskReadandWriteModule();
        private ObservableCollection<TaskTodo> History { get;  set; }
        internal ObservableCollection<TaskTodo> history { get { return History; }  }
        public ObservableCollection<TaskTodo> TaskTodo { get; set; }
        private SearcherTask searcher = new SearcherTask();

        //List Controller
        public void Add(TaskTodo task)
        {
            TaskTodo.Add(task);
            if (!History.Contains(task))
            {
                History.Add(task);
            }
        }

        public void Remove(TaskTodo task)
        {
            TaskTodo.Remove(task);
        }

        public void Clear(ObservableCollection<TaskTodo> tasks)
        {
            tasks.Clear();
        }

        //serialization method and constructor
        internal void LoadToHistoryFile()
        {
            serialize.WriteToStoryFile(History);
        }
        internal ObservableCollection<TaskTodo> GetFromHistoryFile() {

            return serialize.ReadFromHistoryFile();
        }

        public TaskListController() {
            TaskTodo = new ObservableCollection<TaskTodo>();
            History = new ObservableCollection<TaskTodo>();
            History = GetFromHistoryFile();
        }


        //Searching Tasks
        //by name
        public List<ITaskAble> GetTaskByNameFromHistory(string Name)
        {
            return searcher.GetByName(history, Name);
        }
        public List<ITaskAble> GetTaskByNameFromActiveList(string Name)
        {
            return searcher.GetByName(TaskTodo, Name);
        }
        //by description
        public List<ITaskAble> GetTaskByDescFromHistory(string Description)
        {
            return searcher.GetByDesc(history, Description);
        }
        public List<ITaskAble> GetTaskByDescFromActiveList(string Description)
        {
            return searcher.GetByDesc(TaskTodo, Description);
        }
       //by tag
        public List<ITaskAble> GetTaskByTagFromHistory(string Tag)
        {
            return searcher.GetByTag(history, Tag);
        }
        public List<ITaskAble> GetTaskByTagFromActiveList(string Tag)
        {
            return searcher.GetByTag(TaskTodo, Tag);
        }
        //by priority
        public List<ITaskAble> GetByPriorityFromHistory(int Priority)
        {
            return searcher.GetByPriority(history, Priority);
        }
        public List<ITaskAble> GetByPriorityFromActiveList(int Priority)
        {
            return searcher.GetByPriority(TaskTodo, Priority);
        }
        //by date
        public List<ITaskAble> GetTodayCreatingTask() {
            DateTime Today = DateTime.Now;
            return searcher.GetByDateCreating(history, Today);
        }

        public List<ITaskAble> GetByCreatingDayTasks(DateTime date)
        {
            return searcher.GetByDateCreating(history, date);
        }

        public List<ITaskAble> GetTasksDueTofromHistory(DateTime dueTo)
        {
            return searcher.GetByDateDue(history, dueTo);
        }
        public List<ITaskAble> GetTasksDueTofromActiveTasks(DateTime dueTo)
        {
            return searcher.GetByDateDue(TaskTodo, dueTo);
        }

        //by status
        public List<ITaskAble> GetTaskByStatusFromHistory (bool status) {
            return searcher.GetByStatus(history, status);
        }
        public List<ITaskAble> GetTaskByStatusFromActiveList(bool status)
        {
            return searcher.GetByStatus(TaskTodo, status);
        }

       
    }
}
