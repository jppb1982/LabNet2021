import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
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

  constructor(private formBuilder: FormBuilder, private abmProductoService: AbmProductosService) { }

  ngOnInit(): void {
    this.verProductoForm = this.formBuilder.group(
      {
        id: ["", Validators.required],
        nombre: [""],
        presentacion: [""],
        precio: [""]
      }

    );
  }

  get form() {
    return this.verProductoForm.controls;
  }

  onSubmit() {
    this.submitted = true;
    var p: Producto = new Producto();
    // stop here if form is invalid
    if (this.verProductoForm.invalid) {
      return;
    }
    else {

      this.abmProductoService.BuscarProductoPorId(this.verProductoForm.controls.id.value).subscribe(
        res => {
          console.log(res);
          p = (JSON.parse(res) as Producto);
          this.verProductoForm.controls.nombre.setValue(p.Nombre);
          this.verProductoForm.controls.precio.setValue(p.PrecioUnitario);
          this.verProductoForm.controls.presentacion.setValue(p.CantidadPorUnidad);
        }
      );
    }
  }

}
