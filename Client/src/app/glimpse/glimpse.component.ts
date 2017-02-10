import { Component } from '@angular/core';
import { DashboardEventService } from '../dashboard/dashboard-event.service';

@Component({
    moduleId: module.id,
    selector: 'as-glimpse',
    templateUrl: 'glimpse.html'
})
export class GlimpseComponent {
    constructor(private dashboarEventService: DashboardEventService) {
        dashboarEventService.componentUpdated({ Event: 'loaded', Name: 'Glimpse' });
    }
}
