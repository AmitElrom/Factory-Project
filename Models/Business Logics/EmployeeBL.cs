using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory_Project.Models.Business_Logics
{
    public class EmployeeBL
    {
        private FactoryDBEntities FactoryDB = new FactoryDBEntities();

        public List<EmployeeExtended> GetEmployees(string fname, string lname, int department)
        {
            if (fname == "") //no filter fname
            { 
                if(lname == "") // no filer fname, no filer lname
                {
                    if (department == 0) // no filer fname, no filer lname, no filer department
                    {
                        List<EmployeeExtended> Employees = new List<EmployeeExtended>();

                        foreach (var employee in FactoryDB.Employee)
                        {
                            EmployeeExtended e = new EmployeeExtended();
                            e.ID = employee.ID;
                            e.FirstName = employee.FirstName;
                            e.LastName = employee.LastName;
                            e.StartWorkYear = employee.StartWorkYear;

                            e.Shifts = new List<Shift>();

                            var EmpDep = FactoryDB.Department.Where(x => x.ID == employee.DepartmentID).FirstOrDefault();
                            if (EmpDep != null)
                            {
                                e.DepartmentName = EmpDep.Name;
                            }

                            var result1 = FactoryDB.EmployeeShift.Where(x => x.EmployeeID == employee.ID).ToList();

                            foreach (var shift in result1)
                            {
                                var s = FactoryDB.Shift.Where(x => x.ID == shift.ShiftID).FirstOrDefault();

                                Shift shift2 = new Shift();
                                shift2.ID = s.ID;
                                shift2.Date = s.Date;
                                shift2.StartTime = s.StartTime;
                                shift2.EndTime = s.EndTime;

                                e.Shifts.Add(shift2);
                            }
                            Employees.Add(e);
                        }
                        return Employees;
                    }
                    else // no filer fname, no filer lname, yes filer department
                    {
                        List<EmployeeExtended> Employees = new List<EmployeeExtended>();

                        var result = FactoryDB.Employee.Where(x => x.DepartmentID == department).ToList();
                        foreach (var employee in result)
                        {
                            EmployeeExtended e = new EmployeeExtended();
                            e.ID = employee.ID;
                            e.FirstName = employee.FirstName;
                            e.LastName = employee.LastName;
                            e.StartWorkYear = employee.StartWorkYear;

                            e.Shifts = new List<Shift>();

                            var EmpDep = FactoryDB.Department.Where(x => x.ID == employee.DepartmentID).FirstOrDefault();
                            if (EmpDep != null)
                            {
                                e.DepartmentName = EmpDep.Name;
                            }

                            var result1 = FactoryDB.EmployeeShift.Where(x => x.EmployeeID == employee.ID).ToList();

                            foreach (var shift in result1)
                            {
                                var s = FactoryDB.Shift.Where(x => x.ID == shift.ShiftID).FirstOrDefault();

                                Shift shift2 = new Shift();
                                shift2.ID = s.ID;
                                shift2.Date = s.Date;
                                shift2.StartTime = s.StartTime;
                                shift2.EndTime = s.EndTime;

                                e.Shifts.Add(shift2);
                            }
                            Employees.Add(e);
                        }
                        return Employees;
                    }
                }
                else // no filter fname, yes filer lname
                {
                    if(department == 0) //no filter fname, yes filer lname, no filer department
                    {
                        List<EmployeeExtended> Employees = new List<EmployeeExtended>();

                        var result = FactoryDB.Employee.Where(x => x.LastName == lname).ToList();
                        foreach (var employee in result)
                        {
                            EmployeeExtended e = new EmployeeExtended();
                            e.ID = employee.ID;
                            e.FirstName = employee.FirstName;
                            e.LastName = employee.LastName;
                            e.StartWorkYear = employee.StartWorkYear;

                            e.Shifts = new List<Shift>();

                            var EmpDep = FactoryDB.Department.Where(x => x.ID == employee.DepartmentID).FirstOrDefault();
                            if (EmpDep != null)
                            {
                                e.DepartmentName = EmpDep.Name;
                            }

                            var result1 = FactoryDB.EmployeeShift.Where(x => x.EmployeeID == employee.ID).ToList();

                            foreach (var shift in result1)
                            {
                                var s = FactoryDB.Shift.Where(x => x.ID == shift.ShiftID).FirstOrDefault();

                                Shift shift2 = new Shift();
                                shift2.ID = s.ID;
                                shift2.Date = s.Date;
                                shift2.StartTime = s.StartTime;
                                shift2.EndTime = s.EndTime;

                                e.Shifts.Add(shift2);
                            }
                            Employees.Add(e);
                        }
                        return Employees;
                    }
                    else // no filter fname, yes filer lname, yes filer department
                    {
                        List<EmployeeExtended> Employees = new List<EmployeeExtended>();

                        var result = FactoryDB.Employee.Where(x => x.DepartmentID == department && x.LastName == lname).ToList();
                        foreach (var employee in result)
                        {
                            EmployeeExtended e = new EmployeeExtended();
                            e.ID = employee.ID;
                            e.FirstName = employee.FirstName;
                            e.LastName = employee.LastName;
                            e.StartWorkYear = employee.StartWorkYear;

                            e.Shifts = new List<Shift>();

                            var EmpDep = FactoryDB.Department.Where(x => x.ID == employee.DepartmentID).FirstOrDefault();
                            if (EmpDep != null)
                            {
                                e.DepartmentName = EmpDep.Name;
                            }

                            var result1 = FactoryDB.EmployeeShift.Where(x => x.EmployeeID == employee.ID).ToList();

                            foreach (var shift in result1)
                            {
                                var s = FactoryDB.Shift.Where(x => x.ID == shift.ShiftID).FirstOrDefault();

                                Shift shift2 = new Shift();
                                shift2.ID = s.ID;
                                shift2.Date = s.Date;
                                shift2.StartTime = s.StartTime;
                                shift2.EndTime = s.EndTime;

                                e.Shifts.Add(shift2);
                            }
                            Employees.Add(e);
                        }
                        return Employees;
                    }

                }
            
            }
            else // yes filter fname
            {
                if (lname == "") // yes filter fname, no filer lname
                {
                    if (department == 0) // yes filter fname, no filer lname, no filter department
                    {
                        List<EmployeeExtended> Employees = new List<EmployeeExtended>();

                        var result = FactoryDB.Employee.Where(x => x.FirstName == fname).ToList();
                        foreach (var employee in result)
                        {
                            EmployeeExtended e = new EmployeeExtended();
                            e.ID = employee.ID;
                            e.FirstName = employee.FirstName;
                            e.LastName = employee.LastName;
                            e.StartWorkYear = employee.StartWorkYear;

                            e.Shifts = new List<Shift>();

                            var EmpDep = FactoryDB.Department.Where(x => x.ID == employee.DepartmentID).FirstOrDefault();
                            if (EmpDep != null)
                            {
                                e.DepartmentName = EmpDep.Name;
                            }

                            var result1 = FactoryDB.EmployeeShift.Where(x => x.EmployeeID == employee.ID).ToList();

                            foreach (var shift in result1)
                            {
                                var s = FactoryDB.Shift.Where(x => x.ID == shift.ShiftID).FirstOrDefault();

                                Shift shift2 = new Shift();
                                shift2.ID = s.ID;
                                shift2.Date = s.Date;
                                shift2.StartTime = s.StartTime;
                                shift2.EndTime = s.EndTime;

                                e.Shifts.Add(shift2);
                            }
                            Employees.Add(e);
                        }
                        return Employees;
                    }
                    else // yes filter fname, no filer lname, yes filter department
                    {
                        List<EmployeeExtended> Employees = new List<EmployeeExtended>();

                        var result = FactoryDB.Employee.Where(x => x.FirstName == fname && x.DepartmentID == department).ToList();
                        foreach (var employee in result)
                        {
                            EmployeeExtended e = new EmployeeExtended();
                            e.ID = employee.ID;
                            e.FirstName = employee.FirstName;
                            e.LastName = employee.LastName;
                            e.StartWorkYear = employee.StartWorkYear;

                            e.Shifts = new List<Shift>();

                            var EmpDep = FactoryDB.Department.Where(x => x.ID == employee.DepartmentID).FirstOrDefault();
                            if (EmpDep != null)
                            {
                                e.DepartmentName = EmpDep.Name;
                            }

                            var result1 = FactoryDB.EmployeeShift.Where(x => x.EmployeeID == employee.ID).ToList();

                            foreach (var shift in result1)
                            {
                                var s = FactoryDB.Shift.Where(x => x.ID == shift.ShiftID).FirstOrDefault();

                                Shift shift2 = new Shift();
                                shift2.ID = s.ID;
                                shift2.Date = s.Date;
                                shift2.StartTime = s.StartTime;
                                shift2.EndTime = s.EndTime;

                                e.Shifts.Add(shift2);
                            }
                            Employees.Add(e);
                        }
                        return Employees;
                    }

                }
                else // yes filter fname, yes filer lname
                {
                    if(department == 0) // yes filter fname, yes filer lname, no filter department
                    {
                        List<EmployeeExtended> Employees = new List<EmployeeExtended>();

                        var result = FactoryDB.Employee.Where(x => x.FirstName == fname && x.LastName == lname).ToList();
                        foreach (var employee in result)
                        {
                            EmployeeExtended e = new EmployeeExtended();
                            e.ID = employee.ID;
                            e.FirstName = employee.FirstName;
                            e.LastName = employee.LastName;
                            e.StartWorkYear = employee.StartWorkYear;

                            e.Shifts = new List<Shift>();

                            var EmpDep = FactoryDB.Department.Where(x => x.ID == employee.DepartmentID).FirstOrDefault();
                            if (EmpDep != null)
                            {
                                e.DepartmentName = EmpDep.Name;
                            }

                            var result1 = FactoryDB.EmployeeShift.Where(x => x.EmployeeID == employee.ID).ToList();

                            foreach (var shift in result1)
                            {
                                var s = FactoryDB.Shift.Where(x => x.ID == shift.ShiftID).FirstOrDefault();

                                Shift shift2 = new Shift();
                                shift2.ID = s.ID;
                                shift2.Date = s.Date;
                                shift2.StartTime = s.StartTime;
                                shift2.EndTime = s.EndTime;

                                e.Shifts.Add(shift2);
                            }
                            Employees.Add(e);
                        }
                        return Employees;
                    }
                    else // yes filter fname, yes filer lname, yes filter department
                    {
                        List<EmployeeExtended> Employees = new List<EmployeeExtended>();

                        var result = FactoryDB.Employee.Where(x => x.FirstName == fname && x.LastName == lname && x.DepartmentID == department).ToList();
                        foreach (var employee in result)
                        {
                            EmployeeExtended e = new EmployeeExtended();
                            e.ID = employee.ID;
                            e.FirstName = employee.FirstName;
                            e.LastName = employee.LastName;
                            e.StartWorkYear = employee.StartWorkYear;

                            e.Shifts = new List<Shift>();

                            var EmpDep = FactoryDB.Department.Where(x => x.ID == employee.DepartmentID).FirstOrDefault();
                            if (EmpDep != null)
                            {
                                e.DepartmentName = EmpDep.Name;
                            }

                            var result1 = FactoryDB.EmployeeShift.Where(x => x.EmployeeID == employee.ID).ToList();

                            foreach (var shift in result1)
                            {
                                var s = FactoryDB.Shift.Where(x => x.ID == shift.ShiftID).FirstOrDefault();

                                Shift shift2 = new Shift();
                                shift2.ID = s.ID;
                                shift2.Date = s.Date;
                                shift2.StartTime = s.StartTime;
                                shift2.EndTime = s.EndTime;

                                e.Shifts.Add(shift2);
                            }
                            Employees.Add(e);
                        }
                        return Employees;
                    }
                }
            }
        }

        public EmployeeExtended GetEmployee(int id)
        {
            EmployeeExtended Employee = new EmployeeExtended();

            var emp = FactoryDB.Employee.Where(x => x.ID == id).FirstOrDefault();

            Employee.ID = emp.ID;
            Employee.FirstName = emp.FirstName;
            Employee.LastName = emp.LastName;
            Employee.StartWorkYear = emp.StartWorkYear;

            var EmpDep = FactoryDB.Department.Where(x => x.ID == emp.DepartmentID).FirstOrDefault();
            if (EmpDep != null)
            {
                Employee.DepartmentName = EmpDep.Name;
            }

            Employee.Shifts = new List<Shift>();

            var EmpShifts = FactoryDB.EmployeeShift.Where(x => x.EmployeeID == id).ToList();

            foreach (var shift in EmpShifts)
            {
                var s = FactoryDB.Shift.Where(x => x.ID == shift.ShiftID).FirstOrDefault();

                Employee.Shifts.Add(s);
            }

            return Employee;
        }

        public void UpdateEmployee(int id, EmployeeExtended employee)
        {
            var emp = FactoryDB.Employee.Where(x => x.ID == id).FirstOrDefault();

            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.StartWorkYear = employee.StartWorkYear;

            var dep = FactoryDB.Department.Where(x => x.Name == employee.DepartmentName).FirstOrDefault();
            emp.DepartmentID = dep.ID;

            FactoryDB.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var EmpShifts = FactoryDB.EmployeeShift.Where(x => x.EmployeeID == id).ToList();
            foreach (var item in EmpShifts)
            {
                FactoryDB.EmployeeShift.Remove(item);
            }

            var emp = FactoryDB.Employee.Where(x => x.ID == id).FirstOrDefault();
            FactoryDB.Employee.Remove(emp);

            var dep = FactoryDB.Department.Where(x => x.Manager == id).FirstOrDefault();
            // if the employee is a department manager
            if(dep != null)
            {
                dep.Manager = null;
            }

            FactoryDB.SaveChanges();
        }

        public List<EmployeeExtended> GetEmployeesNotManagers()
        {
            List<EmployeeExtended> Employees = new List<EmployeeExtended>();

            foreach (var employee in FactoryDB.Employee)
            {
               
                var dep = FactoryDB.Department.Where(x => x.Manager == employee.ID).FirstOrDefault();
                if(dep == null)
                {
                    EmployeeExtended e = new EmployeeExtended();
                    e.ID = employee.ID;
                    e.FirstName = employee.FirstName;
                    e.LastName = employee.LastName;
                    e.StartWorkYear = employee.StartWorkYear;

                    e.Shifts = new List<Shift>();

                    var EmpDep = FactoryDB.Department.Where(x => x.ID == employee.DepartmentID).FirstOrDefault();
                    if(EmpDep != null)
                    {
                        e.DepartmentName = EmpDep.Name;
                    }

                    var result1 = FactoryDB.EmployeeShift.Where(x => x.EmployeeID == employee.ID).ToList();

                    foreach (var shift in result1)
                    {
                        var s = FactoryDB.Shift.Where(x => x.ID == shift.ShiftID).FirstOrDefault();

                        Shift shift2 = new Shift();
                        shift2.ID = s.ID;
                        shift2.Date = s.Date;
                        shift2.StartTime = s.StartTime;
                        shift2.EndTime = s.EndTime;

                        e.Shifts.Add(shift2);
                    }

                    Employees.Add(e);
                }
                    
             }
            
            return Employees;
        }

    }
}