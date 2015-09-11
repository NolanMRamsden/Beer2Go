var app = angular.module('Beer2Go.Index', []);

app.controller('IndexController', ['$scope', 'IndexService', function ($scope,IndexService) {
    $scope.DeliveryPrice = "--.--"
    $scope.DeliveryDistance = "--"
    $scope.Location = {};
    $scope.CheckDeliveryCosts = function () {
        IndexService.GetDeliveryFee($scope.Location.Lat, $scope.Location.Long)
        .success(function (response) {
            $scope.DeliveryPrice = response.Cost;
            $scope.DeliveryDistance = response.Kilometres;
        })
    }
    $scope.SetLocation = function(location) {
        $scope.Location = location;
        $scope.CheckDeliveryCosts();
    }
}]);