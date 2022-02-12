using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory_Project.Models.Business_Logics
{
    public class ShiftBL
    {
        private FactoryDBEntities FactoryDB = new FactoryDBEntities();

        public List<ShiftExtended> GetShifts()
        {
            List<ShiftExtended> Shifts = new List<ShiftExtended>();

            foreach (var shift in FactoryDB.Shift)
            {
                ShiftExtended s = new ShiftExtended();
                s.ID = shift.ID;
                s.Date = shift.Date;
                s.StartTime = shift.StartTime;
                s.EndTime = shift.EndTime;

                s.Employees = new List<Employee>();

                var result = FactoryDB.EmployeeShift.Where(x => x.ShiftID == shift.ID).ToList();

                foreach (var item in result)
                {
                    var e = FactoryDB.Employee.Where(x => x.ID == item.EmployeeID).First(); 

                    s.Employees.Add(e);
                }

                Shifts.Add(s);
            }

            return Shifts;
        }

        public void AddShift(Shift shift)
        {
            FactoryDB.Shift.Add(shift);

            FactoryDB.SaveChanges();
        }
    }
}