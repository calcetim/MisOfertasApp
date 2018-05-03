var app = angular.module('misOfertasApp', ['ngLoadingSpinner']);


app.constant('URL_SERVICIOS', { BASE_URL: "http://localhost:51800/" });

app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);


