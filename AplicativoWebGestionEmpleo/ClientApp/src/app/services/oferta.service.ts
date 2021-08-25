import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Oferta } from '../Empleo/models/oferta';
import { tap, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class OfertaService {
  baseUrl: string;
  constructor( 
    private http:HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }

  post(oferta : Oferta): Observable<Oferta>{
    return this.http.post<Oferta>(this.baseUrl + 'api/Oferta', oferta)
    .pipe(
      tap(_ => console.log('registrado')),
        catchError(error =>{
          console.log("error al registrar")
          return of(oferta)
      })
    );
  }

  
  GetOferta(id: number): Observable<Oferta[]>{
    return this.http.get<Oferta[]>(this.baseUrl + 'api/Oferta/'+id)
    .pipe(
      tap(_ => console.log('consultado')),
      catchError(error =>{
        console.log("error al consultar")
        return of(error as Oferta[])
      })
    );
  }

  GetOfertas(): Observable<Oferta[]>{
    return this.http.get<Oferta[]>(this.baseUrl + 'api/Oferta')
    .pipe(
      tap(_ => console.log('Ofertas Encontradas')),
      catchError(error =>{
        console.log("error al consultar")
        return of(error as Oferta[])
      })
    );
  }

  GetOfertaConPostulaciones(id: Number): Observable<Oferta>{
    return this.http.get<Oferta>(this.baseUrl + 'api/Oferta/'+ id +'/Postulaciones')
    .pipe(
      tap(_ => console.log('consultado')),
      catchError(error =>{
        console.log("error al consultar")
        return of(error as Oferta)
      })
    );
  }

  put(id: Number, oferta : Oferta):Observable <Oferta> {
    id = oferta.ofertaId;
    return this.http.put<Oferta>(this.baseUrl +'api/Oferta/'+id, oferta).pipe(
      tap(_ => console.log('Datos Encontrado')),
      catchError(error =>{
        console.log("error al buscar")
        return of(error as Oferta)
      })
    );
  }
}
