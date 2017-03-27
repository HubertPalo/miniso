app.controller('GeneralController', function ($scope, PostServices, GetServices, $window, $cookies, $location) {
    $scope.already_logged_in = false;
    $scope.not_logged_in_yet = true;
    $scope.already_logged_in = $cookies.get('logged_status') === "yes";
    $scope.not_logged_in_yet = $cookies.get('logged_status') === "no";

    if ($cookies.get('logged_status') === "yes") {
        $scope.mensaje = "Esta logueado";
        $scope.user_id = $cookies.get('user_id');
        $scope.user_name = $cookies.get('user_name');
        $scope.user_email = $cookies.get('user_email');
        $scope.user_password = $cookies.get('user_password');
    } else {
        $scope.mensaje = "No esta logueado";
    }

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

    $scope.logout = function () {
        $cookies.put('logged_in', false);//, { 'expires': expireDate });
        $cookies.put('logged_out', true);//, { 'expires': expireDate });
        $cookies.remove('user_id');
        $cookies.remove('user_name');
        $cookies.remove('user_email');
        $cookies.remove('user_password');
        $window.location.href = '/Home/Index';
    }

    $scope.ir_a_home = function () {
        $window.location.href = '/Home/Index';
    }

    $scope.ir_a_login = function () {
        //$window.location = '/login';
        $location.path('/login');
    }

});