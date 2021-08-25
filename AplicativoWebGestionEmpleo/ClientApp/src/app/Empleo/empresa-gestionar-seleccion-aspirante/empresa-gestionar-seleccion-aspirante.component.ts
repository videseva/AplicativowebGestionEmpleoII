import { Component, OnInit } from '@angular/core';
import { OfertaService } from 'src/app/services/oferta.service';
import { PostulacionService } from 'src/app/services/postulacion.service';
import { Aspirante } from '../models/aspirante';
import { Oferta } from '../models/oferta';
import { Postulacion } from '../models/postulacion';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'


@Component({
  selector: 'app-empresa-gestionar-seleccion-aspirante',
  templateUrl: './empresa-gestionar-seleccion-aspirante.component.html',
  styleUrls: ['./empresa-gestionar-seleccion-aspirante.component.css']
})
export class EmpresaGestionarSeleccionAspiranteComponent implements OnInit {
  ofertas: Oferta[];
  ofertasConPostulacion: Oferta;
  oferta : Oferta;
  postulacion : Postulacion;
  seleccionado;
  idOferta;
  usuario;
  aspirante : Aspirante;
  aspirantes: Aspirante[];
  postulaciones : Postulacion[];
  opcion :number;
  mensaje : string;

  constructor(private ofertaService : OfertaService, private postulacionService : PostulacionService) { }

  ngOnInit(): void {
    this.postulacion = new Postulacion();
    this.getEmpresaLocalstorage();
    this.get();
    this.oferta = new Oferta();
    this.aspirante =  new Aspirante();

  }

  getEmpresaLocalstorage(){
    this.usuario = JSON.parse(localStorage.getItem('usuario')); 
   console.log(this.usuario);   
 }
 
  get(){
    this.ofertaService.GetOferta(this.usuario.usuarioId).subscribe(result => {
      this.ofertas = result;
    });
  }
 
  getPostulaciones(){
    this.oferta.ofertaId = this.seleccionado;
    this.ofertaService.GetOfertaConPostulaciones(this.oferta.ofertaId).subscribe(result => {
      this.ofertasConPostulacion = result;
      console.log(this.ofertasConPostulacion);

    });
  }
  BuscarAspirante(){
    console.log(this.seleccionado);
    this.idOferta = this.seleccionado;
    this.getPostulaciones();
    this.getAspirantesPostulacion();
  }
   
  getAspirantesPostulacion(){
    this.oferta.ofertaId = this.seleccionado;
    this.postulacionService.getOfertaId(this.idOferta).subscribe(result => {
      this.postulaciones = result;    
      console.log(this.postulaciones);
    });
  }
  verAspirante(datos){
    this.aspirante= datos;
    console.log(this.aspirante);
  }
  
  seleccionAspirante(datos){
    this.postulacion = datos;
    this.opcion=2;
    this.postulacionService.putSeleccion(this.postulacion.postulacionId,this.opcion ,this.postulacion).subscribe(result => {
      this.postulacion = result;
      console.log("modifico");
      Swal.fire({
        icon: 'success',
        title: 'Aspirante seleccionado',
        showConfirmButton: false,
        timer: 1500,
      })
    });
    this.getAspirantesPostulacion();
    }

      
  cancelarAspirante(datos){
    this.postulacion = datos;
    this.opcion=3;
    this.postulacionService.putSeleccion(this.postulacion.postulacionId,this.opcion ,this.postulacion).subscribe(result => {
      this.postulacion = result;
      Swal.fire({
        icon: 'success',
        title: 'Aspirante Rechazado',
        showConfirmButton: false,
        timer: 1500,
      })
      console.log("modifico");
    });
    }

}
