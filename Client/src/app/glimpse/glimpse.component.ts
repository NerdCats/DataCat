import { Component, OnInit } from '@angular/core';
import { DashboardEventService } from '../dashboard/dashboard-event.service';
import { DataService } from '../data/index';
import { LoggerService } from '../shared/index';

@Component({
    moduleId: module.id,
    selector: 'as-glimpse',
    templateUrl: 'glimpse.html'
})
export class GlimpseComponent implements OnInit {
    public barChartOptions: any = {
        scaleShowVerticalLines: false,
        responsive: true,
        scales: {
            yAxes: [{
                display: true,
                ticks: {
                    suggestedMin: 0,    // minimum will be 0, unless there is a lower value.
                    // OR //
                    beginAtZero: true,   // minimum value will be 0.
                    suggestedMax: 100,
                    max: 150
                }
            }]
        }
    };

    public isDataAvailable: boolean = false;
    public barChartLabels: string[] = [];
    public barChartType: string = 'bar';
    public barChartLegend: boolean = true;
    public barChartData: any[];

    constructor(
        private dataService: DataService,
        private loggerService: LoggerService,
        private dashboarEventService: DashboardEventService) {
        dashboarEventService.componentUpdated({ Event: 'loaded', Name: 'Glimpse' });
    }

    ngOnInit() {
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
                let jobCountArray: any[] = [];
                if (result) {
                    // Need to parse this crap here
                    let res: any[] = result;
                    for (let entry of res) {
                        this.barChartLabels.push(new Date(entry._id.CreateDate.$date).toDateString());
                        jobCountArray.push(entry.count);
                    }
                }
                this.barChartData = [{data: jobCountArray, label: 'Orders'}];
                this.isDataAvailable = true;
            },
            error => { this.loggerService.error(error); });
    }
}
