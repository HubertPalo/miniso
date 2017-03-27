app.service("PostServices", function ($http) {

    this.check_username_password = function (username, password) {
        var usuario = {
            "Name": username,
            "Password": password
        };
        var resultado = $http({
            method: "post",
            url: "http://localhost:52151/api/login/validate_login/",
            //dataType: "json",
            data: usuario
        });
        return resultado;

        /*
        var uri = "http://localhost:52151/api/login/validate_login/?Name=" + username + "&Password=" + password;
        return $http.get(uri).then(function mySuccess(response) {
            return response.data;
        });
        */
        //return username;
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