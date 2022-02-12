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
let depId = params.get("id")

async function GetDepartment()
{
    let respDep = await fetch("https://localhost:44364/api/department/" + depId)
    let dataDep = await respDep.json() //department

    document.querySelector("#dep_name").value = dataDep.Name;
    document.querySelector("#current_manager").innerText = dataDep.ManagerName;

    //get all employees not managers
    let respEmp = await fetch("https://localhost:44364/api/employeesnotmanagers")
    let dataEmp = await respEmp.json()


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
    
    let manager = document.querySelector("#manager");

    dataEmp.forEach(emp => {
        
        let optManager = document.createElement("option");
        optManager.innerHTML = emp.FirstName + " " + emp.LastName;
        manager.appendChild(optManager)

    });
}

async function UpdateDepartment()
{
    // access html elements
    let depName = document.querySelector("#dep_name").value;
    let SelectedManager = document.querySelector("#manager").value;

    let obj = {
                Name : depName,
                ManagerName : SelectedManager
            };

    let fetchParams = {
                method: 'PUT',
                body: JSON.stringify(obj),
                headers : {'Content-Type': 'application/json'}
                };

    let resp = await fetch("https://localhost:44364/api/department/" + depId, fetchParams)
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

    window.location.href = "../departmentsPage/departments.html";

}