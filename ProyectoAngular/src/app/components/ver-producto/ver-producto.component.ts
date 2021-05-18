import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';
import { Producto } from "src/app/models/producto";
import { AbmProductosService } from "src/app/services/abm-productos.service";

@Component({
  selector: 'app-ver-producto',
  templateUrl: './ver-producto.component.html',
  styleUrls: ['./ver-producto.component.css']
})
export class VerProductoComponent implements OnInit {
  verProductoForm!: FormGroup;
  submitted = false;
  id: number;

  constructor(
    private formBuilder: FormBuilder,
    private abmProductoService: AbmProductosService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    activatedRoute.params.subscribe(prm => {
      console.log(`El id es: ${prm['id']}`);
      this.id = prm['id'];
    })
  }

  ngAfterViewInit() {
    this.traerProductoId();
  }

  ngOnInit(): void {

    this.verProductoForm = this.formBuilder.group(
      {
        id: [""],
        nombre: [""],
        presentacion: [""],
        precio: [""],
      }
    );
  }

  get form() {
    return this.verProductoForm.controls;
  }


  traerProductoId() {
    var p: Producto = new Producto();

    this.abmProductoService.BuscarProductoPorId(this.id).subscribe(
      res => {
        p = (JSON.parse(res) as Producto);
        this.verProductoForm.controls.id.setValue(p.Id);
        this.verProductoForm.controls.nombre.setValue(p.Nombre);
        this.verProductoForm.controls.precio.setValue(p.PrecioUnitario);
        this.verProductoForm.controls.presentacion.setValue(p.CantidadPorUnidad);
      }
    );

  }

}
