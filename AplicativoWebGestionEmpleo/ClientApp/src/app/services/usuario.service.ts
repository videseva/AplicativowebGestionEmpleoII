import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs';
import { Usuario } from '../Empleo/models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl;
  }

  Get(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.baseUrl + 'api/Usuario')
      .pipe(
        tap(_ => console.log('Usuario Encontradas')),
        catchError(error => {
          console.log("error al consultar")
          return of(error as Usuario[])
        })
      );
  }

}