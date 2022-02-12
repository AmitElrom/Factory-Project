using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory_Project.Models.Business_Logics
{
    public class DepartmentBL
    {
        private FactoryDBEntities FactoryDB = new FactoryDBEntities();

        public bool ThereIsNOemployees(int DepartmentID)
        {
            foreach (var employee in FactoryDB.Employee)
            {
                if (employee.DepartmentID == DepartmentID)
                    return false; 
            }
            return true;
        }

        public List<DepartmentExtended> GetDepartments()
        {
            List<DepartmentExtended> Departments = new List<DepartmentExtended>();

            foreach (var department in FactoryDB.Department)
            {
                DepartmentExtended d = new DepartmentExtended();
                d.ID = department.ID;
                d.Name = department.Name;
                d.CanDepBeDeleted = ThereIsNOemployees(d.ID);

                var manager = FactoryDB.Employee.Where(x => x.ID == department.Manager).FirstOrDefault();

                if(manager != null)
                {
                    d.ManagerName = manager.FirstName + " " + manager.LastName;
                }
                else
                {
                    d.ManagerName = "This department does not have a manager yet.";
                }

                Departments.Add(d);
            }

            return Departments;
        }

        public DepartmentExtended GetDepartment(int id)
        {
            var dep = FactoryDB.Department.Where(x => x.ID == id).First();
            var EmpDep = FactoryDB.Employee.Where(x => x.ID == dep.Manager).FirstOrDefault();

            DepartmentExtended d = new DepartmentExtended();
            d.ID = dep.ID;
            d.Name = dep.Name;
            if(dep.Manager != null)
            {
                d.ManagerName = EmpDep.FirstName + " " + EmpDep.LastName;
            }
            else
            {
                d.ManagerName = "This department does not have a manager yet.";
            }

            return d;
        }

        public void AddDepartment(DepartmentExtended department)
        {
            var manager = FactoryDB.Employee.Where(x => x.FirstName + " " + x.LastName == department.ManagerName).FirstOrDefault();
            Department department1 = new Department();
            department1.Name = department.Name;
            department1.Manager = manager.ID;
            FactoryDB.Department.Add(department1);
            FactoryDB.SaveChanges();
            
            var depart = FactoryDB.Department.Where(x => x.Name == department1.Name).First();
            manager.DepartmentID = depart.ID;
            FactoryDB.SaveChanges();
        }

        public void UpdateDepartment(int id, DepartmentExtended department)
        {
            var dep = FactoryDB.Department.Where(x => x.ID == id).First();
            dep.Name = department.Name;

            var NewManager = FactoryDB.Employee.Where(x => x.FirstName + " " + x.LastName == department.ManagerName).FirstOrDefault();
            if (NewManager != null)
            {
                dep.Manager = NewManager.ID;
                NewManager.DepartmentID = dep.ID;
            }

            FactoryDB.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var dep = FactoryDB.Department.Where(x => x.ID == id).FirstOrDefault();
            FactoryDB.Department.Remove(dep);

            FactoryDB.SaveChanges();
        }
    }
}