import { Component, Inject, OnInit } from '@angular/core';
import { UtilitiesService } from 'src/app/_service/utilites/utilities';
import { KeySkills } from '../../_models/Skills/key-skills';
import { JobTypes } from 'src/app/_models/Skills/key-skills';
import { CompanyJob } from 'src/app/_models/company/company-job';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from 'src/app/_service/Category/category.service';
import { FormBuilder } from '@angular/forms';
import { CompVacancyService } from './../../_service/companyVacancy/comp-vacancy.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-postajob',
  templateUrl: './postajob.component.html',
  styleUrls: ['./postajob.component.css']
})
export class PostajobComponent implements OnInit {


  Vacancy:CompanyJob=new CompanyJob();
  // JobTags
  keySkills: KeySkills[] = [];
  resultsskill: string[] = [];
  saveSkills: string[] = [];
  saveSkillsID:number[]=[];
  // JobTypes
  JobTypes: JobTypes[] = [];
  resultsType: string[] = [];
  saveTypes: string[] = [];
  saveTypesID: number[] = [];

  Jobcategories?:any|[]=[]
  email:string;

  constructor(private utilitesser:UtilitiesService,
    private messageService:MessageService,
    private ser:CompVacancyService) {}



  
  ngOnInit(): void {
    this.utilitesser.GetAllJobCatefory().subscribe(a=>{
      this.Jobcategories=a;
   })
      this.utilitesser.GetAllSkills().subscribe((p) => {
        this.keySkills = p;
      });
      this.utilitesser.GetJobTypes().subscribe((p) => {
        this.JobTypes = p;
      });
      var folder = window.location.pathname;
      let URl = folder.split('/')
      this.Vacancy.company= parseInt(URl[3])
  }

  searchskill(event: { query: string }) {
    this.resultsskill = [];
    var searchKeyskills = this.keySkills.filter((c) =>
      c.name?.toLocaleLowerCase().startsWith(event.query.toLocaleLowerCase())
    );
    for (let i = 0; i < searchKeyskills.length; i++) {
      this.resultsskill.push(searchKeyskills[i].name as string);
    }
  }
  searchType(event: { query: string }) {
    this.resultsType = [];
    var jobtypes = this.JobTypes.filter((c) =>
      c.description?.toLocaleLowerCase().startsWith(event.query.toLocaleLowerCase())
    );
    for (let i = 0; i < jobtypes.length; i++) {
      this.resultsType.push(jobtypes[i].description as string);
    }
  }

  PostAjob() {
    let gg: any[] = [];
    this.saveSkills?.forEach((e) => {
      gg.push(this.keySkills.find((c) => c.name == e)?.id);
      this.Vacancy.jobTags = gg as [];
    });
    let types: any[] = [];
    this.saveTypes?.forEach((e) => {
      types.push(this.JobTypes.find((c) => c.description == e)?.id);
      this.Vacancy.jobTypes = types as [];
    });
    console.log(this.Vacancy);
   this.ser.PostAjob(this.Vacancy).subscribe(a=>{
    this.messageService.add({
      severity: 'success',
      summary: 'Sccussfully Added Job',
    });
    location.reload();
   },(err) => {
    this.messageService.add({
      severity: 'error',
      summary: 'Server Error',
      detail: 'Please Fill Data',
    });
  })
}


}






