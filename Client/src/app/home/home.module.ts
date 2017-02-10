import { NgModule } from '@angular/core';
import { HomeComponent } from './index';
import { DashboardModule } from '../dashboard/dashboard.module';

@NgModule({
    declarations: [
        HomeComponent
    ],
    exports: [
        HomeComponent
    ],
    imports: [
        DashboardModule
    ]
})
export class HomeModule {
}
