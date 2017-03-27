var app = angular.module('General', ["ngRoute", "ngCookies"]);
app.controller('UsersController', function ($scope, $http) {
    $http({
        method: "GET",
        url: "http://localhost:52151/api/user/get"
    }).then(function mySucces(response) {
        $scope.myWelcome = response.data;
    }, function myError(response) {
        $scope.myWelcome = response.statusText;
    });
    

    $scope.register_new_user = function (username, email, password) {
        var usuario = {
            "Name": username,
            "Email": email,
            "Password": password
        };

        $http({
            method: "post",
            url: "http://localhost:52151/api/user/post",
            dataType: "json",
            data: usuario
        }).then(function mySuccess(response) {
            return "Se ha registrado el usuario con éxito.";
        }, function myError(response) {
            return "Ha ocurrido un error al intentar registrar el usuario.";
        });
        //$window.location.href = '/index.html';
        //return request;
    };
});