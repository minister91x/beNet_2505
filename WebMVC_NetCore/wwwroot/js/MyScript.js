
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
            if (rs.returnCode > 0) {
                // set cookies
                debugger;

                window.location.href = "/";
            }
            alert(rs.returnMsg);
        },
        error(rs) {
            console.log(JSON.stringify(rs));
        }
    });
}
