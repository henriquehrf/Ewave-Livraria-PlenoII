import { NgModule } from '@angular/core';
import { LivrariaComponent } from './livraria.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HeaderModule } from '../header/header.module';
import { InstituicoesEnsinoModule } from '../instituicoes-ensino/instituicoes-ensino.module';
import { UsuariosModule } from 'app/usuarios/usuarios.module';


@NgModule({
    declarations: [LivrariaComponent],
    imports: [
        CommonModule,
        HttpClientModule,
        RouterModule,
        HeaderModule,
        InstituicoesEnsinoModule,
        UsuariosModule
    ],
    exports: [ LivrariaComponent ]
})
export class LivrariaModule { }