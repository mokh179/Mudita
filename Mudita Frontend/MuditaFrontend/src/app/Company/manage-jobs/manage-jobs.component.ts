import { style } from '@angular/animations';
import { PlatformLocation } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationStart, Router } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { Category } from 'src/app/_models/Category/category';
import { JobCategory } from 'src/app/_models/JobCategory/job-category';
import {
  AppliedVacancy,
  GETVacancyViewModel,
  VacancyViewModel,
} from 'src/app/_models/jobs/jobs';
import { JobTypes, KeySkills } from 'src/app/_models/Skills/key-skills';
import { CategoryService } from 'src/app/_service/Category/category.service';
import { CompVacancyService } from 'src/app/_service/companyVacancy/comp-vacancy.service';
import { JobsService } from 'src/app/_service/jobs/jobs.service';
import { UtilitiesService } from 'src/app/_service/utilites/utilities';

@Component({
  selector: 'app-manage-jobs',
  templateUrl: './manage-jobs.component.html',
  styleUrls: ['./manage-jobs.component.css'],
})
export class ManageJobsComponent implements OnInit {
  mangeeditDialog: boolean = false;
  hideDialog() {
    this.mangeeditDialog = false;
  }

  EditVcancy: VacancyViewModel = new VacancyViewModel();
  onSave() {
    let gg: any[] = [];
    this.vacany.jobTags?.forEach((e) => {
      gg.push(this.keySkills.find((c) => c.name == e)?.id);
      this.EditVcancy.jobTags = gg as [];
    });
    let types: any[] = [];
    this.vacany.jobTypes?.forEach((e) => {
      types.push(this.JobTypes.find((c) => c.description == e)?.id);
      this.EditVcancy.jobTypes = types as [];
    });
    this.categories.forEach((e) => {
      if (e.jobCat_Desc == this.vacany.jobTitle) {
        this.EditVcancy.jobTitle = e.jobCat_Id;
      }
    });
    this.EditVcancy.companyId = this.vacany.companyId;
    this.EditVcancy.description = this.vacany.description;
    this.EditVcancy.vacancyID = this.vacany.vacancyID;

    console.log(this.EditVcancy);
    this.jobser.PostAjob(this.EditVcancy).subscribe(
      (a) => {
        this.mangeeditDialog = false;
        this.messageService.add({
          severity: 'success',
          summary: 'Sccussfully vacancy upload',
        });
      },
      (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Server Error',
          detail: 'Please check data again',
        });
      }
    );
  }


  constructor(
    private confirmationService: ConfirmationService,
    private jobser: JobsService,
    private messageService: MessageService,
    private utilitesser: UtilitiesService,
    private router: Router,
    private location: PlatformLocation,
  ) {
    location.onPopState(() => {
      var folder = window.location.pathname;
      let tt = folder.split('/');
      if(tt[4] == "manageJob"){
        this.pagevisable = true;
      }
      
   });
  }

  jobCompanyArr: AppliedVacancy[] = [];
  ID:number;
  pagevisable:boolean = true
  ngOnInit(): void {
    var folder = window.location.pathname;
    let URl = folder.split('/');
    this.ID = parseInt(URl[3]);
    
    this.jobser.GetAllByCompany(this.ID).subscribe((a) => {
      this.jobCompanyArr = a;
      console.log(this.jobCompanyArr);
    });
  }

  confirm(event: Event, id: number) {
    this.confirmationService.confirm({
      target: event.target,
      message: 'Are you sure that you want to Delete this Data ?',
      icon: 'pi pi-exclamation-triangle',

      accept: () => {
       
        this.jobser.DeleteVacanyByCompany(id).subscribe(
          (p) => {
            for (let i = 0; i < this.jobCompanyArr.length; ++i) {
              if (this.jobCompanyArr[i].vacancyId === id) {
                this.jobCompanyArr.splice(i, 1);
              }
            }
            this.messageService.add({
              severity: 'success',
              summary: 'Sccussfully skill upload',
            });
          },
          (err) => {
            this.messageService.add({
              severity: 'error',
              summary: 'Server Error',
              detail: 'Please Try to add item again',
            });
          }
        );
      },
      reject: () => {
      },
    });
  }

  vacany: GETVacancyViewModel = new GETVacancyViewModel();
  categories: JobCategory[];
  Add(value: any) {
    this.mangeeditDialog = true;
    this.utilitesser.GetAllJobCatefory().subscribe((a) => {
      this.categories = a;
    });
    this.utilitesser.GetAllSkills().subscribe((p) => {
      this.keySkills = p;
    });
    this.utilitesser.GetJobTypes().subscribe((p) => {
      this.JobTypes = p;
    });
    this.jobser.GetVacancy(value).subscribe((res) => {
      this.vacany = res;
      console.log(this.vacany);
    });
  }
  // JobTypes
  JobTypes: JobTypes[] = [];
  resultsType: string[] = [];
  saveTypes: string[] = [];
  saveTypesID: number[] = [];
  searchType(event: { query: string }) {
    this.resultsType = [];
    var jobtypes = this.JobTypes.filter((c) =>
      c.description?.startsWith(event.query)
    );
    for (let i = 0; i < jobtypes.length; i++) {
      this.resultsType.push(jobtypes[i].description as string);
    }
  }
  // JobTags
  keySkills: KeySkills[] = [];
  resultsskill: string[] = [];
  saveSkills: string[] = [];
  saveSkillsID: number[] = [];
  searchskill(event: { query: string }) {
    this.resultsskill = [];
    var searchKeyskills = this.keySkills.filter((c) =>
      c.name?.startsWith(event.query)
    );
    for (let i = 0; i < searchKeyskills.length; i++) {
      this.resultsskill.push(searchKeyskills[i].name as string);
    }
  }
  
  Rsume(){
    this.pagevisable = false;
    console.log(this.pagevisable);
  }
}
