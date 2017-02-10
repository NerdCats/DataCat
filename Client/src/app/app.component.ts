import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';

import { CONSTANTS } from './shared';

@Component({
    moduleId: module.id,
    selector: 'as-main-app',
    templateUrl: 'app.html'
})
export class AppComponent {
    public appBrand: string;

    constructor(private titleService: Title) {
        this.appBrand = CONSTANTS.MAIN.APP.BRAND;
        this.titleService.setTitle(this.appBrand);
    }
}
