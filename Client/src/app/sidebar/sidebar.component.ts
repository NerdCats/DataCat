import { Component } from '@angular/core';
import { LocalStorage } from '../shared/index';
import { AuthConstants } from '../auth/index';

@Component({
    moduleId: module.id,
    selector: 'as-sidebar',
    templateUrl: 'sidebar.html'
})
export class SidebarComponent {
    // TODO: Replication here again, need to put this somewhere in a settings.
    public avatarData: any = {
        size: 40,
        background: '#008d4c', // by default it will produce dynamic colors
        fontColor: '#FFFFFF',
        isSquare: false,
        fixedColor: true
    };

    public userInfo: any = {};

    /**
     * Sidebar constructor
     */
    constructor(private localStorage: LocalStorage) {
        let userToken = localStorage.getObject(AuthConstants.AUTH_TOKEN_KEY);
        this.avatarData.text = userToken.userData.sub;
        this.userInfo.Name = userToken.userData.sub;
        this.userInfo.Email = userToken.email;
    }
}
