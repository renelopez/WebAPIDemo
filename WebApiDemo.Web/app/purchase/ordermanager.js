(function () {
    'use strict';
    var controllerId = 'orderManager';
    angular.module('app').controller(controllerId, ['common', 'datacontext', orderManager]);

    function orderManager(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logInfo = getLogFn(controllerId, "info");
        var logSuccess = getLogFn(controllerId, 'success');
        var currentOrder = null;

        var vm = this;
        vm.orders = [];
        vm.showDetails = showDetails;
        vm.toggleDetails = toggleDetails;

        activate();

        function activate() {
            common.activateController([datacontext.ready], controllerId)
                .then(function () {
                    log('Activated New Order View');
                });
            logInfo("Getting Books...");

            datacontext.getBooks();

            datacontext.getOrdersAndDetails()
                .then(function(orders) {
                    vm.orders = orders;
                });
        }
        
        function showDetails(order) {
            return order === currentOrder;
        }
        
        function toggleDetails(order) {
            currentOrder = order === currentOrder ? null : order;
        }


    }
})();