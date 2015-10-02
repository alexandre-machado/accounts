/// <reference path="../_all-references.ts" />
var Controllers;
(function (Controllers) {
    var Login;
    (function (Login) {
        'use strict';
        var LoginController = (function () {
            function LoginController($scope, $http) {
                this.$scope = $scope;
                this.$http = $http;
                $scope.loading = false;
                $scope.error = false;
                $scope.submit = function (url) {
                    console.log(url);
                    $scope.error = false;
                    $scope.response = null;
                    $scope.loading = true;
                    $http({
                        method: 'POST',
                        url: url,
                        data: $scope.form,
                        headers: { 'Content-Type': 'application/json; charset=utf-8', 'dataType': 'json' }
                    }).then(function (d) {
                        var data = d.data;
                        if (data.status == "error") {
                            console.error(data.message);
                            alert(data.message);
                        }
                        else
                            console.log(data.message);
                        $scope.response = data;
                    }, function (d) {
                        $scope.error = true;
                        $scope.response = d.data;
                        console.error("Erro na requisição:", d.data.message);
                    }).finally(function () {
                        $scope.loading = false;
                    });
                };
            }
            LoginController.$inject = [
                '$scope', '$http'
            ];
            return LoginController;
        })();
        Login.LoginController = LoginController;
    })(Login = Controllers.Login || (Controllers.Login = {}));
})(Controllers || (Controllers = {}));
angular.module('app').controller('LoginController', Controllers.Login.LoginController);
