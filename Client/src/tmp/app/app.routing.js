"use strict";
var router_1 = require("@angular/router");
var index_1 = require("./home/index");
var index_2 = require("./login/index");
var auth_guard_1 = require("./auth/auth.guard");
var securedRoutes = index_1.HomeRoutes.slice();
for (var _i = 0, securedRoutes_1 = securedRoutes; _i < securedRoutes_1.length; _i++) {
    var route = securedRoutes_1[_i];
    if (route) {
        route.canActivate = [auth_guard_1.AuthGuard];
    }
}
var publicRoutes = [
    index_2.LoginRoute
];
var appRoutes = publicRoutes.concat(securedRoutes);
exports.appRoutingProviders = [];
exports.routing = router_1.RouterModule.forRoot(appRoutes);

//# sourceMappingURL=app.routing.js.map
