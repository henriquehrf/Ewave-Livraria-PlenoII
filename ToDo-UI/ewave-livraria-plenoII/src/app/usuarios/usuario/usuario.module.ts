import { NgModule } from '@angular/core';
import { UsuarioComponent } from './usuario.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DropDownModule } from 'app/shared/components/dropdown/dropdown.module';

@NgModule({
    declarations: [UsuarioComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        DropDownModule],
    exports: [
        UsuarioComponent
    ]
})
export class UsuarioModule { }