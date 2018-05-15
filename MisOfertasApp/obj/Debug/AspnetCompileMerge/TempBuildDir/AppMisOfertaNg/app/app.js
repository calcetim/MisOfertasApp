var app = angular.module('misOfertasApp', ['ngLoadingSpinner']);

var getBaseUrlProd = window.location.protocol + window.location.host + window.location.port + "/";
var getBaseUrlDev = "http://localhost:51800/";


app.constant('URL_SERVICIOS', { BASE_URL: getBaseUrlProd.toString() });

app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);


