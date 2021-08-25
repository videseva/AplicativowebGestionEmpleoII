import { Component, OnInit } from '@angular/core';
import { OfertaService } from 'src/app/services/oferta.service';
import { Empresa } from '../models/empresa';
import { Oferta } from '../models/oferta';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'

@Component({
  selector: 'app-oferta-registrar',
  templateUrl: './oferta-registrar.component.html',
  styleUrls: ['./oferta-registrar.component.css']
})
export class OfertaRegistrarComponent implements OnInit {

  empresa : Empresa;
  oferta : Oferta;
  usuario;
  id :Number =0;
  constructor(private ofertaService : OfertaService) { }

  ngOnInit(): void {
    this.oferta = new Oferta();
    this.getEmpresaLocalstorage();
    this.oferta.empresa = new Empresa();
  }

  getEmpresaLocalstorage(){
    this.usuario = JSON.parse(localStorage.getItem('usuario'));  
    this.oferta.empresa = this.usuario;
 }

 RegistrarOferta(){
    this.oferta.usuarioId = this.usuario.usuarioId;
    console.log(this.oferta.usuarioId);
    this.ofertaService.post(this.oferta).subscribe(result => {
      if(result != null){
        this.oferta = result;
        Swal.fire({
          icon: 'success',
          title: 'Oferta Registrada',
          showConfirmButton: false,
          timer: 1500,
        })
      }
    });

   
  }

}