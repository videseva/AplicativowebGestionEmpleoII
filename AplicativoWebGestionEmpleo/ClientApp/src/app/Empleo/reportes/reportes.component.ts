import { Component, OnInit } from '@angular/core';
import { OfertaService } from 'src/app/services/oferta.service';
import { PostulacionService } from 'src/app/services/postulacion.service';
import { createSemanticDiagnosticsBuilderProgram } from 'typescript';
import { Aspirante } from '../models/aspirante';
import { Oferta } from '../models/oferta';
import { Postulacion } from '../models/postulacion';

@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.css']
})
export class ReportesComponent implements OnInit {

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
 date = new Date ().toLocaleString();
 cantOfertas;
 cantPostulanteOfertas2=1;
 cantPostulanteOfertas=1;
 ofertaId;




  constructor(private ofertaService : OfertaService, private postulacionService : PostulacionService) { }
  ngOnInit(): void {
    this.postulacion = new Postulacion();
    this.getEmpresaLocalstorage();
    this.getOfertas();
    this.oferta = new Oferta();
    this.aspirante =  new Aspirante();
    this.getCantidadOfertas();
    this.getAspirantesPostulacion('');
  }
  getEmpresaLocalstorage(){
    this.usuario = JSON.parse(localStorage.getItem('usuario')); 
   console.log(this.usuario);   
 }
 
  getOfertas(){
    this.ofertaService.GetOferta(this.usuario.usuarioId).subscribe(result => {
      this.ofertas = result;
    });
  }

 


  getAspirantesPostulacion(datos){
    this.ofertaId = datos;
    this.postulacionService.getOfertaId(this.idOferta).subscribe(result => {
      this.postulaciones = result;    
      this.cantPostulanteOfertas =  this.postulaciones.length;
    });
  }
  getCantidadOfertas(){
    this.ofertaService.GetOferta(this.usuario.usuarioId).subscribe(result => {
      this.ofertas = result;
      this.cantOfertas =this.ofertas.length;
    });
  }
  print(): void {
    let printContents, popupWin;
    printContents = document.getElementById('detallereportes').innerHTML;
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
