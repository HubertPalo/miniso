app.controller('IndexController', function ($scope, PostServices, $window, $cookies) {
    $scope.Logged_in = $cookies.get('logged_status') === "yes";
    
    if ($cookies.get('logged_status')=== "yes") {
        $scope.mensaje = "Esta logueado";
        $scope.user_id = $cookies.get('user_id');
        $scope.user_name = $cookies.get('user_name');
        $scope.user_email = $cookies.get('user_email');
        $scope.user_password = $cookies.get('user_password');
    } else {
        $scope.mensaje = "No esta logueado";
    }
});