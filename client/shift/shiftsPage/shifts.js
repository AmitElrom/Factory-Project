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


async function GetShifts() {
    // access html elements
    let tbody = document.querySelector("#tbody");

    let resp = await fetch("https://localhost:44364/api/shift")
    let shifts = await resp.json()


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

    shifts.forEach(shift => {

        // create tr, 4 td, 'employees' table
        let trShift = document.createElement("tr");

        let tdDate = document.createElement("td");
        tdDate.innerText = shift.Date;

        let tdStart = document.createElement("td");
        tdStart.innerText = shift.StartTime;

        let tdEnd = document.createElement("td");
        tdEnd.innerText = shift.EndTime;

        let tdEmployees = document.createElement("td");

        let tableEmp = document.createElement("table");

        //create tr, td for employee
        shift.Employees.forEach(emp => {

            let trEmp = document.createElement("tr");
            let tdEmp = document.createElement("td");
            let linkEmp = document.createElement("a");
            linkEmp.innerText = emp.FirstName + " " + emp.LastName;
            linkEmp.href = "file:///C:/Users/user/Desktop/fullsatck/Factory/client/employee/editEmployeePage/edit_employee.html?id=" + emp.ID;

            tdEmp.appendChild(linkEmp)
            trEmp.appendChild(tdEmp)
            tableEmp.appendChild(trEmp)
        })

        tdEmployees.appendChild(tableEmp)
        trShift.append(tdDate, tdStart, tdEnd, tdEmployees)
        tbody.appendChild(trShift)
    });
}