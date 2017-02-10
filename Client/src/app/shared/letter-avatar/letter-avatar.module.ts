import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LetterAvatarComponent } from './index';

@NgModule({
    declarations: [
        LetterAvatarComponent
    ],
    exports: [
        LetterAvatarComponent
    ],
    imports: [
        CommonModule
    ]
})
export class LetterAvatarModule { }
