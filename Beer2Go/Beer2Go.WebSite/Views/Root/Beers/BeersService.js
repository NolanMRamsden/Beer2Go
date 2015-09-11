app.service('BeersService', ['$http', function ($http) {

    this.GetProducts = function () {
        return $http.get('http://beer2go-products.azurewebsites.net/api/Products')
    };

}]);