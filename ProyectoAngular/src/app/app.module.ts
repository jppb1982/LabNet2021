import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AgregarProductoComponent } from './components/agregar-producto/agregar-producto.component';
import { DetalleProductoComponent } from './components/detalle-producto/detalle-producto.component';
import { ListaProductosComponent } from './components/lista-productos/lista-productos.component';

import { FormsModule } from "@angular/forms";
import {ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { VerProductoComponent } from './components/ver-producto/ver-producto.component';

@NgModule({
  declarations: [
    AppComponent,
    AgregarProductoComponent,
    DetalleProductoComponent,
    ListaProductosComponent,
    VerProductoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
