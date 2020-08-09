import { NgModule } from '@angular/core';
import { InstituicaoEnsinoComponent } from './instituicao-ensino.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DropDownModule } from 'app/shared/components/dropdown/dropdown.module';

@NgModule({
    declarations: [InstituicaoEnsinoComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        DropDownModule],
    exports: [
        InstituicaoEnsinoComponent
    ]
})
export class InstituicaoEnsinoModule { }