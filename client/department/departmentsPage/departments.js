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


async function GetDepartments()
{
    // access html elements 
    let tbody = document.querySelector("#tbody");

    let respDeps = await fetch("https://localhost:44364/api/department")
    let departments = await respDeps.json()


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

    let counter = 1;

    departments.forEach(dep => {
        
        //create tr, 4 td
        let trDep = document.createElement("tr");

        let tdCounter = document.createElement("td");
        tdCounter.innerText = counter;

        let tdDepName = document.createElement("td");
        tdDepName.innerText = dep.Name;

        let tdManager = document.createElement("td");
        tdManager.innerText = dep.ManagerName;

        // edit, delete links
        let tdEditOpts = document.createElement("td");
        let tableEdit = document.createElement("table");
        let trEdit = document.createElement("tr");

        let tdEdit = document.createElement("td");
        let linkEdit = document.createElement("a");
        linkEdit.innerText = "Edit";
        linkEdit.href = "../editdepartmentPage/editdepartment.html?id=" + dep.ID;
        tdEdit.appendChild(linkEdit)

        // delete option will appear only if - all employees from department were deleted
        let tdDelete = document.createElement("td");
        let linkDelete = document.createElement("a");
            
        if(dep.CanDepBeDeleted == true)
        {
            linkDelete.innerText = "Delete";
            linkDelete.href = "";
            tdDelete.appendChild(linkDelete)
        };

        linkDelete.onclick = async function DeleteDepartment(eve)
        {
            let fetchParams = {
                                method : "DELETE",
                                headers : {'Content-type' : 'application/json'}
                              };
            
            let respDeleteDep = await fetch("https://localhost:44364/api/department/" + dep.ID, fetchParams)
            let dataDeleteDep = await respDeleteDep.json()
            alert(dataDeleteDep)

            eve.preventDefault()

                    
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

            window.location.href = "../departmentsPage/departments.html"
        }

        trEdit.append(tdEdit, tdDelete)
        tableEdit.appendChild(trEdit)
        tdEditOpts.appendChild(tableEdit)

        trDep.append(tdCounter, tdDepName, tdManager, tdEditOpts)
        tbody.appendChild(trDep)

        counter++;
    });
}

