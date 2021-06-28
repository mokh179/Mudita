import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { AppliedVacancy } from 'src/app/_models/jobs/jobs';
import { BasicInfoModel } from 'src/app/_models/user/user';
import { CategoryService } from 'src/app/_service/Category/category.service';
import { FileService } from 'src/app/_service/file/file.service';
import { JobsService } from 'src/app/_service/jobs/jobs.service';
import { LocationService } from 'src/app/_service/location/location.service';
import { UserService } from 'src/app/_service/user/user.service';
import { UtilitiesService } from 'src/app/_service/utilites/utilities';

@Component({
  selector: 'app-user-applied-vacancy',
  templateUrl: './user-applied-vacancy.component.html',
  styleUrls: ['./user-applied-vacancy.component.css']
})
export class UserAppliedVacancyComponent implements OnInit {

  constructor( private jobser:JobsService
  ) { }
  cp:number=1;

  items: any[];
  jobappliedArr: AppliedVacancy[] = []
  ngOnInit(): void {
 
    this.jobser.GetAllAppliedVacancy(sessionStorage.getItem("user")).subscribe(a=>{
      this.jobappliedArr = a;
      console.log(a);
    })

    // if(this.UserBasicInfo.image != null){
    //   this.Filesser.GetFiles(userID).subscribe( data =>{
    //     this.photos = `https://localhost:44352\\${data.toString()}`;
    //   });
    // }else{
    //   this.photos = `https://bootdey.com/img/Content/avatar/avatar7.png`
    // }
  }
  
  withDraw(id:number){
   let user=sessionStorage.getItem("user");
   this.jobser.WithDraw(id,user).subscribe(a=>{
    //  location.reload();
   this.jobappliedArr=this.jobappliedArr.filter(x=>x.vacancyId!==id);
   })
  }
}
