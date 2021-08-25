import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Aspirante } from '../models/aspirante';

@Component({
  selector: 'app-aspirante-menu',
  templateUrl: './aspirante-menu.component.html',
  styleUrls: ['./aspirante-menu.component.css']
})
export class AspiranteMenuComponent implements OnInit {
  aspirante : Aspirante;
  nombreCompleto : string;
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.getAspiranteLocalstorage();
  }

  getAspiranteLocalstorage(){  
    this.nombreCompleto = localStorage.getItem('nombreCompleto'); 
  }
  cerrarSesion(){
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
