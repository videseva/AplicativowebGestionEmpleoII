import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { InformacionAcademica } from '../Empleo/models/informacion-academica';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs';
import { InformacionLaboral } from '../Empleo/models/informacion-laboral';


@Injectable({
  providedIn: 'root'
})
export class InformacionLaboralService {
  baseUrl: string;
  constructor( 
    private http:HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }

  
  post(informacionLaboral : InformacionLaboral): Observable<InformacionLaboral>{
    return this.http.post<InformacionLaboral>(this.baseUrl + 'api/InformacionLaboral', informacionLaboral)
    .pipe(
      tap(_ => console.log('Informacion Laboral  Registrada')),
        catchError(error =>{
          console.log("error al registrar")
          return of(informacionLaboral)
      })
    );
  }

  get(id: number): Observable<InformacionLaboral[]>{
    return this.http.get<InformacionLaboral[]>(this.baseUrl + 'api/InformacionLaboral/'+id)
    .pipe(
      tap(_ => console.log('Informacion Laboral consultada')),
      catchError(error =>{
        console.log("error al consultar")
        return of(error as InformacionLaboral[])
      })
    );
  }

  put(id: Number, informacionLaboral : InformacionLaboral):Observable <InformacionLaboral> {
    
    id =informacionLaboral.informacionLaboralId;
    return this.http.put<InformacionLaboral>(this.baseUrl +'api/InformacionAcademica/'+id, informacionLaboral).pipe(
      tap(_ => console.log('Datos Encontrado')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as InformacionLaboral)
      })
      );
  }

}
