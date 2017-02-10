import { NgModule } from '@angular/core';
import { AuthConstants, AuthGuard, AuthService} from './index';
import { JwtHelper } from 'angular2-jwt';

@NgModule({
    providers: [
        AuthService,
        AuthConstants,
        AuthGuard,
        JwtHelper
    ]
})
export class AuthModule {}
