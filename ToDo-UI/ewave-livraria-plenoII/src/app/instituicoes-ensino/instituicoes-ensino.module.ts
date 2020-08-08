import { NgModule } from '@angular/core';
import { InstituicaoEnsinoModule } from './instituicao-ensino/instituicao-ensino.module';
import { InstituicaoEnsinoListModule } from './instituicao-ensino-list/instituicao-ensino-list.module';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [
        CommonModule,
        InstituicaoEnsinoModule,
        InstituicaoEnsinoListModule
    ],
    exports: [InstituicaoEnsinoModule, InstituicaoEnsinoListModule]
})
export class InstituicoesEnsinoModule { }