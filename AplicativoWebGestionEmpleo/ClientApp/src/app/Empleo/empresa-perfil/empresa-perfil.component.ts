import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmpresaService } from 'src/app/services/empresa.service';
import { Empresa } from '../models/empresa';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'

@Component({
  selector: 'app-empresa-perfil',
  templateUrl: './empresa-perfil.component.html',
  styleUrls: ['./empresa-perfil.component.css']
})
export class EmpresaPerfilComponent implements OnInit {

  nombreCompleto: string;
  empresa: Empresa;
  usuario;
  id: Number = 0;
  constructor(private empresaService: EmpresaService,private router: Router) { }

  ngOnInit(): void {
    this.empresa = new Empresa();
    this.getEmpresaLocalstorage();
    this.get();
  }

  getEmpresaLocalstorage() {
    this.usuario = JSON.parse(localStorage.getItem('usuario'));
    this.empresa = this.usuario;
    console.log(this.usuario);
  }

  get(){
    this.empresaService.getId(this.empresa.nit).subscribe(result => {
      this.empresa = result;
    });
    console.log(this.empresa);
  }
  
  actualizar() {
    this.empresaService.put(this.empresa.usuarioId, this.empresa).subscribe(result => {
      Swal.fire({
        icon: 'success',
        title: 'Actualizado Perfil',
        showConfirmButton: false,
        timer: 1500,
      })
    });
  }

}
