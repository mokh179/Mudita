import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
// import { ActivatedRoute } from '@angular/router';
import { companyModel } from 'src/app/_models/company/all-company-data-model';
import { CompanyService } from 'src/app/_service/company/company.service';
import { FileService } from 'src/app/_service/file/file.service';


@Component({
  selector: 'app-public-profile',
  templateUrl: './public-profile.component.html',
  styleUrls: ['./public-profile.component.css']
})
export class PublicProfileComponent implements OnInit {
  constructor(private ser:CompanyService,private ac:ActivatedRoute,private fileser:FileService) { }
  CompanyDetials: companyModel = new companyModel();
  photos!: string
  websiteflag: boolean = false;
  facebookflag:boolean = false;
  linkedflag: boolean = false;
  ngOnInit(): void {
    this.ac.params.subscribe(res=>{
      this.ser.GetCompanyByID(res.id).subscribe(a=>{
        // console.log(a);
        this.CompanyDetials = a;
        console.log(this.CompanyDetials)
        if(a.faceProfile){this.facebookflag = true}else{this.facebookflag = false}
        if(a.linkedProfile){this.linkedflag = true}else{this.linkedflag = false}
        if(a.website){this.websiteflag = true}else{this.websiteflag = false}
      //   if(this.CompanyDetials.img != null){
      //     this.fileser.GetProfileCompany(res.id).subscribe( data =>{
      //       this.photos = `https://localhost:44352\\${data.toString()}`;
      //     });   
      //   }else{
      //     this.photos = `https://bootdey.com/img/Content/avatar/avatar7.png`
      //   } 
      })
      
    })
  }
}
