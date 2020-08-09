import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { FormGroup, ReactiveFormsModule, FormControl } from '@angular/forms';
import { InstituicaoEnsinoService } from './instituicao-ensino.service';
import { Router } from '@angular/router';
import { InstituicaoEnsinoModule } from './instituicao-ensino.module';
import { InstituicaoEnsino } from './instituicao-ensino';
/* import { BehaviorSubject } from 'rxjs';
import { Dropdown } from 'app/shared/components/dropdown/dropdown'; */

@Component({
  selector: 'todo-instituicao-ensino',
  templateUrl: './instituicao-ensino.component.html'
})
export class InstituicaoEnsinoComponent implements OnInit {

  @Input() instituicao: InstituicaoEnsino;
  @Output() exibeMenuNovo = new EventEmitter<boolean>();
  //private instituicoesDeEnsino = new BehaviorSubject<any>(null);

  instituicaoForm: FormGroup;
  constructor(private instituicaoEnsinoService: InstituicaoEnsinoService) {
  }

  ngOnInit(): void {
    this.novoFormulario();
    this.limparFormulario();
    // this.carregarDropdonw();
  }

  novoFormulario() {
    this.instituicaoForm = new FormGroup({
      id: new FormControl(),
      nome: new FormControl(),
      endereco: new FormControl(),
      cnpj: new FormControl(),
      telefone: new FormControl(),
    });
  }

  salvar() {
    const ehAlteracao = (this.instituicao.id > 0);
    if (!ehAlteracao) {
      const instituicao = this.instituicaoForm.value;
      instituicao.id = 0;
      this.instituicaoEnsinoService.inserirInstituicaoEnsino(instituicao).subscribe(
        () => {
          alert("Salvo com Sucesso!!!")
          this.voltar();
        },
        err => {
          alert(err.error.toString());
        }
      )
    } else {
      const instituicao = this.instituicaoForm.value;
      instituicao.id = this.instituicao.id;
      this.instituicaoEnsinoService.alterarInstituicaoEnsino(instituicao).subscribe(
        () => {
          alert("Salvo com Sucesso!!!")
          this.voltar();
        },
        err => {
          alert(err.error.toString());
        }
      )
    }
  }

  limparFormulario() {
    this.instituicao = { id: 0, nome: "", cnpj: "", telefone: "", endereco: "" };
  }

  /*   carregarDropdonw() {
      this.instituicaoEnsinoService.retornarTodasInstituicaoEnsino().subscribe(
        (response) => {
          return this.instituicoesDeEnsino.next(response);
        },
        (err) => {
          alert(err);
        }
      )
    } */

  voltar() {
    this.limparFormulario();
    this.exibeMenuNovo.emit(false);
  }
}
