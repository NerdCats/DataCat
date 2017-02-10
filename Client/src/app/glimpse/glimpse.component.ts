import { Component } from '@angular/core';
import { DashboardEventService } from '../dashboard/dashboard-event.service';

@Component({
    moduleId: module.id,
    selector: 'as-glimpse',
    templateUrl: 'glimpse.html'
})
export class GlimpseComponent {
    public barChartOptions: any = {
        scaleShowVerticalLines: false,
        responsive: true
    };

    public barChartLabels: string[] = ['2006', '2007', '2008', '2009', '2010', '2011', '2012'];
    public barChartType: string = 'bar';
    public barChartLegend: boolean = true;

    public barChartData: any[] = [
        { data: [65, 59, 80, 81, 56, 55, 40], label: 'Series A' },
        { data: [28, 48, 40, 19, 86, 27, 90], label: 'Series B' }
    ];
    constructor(private dashboarEventService: DashboardEventService) {
        dashboarEventService.componentUpdated({ Event: 'loaded', Name: 'Glimpse' });
    }
}
