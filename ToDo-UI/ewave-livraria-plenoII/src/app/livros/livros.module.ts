import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { LivroModule } from './livro/livro.module';

@NgModule({
    imports: [ 
        CommonModule,
        LivroModule,
    ],
    exports: [LivroModule]
})
export class LivrosModule {}