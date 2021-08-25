import { Component, OnInit } from '@angular/core';
import { AspiranteService } from 'src/app/services/aspirante.service';
import { addSyntheticTrailingComment, LeftHandSideExpression } from 'typescript';
import { Aspirante } from '../models/aspirante';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'

@Component({
  selector: 'app-aspirante-perfil',
  templateUrl: './aspirante-perfil.component.html',
  styleUrls: ['./aspirante-perfil.component.css']
})
export class AspirantePerfilComponent implements OnInit {

  nombreCompleto : string;
  aspirante : Aspirante;
  usuario;
  id :Number =0;
 

  constructor(private aspiranteServices : AspiranteService) { }

  ngOnInit(): void {
    this.aspirante = new Aspirante();
    this.getAspiranteLocalstorage();
    this.get();

  }

  getAspiranteLocalstorage(){
     this.usuario = JSON.parse(localStorage.getItem('usuario')); 
    console.log(this.usuario);   
  }

  get(){
    this.aspiranteServices.getId(this.usuario.usuarioId).subscribe(result => {
      this.aspirante = result;
    });
    console.log(this.aspirante);
  }

  actualizar(){
    this.aspiranteServices.put(this.aspirante.usuarioId ,this.aspirante).subscribe(result => {
      this.get();
      Swal.fire({
        icon: 'success',
        title: 'Perfil Actualizado',
        showConfirmButton: false,
        timer: 1500,
      })
    });
  }
}
