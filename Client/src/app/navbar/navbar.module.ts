import { NgModule } from '@angular/core';
import { NavbarComponent } from './index';
import { CommonModule } from '@angular/common';
import { LetterAvatarModule } from '../shared/letter-avatar/index';

@NgModule({
    declarations: [
        NavbarComponent
    ],
    exports: [
        NavbarComponent
    ],
    imports: [
        CommonModule,
        LetterAvatarModule
    ]
})
export class NavbarModule { }
