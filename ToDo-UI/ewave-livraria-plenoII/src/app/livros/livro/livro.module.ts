import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { LivroComponent } from './livro.component';

@NgModule({
    imports: [ 
        CommonModule,
    ],
    exports: [LivroComponent]
})
export class LivroModule {}