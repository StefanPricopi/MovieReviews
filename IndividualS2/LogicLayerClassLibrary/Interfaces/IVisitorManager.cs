using LogicLayerClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Interfaces
{
    internal interface IVisitorManager
    {
        public bool AddVisitor(Visitor v);
        public bool UpdateVisitor(Visitor v);
        public List<Visitor> GetAllVisitor();
        public Visitor GetVisitorById(int id);
    }
}
