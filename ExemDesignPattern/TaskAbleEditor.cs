using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemDesignPattern
{
    public class TaskAbleEditor : IEditable
    {
        public void ChangeDateDue(TaskTodo task, DateTime new_Due_Date)
        {
           
                task.DueTo = new_Due_Date;
        }

        public void ChangeDescription(ITaskAble task, string new_Description)
        {
            task.Description = new_Description;
        }

        public void ChangeName(ITaskAble task, string new_name)
        {
            task.Name = new_name;
        }

        public void ChangePriority(ITaskAble task, int new_Priority)
        {
            task.Prioriti = new_Priority;
        }

        public void ChangeTag(ITaskAble task, string new_Tag)
        {
            var temp = task as TaskTodo;
            if (temp != null)
            {
                temp.Tag = new_Tag;
            }
        }
    }
}
