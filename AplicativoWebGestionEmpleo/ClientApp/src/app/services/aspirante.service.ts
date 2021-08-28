import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Aspirante } from '../Empleo/models/aspirante';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AspiranteService {
  baseUrl: string;
  constructor( 
    private http:HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }

  post(aspirante : Aspirante): Observable<Aspirante>{
    return this.http.post<Aspirante>(this.baseUrl + 'api/Aspirante', aspirante)
    .pipe(
      tap(_ => console.log('Aspirante registrado')),
        catchError(error =>{
          console.log(error)
          return of(error)
      })
    );
  }

  get(): Observable <Aspirante[]>{
    return this.http.get<Aspirante[]>(this.baseUrl +'api/Aspirante/').pipe(
      tap(_ => console.log('Datos Encontrado')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as Aspirante[])
      })
      );
  }
  getId(id : Number): Observable <Aspirante>{
    return this.http.get<Aspirante>(this.baseUrl +'api/Aspirante/'+id).pipe(
      tap(_ => console.log('Datos Encontrado')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as Aspirante)
      })
      );
  }

  put(id: Number, aspirante : Aspirante):Observable <Aspirante> {
    id =aspirante.usuarioId;
    return this.http.put<Aspirante>(this.baseUrl +'api/Aspirante/'+id,aspirante).pipe(
      tap(_ => console.log('Datos Encontrado')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as Aspirante)
      })
      );
  }

  getlogin(correo : string, contrasena: string): Observable <Aspirante>{
    return this.http.get<Aspirante>(this.baseUrl +'api/Aspirante/correo/'+ correo +'/contrasena/'+ contrasena).pipe(
      tap(_ => console.log('Aspirante registrada')),
      catchError(error =>{
        console.log(error)
        return of(error)
      })
      );
    }
}
