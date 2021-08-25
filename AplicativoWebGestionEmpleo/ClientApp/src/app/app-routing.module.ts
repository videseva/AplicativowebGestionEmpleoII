import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';


import { PersonaConsultaComponent } from './Pulsacion/persona-consulta/persona-consulta.component';
import { AspirantePerfilComponent } from './Empleo/aspirante-perfil/aspirante-perfil.component';
import { AspiranteBuscarComponent } from './Empleo/aspirante-buscar/aspirante-buscar.component';
import { EmpresaPerfilComponent } from './Empleo/empresa-perfil/empresa-perfil.component';
import { EmpresaBuscarComponent } from './Empleo/empresa-buscar/empresa-buscar.component';
import { OfertaRegistrarComponent } from './Empleo/oferta-registrar/oferta-registrar.component';
import { OfertaGestionarComponent } from './Empleo/oferta-gestionar/oferta-gestionar.component';
import { AspiranteMiResumenComponent } from './Empleo/aspirante-mi-resumen/aspirante-mi-resumen.component';
import { AspiranteFormacionComponent } from './Empleo/Aspirante/aspirante-formacion/aspirante-formacion.component';
import { AspiranteCambiarContrasenaComponent } from './Empleo/aspirante-cambiar-contrasena/aspirante-cambiar-contrasena.component';
import { AspiranteMenuComponent } from './Empleo/aspirante-menu/aspirante-menu.component';
import { AspiranteMisPostulacionesComponent } from './Empleo/aspirante-mis-postulaciones/aspirante-mis-postulaciones.component';
import { EmpresaMenuComponent } from './Empleo/empresa-menu/empresa-menu.component';
import { EmpresaCambiarContrasenaComponent } from './Empleo/empresa-cambiar-contrasena/empresa-cambiar-contrasena.component';
import { AspiranteRegistroComponent } from './Empleo/aspirante-registro/aspirante-registro.component';
import { EmpresaGestionarSeleccionAspiranteComponent } from './Empleo/empresa-gestionar-seleccion-aspirante/empresa-gestionar-seleccion-aspirante.component';
import { LoginComponent } from './Empleo/login/login.component';
import { AdministradorGestionarAspiranteComponent } from './Empleo/administrador-gestionar-aspirante/administrador-gestionar-aspirante.component';
import { AdministradorGestionarEmpresaComponent } from './Empleo/administrador-gestionar-empresa/administrador-gestionar-empresa.component';

const routes: Routes = [
  {
    path: 'personaConsulta',
    component: PersonaConsultaComponent
  },
  {
    path: 'gestionarAspirante',
    component: AdministradorGestionarAspiranteComponent
  },
  {
    path: 'gestionarEmpresa',
    component: AdministradorGestionarEmpresaComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'aspiranteMenu',
    component: AspiranteMenuComponent
  },
  {
    path: 'aspiranteMisPostulaciones',
    component: AspiranteMisPostulacionesComponent
  },
  {
    path: 'registro',
    component: AspiranteRegistroComponent
  },
  {
    path: 'aspiranteFormacion',
    component: AspiranteFormacionComponent 
  },
  {
    path: 'aspiranteCambiarContrasena',
    component: AspiranteCambiarContrasenaComponent
  },
  {
    path: 'aspirantePerfil',
    component: AspirantePerfilComponent
  },
  {
    path: 'aspiranteBuscar',
    component: AspiranteBuscarComponent
  },
  {
    path: 'aspiranteMiResumen',
    component: AspiranteMiResumenComponent
  },

  {
    path: 'empresaMenu',
    component: EmpresaMenuComponent
  },
  {
    path: 'empresaGestionarSeleccionAspirante',
    component: EmpresaGestionarSeleccionAspiranteComponent
  },
  {
    path: 'empresaCambiarContrasena',
    component: EmpresaCambiarContrasenaComponent
  },
  {
    path: 'empresaPerfil',
    component: EmpresaPerfilComponent
  },
  {
    path: 'empresaBuscar',
    component: EmpresaBuscarComponent
  },
  {
    path: 'ofertaRegistrar',
    component: OfertaRegistrarComponent
  },
  {
    path: 'ofertaGestionar',
    component: OfertaGestionarComponent
  },
];
  

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
