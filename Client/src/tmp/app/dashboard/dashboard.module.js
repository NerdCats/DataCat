"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var index_1 = require("../navbar/index");
var index_2 = require("../shared/letter-avatar/index");
var index_3 = require("./index");
var index_4 = require("../sidebar/index");
var index_5 = require("../footer/index");
var index_6 = require("../dashview/index");
var index_7 = require("../dashview-header/index");
var DashboardModule = (function () {
    function DashboardModule() {
    }
    return DashboardModule;
}());
DashboardModule = __decorate([
    core_1.NgModule({
        declarations: [
            index_3.DashboardComponent,
            index_4.SidebarComponent,
            index_5.FooterComponent,
            index_6.DashviewComponent,
            index_7.DashviewHeaderComponent
        ],
        exports: [
            index_3.DashboardComponent,
        ],
        imports: [
            common_1.CommonModule,
            index_1.NavbarModule,
            index_2.LetterAvatarModule
        ]
    })
], DashboardModule);
exports.DashboardModule = DashboardModule;

//# sourceMappingURL=dashboard.module.js.map
