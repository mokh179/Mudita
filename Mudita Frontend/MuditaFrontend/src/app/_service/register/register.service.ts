import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { City } from '../../_models/City/city';
import { Country } from '../../_models/Country/country';
import { Register } from '../../_models/Register/register';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {


  constructor(private http:HttpClient) { }
  getAllCountries(){
    return this.http.get<Country[]>('https://localhost:44352/api/Location/Country');
 }

 getCities(countryid:number){

   return this.http.get<City[]>('https://localhost:44352/api/Location/cityBYcounty/'+countryid);
 }

 getAllCities(){
  return this.http.get<City[]>('https://localhost:44352/api/Location/getCities')
}

  register(credentials : Register){

    return this.http.post('https://localhost:44352/api/Authentication/SignUp',credentials);


  }
  registerAdmin(credentials : Register){
    debugger;
    return this.http.post('https://localhost:44352/api/Authentication/AdminSignUp',credentials);

  }
}

