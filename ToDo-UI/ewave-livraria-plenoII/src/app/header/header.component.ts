import { Component, OnInit } from '@angular/core';
import { User } from '../core/usuario/usuario';
import { UserService } from 'app/core/usuario/usuario.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
    selector: 'todo-header',
    templateUrl: './header.component.html'
})
export class HeaderComponent {
    user$: Observable<User>;

    constructor(
        private userService: UserService,
        private router: Router) {
        console.log(this.user$);
        this.user$ = userService.getUser();
    }

    logout() {
        this.userService.logout();
        this.router.navigate(['']);
    }

}