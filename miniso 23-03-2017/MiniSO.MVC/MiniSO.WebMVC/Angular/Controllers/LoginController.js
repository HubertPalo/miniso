app.controller('LoginController', function ($scope, PostServices, $window, $cookies) {
    $scope.mensajedeprueba = $cookies.get('dataprueba:') + '/';

    $scope.register_user = function () {
        var rpta = PostServices.register_new_user($scope.username, $scope.email, $scope.password);

        if (rpta)
            $window.location.href = '/users';
        else
            $window.location.href = '/users123';
    }

    $scope.login = function () {
        var resultado = PostServices.check_username_password($scope.username, $scope.password);
        resultado.then(function (results) {
            var expireDate = new Date();
            expireDate.setDate(expireDate.getDate() + 1);

            if (results.data.Id == -1) { // Si es que no existe el usuario
                $scope.mensaje = "El usuario no existe";
                $cookies.put('logged_status', "no", { 'expires': expireDate });
            } else { // Si es que si existe el usuario
                $cookies.put('logged_status', "yes", { 'expires': expireDate });
                $cookies.put('user_id', results.data.Id);
                $cookies.put('user_name', results.data.Name);
                $cookies.put('user_email', results.data.Email);
                $cookies.put('user_password', results.data.Password);
                $scope.mensaje = "El id no es -1, es " + results.data.Id;
                $scope.mensaje3 = $cookies.get('data');
                $window.location.href = '/Home/Index';
            }

        },
        function (errorPl) {
            alert("Se produjo un error.");
        });
    }

});