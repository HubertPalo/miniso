app.controller('UserMenuController', function ($scope, $cookies, $location, GetServices, PostServices) {
    $scope.user_name = $cookies.get('user_name');

    $scope.ir_a_preguntar = function () {
        $location.path('/ask');
    }

    var resultado = GetServices.get_all_questions_from_user($cookies.get('user_id'));
    resultado.then(function (results) {
        $scope.items = results.data;

    },
    function (errorPl) {
        alert("Se produjo un error en UserMenuController.");
    });

});