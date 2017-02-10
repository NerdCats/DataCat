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
var http_1 = require("@angular/http");
var router_1 = require("@angular/router");
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/observable/throw");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var auth_constants_1 = require("./auth.constants");
var angular2_jwt_1 = require("angular2-jwt");
var index_1 = require("../shared/index");
var AuthService = (function () {
    /**
     * Authentication service for enterprise dashboard
     */
    function AuthService(http, localStorage, jwtHelper, router, loggerService) {
        this.http = http;
        this.localStorage = localStorage;
        this.jwtHelper = jwtHelper;
        this.router = router;
        this.loggerService = loggerService;
    }
    AuthService.prototype.login = function (username, password) {
        var _this = this;
        var headers = new http_1.Headers();
        var tokenUrl = index_1.CONSTANTS.ENV.API_BASE + 'auth/token'; // TODO: Need to definitely load from settings
        var urlEncodedParam = 'grant_type=' + 'password' +
            '&username=' + username +
            '&password=' + password +
            '&client_id=' + 'GoFetchDevWebApp'; // TODO: We need to load this from either environment or settings somewhere.
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return this.http.post(tokenUrl, urlEncodedParam, { headers: headers })
            .map(function (res) {
            if (res.status < 200 || res.status >= 300) {
                throw new Error('Response status: ' + res.status);
            }
            return _this._extractAndSaveAuthData(res);
        })
            .catch(function (error) {
            return _this._extractAuthError(error);
        });
    };
    AuthService.prototype.logout = function () {
        localStorage.removeItem(auth_constants_1.AuthConstants.AUTH_TOKEN_KEY);
        /**
         * INFO: We don't know at this point what would be the login route
         * of this app. Since we are guarding it by canActivate we can safely
         * expect that navigating to the login route will the do the right thing
         * and move the app to the login page. But we don't yet know that is the
         * proper route. May be at some point we would want it to have a way
         * to know which would be the proper login route for the app
        */
        this.router.navigate(['/login']);
    };
    AuthService.prototype._extractAndSaveAuthData = function (res) {
        var data = res.json();
        if (!data) {
            throw new Error('Invalid/blank auth data, Fatal Error');
        }
        try {
            var userData = this.jwtHelper.decodeToken(data.access_token);
            /**
             * Making sure the user is allowed to get in. Currently this dashboard
             * is only for enterprise users. This would essentially be extended
             * so the components our aware of User types and can act accordingly.
             **/
            var roleString = userData.role;
            // TODO: Make sure we send out a nice message otherwise
            if (roleString.indexOf('Enterprise') === -1) {
                return false;
            }
            data.userData = userData;
            this.localStorage.setObject(auth_constants_1.AuthConstants.AUTH_TOKEN_KEY, data);
        }
        catch (ex) {
            throw new Error('Fatal error, failed to parse token');
        }
        return true;
    };
    AuthService.prototype._extractAuthError = function (res) {
        var error = res.json();
        var errorMsg = error.error_description || 'Server error';
        this.loggerService.error(errorMsg);
        return Observable_1.Observable.throw(errorMsg);
    };
    return AuthService;
}());
AuthService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http,
        index_1.LocalStorage,
        angular2_jwt_1.JwtHelper,
        router_1.Router,
        index_1.LoggerService])
], AuthService);
exports.AuthService = AuthService;

//# sourceMappingURL=auth.service.js.map
