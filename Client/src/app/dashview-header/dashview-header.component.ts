import { Component } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'as-dashview-header',
    templateUrl: 'dashview-header.html'
})
export class DashviewHeaderComponent {
    public pageHeader: string = 'Loading';
    public optionalDescription: string = '';

    /**INFO: Not sure how to play this out here.
     * The first one has to be the dashboard logo
     * and the last one has to have class=active on
     * it so we know which one is active here
     */
    public breadcrumbDef: string[];
}
