/// <reference path="../_all-references.ts" />
var Controllers;
(function (Controllers) {
    'use strict';
    var Login = (function () {
        function Login($scope, $http) {
            this.$scope = $scope;
            this.$http = $http;
            $scope.loading = false;
            $scope.error = false;
            $scope.submit = function (url) {
                console.log(url);
                $scope.loading = true;
                $http.post(url, $scope.form, { headers: { 'Content-Type': 'application/json; charset=utf-8', 'dataType': 'json' } })
                    .success(function () {
                    console.log("login com sucesso");
                })
                    .error(function () {
                    $scope.error = true;
                    console.error("erro na requisição");
                })
                    .finally(function () {
                    $scope.loading = false;
                });
            };
        }
        Login.$inject = [
            '$scope', '$http'
        ];
        return Login;
    })();
    Controllers.Login = Login;
})(Controllers || (Controllers = {}));
angular.module('app').controller('LoginController', Controllers.Login);
