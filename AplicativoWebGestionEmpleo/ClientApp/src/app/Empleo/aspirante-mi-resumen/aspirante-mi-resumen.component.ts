import { Component, OnInit } from '@angular/core';
import { InformacionAcademicaService } from 'src/app/services/informacion-academica.service';
import { InformacionLaboralService } from 'src/app/services/informacion-laboral.service';
import { Aspirante } from '../models/aspirante';
import { InformacionAcademica } from '../models/informacion-academica';
import { InformacionLaboral } from '../models/informacion-laboral';
import Swal from 'sweetalert2/dist/sweetalert2.js'
import 'sweetalert2/src/sweetalert2.scss'

@Component({
  selector: 'app-aspirante-mi-resumen',
  templateUrl: './aspirante-mi-resumen.component.html',
  styleUrls: ['./aspirante-mi-resumen.component.css']
})
export class AspiranteMiResumenComponent implements OnInit {
  informacionAcademica: InformacionAcademica;
  listadoInformacionAcademica: InformacionAcademica[];
  informacionLaboral: InformacionLaboral;
  listadoInformacionLaboral: InformacionLaboral[];
  aspirante: Aspirante;
  usuario;

  constructor(private informacionAcademicaService: InformacionAcademicaService, private informacionLaboralService : InformacionLaboralService) { }

  ngOnInit(): void {
    this.informacionAcademica = new InformacionAcademica();
    this.informacionLaboral = new InformacionLaboral();
    this.getAspiranteLocalstorage();
    this.getInformacionAcdemica();
    this.getInformacionLabora();
  }

  getAspiranteLocalstorage() {
    this.usuario = JSON.parse(localStorage.getItem('usuario'));
  }



  registrarInformacionAcademica() {
    if (this.informacionAcademica.informacionAcademicaId == null) {
      this.informacionAcademica.usuarioId = this.usuario.usuarioId;
      console.log(this.informacionAcademica.usuarioId);
      this.informacionAcademicaService.post(this.informacionAcademica).subscribe(result => {
        if (result != null) {
          this.informacionAcademica = new InformacionAcademica();
          this.getInformacionAcdemica();
          Swal.fire({
            icon: 'success',
            title: 'Informacion Academica Registrada',
            showConfirmButton: false,
            timer: 1500,
          })
        }
      });
    } else {
      this.informacionAcademicaService.put(this.informacionAcademica.informacionAcademicaId, this.informacionAcademica).subscribe(result => {
        Swal.fire({
          icon: 'success',
          title: 'Informacion Academica Actualizada',
          showConfirmButton: false,
          timer: 1500,
        })
      });
    }

  }

  getInformacionAcdemica() {
    this.informacionAcademicaService.get(this.usuario.usuarioId).subscribe(result => {
      this.listadoInformacionAcademica = result;
    });
  }

  verInformacionAcademica(datos) {
    this.informacionAcademica = datos;
    console.log(this.informacionAcademica);
  }

  limpiarinformaiconAcademica() {
    this.informacionAcademica = new InformacionAcademica();
  }

  regitrarInformacionLaboral() {

    if (this.informacionLaboral.informacionLaboralId == null) {

      this.informacionLaboral.usuarioId = this.usuario.usuarioId;

      console.log(this.informacionLaboral.usuarioId );
      this.informacionLaboralService.post(this.informacionLaboral).subscribe(result => {
        if (result != null) {
          this.informacionLaboral = new InformacionLaboral();
          this.getInformacionLabora();
          Swal.fire({
            icon: 'success',
            title: 'Informacion Laboral Regsitrada',
            showConfirmButton: false,
            timer: 1500,
          })
        }
      });
    } else {
      this.informacionLaboralService.put(this.informacionLaboral.informacionLaboralId, this.informacionLaboral).subscribe(result => {
        Swal.fire({
          icon: 'success',
          title: 'Informacion Laboral Actualizada',
          showConfirmButton: false,
          timer: 1500,
        })
      });
    }
  }

  getInformacionLabora(){
    this.informacionLaboralService.get(this.usuario.usuarioId).subscribe(result => {
      this.listadoInformacionLaboral = result;
    });
  }

  verInformacionLaboral(datos) {
    this.informacionLaboral = datos;
    console.log(this.informacionLaboral);
  }
}
