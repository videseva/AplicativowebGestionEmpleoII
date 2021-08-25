import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Oferta } from '../Empleo/models/oferta';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs';
import { Postulacion } from '../Empleo/models/postulacion';

@Injectable({
  providedIn: 'root'
})
export class PostulacionService {
  baseUrl: string;

  mensaje ="error al registrar";
  constructor( 
    private http:HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }

  post(postulacion : Postulacion): Observable<Postulacion>{
    return this.http.post<Postulacion>(this.baseUrl + 'api/Postulacion', postulacion)
    .pipe(
      tap(_ => console.log('Postulacion registrada')),
        catchError(error =>{
          console.log(error)
          return of(error);
      })
    );
  }

  getId(id: number): Observable<Postulacion[]>{
    return this.http.get<Postulacion[]>(this.baseUrl + 'api/Postulacion/'+id)
    .pipe(
      tap(_ => console.log('consultado')),
      catchError(error =>{
        console.log("error al consultar")
        return of(error as Postulacion[])
      })
    );
  }

  getOfertaId(id: number): Observable<Postulacion[]>{
    return this.http.get<Postulacion[]>(this.baseUrl + 'api/Postulacion/PorOferta/'+id)
    .pipe(
      tap(_ => console.log('consultado')),
      catchError(error =>{
        console.log("error al consultar")
        return of(error as Postulacion[])
      })
    );
  }
  
  put(id: Number, postulacion : Postulacion):Observable <Postulacion> {
    id = postulacion.postulacionId;
    return this.http.put<Postulacion>(this.baseUrl +'api/Postulacion/'+id, postulacion).pipe(
      tap(_ => console.log('Datos Encontrado')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as Postulacion)
      })
    );
  }
  putSeleccion(id: Number,opcion:Number ,postulacion : Postulacion):Observable <Postulacion> {
    id = postulacion.postulacionId;
    return this.http.put<Postulacion>(this.baseUrl +'api/Postulacion/postulacion/'+id+"/opcion/"+opcion, postulacion).pipe(
      tap(_ => console.log('Datos Encontrado')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as Postulacion)
      })
    );
  }
}
