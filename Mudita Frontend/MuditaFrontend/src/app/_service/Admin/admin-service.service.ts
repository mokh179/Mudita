import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { City } from 'src/app/_models/City/city';
import { AllCompanyDataModel } from 'src/app/_models/company/all-company-data-model';
import { Country } from 'src/app/_models/Country/country';
import { Adminmodel} from 'src/app/_models/Admin/adminmodel';

@Injectable({
  providedIn: 'root'
})
export class AdminServiceService {

  AddCountry(addCont:Country){
    return this.http.post("https://localhost:44352/api/Admin/AddCountry",addCont);
  }
  EditCountry(editCont:Country){
    debugger;
    return this.http.put("https://localhost:44352/api/Admin/EditCountry",editCont);
  }
  DeleteCountry(id:any){
    return this.http.delete("https://localhost:44352/api/Admin/DeleteCountry?"+"id="+id);
  }
  getallCities(){
    return this.http.get<City[]>("https://localhost:44352/api/Admin/GetAllCities");

  }
  AddCity(addCity:City){
    return this.http.post("https://localhost:44352/api/Admin/AddCity",addCity);
  }
  EditCity(editCity:City){

    return this.http.put("https://localhost:44352/api/Admin/EditCity",editCity);
  }
  DeleteCity(id:any){
    return this.http.delete("https://localhost:44352/api/Admin/DeleteCity?"+"id="+id);
  }

  getAllCompanies() {
    return this.http.get<AllCompanyDataModel[]>(
      'https://localhost:44352/api/Admin/AdminGetAll'
    );
  }
  DeleteCompany(id :any ){
    debugger;
    return this.http.delete(
      'https://localhost:44352/api/Admin/DeleteCompany?'+'id='+id
      );
    }

  getAllUsers(){
    return this.http.get<Adminmodel[]>(
      'https://localhost:44352/api/Admin/GetAllUsers'
    );
  }

  deleteUser(usrname:string){
    debugger;
    return this.http.delete(
      'https://localhost:44352/api/Admin/DeleteUser?'+"usrname="+usrname
      );
  }
//
getAllVacancies(){
  return this.http.get<Adminmodel[]>(
    'https://localhost:44352/api/Vacancy/GetVacanciesFORuser'
  );
}
///api/Vacancy/DeleteVacancy/{id}
deletVacancy(id :any ){
  return this.http.delete(
    'https://localhost:44352/api/Admin/DeleteVacancies/'+id
    );
  }

  GetCloseVacancy(){
  return this.http.get(
    'https://localhost:44352/api/Admin/GetCloseVacancy'
    );
  }

  //count
  getAllUser(){
    return this.http.get(
      'https://localhost:44352/api/Admin/GetAllUser'
    );
  }

  getAllActiveUser(){
    return this.http.get(
      'https://localhost:44352/api/Admin/GetAllActiveUser'
    );
  }

  getAllDeactiveUser(){
    return this.http.get(
      'https://localhost:44352/api/Admin/GetAllDeactiveUser'
    );
  }

 getAllCompany(){
    return this.http.get(
      'https://localhost:44352/api/Admin/GetAllCompany'
    );
  }

  getAllActiveCompany(){
    return this.http.get(
      'https://localhost:44352/api/Admin/GetAllActiveCompany'
    );
  }

  getAllDeactiveCompany(){
    return this.http.get(
      'https://localhost:44352/api/Admin/GetAllDeactiveCompany'
    );
  }
  getAllVacancy(){
    return this.http.get(
      'https://localhost:44352/api/Admin/GetAllVacancy'
    );
  }

  getAllActiveVacancy(){
    return this.http.get(
      'https://localhost:44352/api/Admin/GetAllActiveVacancy'
    );
  }

  getAllDeactiveVacancy(){
    return this.http.get(
      'https://localhost:44352/api/Admin/GetAllDeactiveVacancy'
    );
  }
  getAllJobCat(){
    return this.http.get(
      'https://localhost:44352/api/Admin/GetAllVacancy'
    );
  }
   getAllJobTitle(){
    return this.http.get(
      'https://localhost:44352/api/Admin/GetAllJobTitle'
    );
  }
  constructor(private http:HttpClient) { }
  }
