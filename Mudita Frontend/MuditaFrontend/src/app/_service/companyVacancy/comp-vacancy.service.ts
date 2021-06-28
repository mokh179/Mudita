import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CompanyJob } from 'src/app/_models/company/company-job';

@Injectable({
  providedIn: 'root'
})
export class CompVacancyService {

  constructor(private http: HttpClient) { }

  PostAjob(Job:CompanyJob){
    return this.http.post('https://localhost:44352/api/Vacancy/PostAJob',Job)
  }
}
