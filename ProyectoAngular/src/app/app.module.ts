import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AgregarProductoComponent } from './components/agregar-producto/agregar-producto.component';
import { ListaProductosComponent } from './components/lista-productos/lista-productos.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule } from "@angular/forms";
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { VerProductoComponent } from './components/ver-producto/ver-producto.component';
import { EditarProductoComponent } from './components/editar-producto/editar-producto.component';
import { GlobalErrorHandler } from './errors/GlobalErrorHandler';
import { ServerErrorInterceptor } from './errors/servererrorinterceptor';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSnackbarSeverityModule } from 'mat-snackbar-severity';

@NgModule({
  declarations: [
    AppComponent,
    AgregarProductoComponent,
    ListaProductosComponent,
    VerProductoComponent,
    EditarProductoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    MatSnackBarModule,
    MatSnackbarSeverityModule
  ],
  providers: [
    {provide: ErrorHandler, useClass: GlobalErrorHandler}, 
    { provide: HTTP_INTERCEPTORS, useClass: ServerErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
