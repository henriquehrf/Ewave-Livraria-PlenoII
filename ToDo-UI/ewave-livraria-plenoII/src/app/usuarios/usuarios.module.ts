import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioListModule } from './usuario-list/usuario-list.module';
import { UsuarioModule } from './usuario/usuario.module';

@NgModule({
    imports: [
        CommonModule,
        UsuarioListModule,
        UsuarioModule
    ],
    exports: [UsuarioListModule, UsuarioModule]
})
export class UsuariosModule { }