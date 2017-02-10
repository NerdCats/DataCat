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
var index_1 = require("../shared/index");
var index_2 = require("../auth/index");
var NavbarUserMenuComponent = (function () {
    /**
     * Constructor for the user component shown in the navbar
     */
    function NavbarUserMenuComponent(localStorage) {
        this.localStorage = localStorage;
        /**
         * TODO: This is definitely replicated code from DashboardComponent.
         * We need to put this avatar configuration somewhere in a settings file
         * if possible.
         */
        this.avatarData = {
            size: 40,
            background: '#008d4c',
            fontColor: '#FFFFFF',
            isSquare: false,
            fixedColor: true
        };
        this.userInfo = {};
        var userToken = localStorage.getObject(index_2.AuthConstants.AUTH_TOKEN_KEY);
        this.avatarData.text = userToken.userData.sub;
        this.userInfo.Name = userToken.userData.sub;
        this.userInfo.Email = userToken.email;
    }
    return NavbarUserMenuComponent;
}());
NavbarUserMenuComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'as-navbar-user-menu',
        templateUrl: 'navbar-user-menu.html'
    }),
    __metadata("design:paramtypes", [index_1.LocalStorage])
], NavbarUserMenuComponent);
exports.NavbarUserMenuComponent = NavbarUserMenuComponent;

//# sourceMappingURL=navbar-user-menu.component.js.map
