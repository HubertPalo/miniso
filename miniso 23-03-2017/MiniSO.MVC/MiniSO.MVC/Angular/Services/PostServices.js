app.service("PostServices", function ($http) {

    this.check_username_password = function (username, password) {
        return $http.get("http://localhost:52151/api/authentication/check_login/" + username + "/" + password);
    }
    
    this.register_new_user = function (username, email, password) {
        var usuario = {
            "Name": username,
            "Email": email,
            "Password": password
        };
        var resultado = $http({
            method: "post",
            url: "http://localhost:52151/api/user/post",
            dataType: "json",
            data: usuario
        }).then(function mySuccess(response) {
            return true;
        }, function myError(response) {
            return false;
        });
        return resultado;
    };

});