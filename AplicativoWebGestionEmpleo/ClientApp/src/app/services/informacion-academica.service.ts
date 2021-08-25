import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { InformacionAcademica } from '../Empleo/models/informacion-academica';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InformacionAcademicaService {

  baseUrl: string;
  constructor( 
    private http:HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }

  
  post(indformacionAcademica : InformacionAcademica): Observable<InformacionAcademica>{
    return this.http.post<InformacionAcademica>(this.baseUrl + 'api/InformacionAcademica', indformacionAcademica)
    .pipe(
      tap(_ => console.log('Informacion Academica Registrada')),
        catchError(error =>{
          console.log("error al registrar")
          return of(indformacionAcademica)
      })
    );
  }

  get(id: number): Observable<InformacionAcademica[]>{
    return this.http.get<InformacionAcademica[]>(this.baseUrl + 'api/InformacionAcademica/'+id)
    .pipe(
      tap(_ => console.log('consultado')),
      catchError(error =>{
        console.log("error al consultar")
        return of(error as InformacionAcademica[])
      })
    );
  }

  put(id: Number, informacionAcademica : InformacionAcademica):Observable <InformacionAcademica> {
    id =informacionAcademica.informacionAcademicaId;
    return this.http.put<InformacionAcademica>(this.baseUrl +'api/InformacionAcademica/'+id, informacionAcademica).pipe(
      tap(_ => console.log('Datos Encontrado')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as InformacionAcademica)
      })
      );
  }


}
