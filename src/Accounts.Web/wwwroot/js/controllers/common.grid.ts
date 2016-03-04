/// <reference path="../_all-references.ts" />


module Controllers.Common {
    'use strict';

    interface Response {
        message: string;
        status: string;
        code: string;
    }

    export class GridController {

        public static $inject = [
            '$scope', '$http', '$log'
        ];

        constructor(
            private $scope,
            private $http: ng.IHttpService,
            private $log: ng.ILogService
        ) {
            $scope.loading = false;
            $scope.error = false;

            $scope.search = function () {
                if (!$scope.searchModel || $scope.searchModel.$invalid)
                    console.log('Campos de pesquisa inválidos para busca.');
                else {
                    $scope.searchModel.pageIndex = 0;
                    send($scope.searchModel);
                }
            };

            $scope.reload = function () {
                send($scope.searchModel);
            };

            var send = function (form) {
                $scope.loading = true;

                $http.post($scope.options.SearchUrl, form)
                    .success(function (res: any) {
                        $scope.loading = false;
                        $scope.rows = res.Rows;
                        $scope.paginator = {
                            count: res.TotalRecords,
                            current: form == null ? 1 : form.pageIndex
                        };
                        if (res.TotalRecords == 0)
                            //notification(GlobalResources.NoInfoFound, "info");
                        if (res.HeaderRows)
                            $scope.headerRows = res.HeaderRows;
                    }).error(function (data, status) {
                        $scope.loading = false;
                    });
            };


            $scope.submit = function (url: string) {
                $log.log(url);
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
                        $log.error(data.message);
                    }
                    else {
                        $log.log(data);
                        if (data.returnUrl) window.location.href = data.returnUrl;
                    }
                    $scope.response = data;
                }, (d) => { // on error
                    $scope.error = true;
                    $scope.response = d.data;
                    $log.error("Erro na requisição:", d.data.message);
                }).finally(() => {
                    $scope.loading = false;
                });
            }
        }
    }
}
angular.module('app').controller('GridController', Controllers.Common.GridController)
