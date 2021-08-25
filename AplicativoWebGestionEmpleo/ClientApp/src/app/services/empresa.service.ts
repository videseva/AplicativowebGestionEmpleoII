import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Empresa } from '../Empleo/models/empresa';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpresaService {
  baseUrl: string;
  constructor( 
    private http:HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }

  post(empresa : Empresa): Observable<Empresa>{
    return this.http.post<Empresa>(this.baseUrl + 'api/Empresa', empresa)
    .pipe(
      tap(_ => console.log('registrado')),
        catchError(error =>{
          console.log("error al registrar")
          return of(empresa)
      })
    );
  }

  get(): Observable <Empresa[]>{
    return this.http.get<Empresa[]>(this.baseUrl +'api/Empresa/').pipe(
      tap(_ => console.log('Datos Encontrado')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as Empresa[])
      })
      );
  }

  getId(id : Number): Observable <Empresa>{
    return this.http.get<Empresa>(this.baseUrl +'api/Empresa/'+id).pipe(
      tap(_ => console.log('Datos Encontrado')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as Empresa)
      })
      );
  }

  put(id: Number, empresa : Empresa):Observable <Empresa> {
    id =empresa.usuarioId;
    return this.http.put<Empresa>(this.baseUrl +'api/Empresa/'+id, empresa).pipe(
      tap(_ => console.log('Datos Encontrado')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as Empresa)
      })
      );
  }

  getlogin(correo : string, contrasena: string): Observable <Empresa>{
    return this.http.get<Empresa>(this.baseUrl +'api/Empresa/correo/'+ correo +'/contrasena/'+ contrasena).pipe(
      tap(_ => console.log('Empresa registrada')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as Empresa)
      })
      );
    }
}