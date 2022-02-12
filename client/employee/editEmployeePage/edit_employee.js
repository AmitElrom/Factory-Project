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
let empId = params.get("id")

async function GetEmployee()
{
    let respEmp = await fetch("https://localhost:44364/api/employee/" + empId)
    let emp = await respEmp.json()


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

    document.querySelector("#first_name").value = emp.FirstName;
    document.querySelector("#last_name").value = emp.LastName;
    document.querySelector("#start_year").value = emp.StartWorkYear;
    document.querySelector("#dep_default_opt").innerText = emp.DepartmentName;

    let selectDep = document.querySelector("#select_dep");

    // get all departments
    let respDeps = await fetch("https://localhost:44364/api/department")
    let deps = await respDeps.json()
    
    console.log(deps);
    // create department options in dropdown
    deps.forEach(dep => {
        
        if(dep.Name != emp.DepartmentName)
        {
            let depOpt = document.createElement("option");
            depOpt.innerText = dep.Name;
            selectDep.appendChild(depOpt)
        }
    });
}

async function UpdateEmployee()
{
    let fName = document.querySelector("#first_name").value;
    let lName = document.querySelector("#last_name").value;
    let year = parseInt(document.querySelector("#start_year").value);
    let depName = document.querySelector("#select_dep").value;

    let obj = {FirstName : fName, 
               LastName : lName, 
               StartWorkYear : year, 
               DepartmentName : depName
              };

    const fetchParams = {
                method: 'PUT',
                body: JSON.stringify(obj),
                headers: {'Content-Type': 'application/json'},
            };

    let resp = await fetch("https://localhost:44364/api/employee/" + empId, fetchParams)
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

    window.location.href = "../employeesPage/employees.html";
}