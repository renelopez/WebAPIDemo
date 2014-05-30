// ReSharper disable InconsistentNaming

window.testFns = (function () {
    'use strict';

    window.testing = true;
    addCustomMatchers();
    createBreezeWebApiTestModule();  // spin up a tiny angular module that prepares breeze to live in an angular world
    extendExpect();                  // monkey patch the jasmine expect so that it has ToFail method

    // absolute url for breeze controller
    var serviceRoot = window.location.protocol + '//' +
        //window.location.host + '/';
        "localhost:9000" + '/';
    var serviceName = serviceRoot + 'api/Breeze';

    // define what our testfns will be
    var fns = {
        failed: failed,
        serviceName: serviceName,
        serviceRoot: serviceRoot
    };
    return fns;  // becomes window.testFns

    /*********************************************************
     * Add our custom Jasmine test matchers which are like custom asserts.
     * See http://jasmine.github.io/2.0/custom_matcher.html
     *********************************************************/
    function addCustomMatchers() {
        beforeEach(function () {
            jasmine.addMatchers({
                toFail: toFail
            });
        });
    }
    /*********************************************************
     * Creates a new Angular Module for pure Breeze Web API Testing
     *********************************************************/
    function createBreezeWebApiTestModule() {
        angular.module('BreezeWebApiTest', [
            'breeze.angular' // tells breeze to use $q instead of Q.js
        ]).factory('config.breeze', [
            function () {
                breeze.NamingConvention.camelCase.setAsDefault();
            }
        ]).run(['breeze','config.breeze', function () { }]);
    }

    /*********************************************************
     * Extend Jasmine window.expect so can write
     * expect.toFail(failMessage)
     *********************************************************/
    function extendExpect() {
        expect.toFail = function (failMessage) {
            expect().toFail(failMessage);
        };
    }

    /*********************************************************
    * All purpose failure reporter to be used within promise fails
    *********************************************************/
    function failed(err) {
        var msg = 'Unexpected test failure: ' + (err.message || err);
        if (err.body) {
            msg += err.body.Message + " " + err.body.MessageDetail;
        }
        else if (err.statusText) {
            msg += err.statusText;
        }
        console.log(msg);
        expect.toFail(msg);
    }

    /*********************************************************
     * Jasmine matcher that always fails with the message
     * Ex: expect().toFail('what a mess');
     *********************************************************/
    function toFail() {
        return {
            compare: function (_, failMessage) {
                return {
                    pass: false, // always fails
                    message: failMessage
                };
            }
        };
    }


})();