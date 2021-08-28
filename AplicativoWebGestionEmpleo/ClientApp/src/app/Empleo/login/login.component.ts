import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AspiranteService } from 'src/app/services/aspirante.service';
import { EmpresaService } from 'src/app/services/empresa.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Aspirante } from '../models/aspirante';
import { Empresa } from '../models/empresa';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidationErrors } from '@angular/forms';

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
  formGroup: FormGroup;
  constructor(private formBuilder: FormBuilder,private aspiranteServices : AspiranteService,private empresaService : EmpresaService,private router: Router) { }

  ngOnInit(): void {
    this.empresa = new Empresa();
    this.aspirante = new Aspirante();
    this.limpiarLocalstorage();
    this.buildForm();
  }
  verificacionUser(){
    if(this.tipoUsuario == "Aspirante" || this.tipoUsuario == 'Empresa'){
      this.buildForm();
    }

  }


  private buildForm(){
    if(this.tipoUsuario == "Aspirante"){
      this.aspirante = new Aspirante();
      this.aspirante.correo='';
      this.aspirante.contrasena='';

      this.formGroup = this.formBuilder.group({
        correo: [this.aspirante.correo, [Validators.required,Validators.maxLength(30),Validators.email]],
        contrasena: [this.aspirante.contrasena, [Validators.required,Validators.maxLength(8)]],
      });
    }else{
      this.empresa = new Empresa();
      this.empresa.correo = '';
      this.empresa.contrasena = '';
      this.formGroup = this.formBuilder.group({
        correo: [this.empresa.correo, [Validators.required, Validators.maxLength(30), Validators.email]],
        contrasena: [this.empresa.contrasena, [Validators.required, Validators.maxLength(8)]],
      });
    }

  }

  get control() { return this.formGroup.controls; }
  
  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    if (this.tipoUsuario == 'Aspirante') {
      this.aspirante = this.formGroup.value
      this.aspiranteServices.getlogin(this.aspirante.correo, this.aspirante.contrasena).subscribe(result => { 
        var res = JSON.stringify(result);
        var respuesta = JSON.parse(res);
        if (respuesta.ok == false) {
          Swal.fire({
            icon: 'error',
            title: respuesta.error,
            timer: 1500,
          });
        } else {
          this.aspirante = result;
          this.PostAspiranteLocalstorage();
          this.limpiarCampos();
          this.router.navigate(['/aspirantePerfil']);
        }
      });
    } else if(this.tipoUsuario == 'Empresa') {
      
      this.empresa = this.formGroup.value;
      console.log(this.empresa);
      this.empresaService.getlogin(this.empresa.correo, this.empresa.contrasena).subscribe(result => { 
        var res = JSON.stringify(result);
        var respuesta = JSON.parse(res);
        if (respuesta.ok == false) {
          Swal.fire({
            icon: 'error',
            title: respuesta.error,
            timer: 1500,
          });
        } else {
          this.empresa = result;
          this.PostEmpresaLocalstorage();
          this.limpiarCampos();
          this.router.navigate(['/empresaPerfil']);
        }
      });
    }
  }
  limpiarLocalstorage(){
    localStorage.clear();
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
/** 
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
 */
}
