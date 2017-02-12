import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ChartsModule } from 'ng2-charts';
import { HttpModule } from '@angular/http';

// Local Modules
import { NavbarModule } from '../navbar/index';
import { LetterAvatarModule } from '../shared/letter-avatar/index';
import { DataModule } from '../data/index';


import { DASHBOARD_PROVIDERS } from './dashboard-event.service';

// Local Components
import { DashboardComponent } from './index';
import { SidebarComponent } from '../sidebar/index';
import { FooterComponent } from '../footer/index';
import { DashviewHeaderComponent } from '../dashview-header/index';

import { GlimpseComponent } from '../glimpse/index';

@NgModule({
    declarations: [
        DashboardComponent,
        SidebarComponent,
        FooterComponent,
        DashviewHeaderComponent,
        GlimpseComponent
    ],
    exports: [
        DashboardComponent,
    ],
    imports: [
        RouterModule,
        CommonModule,
        NavbarModule,
        LetterAvatarModule,
        ChartsModule,
        HttpModule,
        DataModule
    ],
    providers: [...DASHBOARD_PROVIDERS]
})
export class DashboardModule {
}
