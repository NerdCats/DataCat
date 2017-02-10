import { Component } from '@angular/core';
import { CONSTANTS } from '../shared/index';

@Component({
    moduleId: module.id,
    selector: 'as-footer',
    templateUrl: 'footer.html'
})
export class FooterComponent {
    public companyInfo: { title: string, url: string; tagline: string; };

    /**
     * Footer constructor
     */
    constructor() {
        this.companyInfo = {
            title: CONSTANTS.MAIN.COMPANY.TITLE,
            url: CONSTANTS.MAIN.COMPANY.URL,
            tagline: CONSTANTS.MAIN.COMPANY.TAGLINE
        };
    }
}
