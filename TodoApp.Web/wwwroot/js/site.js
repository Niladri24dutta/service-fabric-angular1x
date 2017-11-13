var app = angular.module('TodoApp', ['ui.bootstrap']);

app.run(function () { });

app.controller('TodoAppController', ['$rootScope', '$scope', '$http', '$timeout', function ($rootScope, $scope, $http, $timeout) {

    $scope.refresh = function () {
        $http.get('api/Todo/')
            .then(function (data, status) {
                $scope.todos = data;
            }, function (data, status) {
                $scope.todos = undefined;
            });
    };

    $scope.remove = function (item) {
        $http.delete('api/Todo/' + item)
            .then(function (data, status) {
                $scope.refresh();
            })
    };

    $scope.add = function (item) {
        var fd = new FormData();
        fd.append('item', item);
        $http.put('api/Todo/' + item, fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
            .then(function (data, status) {
                $scope.refresh();
                $scope.item = undefined;
            })
    };

}]);
