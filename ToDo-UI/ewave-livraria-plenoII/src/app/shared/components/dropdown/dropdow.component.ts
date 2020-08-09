import { Component, OnInit, Input, Output } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Dropdown } from './dropdown';

@Component({
  selector: 'todo-dropdown',
  templateUrl: './dropdown.component.html'
})
export class DropdrowComponent implements OnInit {

  @Input() dados: BehaviorSubject<Dropdown>;
  @Output() valorSelecionado: string

  constructor() { }

  ngOnInit(): void {
  }

  onChange(valor) {
    this.valorSelecionado = valor;
  }

}
