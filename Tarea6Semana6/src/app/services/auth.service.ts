
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILogin } from '../interfaces/login.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  RUTA_API = "https://localhost:7208/api/usuario";

  constructor(private http: HttpClient) {}

  login(login: ILogin): Observable<any> {
    console.log(login);
    return this.http.post<any>(this.RUTA_API + "/login", login); 
  }

  carga_variable(usuario: any) {
    localStorage.setItem("id", usuario.id?.toString() || "");
    localStorage.setItem("nombre", usuario.nombre || "");
    localStorage.setItem("email", usuario.email || "");
  }

  logout() {
    localStorage.removeItem("id");
    localStorage.removeItem("nombre");
    localStorage.removeItem("email");
  }

  estaLogueado(): boolean {
    const id = localStorage.getItem("id") ?? "";
    return parseInt(id) > 0;
  }
}