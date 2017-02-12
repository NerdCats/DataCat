import { Component } from '@angular/core';
import { DashboardEventService } from '../dashboard/dashboard-event.service';
import { DataService } from '../data/index';
import { LoggerService } from '../shared/index';

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
    constructor(
        private dataService: DataService,
        private loggerService: LoggerService,
        private dashboarEventService: DashboardEventService) {
        let document: any = {
            'aggregate': [
                { '$sort': { 'CreateTime': -1 } },
                {
                    '$project': {
                        '_id': 1,
                        'HRID': 1,
                        'CreateTime': 1,
                        'Order.Type': 1,
                        'Order.Variant': 1,
                        'User.Type': 1,
                        'User.UserName': 1,
                        'h': {
                            '$hour': '$CreateTime'
                        },
                        'm': {
                            '$minute': '$CreateTime'
                        },
                        's': {
                            '$second': '$CreateTime'
                        },
                        'ml': {
                            '$millisecond': '$CreateTime'
                        }
                    }
                },
                {
                    '$project': {
                        '_id': 1,
                        'HRID': 1,
                        'Order.Type': 1,
                        'Order.Variant': 1,
                        'User.Type': 1,
                        'User.UserName': 1,
                        'CreateTime': {
                            '$subtract': [
                                '$CreateTime',
                                {
                                    '$add': [
                                        '$ml',
                                        {
                                            '$multiply': [
                                                '$s',
                                                1000
                                            ]
                                        },
                                        {
                                            '$multiply': [
                                                '$m',
                                                60,
                                                1000
                                            ]
                                        },
                                        {
                                            '$multiply': [
                                                '$h',
                                                60,
                                                60,
                                                1000
                                            ]
                                        }
                                    ]
                                }
                            ]
                        }
                    }
                },
                {
                    '$group': {
                        '_id': {
                            'CreateDate': '$CreateTime'
                        },
                        'count': {
                            '$sum': 1
                        },
                        'jobs': {
                            '$push': '$HRID'
                        }
                    }
                }
            ]
        };

        this.dataService.executeAggregation('Jobs', document)
            .subscribe(result => {
                if (result) {
                    this.loggerService.log(result);
                }
             },
            error => { this.loggerService.error(error); });

        dashboarEventService.componentUpdated({ Event: 'loaded', Name: 'Glimpse' });
    }
}
