import { Routes, RouterModule } from '@angular/router';

import { HomeRoutes } from './home/index';
import { LoginRoute } from './login/index';

import { AuthGuard } from './auth/auth.guard';

const securedRoutes: Routes = [
    ...HomeRoutes,
];

for (let route of securedRoutes) {
    if (route) {
        route.canActivate = [AuthGuard];
    }
}

const publicRoutes: Routes = [
    LoginRoute
];

const appRoutes: Routes = [
    ...publicRoutes,
    ...securedRoutes
];

export const appRoutingProviders: any[] = [

];

export const routing = RouterModule.forRoot(appRoutes);
