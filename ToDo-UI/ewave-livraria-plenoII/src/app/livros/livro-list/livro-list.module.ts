import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { LivroListComponent } from './livro-list.component';
import { SearchModule } from 'app/shared/components/search/search.module';
import { LivroModule } from '../livro/livro.module';

@NgModule({
    declarations: [LivroListComponent],
    imports: [
        CommonModule,
        SearchModule,
        LivroModule
    ],
    exports: [LivroListComponent, LivroModule]
})
export class LivroListModule { }