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
var index_1 = require("../auth/index");
var index_2 = require("../shared/index");
var LoginComponent = (function () {
    /**
     * Login component for TaskCat.Enterprise Dashboard
     */
    function LoginComponent(router, authService, loggerService) {
        this.router = router;
        this.authService = authService;
        this.loggerService = loggerService;
        this.model = {};
        this.loading = false;
        this.error = '';
        this.appTitle = index_2.CONSTANTS.MAIN.APP.BRAND;
    }
    LoginComponent.prototype.ngOnInit = function () {
        this.authService.logout();
    };
    LoginComponent.prototype.login = function () {
        var _this = this;
        this.loading = true;
        this.authService.login(this.model.username, this.model.password)
            .subscribe(function (result) {
            if (result === true) {
                _this.router.navigate(['/']);
            }
            _this.loading = false;
        }, function (error) {
            _this.loggerService.error(error);
            _this.error = error;
            _this.loading = false;
        });
    };
    return LoginComponent;
}());
LoginComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'as-login',
        templateUrl: 'login.html'
    }),
    __metadata("design:paramtypes", [router_1.Router,
        index_1.AuthService,
        index_2.LoggerService])
], LoginComponent);
exports.LoginComponent = LoginComponent;

//# sourceMappingURL=login.component.js.map
