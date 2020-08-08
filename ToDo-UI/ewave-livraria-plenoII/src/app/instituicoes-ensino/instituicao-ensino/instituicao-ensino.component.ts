import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { FormGroup, ReactiveFormsModule, FormControl } from '@angular/forms';
import { InstituicaoEnsinoService } from './instituicao-ensino.service';
import { Router } from '@angular/router';
import { InstituicaoEnsinoModule } from './instituicao-ensino.module';
import { InstituicaoEnsino } from './instituicao-ensino';

@Component({
  selector: 'todo-instituicao-ensino',
  templateUrl: './instituicao-ensino.component.html'
})
export class InstituicaoEnsinoComponent implements OnInit {

  @Input() instituicao: InstituicaoEnsino;
  @Output() exibeMenuNovo = new EventEmitter<boolean>();

  instituicaoForm: FormGroup;
  constructor(private instituicaoEnsinoService: InstituicaoEnsinoService) {
    this.novoFormulario();
  }

  ngOnInit(): void {
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
    const ehAlteracao = (this.instituicao != null);
    if (!ehAlteracao) {
      this.instituicaoEnsinoService.inserirInstituicaoEnsino(this.instituicaoForm.value).subscribe(
        () => {
          alert("Salvo com Sucesso!!!")
          this.voltar();
        },
        err => {
          alert(err.error.toString());
        }
      )
    } else {
      const inst = this.instituicaoForm.value;
      inst.id = this.instituicao.id;
      this.instituicaoEnsinoService.alterarInstituicaoEnsino(this.instituicaoForm.value).subscribe(
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

  limparFormulario(){
    this.instituicao = { id: 0, nome: "", cnpj: "", telefone: "", endereco: "" };
  }

  voltar() {
    this.limparFormulario();
    this.exibeMenuNovo.emit(false);
  }
}
