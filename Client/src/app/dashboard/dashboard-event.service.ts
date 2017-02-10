import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class DashboardEventService {
    /** The stream to publish component update stream to other components */
    public componentUpdated$ = this.componentUpdateSource.asObservable();

    // TODO: Need to make sure the component updates are standardized
    private componentUpdateSource = new Subject<any>();

    public componentUpdated(value: any) {
        this.componentUpdateSource.next(value);
    }
}

export const DASHBOARD_PROVIDERS: any[] = [
    { provide: DashboardEventService, useClass: DashboardEventService }
];
