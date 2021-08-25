import { Component } from '@angular/core';
import { Empresa } from '../Empleo/models/empresa';
import { Oferta } from '../Empleo/models/oferta';
import { OfertaService } from '../services/oferta.service';
import { PostulacionService } from 'src/app/services/postulacion.service';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'
import { Postulacion } from '../Empleo/models/postulacion';
import { Aspirante } from '../Empleo/models/aspirante';
import { AspiranteService } from '../services/aspirante.service';
import { EmpresaService } from '../services/empresa.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  ofertas: Oferta[];
  aspirantes : Aspirante[];
  empresas : Empresa[];
  oferta : Oferta;
  aspirante : Aspirante;
  contOfertas = 0;
  contAspirante =0;
  conEmpresa=0;
  searchText;
  usuario;
  postulacion : Postulacion;
  postulacionR : Postulacion;// variable utilizada para registrar una postulacion
  constructor(private ofertaService : OfertaService, private postulacionesService : PostulacionService,private aspiranteServices : AspiranteService,private empresaService: EmpresaService) { }

  ngOnInit(): void {
  
    this.get();
    this.oferta = new Oferta();
    this.oferta.empresa = new Empresa();
    this.postulacion = new Postulacion();
    this.getAspiranteLocalstorage();
  }
  getAspiranteLocalstorage(){
    this.usuario = JSON.parse(localStorage.getItem('usuario')); 
    this.aspirante = this.usuario
   console.log(this.aspirante);   
 }

  get(){
    this.ofertaService.GetOfertas().subscribe(result => {
      this.ofertas = result;
      this.contOfertas =this.ofertas.length;
      console.log(this.ofertas);

    });

    this.aspiranteServices.get().subscribe(result => {
      this.aspirantes = result;
      this.contAspirante =this.aspirantes.length;
      console.log(this.aspirantes);
    });

    this.empresaService.get().subscribe(result => {
      this.empresas = result;
      this.conEmpresa =this.empresas.length;
      console.log(this.empresas);
    });
  }
 
  verOferta(datos){
    this.oferta = datos;
    this.postulacion.usuarioId= this.aspirante.usuarioId;
    this.postulacion.ofertaId= this.oferta.ofertaId;
    this.get();
    console.log(this.oferta);
  }

  RegistrarOferta(){
    if (this.aspirante == null) {
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debes estar registrado para postularte',
      })
    } else {
      this.postulacion.usuarioId = this.usuario.usuarioId;
      this.postulacionesService.post(this.postulacion).subscribe(result => {
        var res = JSON.stringify(result);
        var respuesta = JSON.parse(res); 
        if(respuesta.ok == false){
          Swal.fire({
            icon: 'error',
            title: respuesta.error,
            showConfirmButton: false,
            timer: 1500,
          });
        }else{          
          Swal.fire({
            icon: 'success',
            title: 'Postulacion Registrada',
            showConfirmButton: false,
            timer: 1500,
          });
        }
      });
    }
  }
}