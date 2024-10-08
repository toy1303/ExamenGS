import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {ProductosService} from '../Servicio/productos.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-clientesventas',
  standalone: true,
  imports: [],
  templateUrl: './clientesventas.component.html',
  styleUrl: './clientesventas.component.css'
})
export class ClientesventasComponent implements OnInit {



  constructor( private ServicioModal: NgbModal,
  private ProductosService:ProductosService)
  {
    
  }

  ngOnInit(): void 
  {
    this.ObtieneProductos();
  }

  async ObtieneProductos()
  {

  }

  async abreModal(confirma:any)
  {
    this.ServicioModal.open(confirma, { size: 'lg' });
  }
}
