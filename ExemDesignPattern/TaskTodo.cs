using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup.Localizer;

namespace ExemDesignPattern
{
    [Serializable]
    public class TaskTodo : ITaskAble
    {
        private string _name;
        private string _desc;
        private int _prior = 0;
        bool _finish = false;
        private DateTime _timedue = DateTime.Now;
        private DateTime _creatingDate = DateTime.Now;
        public string Name { get => _name; set => _name=value; }
        public string Description { get => _desc; set => _desc =value; }
        public int Prioriti { get => _prior; set => _prior=value; }

        public string Tag { get;  set; }

        public DateTime DueTo { get { return _timedue; }  set { _timedue = value; } }

        public bool Finished { get { return _finish; } set { _finish = value; } }

        public ITaskAble Clone()
        {
            return (TaskTodo)this.MemberwiseClone();
        }
        public DateTime CreatingDate { get; }
    }
}
