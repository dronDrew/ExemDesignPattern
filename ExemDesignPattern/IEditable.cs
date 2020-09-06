using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemDesignPattern
{
    interface IEditable
    {
        void ChangeName(ITaskAble task,string new_name);
        void ChangeDescription(ITaskAble task , string new_Description);
        void ChangePriority(ITaskAble task , int new_Priority);
        void ChangeTag(ITaskAble task , string new_Tag);
        void ChangeDateDue(TaskTodo task ,DateTime new_Due_Date);
    }
}
