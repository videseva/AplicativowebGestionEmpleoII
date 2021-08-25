import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Empresa } from '../models/empresa';

@Component({
  selector: 'app-empresa-menu',
  templateUrl: './empresa-menu.component.html',
  styleUrls: ['./empresa-menu.component.css']
})
export class EmpresaMenuComponent implements OnInit {
  empresa : Empresa;
  razonSocial : string;
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.getEmpresaLocalstorage();
  }
  getEmpresaLocalstorage(){  
    this.razonSocial = localStorage.getItem('RazonSocial'); 
  }

  cerrarSesion(){
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
