import { Component, OnInit } from '@angular/core';
import { OfertaService } from 'src/app/services/oferta.service';
import { Empresa } from '../models/empresa';
import { Oferta } from '../models/oferta';

import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'


@Component({
  selector: 'app-oferta-gestionar',
  templateUrl: './oferta-gestionar.component.html',
  styleUrls: ['./oferta-gestionar.component.css']
})
export class OfertaGestionarComponent implements OnInit {
  ofertas: Oferta[];
  oferta : Oferta;
  empresa : Empresa;
  searchText : string;
  totalOfertas;
  usuario;
  constructor(private ofertaService : OfertaService) { }

  ngOnInit(): void {

    this.getEmpresaLocalstorage();
    this.get();
    this.oferta = new Oferta();
    this.oferta.empresa = new Empresa();

  }

  getEmpresaLocalstorage(){
    this.usuario = JSON.parse(localStorage.getItem('usuario')); 
   console.log(this.usuario);  
 }
 
  get(){
    this.ofertaService.GetOferta(this.usuario.usuarioId).subscribe(result => {
      this.ofertas = result;
      this.totalOfertas =this.ofertas.length;
    });
  }
 
  verOferta(datos){
    this.oferta = datos;
    console.log(this.oferta);
  }

  alertConfirmation(datos){
    Swal.fire({
      title: '¿Está seguro?',
      text: "¡No podrás revertir esto!",
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

  ActualizarOferta(datos){
    this.oferta = datos;
    
  }
  eliminar(datos){
    this.oferta= datos;
    this.ofertaService.put(this.oferta.ofertaId ,this.oferta).subscribe(result => {
      this.get();
    });
  }
}
