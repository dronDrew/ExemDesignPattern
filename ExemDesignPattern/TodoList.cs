using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExemDesignPattern
{
    class TodoList 
    {
        private TaskListController ListOfTask = new TaskListController();
        public TaskListController Listobsorv { get { return ListOfTask; } }
        TaskReadandWriteModule writeandreadmodule = new TaskReadandWriteModule();
        //adding, removing and cleaning block
        public void Add(TaskTodo task)
        {
            ListOfTask.Add(task);
        }

        public void Remove(TaskTodo task)
        {
            ListOfTask.Remove(task);
        }

        public void ClearHistory() {
            Listobsorv.Clear(Listobsorv.history);
        }

        public void ClearActiveList()
        {
            foreach(var task in Listobsorv.TaskTodo)
            {
                Listobsorv.history.Remove(task);
            }
            Listobsorv.Clear(Listobsorv.TaskTodo);
        }
        //Writing tasks block
        public ObservableCollection<TaskTodo> ReadFromPdf(string Path) {
            return writeandreadmodule.ReadFromUserFile(Path);
        }
        public void SaveToFilePdf(string Path, ObservableCollection<TaskTodo> colaction) {
            writeandreadmodule.WriteTaskListToUserFile(Path, colaction);
        
        }

        internal void SaveToHistory() {
            ListOfTask.LoadToHistoryFile();
            
        }
        internal ObservableCollection<TaskTodo> ReadFromHistoryFile() {
            return ListOfTask.GetFromHistoryFile();
        }
        //Searching tasks
        //by name
        public List<ITaskAble> GetTaskByNameFromHistory(string Name)
        {
            return Listobsorv.GetTaskByNameFromHistory(Name);
        }
        public List<ITaskAble> GetTaskByNameFromActiveList(string Name)
        {
            return Listobsorv.GetTaskByNameFromActiveList(Name);
        }
        //by description
        public List<ITaskAble> GetTaskByDescFromHistory(string Description)
        {
            return Listobsorv.GetTaskByDescFromHistory(Description);
        }
        public List<ITaskAble> GetTaskByDescFromActiveList(string Description)
        {
            return Listobsorv.GetTaskByDescFromActiveList(Description);
        }
        //by tag
        public List<ITaskAble> GetTaskByTagFromHistory(string Tag)
        {
            return Listobsorv.GetTaskByTagFromHistory(Tag);
        }
        public List<ITaskAble> GetTaskByTagFromActiveList(string Tag)
        {
            return Listobsorv.GetTaskByTagFromActiveList(Tag);
        }
        //by priority
        public List<ITaskAble> GetByPriorityFromHistory(int Priority)
        {
            return Listobsorv.GetByPriorityFromHistory(Priority);
        }
        public List<ITaskAble> GetByPriorityFromActiveList(int Priority)
        {
            return Listobsorv.GetByPriorityFromActiveList(Priority);
        }
        //by date
        public List<ITaskAble> GetTodayCreatingTask() {
            return Listobsorv.GetTodayCreatingTask();
        }

        public List<ITaskAble> GetByCreatingDate(DateTime date) {
            return Listobsorv.GetByCreatingDayTasks(date);
        }

        public List<ITaskAble> GetTasksDueTofromHistory(DateTime dueTo)
        {
            return Listobsorv.GetTasksDueTofromHistory(dueTo);
        }
        public List<ITaskAble> GetTasksDueTofromActiveTasks(DateTime dueTo)
        {
            return Listobsorv.GetTasksDueTofromActiveTasks(dueTo);
        }

        //by status
        public List<ITaskAble> GetTaskByStatusFromHistory(bool status)
        {
            return Listobsorv.GetTaskByStatusFromHistory(status);
        }
        public List<ITaskAble> GetTaskByStatusFromActiveList(bool status)
        {
            return Listobsorv.GetTaskByStatusFromActiveList(status);
        }

    }

}

