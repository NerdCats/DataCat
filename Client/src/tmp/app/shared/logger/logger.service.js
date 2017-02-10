"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var LoggerService = (function () {
    /**
     * Generic logger service for console
     */
    function LoggerService() {
        this.log('Logger Initialized');
    }
    LoggerService.prototype.assert = function () {
        var args = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            args[_i] = arguments[_i];
        }
        if (console && console.assert) {
            console.assert.apply(console, args);
        }
    };
    LoggerService.prototype.error = function () {
        var args = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            args[_i] = arguments[_i];
        }
        if (console && console.error) {
            console.error.apply(console, args);
        }
    };
    LoggerService.prototype.group = function () {
        var args = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            args[_i] = arguments[_i];
        }
        if (console && console.group) {
            console.group.apply(console, args);
        }
    };
    LoggerService.prototype.groupEnd = function () {
        var args = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            args[_i] = arguments[_i];
        }
        if (console && console.groupEnd) {
            console.groupEnd.apply(console, args);
        }
    };
    LoggerService.prototype.info = function () {
        var args = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            args[_i] = arguments[_i];
        }
        /* INFO: I know this is definitely going against our tslint rules.
         * Since that essentially says that we shouldn't use console writing
         * methods in production code of course. We have to find a way so we
         * can turn proper logging level on and off in development and production
         * mode so It's easier to debug when we want to and log in both modes.
         */
        // tslint:disable-next-line:no-console
        if (console && console.info) {
            console.info.apply(console, args);
        }
    };
    LoggerService.prototype.log = function () {
        var args = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            args[_i] = arguments[_i];
        }
        if (console && console.log) {
            console.log.apply(console, args);
        }
    };
    LoggerService.prototype.warn = function () {
        var args = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            args[_i] = arguments[_i];
        }
        if (console && console.warn) {
            console.warn.apply(console, args);
        }
    };
    return LoggerService;
}());
LoggerService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [])
], LoggerService);
exports.LoggerService = LoggerService;
/* INFO:
 * We will definitely need a default implementation of the ILogger if we
 * ever decide we will go for a platform specific logger implementation.
 *
 * But as per YAGNI, this will do now.
 */
exports.LOGGER_PROVIDERS = [
    { provide: LoggerService, useClass: LoggerService }
];

//# sourceMappingURL=logger.service.js.map
