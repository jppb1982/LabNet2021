import { Component, OnInit } from '@angular/core';

import { AbmProductosService } from 'src/app/services/abm-productos.service';
import { Producto } from 'src/app/models/producto';

@Component({
  selector: 'app-lista-productos',
  templateUrl: './lista-productos.component.html',
  styleUrls: ['./lista-productos.component.css']
})

export class ListaProductosComponent implements OnInit {
  productos!: Producto[];

  constructor(private abmProductoService: AbmProductosService) { }

  ngOnInit(): void {
    this.ObtenerProductos();
  }

  ObtenerProductos() {
    this.abmProductoService.ObtenerTodos().subscribe(
      res => {
        console.log(res);
        this.productos = (JSON.parse(res) as Producto[]);

      }
    );
  }


  onAdd(){
    
  }

  onDelete(id: number) {
    this.abmProductoService.Borrar(id).subscribe(res => { this.ObtenerProductos(); }
    );
  }
}
