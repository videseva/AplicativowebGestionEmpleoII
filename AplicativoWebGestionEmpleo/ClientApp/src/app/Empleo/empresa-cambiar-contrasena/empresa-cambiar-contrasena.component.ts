import { Component, OnInit } from '@angular/core';
import { EmpresaService } from 'src/app/services/empresa.service';
import { Empresa } from '../models/empresa';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'

@Component({
  selector: 'app-empresa-cambiar-contrasena',
  templateUrl: './empresa-cambiar-contrasena.component.html',
  styleUrls: ['./empresa-cambiar-contrasena.component.css']
})
export class EmpresaCambiarContrasenaComponent implements OnInit {
contrasena : string;
contrasenaValidad : string;
empresa : Empresa;
usuario
  constructor(private empresaService : EmpresaService) { }

  ngOnInit(): void {
    this.empresa = new Empresa();
    this.getEmpresaLocalstorage();
  }

  validarContrasena(){
    if(this.contrasena == this.contrasenaValidad){
      this.actualizarContrasena();
      this.limpiarCampos();
      Swal.fire({
        icon: 'success',
        title: 'Contraseña Actualizada',
        showConfirmButton: false,
        timer: 1500,
      })
    }else{
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Contraseña no coincide',
      })
    }
  }

  getEmpresaLocalstorage() {
    this.usuario = JSON.parse(localStorage.getItem('usuario'));
    this.empresa = this.usuario;
    console.log(this.usuario);
  }

  actualizarContrasena(){
    this.empresa.contrasena = this.contrasenaValidad;
    this.empresaService.put(this.empresa.usuarioId, this.empresa).subscribe(result => {
    });
  }

  limpiarCampos(){
    this.contrasena =" ";
    this.contrasenaValidad =" ";
  }
}
