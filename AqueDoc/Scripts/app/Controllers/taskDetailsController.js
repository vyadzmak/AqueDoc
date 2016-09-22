(function () {
    var taskDetailsController = function ($scope, $http, $location, $state, $rootScope, $uibModal, $log, usSpinnerService, $stateParams) {
        var url = $$ApiUrl + "/Task";

        var getTaskDetails = function () {
            $scope.currentTaskId = $stateParams.taskId;
          //  alert();
        };
        //вызываем метод для получения всех входящих документов
        getTaskDetails();
    };
    aqueDocApp.controller("taskDetailsController", ["$scope", "$http", "$location", "$state", "$rootScope", "$uibModal", "$log", "usSpinnerService", "$stateParams", taskDetailsController]);
}())