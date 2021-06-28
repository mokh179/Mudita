import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { companyModel } from 'src/app/_models/company/all-company-data-model';
import { FileService } from 'src/app/_service/file/file.service';
import { CompanyService } from '../../_service/company/company.service';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.css']
})
export class CompanyDetailsComponent implements OnInit {
 constructor(
   private ser:CompanyService,
   private ac:ActivatedRoute,
   private fileser:FileService) { }

 CompanyDetials: companyModel = new companyModel();
  photos!: string
  websiteflag: boolean = false;
  facebookflag:boolean = false;
  linkedflag: boolean = false;
  relatedflag:boolean=false;
  isrelated:any;
  listOfisRelated:number[]=[];
  returnUrl:any;
  listOfNumber:number;
  isRelated(){

    this.isrelated = sessionStorage.getItem('isRelated') ;
    console.log(typeof(sessionStorage.getItem('isRelated')))
    this.listOfisRelated= this.isrelated.split`,`.map(x=>+x) ;
    console.log(this.listOfisRelated);
    if(this.listOfisRelated==null){
      this.relatedflag=false
    }
    else{
      debugger;
     for(let i of this.listOfisRelated){
       console.log(i)
     this.returnUrl= window.location.href ;
       if(this.returnUrl=="http://localhost:4200/company/companydetails/"+i){
        this.relatedflag=true;
        break;
       }
       else
       this.relatedflag=false;
    }
  }
}
  ngOnInit(): void {
    this.isRelated();
    this.ac.params.subscribe(res=>{
      this.ser.GetCompanyByID(res.id).subscribe(a=>{
        this.CompanyDetials = a;
        if(a.faceProfile){this.facebookflag = true}else{this.facebookflag = false}
        if(a.linkedProfile){this.linkedflag = true}else{this.linkedflag = false}
        if(a.website){this.websiteflag = true}else{this.websiteflag = false}
        if(this.CompanyDetials.img != null){
          this.fileser.GetProfileCompany(res.id).subscribe( data =>{
            this.photos = `https://localhost:44352\\${data.toString()}`;
          });
        }else{
          this.photos = `https://bootdey.com/img/Content/avatar/avatar7.png`
        }
      })

    })

}
  }
