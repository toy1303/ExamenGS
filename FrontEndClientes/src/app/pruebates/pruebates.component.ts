import { Component, OnInit } from '@angular/core';
import {MiServicioService} from '../servicios/mi-servicio.service'
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-pruebates',
  standalone: true,
  imports: [CommonModule,FormsModule ],
  templateUrl: './pruebates.component.html',
  styleUrl: './pruebates.component.css'
})
export class PruebatesComponent implements OnInit
{

  productos:any;
  productoSeleccionado: any;
  ClienteSeleccionnado:any;
  cantidad: number = 0;
  cunit:number=0;
  Total:number=0;
  ClientesActivos:any;
  respouestaventa:string="";
  VentasClientes:any;
  DetalleVenta:any;
  constructor(private ServicioModal: NgbModal,
    private SS : MiServicioService
  )
  {}

  ngOnInit(): void {
   this.ObtieneVentasClientes();
   this.ObtieneProductos();
   this.ObtieneClientesActivos();
   
  }

  async ObtieneVentasClientes()
  {
    this.VentasClientes= await this.SS.ObtieneVentasCliente();
    console.log( this.VentasClientes);
  }

  async ObtieneClientesActivos()
  {
    this.ClientesActivos= await this.SS.ObtieneCXlientesActivios();
  }

  async ObtieneProductos()
  {
    this.productos= await this.SS.ObtieneProductos();
  }
  async abreModal(confirma:any)
  {
    this.ServicioModal.open(confirma, { size: 'lg' });
  }

  onSelect(event :any) {

    const selectElement = event.target as HTMLSelectElement;
    const productoId = Number(selectElement.value);
    this.productoSeleccionado = this.productos.find((u: { productO_ID: number; }) => u.productO_ID === productoId);
    console.log('Producto seleccionado:', this.productoSeleccionado);
    this.cunit=this.productoSeleccionado.costO_UNITARIO;
   
  }

  onSelectCliente(event :any)
  {
    const selectElement = event.target as HTMLSelectElement;
    const cliente = Number(selectElement.value);
    this.ClienteSeleccionnado = this.ClientesActivos.find((u: { clientE_ID: number; }) => u.clientE_ID === cliente);
    console.log('Cliente seleccionado:', this.ClienteSeleccionnado);

  }

  onCantidadChange(event: any)
  {
    this.Total=this.cunit*event;
  }

  async AgregaVenta()
  {
    let peticion=
    {
      ClienteId:this.ClienteSeleccionnado.clientE_ID,
      ProductoId:this.productoSeleccionado.productO_ID,
      cantidad:this.cantidad
    }
    this.respouestaventa= await this.SS.InsertaVenta(peticion);

  }

  async Verdatell(ventaid:number, detallle:any)
  {
      this.DetalleVenta= await this.SS.DeatalleVenta(ventaid);
      console.log(this.DetalleVenta);
    this.ServicioModal.open(detallle, { size: 'lg' });

  }

}
