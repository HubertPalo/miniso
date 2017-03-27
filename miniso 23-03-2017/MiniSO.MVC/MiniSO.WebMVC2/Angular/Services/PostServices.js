app.service("PostServices", function ($http) {

    this.check_username_password = function (username, password) {
        var usuario = {
            "Name": username,
            "Password": password
        };
        var resultado = $http({
            method: "post",
            url: "http://localhost:52151/api/login/validate_login/",
            data: usuario
        });
        return resultado;
    }

    this.register_new_user = function (username, email, password) {
        var usuario = {
            "Name": username,
            "Email": email,
            "Password": password
        };
        var resultado = $http({
            method: "post",
            url: "http://localhost:52151/api/user/post",
            dataType: "json",
            data: usuario
        });
        return resultado;
    };

    this.register_new_question = function (user_id, question_title, question_details) {
        var question = {
            "User_id": user_id,
            "Title": question_title,
            "Description": question_details
        };
        var resultado = $http({
            method: "post",
            url: "http://localhost:52151/api/question/post",
            dataType: "json",
            data: question
        });
        return resultado;
    };

    this.register_new_answer = function (user_id, question_id, answer_details) {
        var answer = {
            "User_id": user_id,
            "Question_id": question_id,
            "Description": answer_details
        };
        var resultado = $http({
            method: "post",
            url: "http://localhost:52151/api/answer/post",
            dataType: "json",
            data: answer
        });
        return resultado;
    };

    /*
    this.register_new_question = function (user_id, question_title, question_description) {
        var pregunta = {
            "User_id": username,
            "Email": email,
            "Password": password
        };
        var resultado = $http({
            method: "post",
            url: "http://localhost:52151/api/user/post",
            dataType: "json",
            data: usuario
        }).then(function mySuccess(response) {
            return true;
        }, function myError(response) {
            return false;
        });
        return resultado;
    };
    */
});