import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ListaProductosComponent } from './components/lista-productos/lista-productos.component';
import { DetalleProductoComponent } from './components/detalle-producto/detalle-producto.component';
import { AgregarProductoComponent } from './components/agregar-producto/agregar-producto.component';
import { VerProductoComponent } from './components/ver-producto/ver-producto.component';


const routes: Routes = [
  { path: '', redirectTo: 'productos', pathMatch: 'full' },
  { path: 'productos', component: ListaProductosComponent },
  { path: 'producto/:id', component: DetalleProductoComponent },
  { path: 'agregar', component: AgregarProductoComponent },
  { path: 'ver', component: VerProductoComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
