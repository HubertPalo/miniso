app.controller('LogoutController', function ($scope, $location, $cookies) {
    $scope.logout = function () {
        $cookies.put('logged_status', 'no');//, { 'expires': expireDate });
        $cookies.remove('user_id');
        $cookies.remove('user_name');
        $cookies.remove('user_email');
        $cookies.remove('user_password');
        $scope.objetopadre.logueado = false;
        $location.path('/');
    }

    $scope.ir_a_home = function () {
        $location.path('/');
    }
});