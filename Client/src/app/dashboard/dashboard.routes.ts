import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { GlimpseComponent } from '../glimpse/index';

export const DashboardRoutes: Routes = [
    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
    {
        path: 'dashboard',
        component: DashboardComponent,
        children: [
            { path: '', redirectTo: 'glimpse', pathMatch: 'full' },
            { path: 'glimpse', component: GlimpseComponent }
        ]
    }
];
