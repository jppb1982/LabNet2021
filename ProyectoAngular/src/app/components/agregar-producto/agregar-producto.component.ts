import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators, FormBuilder, FormControlName } from "@angular/forms";
import { Producto } from "src/app/models/producto";
import { AbmProductosService } from "src/app/services/abm-productos.service";
import { Router } from '@angular/router';

@Component({
  selector: 'app-agregar-producto',
  templateUrl: './agregar-producto.component.html',
  styleUrls: ['./agregar-producto.component.css']
})
export class AgregarProductoComponent implements OnInit {

  agregarProductoForm!: FormGroup;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private abmProductoService: AbmProductosService,
    private router: Router) 
  {
  }

  ngOnInit(): void {
    this.agregarProductoForm = this.formBuilder.group(
      {
        nombre: ["", [Validators.maxLength(40), Validators.minLength(3), Validators.required]],
        presentacion: ["", [Validators.maxLength(20)]],
        precio: ["", [Validators.required]]
      }
    );

  }

  get form() {
    return this.agregarProductoForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    if (this.agregarProductoForm.invalid) {
      console.log("Campos erroneos");
      return;
    }
    else {
      var p: Producto = new Producto();
      p.Nombre = this.agregarProductoForm.controls.nombre.value;
      p.PrecioUnitario = this.agregarProductoForm.controls.precio.value;
      p.CantidadPorUnidad = this.agregarProductoForm.controls.presentacion.value;
      this.abmProductoService.Agregar(p).subscribe();
      this.router.navigate(['/']);
    }
  }

  onReset() {
    this.agregarProductoForm.reset();
  }
}
