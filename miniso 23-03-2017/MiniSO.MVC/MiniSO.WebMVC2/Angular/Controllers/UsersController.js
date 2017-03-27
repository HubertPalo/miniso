app.controller('UsersController', function ($scope, $cookies, $location, PostServices) {

    $scope.register_user = function () {
        if ($scope.password === $scope.confirm_password) {
            var resultado = PostServices.register_new_user($scope.name, $scope.email, $scope.password);
            resultado.then(function (results) {
                if (results.data == -2) {
                    $scope.mensajeError = "El nombre de usuario ya ha sido registrado. Especifique otro, por favor.";
                } else if (results.data == -1) {
                    $scope.mensajeError = "Ha ocurrido un error desconocido al registrar al usuario. Por favor contactenos para arreglarlo lo mas pronto posible.";
                } else {
                    $cookies.put('logged_status', "yes");
                    $cookies.put('user_id', results.data);
                    $cookies.put('user_name', $scope.name);
                    $cookies.put('user_email', $scope.email);
                    $location.path('/usermenu');
                }
            },
            function (errorPl) {
                alert("Se produjo un error.");
            });
        } else {
            $scope.mensajeError = "Las contraseñas no coinciden."
        }
    }

    $scope.register_question = function () {
        var resultado = PostServices.register_new_question($cookies.get('user_id'), $scope.question_title, $scope.question_details);
        resultado.then(function (results) {
            //alert(results.data);
            $location.path('/questions/' + results.data.Id);
        },
        function (errorPl) {
            alert("Se produjo un error en UsersController.");
        });
    }
});