import { Pipe, PipeTransform } from '@angular/core';
import { Oferta } from '../Empleo/models/oferta';
import { Usuario } from '../Empleo/models/usuario';

@Pipe({
  name: 'filtroOfertaCargo'
})
export class FiltroOfertaCargoPipe implements PipeTransform {

  transform(oferta: Oferta[], searchText: string): any {
    if (searchText == null) return oferta;
   return oferta.filter(p =>
   p.cargo.toLowerCase()
  .indexOf(searchText.toLowerCase()) !== -1);
    }
}
