import { Router } from '@angular/router';
import { Component, Input, OnInit } from '@angular/core';
import { NavbarService } from '../_service/navbarandfooter/navbar&footer.service';
import { Observable } from 'rxjs';
import { BasicInfoModel } from '../_models/user/user';
import { UserService } from '../_service/user/user.service';
import { FileService } from '../_service/file/file.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  UserBasicInfo: BasicInfoModel = new BasicInfoModel();
  photos!:string;
  isLoggedIn:any;
  CanEdit:string;
  Editable:boolean=false;
  username!: string;
  companyId: any;
  Role:string;
  Admin:boolean=false;
  constructor(
    private userser: UserService, private Filesser: FileService,
    public nav: NavbarService ,
    private router : Router,
       ) {}

  ngOnInit(): void {

    this.nav.show();
    this.isLoggedIn=this.nav.check();
    this.username = sessionStorage.getItem('user') as string;
    this.companyId = sessionStorage.getItem('companyId') ;
    var userID = sessionStorage.getItem("user")
    //console.log(userID);
    this.userser.GetInfo(userID as string).subscribe(res =>{
      this.UserBasicInfo = res;
      //console.log(this.UserBasicInfo);
      if(this.UserBasicInfo.image != null){
        this.Filesser.GetFiles(userID).subscribe( data =>{
          this.photos = `https://localhost:44352\\${data.toString()}`;
        });
      }else{
        this.photos = `https://bootdey.com/img/Content/avatar/avatar7.png`
      }
    });
    this.CheckCompanyOrUser();
    this.AdminOrNot();
    }

    CheckCompanyOrUser(){
      this.CanEdit = sessionStorage.getItem('CanEdit') as string;
      if(this.CanEdit==="true"){
        this.Editable= true;
        return this.Editable
      }
      else  return this.Editable;
    }
    AdminOrNot(){
      this.Role = sessionStorage.getItem('Role') as string;
      if( this.Role=='Admin'){
            this.Admin=true;
      }
      return this.Admin;
    }


  logout(){
    sessionStorage.clear();
    this.router.navigateByUrl("/login");
  }

  login(){
    this.router.navigateByUrl("/login");
  }
  signup(){
    this.router.navigateByUrl("/register");
  }

}
