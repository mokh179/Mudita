import { LoginService } from '../../_service/login/login.service';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Login } from 'src/app/_models/Login/login';
import { BnNgIdleService } from 'bn-ng-idle';
import { NavbarService } from 'src/app/_service/navbarandfooter/navbar&footer.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css' ]
})
export class LoginComponent implements OnInit {
 returnUrl: string="";
 invalidLogin :boolean =false ;
 ExpiredLogin:boolean= false;
 Data:Login=new Login();
 //username:any=this.Data.username ;


 constructor( public loginservice:LoginService ,
  private router:Router ,
  public bnIdle :BnNgIdleService ,
  public nav:NavbarService,
  private route: ActivatedRoute) { }


   Save(){
     debugger;
     this.loginservice.LogIN(this.Data) .subscribe(response => {
      debugger;
        const token = (<any>response).token;
        const user = (<any>response).username;
        const CanEdit= (<any>response).canEdit;
        const strength= (<any>response).strength;
        const companyId= (<any>response).companyId;
        const companies = (<any>response).isRelated
        const Role = (<any>response).roles;

        sessionStorage.setItem("jwt" , token);
       sessionStorage.setItem("user" ,user);
       sessionStorage.setItem("CanEdit" ,CanEdit);
       sessionStorage.setItem("Strength" ,strength);
       sessionStorage.setItem("companyId" ,companyId);
       sessionStorage.setItem("isRelated" ,companies);
       sessionStorage.setItem("Role" , Role);


        this.invalidLogin=false;
        this.nav.show();
        window.location.href=this.returnUrl;
       // this.router.navigateByUrl(this.returnUrl);

        } , err => {
        this.invalidLogin=true;

     })

   }

   switchVisible(){
     this.router.navigateByUrl("/register")
   }

  ngOnInit(): void {
    this.nav.hide();
    this.bnIdle.startWatching(11000).subscribe((isTimedOut: boolean) => {
      if (isTimedOut) {
        this.ExpiredLogin=true ;
        this.router.navigateByUrl("/login")
      }
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
   }


}

