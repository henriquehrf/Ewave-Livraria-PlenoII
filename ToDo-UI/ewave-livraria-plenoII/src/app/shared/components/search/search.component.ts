import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, ReactiveFormsModule, FormControl } from '@angular/forms';
import { InstituicaoEnsinoService } from '../instituicao-ensino/instituicao-ensino.service';
import { InstituicaoEnsino } from '../instituicao-ensino/instituicao-ensino';
import { BehaviorSubject, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { InstituicaoEnsinoModule } from '../instituicao-ensino/instituicao-ensino.module';

@Component({
    selector: 'todo-search',
    templateUrl: './search.component.html'
})
export class SearchComponent implements OnInit {

    @Output() textoPesquisado = new EventEmitter<string>();

    constructor() {

    }

    ngOnInit(): void {
    }

    pesquisar(valor) {
        this.textoPesquisado.emit(valor);
    }
}
