using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory_Project.Models.Business_Logics
{
    public class EmployeeShiftBL
    {
        private FactoryDBEntities FactoryDB = new FactoryDBEntities();

        public void AddShiftToEmployee(EmployeeShift shift)
        {
            FactoryDB.EmployeeShift.Add(shift);

            FactoryDB.SaveChanges();
        }
    }
}