import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InstituicaoEnsinoListComponent } from './instituicao-ensino-list.component';
import { InstituicaoEnsinoModule } from '../instituicao-ensino/instituicao-ensino.module';
import { SearchModule } from 'app/shared/components/search/search.module';

@NgModule({
    declarations: [InstituicaoEnsinoListComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        InstituicaoEnsinoModule,
        SearchModule],
    exports: [
        InstituicaoEnsinoListComponent
    ]
})
export class InstituicaoEnsinoListModule { }