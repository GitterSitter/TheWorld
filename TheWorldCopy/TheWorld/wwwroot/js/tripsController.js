//tripsController.js

(function () {

    "use strict";

    //referencing the module
    angular.module("app-trips").controller("tripsController", tripsController);


    function tripsController($http) {

        var vm = this;

        //vm.trips = [{
        //    name: "Us Trip",
        //    created: new Date()

        //}, 
        //    {
        //        name: "World Trip",
        //        created: new Date()
        //    }];

        vm.trips = [];

        vm.newTrip = {};

        vm.errorMessage = "";

        vm.isBusy = true;

        $http.get("/api/trips")
            .then(function (response) {
                //success
                angular.copy(response.data, vm.trips)
                

            }, function (error) {

                //fail
                vm.errorMessage = "Failed to load error" + error;
            }).finally(function () {
                vm.isBusy = false;
            });
                

        vm.addTrip = function () {
            //vm.trips.push({name: vm.newTrip.name , created: new Date()})
            //vm.newTrip = {};

            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("api/trips", vm.newTrip)
                .then(function (reponse) {
                   //success
                    vm.trips.push(reponse.data);
                    vm.newTrip = {};
        }, function () {
            //failure
            vm.errorMessage = "Failed to save new trip";

            }).finally(function () {
                vm.isBusy = false;  
            });
        };




    }


})();