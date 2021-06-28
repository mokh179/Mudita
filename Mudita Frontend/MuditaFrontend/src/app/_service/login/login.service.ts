import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../../_models/Login/login';
import { Register } from '../../_models/Register/register';
@Injectable({
  providedIn: 'root'
})
export class LoginService {

  LogIN(credentials:Login){
    //return observable

      return this.http.post('https://localhost:44352/api/Authentication/LogIn',credentials);
  }
  constructor(private http : HttpClient) {
   }

}
