var app = angular.module('Beer2Go.Beers', []);

app.controller('BeersController', ['$scope', 'BeersService', function ($scope, BeersService) {
    $scope.Products = [];
    $scope.VisibleProducts = [];
    $scope.textFilter = "";
    $scope.includeOutOfStock = false;

    BeersService.GetProducts()
        .success(function (response) {
            $scope.Products = response;
            $scope.ApplyFilters();
        })
        .error(function () {
            $scope.VisibleProducts = undefined;
        });

    $scope.ApplyFilters = function() {
        $scope.VisibleProducts = [];
        console.log($scope.includeOutOfStock);
        for (i = 0; i < $scope.Products.length; i++) {
            var good = true;
            if ($scope.includeOutOfStock == false && $scope.Products[i].Inventory <= 0) {
                good = false;
            }
            if ($scope.Products[i].Name.toLowerCase().indexOf($scope.textFilter.toLowerCase()) == -1) {
                good = false;
            }
            if (good == true) {
                $scope.VisibleProducts.push($scope.Products[i]);
            }
        }
    }

    $scope.SetLocation = function () {

    }
}]);