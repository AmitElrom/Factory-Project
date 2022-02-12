function sessionStorageUser()
{
    let userStr = sessionStorage["user"];
    let user = JSON.parse(userStr);

    document.querySelector("#fullname_span").innerText = user.FullName;
}

function userActions()
{
    if(sessionStorage.getItem('useraction')!="")
    {
        let actionsNum = sessionStorage.getItem('useraction');

        document.querySelector("#credit_count").innerText = actionsNum;
    }
}


let params = new URLSearchParams(window.location.search);
let fname = params.get("fname")
let lname = params.get("lname")
let department = params.get("department")

function createEmpsTable(emps)
{
    let counter = 1;

    emps.forEach(emp => {

        //employees table
        //create tr, 7 td, 'shifts' table
        let trEmp = document.createElement("tr");

        let tdCounter = document.createElement("td");
        tdCounter.innerText = counter;

        let tdName = document.createElement("td");
        tdName.innerText = `${emp.FirstName} ${emp.LastName}`;

        let tdID = document.createElement("td");
        tdID.innerText = emp.ID;

        let tdYear = document.createElement("td");
        tdYear.innerText = emp.StartWorkYear;

        let tdDepartment = document.createElement("td");
        tdDepartment.innerText = emp.DepartmentName;

        let tdShifts = document.createElement("td");

        let tableShifts = document.createElement("table");
        
        //create tr, td for shift
        emp.Shifts.forEach(s => {
            let trShift = document.createElement("tr");
            let tdShift = document.createElement("td");
            tdShift.innerText = `${s.Date}, ${s.StartTime} - ${s.EndTime}`;

            trShift.appendChild(tdShift)
            tableShifts.appendChild(trShift)
        })

        tdShifts.appendChild(tableShifts)

        // create employee edit links
        let tdEditOpts = document.createElement("td");
        let tableEdit = document.createElement("table");
        let trEdit = document.createElement("tr");

        let tdEdit = document.createElement("td");
        let linkEdit = document.createElement("a");
        linkEdit.innerText = "Edit";
        linkEdit.href = "../editEmployeePage/edit_employee.html?id=" + emp.ID;
        tdEdit.appendChild(linkEdit)

        let tdDelete = document.createElement("td");
        let linkDelete = document.createElement("a");
        linkDelete.innerText = "Delete";
        linkDelete.href = "#";
        linkDelete.onclick = async function DeleteEmployee(eve)
        {
            let fetchParams = {
                                method : "DELETE",
                                headers : {'Content-type' : 'application/json'}
                              };
            
            let respDeleteEmp = await fetch("https://localhost:44364/api/employee/" + emp.ID, fetchParams)
            let dataDeleteEmp = await respDeleteEmp.json()
            alert(dataDeleteEmp)

            //update user num of actions /////////////////////////////////////////
            let userStr = sessionStorage["user"];
            let user = JSON.parse(userStr);
            let obj2 = {FullName : user.FullName}
        
            let fetchParams2 = {
                                method : "PUT",
                                body : JSON.stringify(obj2),
                                headers : {"Content-type" : "application/json"}
                            };

            let respUser = await fetch("https://localhost:44364/api/user/" + user.ID, fetchParams2);
            let dataUser = await respUser.json()
            if(dataUser == "No more doable actions")
            {
                window.location.href = "/loginPage/login_page.html";
            }
            else
            {
                sessionStorage.setItem('useraction', `${dataUser}`)
            }
        
            ////////////////////////////////////////////////////////////////////

            eve.preventDefault()

            window.location.href = "employees.html"
        }
        tdDelete.appendChild(linkDelete)
        
        let tdAddShift = document.createElement("td");
        let linkAddShift = document.createElement("a");
        linkAddShift.innerText = "Add Shift";
        linkAddShift.href = "../addShiftToEmpPage/add_shift_to_emp.html?id=" + emp.ID;
        tdAddShift.appendChild(linkAddShift)
        
        trEdit.append(tdEdit, tdDelete, tdAddShift)
        tableEdit.appendChild(trEdit)
        tdEditOpts.appendChild(tableEdit)

        trEmp.append(tdCounter, tdName, tdID, tdYear, tdDepartment, tdShifts, tdEditOpts)
        tbody.appendChild(trEmp)

        counter++;
    });
}

