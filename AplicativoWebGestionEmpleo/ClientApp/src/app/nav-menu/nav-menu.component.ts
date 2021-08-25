import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  usuario;
  tipoUsuario;
  isExpanded = false;

  ngOnInit(): void {
    this.getUsuario();

  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  getUsuario(){
    this.usuario = JSON.parse(localStorage.getItem('usuario')); 
    console.log(this.usuario);   
    this.tipoUsuario = this.usuario.tipoUsuario;
    console.log(this.tipoUsuario);
  }

}


