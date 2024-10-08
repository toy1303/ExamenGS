import { Injectable } from '@angular/core';
import { PrincipalService } from './principal.service';

@Injectable({
  providedIn: 'root'
})
export class ProductosService extends PrincipalService{


  public async Obtieneplanbyid()
  {
      return await this.getAsync(this.Url + 'ObtieneProductos');
  }
}
