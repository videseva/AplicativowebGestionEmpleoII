import { Pipe, PipeTransform } from '@angular/core';
import { Usuario } from '../Empleo/models/usuario';

@Pipe({
  name: 'filtroUsuario'
})
export class FiltroUsuarioPipe implements PipeTransform {

  transform(usuario: Usuario[], searchText: Number): any {
    if (searchText == null) return usuario;
   return usuario.filter(p => p.tipoUsuario == searchText);
    }
}
