/// <reference path="../_all-references.ts" />
var Controllers;
(function (Controllers) {
    var Login;
    (function (Login) {
        'use strict';
        var LoginController = (function () {
            function LoginController($scope, $http, $log) {
                this.$scope = $scope;
                this.$http = $http;
                this.$log = $log;
                $scope.loading = false;
                $scope.error = false;
                $scope.submit = function (url) {
                    $log.log(url);
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
                            $log.error(data.message);
                        }
                        else {
                            $log.log(data);
                            if (data.returnUrl)
                                window.location.href = data.returnUrl;
                        }
                        $scope.response = data;
                    }, function (d) {
                        $scope.error = true;
                        $log.error("Erro na requisição:", d);
                        $scope.response = d.data;
                    }).finally(function () {
                        $scope.loading = false;
                    });
                };
            }
            LoginController.$inject = [
                '$scope', '$http', '$log'
            ];
            return LoginController;
        })();
        Login.LoginController = LoginController;
    })(Login = Controllers.Login || (Controllers.Login = {}));
})(Controllers || (Controllers = {}));
angular.module('app').controller('LoginController', Controllers.Login.LoginController);
