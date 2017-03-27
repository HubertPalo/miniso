app.controller('GeneralController', function ($scope, $cookies, $location) {
    

    $scope.objetopadre = {};
    $scope.objetopadre.logueado = false;
    if ($cookies.get('logged_status') === 'yes') {
        $scope.objetopadre.logueado = true;
    }

    $scope.ir_a_home = function () {
        $location.path('/');
    }

    $scope.ir_a_login = function () {
        $location.path('/login');
    }

    $scope.ir_a_logout = function () {
        $location.path('/logout');
    }

    $scope.ir_a_register = function () {
        $location.path('/newuser');
    }

});