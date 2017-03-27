var app = angular.module("app", ["ngRoute", "ngCookies"]);
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/',
    {
        templateUrl: '/Home/Home',
        controller: 'HomeController'
    });

    $routeProvider.when('/login',
    {
        templateUrl: '/Home/Login',
        controller: 'LoginController'
    });

    $routeProvider.when('/logout',
    {
        templateUrl: '/Home/Logout',
        controller: 'LogoutController'
    });

    $routeProvider.when('/newuser',
    {
        templateUrl: '/User/NewUser',
        controller: 'UsersController'
    });

    $routeProvider.when('/usermenu',
    {
        templateUrl: '/User/Index',
        controller: 'UserMenuController'
    });

    $routeProvider.when('/ask',
    {
        templateUrl: '/User/RegisterQuestion',
        controller: 'UsersController'
    });

    $routeProvider.when('/questions/:question_id',
    {
        templateUrl: '/User/GetQuestion',
        controller: 'QuestionController'
    });


    $routeProvider.otherwise(
    {
        redirectTo: '/ERROR-NGROUTE'
    });
}]);
