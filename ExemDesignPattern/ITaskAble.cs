using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemDesignPattern
{
    public  interface ITaskAble
    {
         string Name { get;  set; }
         string Description { get; set; }
         int Prioriti { get; set; }
        bool Finished { get; set; }
         ITaskAble Clone();
    }
}
