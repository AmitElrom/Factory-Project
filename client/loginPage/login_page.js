async function UserAuthentication()
{
    let username = document.querySelector("#username").value;
    let password = document.querySelector("#password").value;

    // get all users 
    let respUsers = await fetch("https://localhost:44364/api/user")
    let dataUsers = await respUsers.json()

    dataUsers.forEach(user => {
        
        if(user.UserName == username && user.Password == password)
        {
            sessionStorage.setItem('user', JSON.stringify(user));

            window.location.href="../homePage/home_page.html";
        }
    });
}

