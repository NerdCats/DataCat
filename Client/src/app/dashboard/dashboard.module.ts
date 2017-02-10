import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

// Local Modules
import { NavbarModule } from '../navbar/index';
import { LetterAvatarModule } from '../shared/letter-avatar/index';


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
        LetterAvatarModule
    ],
    providers: [...DASHBOARD_PROVIDERS]
})
export class DashboardModule {
}
