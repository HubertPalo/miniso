var app = angular.module("app", ["ngRoute", "ngCookies"]);
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    //$locationProvider.html5Mode(false); $locationProvider.hashPrefix('');
    //$locationProvider.html5Mode(false);
    //$locationProvider.hashPrefix('');
    $routeProvider.when('/',
    {
        templateUrl: '/Home/Home',
        controller: 'HomeController'
    });

    $routeProvider.when('/login',
    {
        templateUrl: '/Home/Login'//,
        //controller: 'ResultCtrl'
    });

    $routeProvider.when('/register',
    {
        templateUrl: '/Home/Register'//,
        //controller: 'ResultCtrl'
    });

    $routeProvider.otherwise(
    {
        redirectTo: '/asdasdadasd'
    });
}]);
