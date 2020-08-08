import { NgModule } from '@angular/core';
import { InstituicaoEnsinoComponent } from './instituicao-ensino.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    declarations: [InstituicaoEnsinoComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule],
    exports: [
        InstituicaoEnsinoComponent
    ]
})
export class InstituicaoEnsinoModule { }