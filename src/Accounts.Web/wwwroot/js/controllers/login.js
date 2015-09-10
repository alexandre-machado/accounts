/// <reference path="../_all-references.ts" />
var Controllers;
(function (Controllers) {
    'use strict';
    var Login = (function () {
        function Login($scope, $http) {
            this.$scope = $scope;
            this.$http = $http;
            $scope.loading = false;
            $scope.submit = function (url) {
                console.log(url);
                $scope.loading = true;
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
