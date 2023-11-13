using LogicLayerClassLibrary.Classes;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Interfaces
{
    internal interface IUSERManagerDAL
    {
        public bool AddVisitor(User v);
        public bool UpdateVisitor(User v);
        public List<User> GetAllVisitor();
        public User GetVisitorById(int id);
    }
}
