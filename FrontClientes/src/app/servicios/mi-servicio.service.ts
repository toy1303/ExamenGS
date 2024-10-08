
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root' // Esto lo hace disponible en toda la aplicación
})
export class MiServicioService {

  private apiUrl = 'https://localhost:7194/'; 
  constructor(private http:HttpClient) 
  { 

  }


  async ObtieneProductos(): Promise<any> {
    const response = await this.http.get<any>(this.apiUrl+'ObtieneProductos').toPromise();
    // Extraer solo el array de datos
    return response;
  }

  async ObtieneCXlientesActivios(): Promise<any> {
    const response = await this.http.get<any>(this.apiUrl+'ObtieneclientesActivos').toPromise();
    // Extraer solo el array de datos
    return response;
  }

  async ObtieneVentasCliente(): Promise<any> {
    const response = await this.http.get<any>(this.apiUrl+'Obtieneventas').toPromise();
    // Extraer solo el array de datos
    return response;
  }

  async DeatalleVenta(Idventa:any): Promise<any> {
    const response = await this.http.get<any>(this.apiUrl+'DetalleVenta/'+Idventa).toPromise();
    // Extraer solo el array de datos
    return response;
  }
  
  async InsertaVenta(objeto:any): Promise<any> {
    const response = await this.http.post<any>(this.apiUrl+'Agregaventa',objeto).toPromise();
    // Extraer solo el array de datos
    return response;
  }
  async ObtieneDatos(): Promise<any> {
    const response = await this.http.get<any>(this.apiUrl).toPromise();
      console.log(response);
    // Extraer solo el array de datos
    return response;
  }
}
