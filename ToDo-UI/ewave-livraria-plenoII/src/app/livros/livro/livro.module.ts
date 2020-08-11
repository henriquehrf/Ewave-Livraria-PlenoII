import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { LivroComponent } from './livro.component';

@NgModule({
    declarations: [LivroComponent],
    imports: [ 
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ],
    exports: [LivroComponent]
})
export class LivroModule {}