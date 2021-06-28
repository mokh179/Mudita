import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { BehaviorSubject, Subscription } from 'rxjs';
import { CompareCompany } from 'src/app/_models/CompareCompany/compare-company';
import { Observable, Subject, asapScheduler, pipe, of, from, interval, merge, fromEvent } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CompareCompanyService {
private paramSource = new BehaviorSubject(null);
sharedParam = this.paramSource.asObservable();



getAllCompanies(){
    return this.http.get<CompareCompany[]>("https://localhost:44352/api/Company/companies")
}
getAllCompare(company_Name:any){
  debugger;
   return this.http.get<CompareCompany[]>("https://localhost:44352/api/Company/GetAllCompare?"+'CompanyName='+company_Name)
}
getResult(name1:any, name2:any):Observable<CompareCompany[]>{
  return this.http.get<CompareCompany[]>('https://localhost:44352/api/Company/GetCompareById?'+'name1='+name1 +'&name2='+name2);

 }

constructor(private http : HttpClient) { }


}
