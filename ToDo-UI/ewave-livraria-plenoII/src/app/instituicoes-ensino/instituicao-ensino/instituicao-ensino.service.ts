import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { InstituicaoEnsino } from './instituicao-ensino'
import { UserService } from 'app/core/usuario/usuario.service';

const API_URL = environment.todo_api;

@Injectable({ providedIn: 'root' })
export class InstituicaoEnsinoService {

    constructor(private http: HttpClient) { }

    inserirInstituicaoEnsino(instituicao: InstituicaoEnsino) {
        return this.http
            .post(
                API_URL + '/api/instituicao-ensino',
                instituicao,
                { observe: 'response' },
            );
    }

    alterarInstituicaoEnsino(instituicao: InstituicaoEnsino) {
        return this.http
            .put(
                API_URL + '/api/instituicao-ensino',
                instituicao,
                { observe: 'response' },
            );
    }

    retornarTodasInstituicaoEnsino(){
        return this.http
        .get(
            API_URL + '/api/instituicao-ensino'
        ); 
    }
}


