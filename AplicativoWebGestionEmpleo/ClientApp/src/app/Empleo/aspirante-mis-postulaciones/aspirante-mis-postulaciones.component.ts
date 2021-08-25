import { Component, OnInit } from '@angular/core';
import { PostulacionService } from 'src/app/services/postulacion.service';
import { Aspirante } from '../models/aspirante';
import { Postulacion } from '../models/postulacion';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'
import { Oferta } from '../models/oferta';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { ThisReceiver } from '@angular/compiler';
import { OfertaService } from 'src/app/services/oferta.service';

@Component({
  selector: 'app-aspirante-mis-postulaciones',
  templateUrl: './aspirante-mis-postulaciones.component.html',
  styleUrls: ['./aspirante-mis-postulaciones.component.css']
})
export class AspiranteMisPostulacionesComponent implements OnInit {
  nombreCompleto: string;
  postulacion: Postulacion;
  postulacionModal : Postulacion;
  postulacionC: Postulacion;
  postulaciones: Postulacion[];
  aspirante: Aspirante;
  oferta: Oferta;
  ofertaId;
  usuario;
  datos;
  id: Number = 0;
  constructor(private postulacionesService: PostulacionService,private ofertaService : OfertaService) { }

  ngOnInit(): void {
    this.aspirante = new Aspirante;
    this.oferta = new Oferta;
    this.postulacion = new Postulacion();
    this.getAspiranteLocalstorage();
    this.get();
    this.verPostulacion(this.postulacion);
  
  }

  getAspiranteLocalstorage() {
    this.usuario = JSON.parse(localStorage.getItem('usuario'));
    console.log(this.usuario);
  }
  
  get(){
    this.postulacionesService.getId(this.usuario.usuarioId).subscribe(result => {
      this.postulaciones = result;
    });
  }

  verPostulacion(datos) {
    this.postulacion = datos;
  }
  
  verOferta(datos){
    console.log(datos);
    this.postulacionModal= datos;
    this.oferta = this.postulacionModal.oferta;
    console.log(this.oferta);

  }

  alertConfirmation(datos) {
    Swal.fire({
      title: '¿Está seguro?',
      text: "¡Desea cancelar tu postulacion a esta oferta!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, Eliminalo!'
    }).then((result) => {
      if (result.isConfirmed) {
        Swal.fire(
          this.eliminar(datos),
          'Eliminado!',
        )
      }
    })
  }
  
  eliminar(datos) {
    this.postulacion = datos;
    this.postulacionesService.put(this.postulacion.postulacionId, this.postulacion).subscribe(result => {
      this.get();
    });
  }
}
