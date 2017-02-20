(function () {
    function loadCss(url) {
        var head = document.getElementsByTagName('head')[0];
        var link = document.createElement('link');
        link.rel = 'stylesheet';
        link.type = 'text/css';
        link.href = url;
        link.media = 'all';
        head.appendChild(link);
    }

    function loadScript(url, callback) {
        loadCss('https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css')
        loadCss('https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css');

        var script = document.createElement("script")
        script.type = "text/javascript";

        if (script.readyState) {  //IE
            script.onreadystatechange = function () {
                if (script.readyState == "loaded" ||
                        script.readyState == "complete") {
                    script.onreadystatechange = null;
                    callback();
                }
            };
        } else {  //Others
            script.onload = function () {
                callback();
            };
        }

        script.src = url;
        document.getElementsByTagName("head")[0].appendChild(script);
    }


    loadScript("https://ajax.googleapis.com/ajax/libs/angularjs/1.5.0/angular.min.js", function () {
        angular.module('murvasbokhandel', [])
        .controller("ResultsController", ['$scope', '$http', function ($scope, $http) {
            $scope.search_field = "";
            $scope.loading = false;

            $scope.search = function (search_field) {
                $scope.errormessage = null;
                $scope.result = null;
                $scope.loading = true;
                $http({
                    method: "GET",
                    url: "http://murvasbibliotek.azurewebsites.net/Api/Book/Search/" + search_field
                }).then(function successCallback(response) {
                    $scope.result = response.data;
                    $scope.loading = null;
                }, function errorCallback(response) {
                    console.log(response);
                    $scope.errormessage = "Meddelande från server: "
                    $scope.errorcode = response.statusText;
                    $scope.loading = false;
                });
            }
        }])
        .directive('searchWidget', function () {
            return {
                restrict: 'E',
                templateUrl: 'http://murvasbibliotek.azurewebsites.net/Api/File/Widget/html'
            };
        }).config(function ($sceProvider) {
            $sceProvider.enabled(false);
        });
    });
})()