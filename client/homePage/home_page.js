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





