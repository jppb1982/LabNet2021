import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators, FormBuilder, FormControlName } from "@angular/forms";
import { Producto } from "src/app/models/producto";
import { AbmProductosService } from "src/app/services/abm-productos.service";



@Component({
  selector: 'app-agregar-producto',
  templateUrl: './agregar-producto.component.html',
  styleUrls: ['./agregar-producto.component.css']
})
export class AgregarProductoComponent implements OnInit {

  agregarProductoForm!: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder, private abmProductoService: AbmProductosService) {

  }

  ngOnInit(): void {
    this.agregarProductoForm = this.formBuilder.group(
      {
        nombre: ["", Validators.required],
        presentacion: ["", Validators.required],
        precio: ["", Validators.required]
      }

    );

  }

  get form() {
    return this.agregarProductoForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.agregarProductoForm.invalid) {
      return;
    }
    else {
      var p: Producto = new Producto();
      p.Nombre = this.agregarProductoForm.controls.nombre.value;
      p.PrecioUnitario = this.agregarProductoForm.controls.precio.value;
      p.CantidadPorUnidad = this.agregarProductoForm.controls.presentacion.value;
      this.abmProductoService.Agregar(p).subscribe();
    }
  }

  onReset() {
    this.submitted = false;
    this.agregarProductoForm.reset();
  }
}
