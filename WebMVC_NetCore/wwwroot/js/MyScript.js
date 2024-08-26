
function myFunction() {
    alert('Hello from myFunction!');
}


function Login() {
    var UserName = $("#txtUserName").val();
    var Password = $("#txtPassword").val();

    if (UserName == null || UserName== "") {
        alert("UserName không được trống")
        return;
    }

    var param = {
        UserName: $("#txtUserName").val(),
        Password: $("#txtPassword").val()
    };

    $.ajax({
        type: 'POST',
        url: "/Account/Account_Login",
        data: param,
        async: true,
        // dataType: "html",
        dataType: "json",
        success: function (rs) {
            alert(rs.token);
            if (rs.responseCode > 0) {
                // set cookies
                debugger;
                console.log(rs.token);
                setCookie("COOKIE_JWT_TOKEN", rs.token, 1);
                window.location.href = "/";
            }
           
        },
        error(rs) {
            console.log(JSON.stringify(rs));
        }
    });
}

function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}
