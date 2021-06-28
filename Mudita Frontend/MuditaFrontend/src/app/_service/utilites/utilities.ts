import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JobCategory } from 'src/app/_models/JobCategory/job-category';
import { JobTypes, KeySkills } from 'src/app/_models/Skills/key-skills';

@Injectable({
  providedIn: 'root'
})
export class UtilitiesService {

  constructor(private http:HttpClient) { }

 
  GetAllJobCatefory(){
    return this.http.get<JobCategory[]>("https://localhost:44352/api/Utilities/AllJobCategory")
  }
  GetJobCategory(id: number){
    return this.http.get<JobCategory[]>("https://localhost:44352/api/Utilities/JobCategoryBYcategory/"+id);
  }
  GetJobCategoryByID(id: number){
    return this.http.get<JobCategory>("https://localhost:44352/api/Utilities/JobCategory/"+id);
  }
  GetAllSkills(){
    return this.http.get<KeySkills[]>("https://localhost:44352/api/Utilities/AllSkills");
  }
  GetSkill(id : number){
    return this.http.get<KeySkills>("https://localhost:44352/api/Utilities/AllSkills/"+id);
  } 
  GetJobTypes(){
    return this.http.get<JobTypes[]>("https://localhost:44352/api/Utilities/jobTypes");
  } 
  
}
