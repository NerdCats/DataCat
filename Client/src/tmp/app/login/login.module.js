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
var forms_1 = require("@angular/forms");
var index_1 = require("./index");
var index_2 = require("../auth/index");
var LoginModule = (function () {
    /**
     * TaskCat Enterprise dashboard login module
     */
    function LoginModule(authGuard) {
        this.authGuard = authGuard;
        authGuard.loginRoute = '/' + index_1.LoginRoute.path;
    }
    return LoginModule;
}());
LoginModule = __decorate([
    core_1.NgModule({
        declarations: [
            index_1.LoginComponent
        ],
        exports: [
            index_1.LoginComponent,
            index_2.AuthModule
        ],
        imports: [
            index_2.AuthModule,
            forms_1.FormsModule
        ]
    }),
    __metadata("design:paramtypes", [index_2.AuthGuard])
], LoginModule);
exports.LoginModule = LoginModule;

//# sourceMappingURL=login.module.js.map
