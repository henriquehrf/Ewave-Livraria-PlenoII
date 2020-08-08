import { Component, Input } from '@angular/core';

@Component({
    selector: 'todo-livraria',
    templateUrl: 'livraria.component.html'
})
export class LivrariaComponent {

    @Input() menuSelecionado: string;
    constructor(){
    }


    receberValorMenu(valor){
        this.menuSelecionado = valor;
    }
}