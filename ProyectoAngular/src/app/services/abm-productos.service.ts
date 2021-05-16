import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable, pipe } from 'rxjs';

import { Producto } from '../models/producto';

import { catchError, tap } from 'rxjs/operators';

const urlAPI = 'http://localhost:51561/api/ProductoAPI';



@Injectable({
  providedIn: 'root'
})
export class AbmProductosService {
  constructor(private http: HttpClient) { }

  ObtenerTodos(): Observable<any> {
    return this.http.get(urlAPI);
  }

  BuscarProductoPorId(id: number): Observable<any> {
    return this.http.get(`${urlAPI}/${id}`);
  }

  Agregar(data: Producto): Observable<Producto> {
    return this.http.post<Producto>(urlAPI, data).pipe(tap((data: Producto) => console.log("Agregado!"))    );
  }

  Actualizar(id: number, data: Producto): Observable<Producto> {
    return this.http.put<Producto>(`${urlAPI}/${id}`, data).pipe(tap((data: Producto) => console.log("Actualizado!")));
  }

  Borrar(id: number): Observable<any> {
    return this.http.delete(`${urlAPI}/${id}`);
  }

}
