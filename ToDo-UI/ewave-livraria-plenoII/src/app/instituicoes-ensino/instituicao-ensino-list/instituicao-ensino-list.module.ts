import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InstituicaoEnsinoListComponent } from './instituicao-ensino-list.component';
import { InstituicaoEnsinoComponent } from '../instituicao-ensino/instituicao-ensino.component';
import { InstituicaoEnsinoModule } from '../instituicao-ensino/instituicao-ensino.module';

@NgModule({
    declarations: [InstituicaoEnsinoListComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        InstituicaoEnsinoModule],
    exports: [
        InstituicaoEnsinoListComponent
    ]
})
export class InstituicaoEnsinoListModule { }