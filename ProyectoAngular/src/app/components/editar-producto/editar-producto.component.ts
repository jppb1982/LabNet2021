import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControlName } from "@angular/forms";
import { Producto } from "src/app/models/producto";
import { AbmProductosService } from "src/app/services/abm-productos.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-editar-producto',
  templateUrl: './editar-producto.component.html',
  styleUrls: ['./editar-producto.component.css']
})
export class EditarProductoComponent implements OnInit {
  editarProductoForm!: FormGroup;
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

    this.editarProductoForm = this.formBuilder.group(
      {
        nombre: ["", [Validators.maxLength(40), Validators.minLength(3), Validators.required]],
        presentacion: ["", [Validators.maxLength(20)]],
        precio: ["", [Validators.required]]
      }
    );
  }

  get form() {
    return this.editarProductoForm.controls;
  }


  traerProductoId() {
    var p: Producto = new Producto();

    this.abmProductoService.BuscarProductoPorId(this.id).subscribe(
      res => {
        p = (JSON.parse(res) as Producto);
        this.editarProductoForm.controls.nombre.setValue(p.Nombre);
        this.editarProductoForm.controls.precio.setValue(p.PrecioUnitario);
        this.editarProductoForm.controls.presentacion.setValue(p.CantidadPorUnidad);
      }
    );

  }

  haciaPrincipal(){
    this.router.navigate(['/']);
  }

  onSubmit() {
    this.submitted = true;

    if (this.editarProductoForm.invalid) {
      console.log("Campos erroneos");
      return;
    }
    else {
      var p: Producto = new Producto();
      p.Id=this.id;
      p.Nombre = this.editarProductoForm.controls.nombre.value;
      p.PrecioUnitario = this.editarProductoForm.controls.precio.value;
      p.CantidadPorUnidad = this.editarProductoForm.controls.presentacion.value;
      this.abmProductoService.Actualizar(this.id, p).subscribe();
      this.router.navigate(['/']);
    }
  }

}
