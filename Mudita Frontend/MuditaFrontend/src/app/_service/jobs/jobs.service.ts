import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CompanyJob } from 'src/app/_models/company/company-job';
import { AppliedVacancy, Apply, GETAplicantVacany, GETVacancyViewModel, VacancyViewModel } from 'src/app/_models/jobs/jobs';

@Injectable({
  providedIn: 'root'
})
export class JobsService {

  constructor(private http:HttpClient) { }

  GetAllJobForuser(username?:string){
    return this.http.get<GETVacancyViewModel[]>(`https://localhost:44352/api/Vacancy/GetVacanciesFORuser?userName=${username}`);
  }
  GetVacancy(id:number){
    return this.http.get<GETVacancyViewModel>('https://localhost:44352/api/Vacancy/GetVacanciesBYid/'+id);
  }
  Apply(Appl:Apply){
    return this.http.post('https://localhost:44352/api/Vacancy/Apply',Appl);
  }
  GetAllAppliedVacancy(usernaemr: string){
    return this.http.get<AppliedVacancy[]>('https://localhost:44352/api/Vacancy/GetApplieduser/'+usernaemr);

  }
  GetAllByCompany(id :number){
    return this.http.get<AppliedVacancy[]>('https://localhost:44352/api/Vacancy/GetAllcompanyJobs/'+id);
  }
  DeleteVacanyByCompany(id:number){
    return this.http.delete('https://localhost:44352/api/Vacancy/DeleteVacancy/'+id);
  }
  PostAjob(Job:any){
    return this.http.post('https://localhost:44352/api/Vacancy/PostAJob',Job)
  }
  GetResumes(comID:number,vacID:number){
    return this.http.get<GETAplicantVacany[]>(`https://localhost:44352/api/Vacancy/GetResumes?comID=${comID}&VacID=${vacID}`)
  }
  changeStatus(st:GETAplicantVacany){
    return this.http.post<GETAplicantVacany>('https://localhost:44352/api/Vacancy/changeStatus',st)
  }

  WithDraw(id:number,username:string){
    return this.http.put(`https://localhost:44352/api/Vacancy/withDraw?id=${id}&username=${username}`,null)

  }
}
