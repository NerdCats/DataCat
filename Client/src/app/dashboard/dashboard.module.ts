import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarModule } from '../navbar/index';
import { LetterAvatarModule } from '../shared/letter-avatar/index';

import { DashboardComponent } from './index';
import { SidebarComponent } from '../sidebar/index';
import { FooterComponent } from '../footer/index';
import { DashviewComponent } from '../dashview/index';
import { DashviewHeaderComponent } from '../dashview-header/index';

@NgModule({
    declarations: [
        DashboardComponent,
        SidebarComponent,
        FooterComponent,
        DashviewComponent,
        DashviewHeaderComponent
    ],
    exports: [
        DashboardComponent,
    ],
    imports: [
        CommonModule,
        NavbarModule,
        LetterAvatarModule
    ]
})
export class DashboardModule {
}
