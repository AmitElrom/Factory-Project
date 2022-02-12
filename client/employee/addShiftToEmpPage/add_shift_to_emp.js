let params = new URLSearchParams(window.location.search);
let empId = params.get("id")

async function loadAddShiftPage()
{
    // get employee
    let respEmp = await fetch("https://localhost:44364/api/employee/" + empId)
    let dataEmp = await respEmp.json()

    // about employee
    let empName = document.querySelector("#employee_name");
    empName.innerText  = dataEmp.FirstName + " " + dataEmp.LastName; 
    let employeeID = document.querySelector("#employee_id");
    employeeID.innerText = dataEmp.ID;

    // get all shifts execpt employee's shifts
    let respShifts = await fetch("https://localhost:44364/api/shift")
    let dataShifts = await respShifts.json()

    
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

    console.log(dataShifts);

    let selectShift = document.querySelector("#select_shift");

    dataShifts.forEach(shift => {
        let optShift = document.createElement("option");
        optShift.innerText = shift.Date + " | " + shift.StartTime + " - " + shift.EndTime;
        optShift.value = shift.ID;
        selectShift.appendChild(optShift)
    });
}

async function AddShiftToEmployee()
{
    let selectedShiftID = document.querySelector("#select_shift").value;

    let obj = {
        EmployeeID : empId,
        ShiftID : selectedShiftID
      }

    let fetchParams = {
                method: 'POST',
                body: JSON.stringify(obj),
                headers : {'Content-Type': 'application/json'}
                }

    let resp = await fetch("https://localhost:44364/api/employeeshift", fetchParams)
    let data = await resp.json()
    alert(data)


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

    window.location.href = "../employeespage/employees.html";
}