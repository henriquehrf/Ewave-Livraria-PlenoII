import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchModule } from 'app/shared/components/search/search.module';
import { UsuarioListComponent } from './usuario-list.component';
import { UsuarioModule } from '../usuario/usuario.module';

@NgModule({
    declarations: [UsuarioListComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        SearchModule,
        UsuarioModule
    ],
    exports: [
        UsuarioListComponent
    ]
})
export class UsuarioListModule { }