app.controller('HomeController', function ($scope, $window, $cookies, $location) {
    $scope.ir_a_login = function () {
        //$window.location.assign('/login');
        $location.path('/login');
    }
});