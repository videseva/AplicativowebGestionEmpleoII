import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
//import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PersonaConsultaComponent } from './Pulsacion/persona-consulta/persona-consulta.component';
import { AppRoutingModule } from './app-routing.module';
import { EmpresaConsultaComponent } from './Empleo/empresa-consulta/empresa-consulta.component';
import { EmpresaPerfilComponent } from './Empleo/empresa-perfil/empresa-perfil.component';
import { AspirantePerfilComponent } from './Empleo/aspirante-perfil/aspirante-perfil.component';
import { OfertaRegistrarComponent } from './Empleo/oferta-registrar/oferta-registrar.component';
import { AspiranteBuscarComponent } from './Empleo/aspirante-buscar/aspirante-buscar.component';
import { EmpresaBuscarComponent } from './Empleo/empresa-buscar/empresa-buscar.component';
import { OfertaGestionarComponent } from './Empleo/oferta-gestionar/oferta-gestionar.component';
import { AspiranteMiResumenComponent } from './Empleo/aspirante-mi-resumen/aspirante-mi-resumen.component';
import { AspiranteFormacionComponent } from './Empleo/Aspirante/aspirante-formacion/aspirante-formacion.component';
import { AspiranteExperienciaComponent } from './Empleo/Aspirante/aspirante-experiencia/aspirante-experiencia.component';
import { AspiranteHabilidadesComponent } from './Empleo/Aspirante/aspirante-habilidades/aspirante-habilidades.component';
import { AspiranteCambiarContrasenaComponent } from './Empleo/aspirante-cambiar-contrasena/aspirante-cambiar-contrasena.component';
import { AspiranteMenuComponent } from './Empleo/aspirante-menu/aspirante-menu.component';
import { AspiranteMisPostulacionesComponent } from './Empleo/aspirante-mis-postulaciones/aspirante-mis-postulaciones.component';
import { EmpresaCambiarContrasenaComponent } from './Empleo/empresa-cambiar-contrasena/empresa-cambiar-contrasena.component';
import { EmpresaMenuComponent } from './Empleo/empresa-menu/empresa-menu.component';
import { AspiranteRegistroComponent } from './Empleo/aspirante-registro/aspirante-registro.component';
import { EmpresaGestionarSeleccionAspiranteComponent } from './Empleo/empresa-gestionar-seleccion-aspirante/empresa-gestionar-seleccion-aspirante.component';
import { LoginComponent } from './Empleo/login/login.component';
import { AdministradorGestionarAspiranteComponent } from './Empleo/administrador-gestionar-aspirante/administrador-gestionar-aspirante.component';
import { AdministradorMenuComponent } from './Empleo/administrador-menu/administrador-menu.component';
import { AdministradorGestionarEmpresaComponent } from './Empleo/administrador-gestionar-empresa/administrador-gestionar-empresa.component';
import { AspiranteService } from './services/aspirante.service';
import { UsuarioService } from './services/usuario.service';
import { EmpresaService } from './services/empresa.service';
import { AdministradorConsultasComponent } from './Pagos/administrador-consultas/administrador-consultas.component';
import { FiltroUsuarioPipe } from './pipe/filtro-usuario.pipe';
import { FiltroOfertaCargoPipe } from './pipe/filtro-oferta-cargo.pipe';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PersonaConsultaComponent,
    EmpresaConsultaComponent,
    EmpresaPerfilComponent,
    AspirantePerfilComponent,
    OfertaRegistrarComponent,
    AspiranteBuscarComponent,
    EmpresaBuscarComponent,
    OfertaGestionarComponent,
    AspiranteMiResumenComponent,
    AspiranteFormacionComponent,
    AspiranteExperienciaComponent,
    AspiranteHabilidadesComponent,
    AspiranteCambiarContrasenaComponent,
    AspiranteMenuComponent,
    AspiranteMisPostulacionesComponent,
    EmpresaCambiarContrasenaComponent,
    EmpresaMenuComponent,
    AspiranteRegistroComponent,
    EmpresaGestionarSeleccionAspiranteComponent,
    LoginComponent,
    AdministradorGestionarAspiranteComponent,
    AdministradorMenuComponent,
    AdministradorGestionarEmpresaComponent,
    AdministradorConsultasComponent,
    FiltroUsuarioPipe,
    FiltroOfertaCargoPipe,
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent },
], { relativeLinkResolution: 'legacy' }),
    AppRoutingModule
  ],
  providers: [AspiranteService,UsuarioService, EmpresaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
