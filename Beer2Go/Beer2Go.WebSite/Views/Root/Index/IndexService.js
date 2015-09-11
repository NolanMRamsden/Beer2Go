app.service('IndexService', ['$http', function ($http) {

    this.GetDeliveryFee = function (lat,lng) {
        return $http.get('http://beer2go-locations.azurewebsites.net/api/Delivery?lat=' + lat + '&lng=' + lng);
    };

}]);