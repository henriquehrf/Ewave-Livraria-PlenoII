import { NgModule } from '@angular/core';
import { DropdrowComponent } from './dropdow.component';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [DropdrowComponent],
    imports: [CommonModule],
    exports: [
        DropdrowComponent
    ]
})
export class DropDownModule {
}