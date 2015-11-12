/// <reference path="../_all-references.ts" />


module Controllers.Login {
    'use strict';

    interface Response {
        message: string;
        status: string;
        code: string;
    }

    export class LoginController {

        public static $inject = [
            '$scope', '$http'
        ];

        constructor(
            private $scope,
            private $http: ng.IHttpService
        ) {
            $scope.loading = false;
            $scope.error = false;
            $scope.submit = function (url: string) {
                console.log(url);
                $scope.error = false;
                $scope.response = null;
                $scope.loading = true;
                $http({
                    method: 'POST',
                    url: url,
                    data: $scope.form,
                    headers: { 'Content-Type': 'application/json; charset=utf-8', 'dataType': 'json' }
                    //headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' }
                }).then((d) => { // on success
                    let data: any = d.data;
                    if (data.status == "error") {
                        console.error(data.message);
                        alert(data.message);
                    }
                    else {
                        console.log(data);
                        if (data.returnUrl) window.location.href = data.returnUrl;
                    }
                    $scope.response = data;
                }, (d) => { // on error
                    $scope.error = true;
                    $scope.response = d.data;
                    console.error("Erro na requisição:", d.data.message);
                }).finally(() => {
                    $scope.loading = false;
                });
            }
        }
    }
}
angular.module('app').controller('LoginController', Controllers.Login.LoginController)
