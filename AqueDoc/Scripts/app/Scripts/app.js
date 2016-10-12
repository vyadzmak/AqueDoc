var $$ApiUrl = "http://localhost/AqueDocApi/api";
var aqueDocApp = angular.module("aqueDocApp", ["ui.router", 'ui.router.title', 'angularSpinner', 'ui.bootstrap','summernote', "FileManagerApp"]);

aqueDocApp.run([
    '$rootScope', '$state', '$stateParams',
    function($rootScope, $state, $stateParams) {
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;

    }
]);

aqueDocApp.config(['usSpinnerConfigProvider', function (usSpinnerConfigProvider) {
    usSpinnerConfigProvider.setTheme('bigBlue', { color: 'blue', radius: 20 });
   // usSpinnerConfigProvider.setTheme('smallRed', { color: 'red', radius: 6 });
}]);