import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { typeOfEducation,userEducation } from 'src/app/_models/Education/education';

@Injectable({
  providedIn: 'root'
})
export class EducationService {

  constructor(private http:HttpClient) { }

  GetTypeOfEducation(){
    return this.http.get<typeOfEducation[]>("https://localhost:44352/api/Education/typeofEducation");
  }
  GetTypeOfEducationID(id:number){
    return this.http.get<typeOfEducation>("https://localhost:44352/api/Education/typeofEducation/"+id)
  }
  GetUserEducaton(id:string){
    return this.http.get<userEducation[]>("https://localhost:44352/api/Education/typeofEducation/"+id)
  }
}
