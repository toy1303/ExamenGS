

import { HttpClient ,HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })

export class PrincipalService {

  Url = 'https://localhost:7194/';
  constructor(public httpClient: HttpClient) { }

  getAsync(url: string): Promise<any> {
    return new Promise(resolve => {

      const subscription = this.httpClient.get<any>(url)
        .subscribe(
          data => {

            subscription.unsubscribe();

            resolve(data);

          }, error => {

            subscription.unsubscribe();

            resolve({
              exito: false,
              mensaje: error.message.toString(),
              respuesta: null
            } as any);
          });
    });
  }




  postAsync(url: string, objeto: any): Promise<any> {

    return new Promise(resolve => {

      const subscription = this.httpClient.post(url, objeto)
        .subscribe(
          data => {

            subscription.unsubscribe();

            resolve(data ? data : { exito: true } as any);
          },
          error => {

            subscription.unsubscribe();

            return resolve({
              exito: false,
              mensaje: error.error.toString(),
              respuesta: null
            } as any);
          });
    });
  }
}
