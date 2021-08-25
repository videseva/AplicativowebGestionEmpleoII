import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AspiranteService } from 'src/app/services/aspirante.service';
import { EmpresaService } from 'src/app/services/empresa.service';
import { resolveTypeReferenceDirective } from 'typescript';
import { Aspirante } from '../models/aspirante';
import { Empresa } from '../models/empresa';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'


@Component({
  selector: 'app-aspirante-registro',
  templateUrl: './aspirante-registro.component.html',
  styleUrls: ['./aspirante-registro.component.css']
})
export class AspiranteRegistroComponent implements OnInit {
   
  tipoUsuario:string = "";
    identificacion : Number;
    nombres : string;
    apellidos: string;
    contrasena : string;
    nit : Number;
    razonSocial : string;
    correo : string;
    aspirante : Aspirante;
    empresa : Empresa;

  constructor(private aspiranteServices : AspiranteService, private  empresaServices : EmpresaService, private router: Router) { 

  }
  ngOnInit(): void {
    this.limpiarLocalstorage();
    this.aspirante = new Aspirante();
    this.empresa = new Empresa();
  }

  limpiarLocalstorage(){
    localStorage.clear();
  }

  RegistrarUsuario(){
    if(this.tipoUsuario == "Aspirante"){
      this.aspirante.identificacion = this.identificacion;
      this.aspirante.nombres = this.nombres;
      this.aspirante.apellidos =this.apellidos;
      this.aspirante.correo = this.correo;
      this.aspirante.contrasena = this.contrasena;
      
      this.aspiranteServices.post(this.aspirante).subscribe(p => {
        this.aspirante = p;   
        if(this.aspirante.identificacion != null){
          Swal.fire({
            icon: 'success',
            title: 'Aspirante registrado',
            showConfirmButton: false,
            timer: 1500,
          });

          this.PostAspiranteLocalstorage();
          this.limpiarCampos(); 
          this.router.navigate(['/aspirantePerfil']);
        }
      });
    }else{

    this.empresa.nit = this.nit;
    this.empresa.razonSocial = this.razonSocial;
    this.empresa.correo = this.correo;
    this.empresa.contrasena = this.contrasena;
    
    this.empresaServices.post(this.empresa).subscribe(p => {
      this.empresa = p; 
      console.log(this.empresa);
      if(this.empresa.razonSocial != null){
        Swal.fire({
          icon: 'success',
          title: 'Empresa registrada',
          showConfirmButton: false,
          timer: 1500,
        });
        this.PostEmpresaLocalstorage();
        this.limpiarCampos(); 
        this.router.navigate(['/empresaPerfil']);
      }else{
        
      }
    });
    }
  
  }

  limpiarCampos(){
    this.tipoUsuario = "";
    this.identificacion = null;
    this.nombres  = "";
    this.apellidos  = "";
    this.contrasena = "";
    this.nit  = null;
    this.razonSocial  = "";
    this.correo = "";
  }

  PostAspiranteLocalstorage(){
    localStorage.setItem('usuario',JSON.stringify(this.aspirante));
    localStorage.setItem('NombreAspirante',(this.aspirante.nombres+" "+this.aspirante.apellidos));
  }

  PostEmpresaLocalstorage(){
    localStorage.setItem('usuario',JSON.stringify(this.empresa));
    localStorage.setItem('RazonSocial',this.empresa.razonSocial);
  }
}
