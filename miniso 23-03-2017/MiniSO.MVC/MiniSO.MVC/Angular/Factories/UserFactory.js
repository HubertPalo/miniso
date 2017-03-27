app.factory('UserService', ['$http', function ($http) {
    var check_login = function (username, password) {
        return $http.get("http://localhost:52151/api/authentication/check_login_data/" + username + "/" + password);
    };

    return {
        check_login : check_login
    };
}]);