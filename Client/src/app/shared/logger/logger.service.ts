import { Injectable } from '@angular/core';

export interface ILogger {
    assert(...args: any[]): void;
    error(...args: any[]): void;
    group(...args: any[]): void;
    groupEnd(...args: any[]): void;
    info(...args: any[]): void;
    log(...args: any[]): void;
    warn(...args: any[]): void;
}

declare var console: any;

@Injectable()
export class LoggerService implements ILogger {
    public assert(...args: any[]): void {
        if (console && console.assert) { console.assert(...args); }
    }
    public error(...args: any[]): void {
        if (console && console.error) { console.error(...args); }
    }
    public group(...args: any[]): void {
        if (console && console.group) { console.group(...args); }
    }
    public groupEnd(...args: any[]): void {
        if (console && console.groupEnd) { console.groupEnd(...args); }
    }
    public info(...args: any[]): void {
        /* INFO: I know this is definitely going against our tslint rules.
         * Since that essentially says that we shouldn't use console writing
         * methods in production code of course. We have to find a way so we
         * can turn proper logging level on and off in development and production
         * mode so It's easier to debug when we want to and log in both modes.
         */
        // tslint:disable-next-line:no-console
        if (console && console.info) { console.info(...args); }
    }
    public log(...args: any[]): void {
        if (console && console.log) { console.log(...args); }
    }
    public warn(...args: any[]): void {
        if (console && console.warn) { console.warn(...args); }
    }

    /**
     * Generic logger service for console
     */
    constructor() {
        this.log('Logger Initialized');
    }
}


/* INFO:
 * We will definitely need a default implementation of the ILogger if we
 * ever decide we will go for a platform specific logger implementation.
 *
 * But as per YAGNI, this will do now.
 */
export const LOGGER_PROVIDERS: any[] = [
    { provide: LoggerService, useClass: LoggerService }
];
