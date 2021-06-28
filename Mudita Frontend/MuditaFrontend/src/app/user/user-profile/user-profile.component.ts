import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Category } from 'src/app/_models/Category/category';
import { City } from 'src/app/_models/City/city';
import { Country } from 'src/app/_models/Country/country';
import { JobCategory } from 'src/app/_models/JobCategory/job-category';
import { BasicInfoModel } from 'src/app/_models/user/user';
import { CategoryService } from 'src/app/_service/Category/category.service';
import { CompanyService } from 'src/app/_service/company/company.service';
import { EducationService } from 'src/app/_service/Education/education.service';
import { FileService } from 'src/app/_service/file/file.service';
import { LocationService } from 'src/app/_service/location/location.service';
import { UserService } from 'src/app/_service/user/user.service';
import { UtilitiesService } from 'src/app/_service/utilites/utilities';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
})
export class UserProfileComponent implements OnInit {



  UserBasicInfo: BasicInfoModel = new BasicInfoModel();
  Country: Country = new Country();
  countries: Country[] = [];
  City: City = new City();
  cities: City[] = [];
  category: Category[] = [];

  public val!: number;

  constructor(
    private userser: UserService,
    private locationser: LocationService,
    private utilitesser: UtilitiesService,
    private categoryser: CategoryService,
    private messageService: MessageService,
  ) {}
  date1:Date=new Date();
  ngOnInit(): void {
    var userID = sessionStorage.getItem("user")
    //console.log(userID);
    this.userser.GetInfo(userID as string).subscribe(res =>{
      this.UserBasicInfo = res;  
      this.date1=this.UserBasicInfo.birthdate
      console.log(res)    
    });
  }

  x: boolean = true;
  HideEditBtn: boolean = false;
  HideSaveBtn: boolean = true;
  onEdit() {
    this.x = false;
    this.HideEditBtn = true;
    this.HideSaveBtn = false;
    this.categoryser.GetAllCategories().subscribe((a) => {
      this.category = a;
      //console.log(this.category);
    });
    this.locationser.getAllCountries().subscribe((a) => {
      this.countries = a;
    });

  }
  selectChangeHandler(value: any) {
    //console.log(value);
    if (value == 0) this.cities = [];
    else
      this.locationser.getCitiesBYCountry(value as number).subscribe((a) => {
          this.cities = a;
          //console.log(a);
        });
  }
  JobCategory: JobCategory[] = [];
  selectChangeCategory(value: any) {
    console.log(value);
    if (value == 0) this.JobCategory = [];
    else {
      this.utilitesser.GetJobCategory(value).subscribe((data) => {
        this.JobCategory = data;
        //console.log(this.JobCategory);
      });
    }
  }

  onSave() {
   console.log(this.UserBasicInfo);
    this.userser.EditBasicInfo(this.UserBasicInfo).subscribe(
      (p) => {
        this.x = true;
        this.HideEditBtn = false;
        this.HideSaveBtn = true;
        location.reload();
        this.messageService.add({
          severity: 'success',
          summary: 'Sccussfully upload',
          detail: p.message,
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
  }

   show(id1:number,id2:number){
     this.selectChangeHandler(id1)
     this.selectChangeCategory(id2)
   }


}
