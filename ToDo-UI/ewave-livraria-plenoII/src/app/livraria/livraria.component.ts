import { Component, Input, OnInit } from '@angular/core';
import { EmprestimoService } from 'app/emprestimos/emprestimo.service';
import { BehaviorSubject, interval } from 'rxjs';
import { Emprestimo } from 'app/emprestimos/emprestimo';
import * as moment from 'moment';

@Component({
    selector: 'todo-livraria',
    templateUrl: 'livraria.component.html'
})
export class LivrariaComponent implements OnInit {

    @Input() menuSelecionado: string;
    private emprestimos = new BehaviorSubject<Emprestimo>(null);

    constructor(private emprestimoService: EmprestimoService) {
    }

    ngOnInit(): void {
        this.carregarDados();
        interval(1000 * 5).subscribe(i => this.carregarDados())
    };

    receberValorMenu(valor) {
        this.menuSelecionado = valor;
    }

    carregarDados() {
        this.emprestimoService.retornarTodosEmprestimoAtivo().subscribe(
            (response) => this.emprestimos.next(response as Emprestimo)
        );
    }

    retornarStatusEmprestimo(emprestimo: Emprestimo) {
        var estaEmAtraso = moment().isAfter(emprestimo.dataPrevistaDevolucao);
        if (estaEmAtraso)
            return "alert-danger"
        return "alert-dark"
    }

}