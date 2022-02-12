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

async function AddShift()
{
    // access html elements
    let date = String(document.querySelector("#date").value);
    let startTime = String(document.querySelector("#start_time").value);
    let endTime = String(document.querySelector("#end_time").value);

    
    let obj = {
                Date : date,
                StartTime : startTime,
                EndTime : endTime
              };

    console.log(obj);

    let fetchParams = {
                method: 'POST',
                body: JSON.stringify(obj),
                headers : {'Content-Type': 'application/json'}
                }

    let resp = await fetch("https://localhost:44364/api/shift", fetchParams)
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

    window.location.href = "../shiftsPage/shifts.html";  
}