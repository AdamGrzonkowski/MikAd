var app = angular.module("shop", ["ngStorage"]);

var productsUrl = "http://localhost:59583/products/data/";

app.controller("BasketController", function ($scope, $http, $localStorage, $sessionStorage) {

    $scope.$storage = $sessionStorage.$default({
        products: []
    });

    $scope.getTotalPrice = function () {
        var price = 0.0;
        for (var i in $scope.$storage.products) {
            price += $scope.$storage.products[i].Price * $scope.$storage.products[i].Amount;
        }
        return price;
    };
});

app.controller("OrdersController", function ($scope, $http, $localStorage, $sessionStorage) {

    $scope.$storage = $sessionStorage.$default({
        products: []
    });
    $scope.message = "";

    $scope.isProductInBasket = function (id) {
        // jeśli produkt jest w bazie, zwraca jego indeks, w innym wypadku -1.
        for (var i in $scope.$storage.products) {
            if ($scope.$storage.products[i].id == id) {
                return i;
            }
        }
        return -1;
    }

    $scope.getProduct = function (id, amount) {
        return $http({
            method: "get",
            url: productsUrl + id
        }).success(function (data, status, headers, config) {
            if (data.Amount < amount) {
                $scope.message = "Nie możesz zamówić więcej produktów, niż ich liczba w magazynie";
            } else {
                var i = $scope.isProductInBasket(id);
                if (i < 0) {
                    var cleanedData = data;
                    cleanedData.Amount = amount;
                    $scope.$storage.products.push(cleanedData);
                } else {
                    if ($scope.$storage.products[i].Amount + amount > data.Amount) {
                        $scope.message = "Nie możesz zamówić więcej produktów, niż ich liczba w magazynie";
                    } else {
                        $scope.$storage.products[i].Amount += amount;
                        $scope.message = "";
                    }
                }
            }
            //return data;
        });
    }

    $scope.addProductToOrder = function (id, amount) {
        $scope.getProduct(id, amount, $scope.setCurrentProduct).then(function (data, status, headers, config) {
            //if (data.Amount < amount) {
            //    $scope.message = "Nie możesz zamówić więcej produktów, niż ich liczba w magazynie";
            //} else {
            //    var i = $scope.isProductInBasket(id);
            //    if (i < 0) {
            //        $scope.$storage.products.push(data);
            //    } else {
            //        if ($scope.$storage.products[i].Amount + amount > data.Amount) {
            //            $scope.message = "Nie możesz zamówić więcej produktów, niż ich liczba w magazynie";
            //        } else {
            //            $scope.$storage.products[i].Amount += amount;
            //            $scope.message = "";
            //        }
            //    }
            //}
        });
    }
});