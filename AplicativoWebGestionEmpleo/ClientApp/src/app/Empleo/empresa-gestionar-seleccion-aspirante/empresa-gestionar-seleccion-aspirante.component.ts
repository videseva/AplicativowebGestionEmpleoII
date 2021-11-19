import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
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
    print(): void {
      let printContents, popupWin;
      printContents = document.getElementById('detalledehojavida').innerHTML;
      popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
      popupWin.document.open();
      popupWin.document.write(`
        <html>
          <head>
            <title>Hoja de vida -${this.aspirante.identificacion} - ${this.aspirante.nombres} ${this.aspirante.apellidos} </title>
            <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
            <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous">
            <style>
            #verhojavida p{
              font-size: 17px;
              color: #6f6f6f;
            }
            
            .img-centro{
              width: 30%;
              border-radius: 50%;
              margin: 5px auto 5px;
              display: block;
            }
            #verhojavida h5 i{
              color:  #2e55fa;
            }
            
            </style>
          </head>
      <body onload="window.print();window.close()">${printContents}</body>
        </html>`
      );
      popupWin.document.close();
  }
}
