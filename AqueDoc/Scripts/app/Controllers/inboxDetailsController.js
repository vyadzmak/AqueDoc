(function () {
    var inboxDetailsController = function ($scope, $http, $location, $state, usSpinnerService,  $uibModalInstance) {
       
        $scope.loadData = function(id) {
            var message;
            for (var i = 0; i < $scope.inboxMessages.length; i++) {
                var sMessage = $scope.inboxMessages[i];

                if (sMessage.Id == id) {
                    message = sMessage;
                    break;;
                }
            }
            if (message!=undefined)
            $scope.inboxMessage = message;
            // alert(JSON.stringify(message));
        }

        if ($scope.selectedMessage != undefined) {
            $scope.loadData($scope.selectedMessage);
        }

        $scope.ok = function () {
            $uibModalInstance.close();
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };

    };

    aqueDocApp.controller("inboxDetailsController", ["$scope", "$http", "$location", "$state", "usSpinnerService", "$uibModalInstance", inboxDetailsController]);
}())