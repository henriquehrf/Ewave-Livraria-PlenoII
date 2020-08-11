import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { User } from '../core/user/usuario';
import { UserService } from 'app/core/user/usuario.service';
import { Router } from '@angular/router';
import { Observable, BehaviorSubject } from 'rxjs';
import { EmprestimoService } from './emprestimo.service';

@Component({
    selector: 'todo-emprestimo',
    templateUrl: './emprestimo.component.html'
})
export class EmprestimoComponent implements OnInit {

    private emprestimos = new BehaviorSubject<any>(null);
    user$: Observable<User>;


    constructor(private emprestimoService: EmprestimoService, private userService: UserService) {
        this.user$ = userService.getUser();
    }
    ngOnInit(): void {
        this.buscarDados();
    }

    buscarDados() {
        this.user$.subscribe(
            (usuario) => {
                this.emprestimoService.retornarEmprestimosPorIdUsuario(usuario.id).subscribe(
                    (response) => {
                        this.emprestimos.next(response);
                    },
                    err => {
                        alert(err);
                    }
                )
            }
        )
    }

    devolver(emprestimo) {
        this.emprestimoService.devolverLivro(emprestimo).subscribe(
            (response) => {
               alert("Livro devolvido com sucesso!");
               this.buscarDados();
            },
            err => {
                alert(err);
            }
        )
    }
}

