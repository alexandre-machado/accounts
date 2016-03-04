/// <reference path="../_all-references.ts" />
var Controllers;
(function (Controllers) {
    var Common;
    (function (Common) {
        'use strict';
        var GridController = (function () {
            function GridController($scope, $http, $log) {
                this.$scope = $scope;
                this.$http = $http;
                this.$log = $log;
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
                        .success(function (res) {
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
                        $scope.response = d.data;
                        $log.error("Erro na requisição:", d.data.message);
                    }).finally(function () {
                        $scope.loading = false;
                    });
                };
            }
            GridController.$inject = [
                '$scope', '$http', '$log'
            ];
            return GridController;
        })();
        Common.GridController = GridController;
    })(Common = Controllers.Common || (Controllers.Common = {}));
})(Controllers || (Controllers = {}));
angular.module('app').controller('GridController', Controllers.Common.GridController);
