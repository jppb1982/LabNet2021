
import { Injectable} from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSnackbarSeverity, SnackbarSeverity } from 'mat-snackbar-severity';
import { reduce } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  
  constructor(public snackBar: MatSnackBar, private snackBarSeverity: MatSnackbarSeverity) {
    
   }
  
  showSuccess(message: string): void {

    const severity: SnackbarSeverity = 'success';

    this.snackBarSeverity.open(severity, 'Ha ocurrido un error. Detalle: ' + message, 'Ok', {
        verticalPosition: 'top',
        horizontalPosition: 'right',
        panelClass:["snackbarStyle"]
      });
  }
  
  showError(message: string): void {

    const severity: SnackbarSeverity = 'error';

    this.snackBarSeverity.open(severity, 'Ha ocurrido un error. Detalle: ' + message, 'Error', {
        verticalPosition: 'top',
        horizontalPosition: 'right',
        panelClass:["snackbarStyleError"]
      });

  }
}