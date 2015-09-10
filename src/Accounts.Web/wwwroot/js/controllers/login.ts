/// <reference path="../_all-references.ts" />


module Controllers {
    'use strict';

    export class Login {

        public static $inject = [
            '$scope', '$http'
        ];

        constructor(
            private $scope,
            private $http: ng.IHttpService
            ) {
            $scope.loading = false;
            $scope.submit = function (url: string) {
                console.log(url);
                $scope.loading = true;
            }
        }
    }
}
angular.module('app').controller('LoginController', Controllers.Login)
