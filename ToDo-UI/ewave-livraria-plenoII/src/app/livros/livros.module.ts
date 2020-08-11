import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { LivroModule } from './livro/livro.module';
import { LivroListModule } from './livro-list/livro-list.module';

@NgModule({
    imports: [
        CommonModule,
        LivroModule,
        LivroListModule
    ],
    exports: [LivroModule, LivroListModule]
})
export class LivrosModule { }