import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AspiranteService } from 'src/app/services/aspirante.service';
import { EmpresaService } from 'src/app/services/empresa.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Aspirante } from '../models/aspirante';
import { Empresa } from '../models/empresa';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  correo : string;
  contrasena : string;
  tipoUsuario: string ="";
  empresa : Empresa;
  aspirante : Aspirante;
  constructor(private aspiranteServices : AspiranteService,private empresaService : EmpresaService,private router: Router) { }

  ngOnInit(): void {
    this.empresa = new Empresa();
    this.aspirante = new Aspirante();
    this.limpiarLocalstorage();
  }

  limpiarLocalstorage(){
    localStorage.clear();
  }

  login() {
    if (this.tipoUsuario == "Empresa") {
      this.empresaService.getlogin(this.correo, this.contrasena).subscribe(result => { 
        this.empresa = result;
        if (this.empresa.nit == null) {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'No estas registrado o contraseña incorrecta',
            showConfirmButton: false,
            timer: 1500,
          })
        } else {
          this.empresa = result;
          console.log(this.empresa)
          this.PostEmpresaLocalstorage();
          this.limpiarCampos();
          this.router.navigate(['/empresaPerfil']);
        }
      });
    }else if(this.tipoUsuario == "Aspirante"){
      this.aspiranteServices.getlogin(this.correo, this.contrasena).subscribe(result => { 
        if (result == null) {
          console.log("Datos incorrectos ")
        } else {
          this.aspirante = result;
          console.log(this.aspirante)
          this.  PostAspiranteLocalstorage();
          this.limpiarCampos();
          this.router.navigate(['/aspirantePerfil']);
        }
      });
    }
  }

  PostEmpresaLocalstorage(){
    localStorage.setItem('usuario',JSON.stringify(this.empresa));
    localStorage.setItem('RazonSocial',this.empresa.razonSocial);
  }

  PostAspiranteLocalstorage(){
    localStorage.setItem('usuario',JSON.stringify(this.aspirante));
    localStorage.setItem('nombreCompleto',this.aspirante.nombres);
  }
  limpiarCampos(){
    this.tipoUsuario = "";
    this.contrasena = "";
    this.correo = "";
  }
}
