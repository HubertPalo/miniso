app.controller('LoginController', function ($scope, $cookies, $location, PostServices) {


    $scope.login = function () {
        var resultado = PostServices.check_username_password($scope.username, $scope.password);
        resultado.then(function (results) {
            var expireDate = new Date();
            expireDate.setDate(expireDate.getDate() + 1);

            if (results.data.Id == -1) { // Si es que no existe el usuario blablabla
                $scope.error_datos_incorrectos = "Usuario o contraseña incorrectos. Por favor, ingrese sus datos nuevamente.";
                $cookies.put('logged_status', "no");
            } else { // Si es que si existe el usuario
                $cookies.put('logged_status', "yes");
                $cookies.put('user_id', results.data.Id);
                $cookies.put('user_name', results.data.Name);
                $cookies.put('user_email', results.data.Email);
                $cookies.put('user_password', results.data.Password);
                $scope.mensaje = "El id no es -1, es " + results.data.Id;
                
                $cookies.put('data', 'Inicio al loguearse');
                $scope.objetopadre.logueado = true;
                
                
                $location.path('/usermenu');
            }

        },
        function (errorPl) {
            alert("Se produjo un error en LoginController.");
        });
    }
});