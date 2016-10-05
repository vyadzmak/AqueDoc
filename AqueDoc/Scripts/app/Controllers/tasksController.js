(function () {
    var tasksController = function ($scope, $http, $location, $state, $rootScope, $uibModal, $log, usSpinnerService) {
        var url = $$ApiUrl + "/Task";

        var getTasks = function () {

            usSpinnerService.spin("spinner-1");

            $http.get(url).then(function (response) {
                $scope.tasks = response.data;
                usSpinnerService.stop("spinner-1");
                $rootScope.tasksCount = response.data.length;
            });
        };
        //вызываем метод для получения всех входящих документов
        getTasks();
    };
    aqueDocApp.controller("tasksController", ["$scope", "$http", "$location", "$state", "$rootScope", "$uibModal", "$log", "usSpinnerService", tasksController]);
}())