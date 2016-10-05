(function() {
    var inboxController = function($scope, $http, $location, $state, $rootScope, $uibModal, $log, usSpinnerService) {
        var url = $$ApiUrl + "/Inbox/1";

       // $scope.user = { name: "Hello Niggas" };
        $scope.open = function(id) {
            $scope.selectedMessage = id;
            var modalInstance = $uibModal.open({
                animation: true,
                size:'lg',
                templateUrl: "./Scripts/app/Views/InboxDetails.html",
                controller: "inboxDetailsController",
                scope: $scope
            });

        };


        var getInbox = function() {

            usSpinnerService.spin("spinner-1");

            $http.get(url).then(function(response) {
                $scope.inboxMessages = response.data;
                usSpinnerService.stop("spinner-1");
                $rootScope.inboxMessagesCount = response.data.length;
            });
        };
        //вызываем метод для получения всех входящих документов
        getInbox();
    };
    aqueDocApp.controller("inboxController", ["$scope", "$http", "$location", "$state", "$rootScope", "$uibModal", "$log", "usSpinnerService", inboxController]);
}())