import { Component, OnInit, Output } from '@angular/core';

import { AbmProductosService } from 'src/app/services/abm-productos.service';
import { Producto } from 'src/app/models/producto';
import { Router } from '@angular/router';
import * as EventEmitter from 'events';

@Component({
  selector: 'app-lista-productos',
  templateUrl: './lista-productos.component.html',
  styleUrls: ['./lista-productos.component.css']
})

export class ListaProductosComponent implements OnInit {
  productos!: Producto[];
  paginaActual: number = 1;

  constructor(private abmProductoService: AbmProductosService, private router: Router) { }



  ngOnInit(): void {
    this.ObtenerProductos();
  }

  ObtenerProductos() {
    this.abmProductoService.ObtenerTodos().subscribe(
      res => {
        this.productos = (JSON.parse(res) as Producto[]);
      }
    );
  }

  navegarHaciaEditar(id: number) {
    this.router.navigate(['/editar/' + id]);
  }

  navegarHaciaVer(id: number) {
    this.router.navigate(['/ver/' + id]);
  }

  navegarHaciaAgregar() {
    this.router.navigate(['/agregar']);
  }

  onDelete(id: number) {
    this.abmProductoService.Borrar(id).subscribe(res => { this.ObtenerProductos(); }
    );
    this.router.navigate(['/']);

  }
}
