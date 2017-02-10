import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';

export interface IDashboardComponetEvent {
    Event: string;
    Name: string;
}

@Injectable()
export class DashboardEventService {
    // TODO: Need to make sure the component updates are standardized
    public componentUpdateSource = new Subject<IDashboardComponetEvent>();

    /** The stream to publish component update stream to other components */
    public componentUpdated$ = this.componentUpdateSource.asObservable();

    public componentUpdated(value: IDashboardComponetEvent) {
        this.componentUpdateSource.next(value);
    }
}

export const DASHBOARD_PROVIDERS: any[] = [
    { provide: DashboardEventService, useClass: DashboardEventService }
];
