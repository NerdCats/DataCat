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
var router_1 = require("@angular/router");
var auth_constants_1 = require("./auth.constants");
var AuthGuard = (function () {
    /**
     * AuthGuard should block components from loading if authentication denies so
     */
    function AuthGuard(router) {
        this.router = router;
    }
    Object.defineProperty(AuthGuard.prototype, "loginRoute", {
        get: function () {
            return this._loginRoute;
        },
        set: function (v) {
            this._loginRoute = v;
        },
        enumerable: true,
        configurable: true
    });
    AuthGuard.prototype.canActivate = function () {
        if (localStorage.getItem(auth_constants_1.AuthConstants.AUTH_TOKEN_KEY)) {
            return true;
        }
        this.router.navigate([this.loginRoute || '/login']);
    };
    return AuthGuard;
}());
AuthGuard = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [router_1.Router])
], AuthGuard);
exports.AuthGuard = AuthGuard;

//# sourceMappingURL=auth.guard.js.map
