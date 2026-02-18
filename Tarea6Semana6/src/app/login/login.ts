import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ILogin } from '../interfaces/login.interface';
@Component({
  selector: 'app-login',
  standalone: true,   // Esto indica que el componente es independiente y no forma parte de ningún módulo específico
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  loading = false;
  errorMsg = "";
  form: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    contrasenia: new FormControl('', [Validators.required])
  });
  
  constructor(private fb:FormBuilder, private loginService: AuthService, private rutas: Router) {

  }

  grabar() {
    if (this.form.invalid) return;

    this.errorMsg = "";
    this.loading = true;
    const usuario: ILogin = this.form.getRawValue();

    this.loginService.login(usuario).subscribe({
      next: (dato) => {
        this.loginService.carga_variable(dato); 
        this.loading = false;
        this.rutas.navigate(['/dashboard']);
      },
      error: (err) => {
        this.errorMsg = "Credenciales inválidas. Intenta de nuevo.";
        this.loading = false; 
      }
    });
  }
}
  


