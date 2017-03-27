app.service("GetServices", function ($http) {

    this.get_question_by_id = function (question_id) {
        var resultado = $http({
            method: "get",
            url: "http://localhost:52151/api/question/get/" + question_id
        });
        return resultado;
    }

    this.get_all_questions_from_user = function (user_id) {
        var resultado = $http({
            method: "get",
            url: "http://localhost:52151/api/question/getallbyuser/" + user_id
        });
        return resultado;
    }

});