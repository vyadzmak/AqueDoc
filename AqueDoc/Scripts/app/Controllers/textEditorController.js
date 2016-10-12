(function () {
    var textEditorController = function ($scope, $http, $location, $state, usSpinnerService, $uibModalInstance) {

        console.log(333);
        $scope.init = function () { console.log('Summernote is launched'); }
        $scope.enter = function () { console.log('Enter/Return key pressed'); }
        $scope.focus = function (e) { console.log('Editable area is focused'); }
        $scope.blur = function (e) { console.log('Editable area loses focus'); }
        $scope.paste = function (e) { console.log('Called event paste'); }
        $scope.change = function (contents) {
            console.log('contents are changed:', contents, $scope.editable);
        };
        $scope.keyup = function (e) { console.log('Key is released:', e.keyCode); }
        $scope.keydown = function (e) { console.log('Key is pressed:', e.keyCode); }

        $scope.ok = function () {
            $uibModalInstance.close();
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };

    };

    aqueDocApp.controller("textEditorController", ["$scope", "$http", "$location", "$state", "usSpinnerService","$uibModalInstance",textEditorController]);
}())