function ifNoEmployees(emps) 
{
    if (emps.length == 0) 
    {
        window.location.href = "../ifNoEmployees/if_no_employees.html"
    }
}

async function GetFilteredEmployees()
{    
        if(fname == null && lname != null)
        {
            let respEmps = await fetch(`https://localhost:44364/api/employee?lname=${lname}&department=${department}`);
            let employees = await respEmps.json()

            //update user num of actions /////////////////////////////////////////
            let userStr = sessionStorage["user"];
            let user = JSON.parse(userStr);
            let obj2 = {FullName : user.FullName}
        
            let fetchParams2 = {
                                method : "PUT",
                                body : JSON.stringify(obj2),
                                headers : {"Content-type" : "application/json"}
                            };

            let respUser = await fetch("https://localhost:44364/api/user/" + user.ID, fetchParams2);
            let dataUser = await respUser.json()
            if(dataUser == "No more doable actions")
            {
                window.location.href = "/loginPage/login_page.html";
            }
            else
            {
                sessionStorage.setItem('useraction', `${dataUser}`)
            }
        
            ////////////////////////////////////////////////////////////////////

            ifNoEmployees(employees)
            createEmpsTable(employees)
        }
        else if(lname == null && fname != null)
        {
            let respEmps = await fetch(`https://localhost:44364/api/employee?fname=${fname}&department=${department}`);
            let employees = await respEmps.json()

            //update user num of actions /////////////////////////////////////////
            let userStr = sessionStorage["user"];
            let user = JSON.parse(userStr);
            let obj2 = {FullName : user.FullName}
        
            let fetchParams2 = {
                                method : "PUT",
                                body : JSON.stringify(obj2),
                                headers : {"Content-type" : "application/json"}
                            };

            let respUser = await fetch("https://localhost:44364/api/user/" + user.ID, fetchParams2);
            let dataUser = await respUser.json()
            if(dataUser == "No more doable actions")
            {
                window.location.href = "/loginPage/login_page.html";
            }
            else
            {
                sessionStorage.setItem('useraction', `${dataUser}`)
            }
        
            ////////////////////////////////////////////////////////////////////

            ifNoEmployees(employees)
            createEmpsTable(employees)
        }
        else if(lname == null && fname == null)
        {
            let respEmps = await fetch(`https://localhost:44364/api/employee?department=${department}`);
            let employees = await respEmps.json()

            //update user num of actions /////////////////////////////////////////
            let userStr = sessionStorage["user"];
            let user = JSON.parse(userStr);
            let obj2 = {FullName : user.FullName}
        
            let fetchParams2 = {
                                method : "PUT",
                                body : JSON.stringify(obj2),
                                headers : {"Content-type" : "application/json"}
                            };

            let respUser = await fetch("https://localhost:44364/api/user/" + user.ID, fetchParams2);
            let dataUser = await respUser.json()
            if(dataUser == "No more doable actions")
            {
                window.location.href = "/loginPage/login_page.html";
            }
            else
            {
                sessionStorage.setItem('useraction', `${dataUser}`)
            }
        
            ////////////////////////////////////////////////////////////////////

            ifNoEmployees(employees)
            createEmpsTable(employees)
        }
        else
        {
            let respEmps = await fetch(`https://localhost:44364/api/employee?fname=${fname}&lname=${lname}&department=${department}`);
            let employees = await respEmps.json()

            //update user num of actions /////////////////////////////////////////
            let userStr = sessionStorage["user"];
            let user = JSON.parse(userStr);
            let obj2 = {FullName : user.FullName}
        
            let fetchParams2 = {
                                method : "PUT",
                                body : JSON.stringify(obj2),
                                headers : {"Content-type" : "application/json"}
                            };

            let respUser = await fetch("https://localhost:44364/api/user/" + user.ID, fetchParams2);
            let dataUser = await respUser.json()
            if(dataUser == "No more doable actions")
            {
                window.location.href = "/loginPage/login_page.html";
            }
            else
            {
                sessionStorage.setItem('useraction', `${dataUser}`)
            }
        
            ////////////////////////////////////////////////////////////////////

            ifNoEmployees(employees)
            createEmpsTable(employees)
        }

    
}