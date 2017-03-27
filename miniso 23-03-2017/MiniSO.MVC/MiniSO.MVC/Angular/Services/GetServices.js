app.service("GetServices", function ($http) {
    this.GetDocument = function (docId) {
        return $http.get("http://localhost:51748/api/documents/" + docId);
    };

    this.GetDocumentsIr = function (Filtro) {
        var request = $http({
            method: "post",
            url: "http://localhost:51748/api/documents/query",
            data: Filtro
        });
        return request;
    };

    this.GetAccesosUsuario = function (username) {
        var request = $http({
            method: "post",
            url: "http://localhost:51748/api/auth/accesos/usuario/",
            data: { NombreUsuario: username }
        });
        return request;
    };

    this.Login = function (username, pass) {
        var request = $http({
            method: "post",
            url: "http://localhost:51748/api/auth/usuarios/login",
            data: { NombreUsuario: username, Contrasenha: pass }
        });
        return request;
    };

    this.GetRootNodes = function () {
        return $http.get("http://localhost:51748/api/nodes");
    };

    this.GetNodes = function (nodoId) {
        return $http.get("http://localhost:51748/api/nodes/" + nodoId + "/T");
    };

    this.GetDocumentsNode = function (nodoId) {
        return $http.get("http://localhost:51748/api/documents/nodo/" + nodoId);
    };

    this.GetEspecificNodes = function (nodoId) {
        return $http.get("http://localhost:51748/api/nodes/" + nodoId + "/F");
    };

    this.GetPathNodes = function (nodoId) {
        return $http.get("http://localhost:51748/api/nodes/path/" + nodoId);
    };

    this.CrearUsuario = function (UserContext) {
        var request = $http({
            method: "post",
            url: "http://localhost:51748/api/auth/usuarios/login",
            data: { NombreUsuario: username, Contrasenha: pass }
        });
        return request;
    };
});