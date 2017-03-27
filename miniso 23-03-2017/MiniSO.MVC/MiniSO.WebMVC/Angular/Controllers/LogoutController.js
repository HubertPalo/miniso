app.controller('LogoutController', function ($scope, $window, $cookies) {
    $scope.logout = function () {
        $cookies.put('logged_status', 'no');//, { 'expires': expireDate });
        $cookies.remove('user_id');
        $cookies.remove('user_name');
        $cookies.remove('user_email');
        $cookies.remove('user_password');
        $window.location.href = '/Home/Index';
    }

    $scope.ir_a_home = function () {
        $window.location.href = '/Home/Index';
    }
});