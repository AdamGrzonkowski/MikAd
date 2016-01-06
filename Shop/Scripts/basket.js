var app = angular.module("shop", ["ngStorage"]);

app.controller("BasketController", function ($scope, $http, $localStorage, $sessionStorage) {

    $scope.$storage = $sessionStorage.$default({
        products: [{ id: 6, name: "test", amount: 153, price: 19.99 }]
    });

    $scope.getTotalPrice = function () {
        var price = 0.0;
        for (var i in $scope.$storage.products) {
            price += $scope.$storage.products[i].price;
        }
        return price;
    };
});

app.controller("OrdersController", function ($scope, $http, $localStorage, $sessionStorage) {

    var productsUrl = "localhost:55300/api/products/";

    $scope.$storage = $sessionStorage.$default({
        products: []
    });

    $scope.isProductInBasket = function (id) {
        for (var i in $scope.$storage.products) {
            if ($scope.$storage.products[i].id == id) {
                return i;
            }
        }
        return -1;
    }

    $scope.addProductToOrder = function (id, amount) {
        if ($scope.isProductInBasket(id) < 0) {
            alert("Nie ma w bazie.");
        } else {
            alert("jest w bazie");
        }
    }
});