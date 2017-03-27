app.controller('QuestionController', function ($scope, $cookies, $location, $routeParams, GetServices) {
    $scope.user_id = $cookies.get('user_id');
    $scope.question_id = $routeParams.question_id;
    var existe = false;

    var resultado = GetServices.get_question_by_id($routeParams.question_id);
    resultado.then(function (results) {
        if (results.data.Id == -1) {
            existe = false;
            $scope.question_title = "Opps! Esta pregunta no existe. ";
            $scope.question_details = "Opps! Esta pregunta no existe.";
        } else {
            existe = true;
            $scope.question_title = results.data.Title;
            $scope.question_details = results.data.Description;
        }
        
    },
    function (errorPl) {
        alert("Se produjo un error en QuestionController.");
    });

    $scope.answer_the_question = function () {
        var resultado = PostServices.register_new_answer($cookies.get('user_id'), $scope.question_id, $scope.answer_details);
        resultado.then(function (results) {
            //alert(results.data);
            $location.path('/usermenu');
        },
        function (errorPl) {
            alert("Se produjo un error en UsersController.");
        });
    }

});