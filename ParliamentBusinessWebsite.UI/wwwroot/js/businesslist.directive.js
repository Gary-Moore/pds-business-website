(function (){
    "use strict";

    angular.module("app.business").directive("businessList", businessList);

    businessList.$inject = [];

    function businessList() {
        var directive = {
            restrict: "E",
            bindToController: {
                params: "="
            },
            scope: {},
            replace: false,
            controller: businessListController,
            controllerAs: "vm",
            templateUrl: '/js/businesslist.template.html'
        };

        return directive;
    }

    businessListController.$inject = ["$scope", "businessService"];

    function businessListController($scope, businessService){
        var vm = this;
        vm.items = [];
        vm.pickerOpen = pickerOpen;
        vm.$onInit = init;
        vm.pickerOpened = false;

        vm.dateOptions = {
            formatYear: 'yy',
            dateDisabled: disabled,
            maxDate: new Date(2020, 5, 22),
            startingDay: 1
          };

        function init(){
            vm.currentDate = new Date();
            load(); 
        }

        function load(){
            var startOfWeek = moment(vm.currentDate).day(1).format('YYYY-MM-D');
            var endOfWeek = moment(vm.currentDate).day(5).format('YYYY-MM-D');

            var query = {startDate: startOfWeek, endDate: endOfWeek};
            businessService.get(query).then(function(data){
                vm.items = data;
            });
        }

        function pickerOpen(){
            vm.pickerOpened = true;
        }

        function disabled(data) {
            var date = data.date,
              mode = data.mode;
            return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
          }

          $scope.$watch('vm.currentDate', function () {
                load();
            }, true);
    }

})();