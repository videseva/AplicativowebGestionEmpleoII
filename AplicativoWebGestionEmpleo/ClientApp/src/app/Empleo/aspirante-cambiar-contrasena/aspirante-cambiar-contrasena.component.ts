import { Component, OnInit } from '@angular/core';
import { Aspirante } from '../models/aspirante';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'
import { AspiranteService } from 'src/app/services/aspirante.service';

@Component({
  selector: 'app-aspirante-cambiar-contrasena',
  templateUrl: './aspirante-cambiar-contrasena.component.html',
  styleUrls: ['./aspirante-cambiar-contrasena.component.css']
})
export class AspiranteCambiarContrasenaComponent implements OnInit {
  contrasena : string;
  contrasenaValidad : string;
  aspirante : Aspirante;
  usuario
  constructor(private aspiranteServices : AspiranteService) { }

  ngOnInit(): void {
    this.aspirante = new Aspirante();
    this.getAspiranteLocalstorage();
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

  getAspiranteLocalstorage() {
    this.usuario = JSON.parse(localStorage.getItem('usuario'));
    this.aspirante = this.usuario;
    console.log(this.usuario);
  }

  actualizarContrasena(){
    this.aspirante.contrasena = this.contrasenaValidad;
    this.aspiranteServices.put(this.aspirante.usuarioId, this.aspirante).subscribe(result => {
    });
  }

  limpiarCampos(){
    this.contrasena =" ";
    this.contrasenaValidad =" ";
  }
}
