var app = angular.module("shop", ["ngStorage"]);

var productsUrl = "/products/data/";

app.controller("BasketController", function ($scope, $http, $localStorage, $sessionStorage) {

    $scope.$storage = $sessionStorage.$default({
        products: [],
        consignments : []
    });

    $scope.consignment = 0;

    $scope.getConsignments = function() {
        $http({
            method: "get",
            url: "/consignments/data"
        }).success(function(data, status, headers, config) {
            $scope.$storage.consignments = data;
        });
    }

    $scope.getShippingPrice = function (index) {
        return 0 || $scope.$storage.consignments[index].Cost;
    }

    $scope.isProductInBasket = function (id) {
        // jeśli produkt jest w bazie, zwraca jego indeks, w innym wypadku -1.
        for (var i in $scope.$storage.products) {
            if ($scope.$storage.products[i].Id === id) {
                return i;
            }
        }
        return -1;
    }

    $scope.getTotalPrice = function () {
        var price = 0.0;
        for (var i in $scope.$storage.products) {
            price += $scope.$storage.products[i].Price * $scope.$storage.products[i].Amount;
        }
        return price;
    };

    $scope.createOrder = function () {
        $http({
            method: "post",
            url: "/Orders/Create",
            data: { Basket: $scope.$storage.products, Notes: $scope.Notes, Consignment: 1 }
        }).success(function (data) {
            console.log(data);
            $scope.clearBasket();
            window.location.href = '/Order/Finish/' + data;
        });
    }

    $scope.incrementProduct = function (id) {
        var i = $scope.isProductInBasket(id);
        if (i >= 0) {
            if ($scope.$storage.products[i].Amount < $scope.$storage.products[i].Stock) {
                $scope.$storage.products[i].Amount += 1;
            }
        }
    }

    $scope.decrementProduct = function (id) {
        var i = $scope.isProductInBasket(id);
        if (i >= 0) {
            $scope.$storage.products[i].Amount -= 1;

            if ($scope.$storage.products[i].Amount <= 0) {
                $scope.$storage.products.splice(i, 1);
            }
        }
    }

    $scope.clearBasket = function() {
        $scope.$storage.$reset({
            products: []
        });
    }

    $scope.getConsignments();
});

app.controller("OrdersController", function ($scope, $http, $localStorage, $sessionStorage) {

    $scope.$storage = $sessionStorage.$default({
        products: []
    });
    $scope.message = "";
    $scope.notes = "";

    $scope.isProductInBasket = function (id) {
        // jeśli produkt jest w bazie, zwraca jego indeks, w innym wypadku -1.
        for (var i in $scope.$storage.products) {
            if ($scope.$storage.products[i].Id === id) {
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
            if (data.Stock < amount) {
                $scope.message = "Nie możesz zamówić więcej produktów, niż ich liczba w magazynie";
            } else {
                var i = $scope.isProductInBasket(id);
                if (i < 0) {
                    var cleanedData = data;
                    cleanedData.Amount = amount;
                    $scope.$storage.products.push(cleanedData);
                } else {
                    if ($scope.$storage.products[i].Amount + amount > data.Stock) {
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
        });
    }

    $scope.removeProductFromOrder = function (id, amount) {
        var i = $scope.isProductInBasket(id);
        if (i >= 0) {
            $scope.$storage.products[i].Amount -= amount;

            if ($scope.$storage.products[i].Amount < 1) {
                $scope.$storage.products.splice(i, 1);
            }
        }
    }
});