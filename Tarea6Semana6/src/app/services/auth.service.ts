// import { Injectable } from '@angular/core';

// @Injectable({
//   providedIn: 'root',
// })
// export class AuthService {
  
// }

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILogin } from '../interfaces/login.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  RUTA_API="https://localhost:7159/Api/Usuario"
  
  constructor(private http:HttpClient) {}

  login(login:any):Observable<any>{
    let dato:any= this.http.post<ILogin>(this.RUTA_API + "/login", login)
    this.carga_variable(login)
    return login
  }
  carga_variable(usuario:ILogin){
    console.log(usuario)
    localStorage.setItem("id", usuario.id?.toString() || "")
    localStorage.setItem("nombre", usuario.nombre)
    localStorage.setItem("email", usuario.email)
  }
  logout(){
    localStorage.removeItem("id")
    localStorage.removeItem("nombre")
    localStorage.removeItem("email")
  }
  estaLogueado():boolean{
    const id: string = (localStorage.getItem("id"))??""
    if (parseInt(id)!=0){
      return true
    } else {
      return false
    }
  }
}
