import { AddLocation, EditLocation  } from './../../_models/company/add-location';
import { CreateCompany } from './../../_models/company/create-company';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AllCompanyDataModel,companyModel } from 'src/app/_models/company/all-company-data-model';
import { Rate, Status } from './../../_models/company/rate';
@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private http: HttpClient) { }
  GetAllCompanies(){
    return this.http.get<AllCompanyDataModel[]>("https://localhost:44352/api/Company/companies");
  }
   GetonCompany(id:number){
    return this.http.get<companyModel>("https://localhost:44352/api/Company/GetonCompare/"+id);
  }
  GetCompanyByCategory(id:number){
    return this.http.get<AllCompanyDataModel[]>("https://localhost:44352/api/Company/companies/"+id);
  }
  GetCompanyByID(id:number){
    return this.http.get<companyModel>("https://localhost:44352/api/Company/Company/"+id)
  }

  giveArate(rate:Rate){
    return this.http.post("https://localhost:44352/api/Rating/GiveRate/",rate)
  }

  EditCompany(id:number,credintials:companyModel){
    return this.http.put("https://localhost:44352/api/Company/UpdateCompany/"+id,credintials)
  }

  addCompany(CreateCompany:CreateCompany){
    return this.http.post("https://localhost:44352/api/Company/AddNew",CreateCompany);

  }

  addCompanyLocation(AddLocation:AddLocation){
    return this.http.post("https://localhost:44352/api/Company/SetupLocation",AddLocation);
  }
  EditCompanyLocation(AddLocation:EditLocation){
    return this.http.put("https://localhost:44352/api/Company/UpdateLocation",AddLocation);
  }
  getstatus(id:number){
    return this.http.get<Status>("https://localhost:44352/api/Company/GetStatus/"+id);
  }
  getreviews(id:number){
    return this.http.get<string[]>("https://localhost:44352/api/Company/Reviews/"+id);
  }
  deactivate(id:number){
    return this.http.delete("https://localhost:44352/api/Company/deactivate/"+id);
  }
}
