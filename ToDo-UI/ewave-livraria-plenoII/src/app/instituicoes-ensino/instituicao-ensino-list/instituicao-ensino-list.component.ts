import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, ReactiveFormsModule, FormControl } from '@angular/forms';
import { InstituicaoEnsinoService } from '../instituicao-ensino/instituicao-ensino.service';
import { InstituicaoEnsino } from '../instituicao-ensino/instituicao-ensino';
import { BehaviorSubject, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { InstituicaoEnsinoModule } from '../instituicao-ensino/instituicao-ensino.module';

@Component({
  selector: 'todo-instituicao-ensino-list',
  templateUrl: './instituicao-ensino-list.component.html'
})
export class InstituicaoEnsinoListComponent implements OnInit {

  private instituicoes = new BehaviorSubject<any>(null);
  @Input() exibeFormularioNovo: boolean;
  private instituicaoSelecionada: InstituicaoEnsino;

  constructor(private instituicaoEnsinoService: InstituicaoEnsinoService) {

  }

  ngOnInit(): void {
    this.carregarDados();
  }

  atualizar() {
    this.carregarDados();
  }

  carregarDados() {
    this.instituicaoEnsinoService.retornarTodasInstituicaoEnsino().subscribe(
      (response) => {
        this.instituicoes.next(response);
      },
      err => {
        alert(err);
      }
    )
  }

  novo() {
    this.exibeFormularioNovo = true;
    //this.instituicaoSelecionada = null;
  }

  editar(instituicao) {
    this.instituicaoSelecionada = instituicao;
    this.exibeFormularioNovo = true;
  }

  voltar() {
    this.exibeFormularioNovo = false;
    //this.instituicaoSelecionada = null;
  }
}
