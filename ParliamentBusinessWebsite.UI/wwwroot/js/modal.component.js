angular.module('app.business').component('modalComponent', {
    templateUrl: '/js/modal.template.html',
    bindings: {
      resolve: '<',
      close: '&',
      dismiss: '&'
    },
    controller: function () {
      var $ctrl = this;
  
      $ctrl.$onInit = function () {
        $ctrl.item = $ctrl.resolve.item;
      };  
  
      $ctrl.cancel = function () {
        $ctrl.dismiss({$value: 'cancel'});
      };
    }
  });