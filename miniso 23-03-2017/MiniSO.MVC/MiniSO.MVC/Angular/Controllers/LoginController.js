app.controller('LoginController', function ($scope, PostServices, $window, $cookieStore) {
    $scope.usuario = {
        "Logged_in": false,
        "Id": -1,
        "Name": "Desconocido",
        "Email": "Desconocido@quiensabe.com",
        "Password": "Contraseña"
    };

    $scope.mensaje = $cookieStore.get('data');
    $scope.myWelcome = "Este mensaje debe cambiar";
    $cookieStore.put('valueincookie', "Mensaje que debe cambiar");
    $scope.register_user = function () {
        var rpta = PostServices.register_new_user($scope.username, $scope.email, $scope.password);

        if (rpta)
            $window.location.href = '/users';
        else
            $window.location.href = '/users123';
    }
    $scope.update_welcome = function () {
        $scope.myWelcome = $cookieStore.get('valueincookie');
    }

    $scope.login = function () {
        PostServices.check_username_password($scope.username, $scope.password).then(function (data) {
            $scope.mensaje = data.data.Id;
            $cookieStore.put('userId', data.data.Id);
            $cookieStore.put('userId', data.data.Name);
            $cookieStore.put('userId', data.data.Email);
            $cookieStore.put('userId', data.data.Password);
            $scope.mensaje2 = $cookieStore.get('usuario');
        }).catch(function () {
            $scope.mensaje = "No se pudo";
        });
    }


    //$location.path('/Result/1/' + encodeURI(q1) + '/' + encodeURI(q2) + '/' + encodeURI(q3) + '/' + f1 + '/' + f2 + '/' + f3 + '/' + f4);
});