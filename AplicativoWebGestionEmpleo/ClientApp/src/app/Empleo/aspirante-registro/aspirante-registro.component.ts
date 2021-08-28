import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AspiranteService } from 'src/app/services/aspirante.service';
import { EmpresaService } from 'src/app/services/empresa.service';
import { resolveTypeReferenceDirective } from 'typescript';
import { Aspirante } from '../models/aspirante';
import { Empresa } from '../models/empresa';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'



@Component({
  selector: 'app-aspirante-registro',
  templateUrl: './aspirante-registro.component.html',
  styleUrls: ['./aspirante-registro.component.css']
})
export class AspiranteRegistroComponent implements OnInit {

    formGroup: FormGroup;
    tipoUsuario2:string
    identificacion : Number;
    nombres : string;
    apellidos: string;
    contrasena : string;
    nit : Number;
    razonSocial : string;
    correo : string;
    aspirante : Aspirante;
    empresa : Empresa;
    emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";

  constructor(private formBuilder: FormBuilder,private aspiranteServices : AspiranteService, private  empresaServices : EmpresaService, private router: Router) { 

  }
  ngOnInit(): void {
    this.buildForm();
    this.tipoUsuario2="";
    this.limpiarLocalstorage();
    this.aspirante = new Aspirante();
    this.empresa = new Empresa();
  }

  limpiarLocalstorage(){
    localStorage.clear();
  }

  verificacionUser(){
    if(this.tipoUsuario2 == "Aspirante" || this.tipoUsuario2 == 'Empresa'){
      this.buildForm();
    }

  }


  private buildForm(){
    if(this.tipoUsuario2 == "Aspirante"){
      this.aspirante = new Aspirante();
      this.aspirante.identificacion =0;
      this.aspirante.nombres ='';
      this.aspirante.apellidos='';
      this.aspirante.correo='';
      this.aspirante.contrasena='';

      this.formGroup = this.formBuilder.group({
        identificacion: [this.aspirante.identificacion,[Validators.required, Validators.max(999999999999),Validators.min(1)]],
        nombres: [this.aspirante.nombres, [Validators.required,Validators.minLength(3)]],
        apellidos: [this.aspirante.apellidos, [Validators.required,Validators.minLength(3)]],
        correo: [this.aspirante.correo, [Validators.required,Validators.maxLength(30),Validators.email]],
        contrasena: [this.aspirante.contrasena, [Validators.required,Validators.maxLength(8)]],
      });
    }else{
      this.empresa = new Empresa();
      this.empresa.nit = 0;
      this.empresa.razonSocial = '';
      this.empresa.correo = '';
      this.empresa.contrasena = '';
      this.formGroup = this.formBuilder.group({
        nit: [this.empresa.nit, [Validators.required, Validators.min(999999999)]],
        razonSocial: [this.empresa.razonSocial, [Validators.required, Validators.minLength(3)]],
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
    if (this.tipoUsuario2 == 'Aspirante') {
      this.aspirante = this.formGroup.value;
      console.log(this.aspirante);
      this.aspiranteServices.post(this.aspirante).subscribe(p => {
        var res = JSON.stringify(p);
        var respuesta = JSON.parse(res);
        if (respuesta.ok == false) {
          Swal.fire({
            icon: 'error',
            title: respuesta.error,
            showConfirmButton: false,
            timer: 1500,
          });
        } else {
          Swal.fire({
            icon: 'success',
            title: 'Aspirante Registrado',
            showConfirmButton: false,
            timer: 1500,
          });

          this.PostAspiranteLocalstorage();
          this.router.navigate(['/aspirantePerfil']);
        }
      });
    } else if(this.tipoUsuario2 == 'Empresa') {
      
      this.empresa = this.formGroup.value;
      console.log(this.empresa);

      this.empresaServices.post(this.empresa).subscribe(p => {
        var res = JSON.stringify(p);
        var respuesta = JSON.parse(res);
        if (respuesta.ok == false) {
          Swal.fire({
            icon: 'error',
            title: respuesta.error,
            showConfirmButton: false,
            timer: 1500,
          });
        } else {
          Swal.fire({
            icon: 'success',
            title: 'Empresa Registrada',
            showConfirmButton: false,
            timer: 1500,
          });
          this.PostEmpresaLocalstorage();
          this.router.navigate(['/empresaPerfil']);
        }
        });
    }
  }
  PostAspiranteLocalstorage(){
    localStorage.setItem('usuario',JSON.stringify(this.aspirante));
    console.log(this.aspirante);
    localStorage.setItem('NombreAspirante',(this.aspirante.nombres+" "+this.aspirante.apellidos));
  }
    PostEmpresaLocalstorage(){
    localStorage.setItem('usuario',JSON.stringify(this.empresa));
    localStorage.setItem('RazonSocial',this.empresa.razonSocial);
  }



}




