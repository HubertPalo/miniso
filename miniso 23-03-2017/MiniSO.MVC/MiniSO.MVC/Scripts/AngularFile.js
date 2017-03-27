var app = angular.module('General', []);
app.controller('UsersController', function ($scope, $http) {
    $http({
        method: "GET",
        url: "http://localhost:52151/api/user/get"
    }).then(function mySucces(response) {
        $scope.myWelcome = response.data;
    }, function myError(response) {
        $scope.myWelcome = response.statusText;
    });
});