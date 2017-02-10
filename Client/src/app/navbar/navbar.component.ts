import { Component } from '@angular/core';
import { LocalStorage } from '../shared/index';
import { AuthConstants } from '../auth/index';
import { CONSTANTS } from '../shared/index';
import { AuthService } from '../auth/auth.service';

@Component({
    moduleId: module.id,
    selector: 'as-navbar',
    templateUrl: 'navbar.html'
})
export class NavbarComponent {
    /**
     * TODO: This is definitely replicated code from DashboardComponent.
     * We need to put this avatar configuration somewhere in a settings file
     * if possible.
     */

    public avatarData: any = {
        size: 40,
        background: '#008d4c', // by default it will produce dynamic colors
        fontColor: '#FFFFFF',
        isSquare: false,
        fixedColor: true
    };

    public userInfo: any = {};
    public productInfo: { platform_title: string; product_title: string };

    // Navbar constructor
    constructor(private localStorage: LocalStorage, private authService: AuthService) {
        let userToken = localStorage.getObject(AuthConstants.AUTH_TOKEN_KEY);
        this.avatarData.text = userToken.userData.sub;
        this.userInfo.Name = userToken.userData.sub;
        this.userInfo.Email = userToken.email;

        this.productInfo = {
            platform_title: CONSTANTS.MAIN.APP.PLATFORM_TITLE,
            product_title: CONSTANTS.MAIN.APP.PRODUCT_TITLE
        };
    }

    public signout() {
        this.authService.logout();
    }
}
