import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Aspirante } from '../models/aspirante';
import { Empresa } from '../models/empresa';
import { Usuario } from '../models/usuario';

@Component({
  selector: 'app-administrador-gestionar-aspirante',
  templateUrl: './administrador-gestionar-aspirante.component.html',
  styleUrls: ['./administrador-gestionar-aspirante.component.css']
})
export class AdministradorGestionarAspiranteComponent implements OnInit {
  nombreCompleto : string;
  usuarios : Usuario[];
  usuario2 : Usuario;
  empresa : Empresa;
  aspirante : Aspirante;
  id :Number =0;
  searchText;
 

  constructor(private usuariosService : UsuarioService) { }

  ngOnInit(): void {
    this.usuario2 = new Usuario();
    this.get();

  }

  get(){
    this.usuariosService.Get().subscribe(result => {
      this.usuarios = result;
    });
    console.log(this.usuarios);
  }


  }
