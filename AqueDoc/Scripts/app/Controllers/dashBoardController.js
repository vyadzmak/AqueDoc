(function() {
    var dashBoardController = function ($scope, $http, $location, $state, usSpinnerService) {


        var dash = function () {
            var initMenu = function () {
                var menu = new BootstrapMenu('#projects', {

                    fetchElementData: function ($rowElem) {
//                        var rr = $rowElem.data;
//                        var rowId = $rowElem[0].id;
//
//                        return $scope.inboxMessages[rowId];
                    },

                    actions: [{
                        name: 'Новый проект',
                        onClick: function () {
                            // run when the action is clicked
                            alert("create");
                        }
                    }, {
                        name: 'Another action',
                        onClick: function () {
                            // run when the action is clicked 
                        }
                    }, {
                        name: 'A third action',
                        onClick: function () {
                            // run when the action is clicked 
                        }
                    }]
                });
            }
            initMenu();
            $state.go("main.dashboard.inbox");
          //  getInbox();
            
        };
        dash();

    };

    aqueDocApp.controller("dashBoardController", ["$scope", "$http", "$location", "$state", "usSpinnerService", dashBoardController]);
}())