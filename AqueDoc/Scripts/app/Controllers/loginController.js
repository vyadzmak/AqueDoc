(function() {
    var loginController = function ($scope, $http, $location, $state, usSpinnerService) {
        var url = $$ApiUrl + "/Login";
        $scope.emailFormat = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/;
        $scope.loadData = false;
        $scope.loginUser = function() {

            if ($scope.loginUser == "") {
                $scope.loginIsEmpty = true;
                return;
            }
            usSpinnerService.spin('spinner-2');
            $scope.loadData = true;
            $http({
                    url: url,
                    method: "POST",
                    data: { 'Login': $scope.login,'Password':$scope.password}
                })
                .then(function(response) {
                    usSpinnerService.stop('spinner-2');
                    $scope.loadData = false;
                    var answer = JSON.parse(response.data);
                    if (!answer) {
                      //  BootstrapDialog.show({
                        var dialog = new BootstrapDialog({
                        type: BootstrapDialog.TYPE_DANGER,
                            size: BootstrapDialog.SIZE_SMALL,
                            title: "Ошибка авторизации",
                            message: "Авторизация не удалась. Пожалуйста проверьте свои данные!"
                        });
                        dialog.setSize(BootstrapDialog.SIZE_SMALL);
                        dialog.open();
                    } else {
                        $state.go("main.dashboard");

                    }

                        // success
                    },
                    function(response) { // optional
                        // failed
                    });


        };
    };

    aqueDocApp.controller("loginController", ["$scope", "$http", "$location", "$state", "usSpinnerService", loginController]);
}())