import { ActivatedRoute, Router } from '@angular/router';
import { RegisterService } from '../../_service/register/register.service';
import { Component, OnInit } from '@angular/core';
import { Country } from 'src/app/_models/Country/country';
import { City } from 'src/app/_models/City/city';
import { Register } from 'src/app/_models/Register/register';
import { NavbarService } from 'src/app/_service/navbarandfooter/navbar&footer.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  countrylist:Country[]=[];
  SelectedCountry :Country = new Country();
  citylist:City[]=[];
  Data:Register=new Register();
  invalidregister: boolean=false;
  mobNumberPattern ="^((\\+91-?)|0)?[0-9]{11}$";
  returnUrl!: string;
  url:any;
 // emailll="^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$";



  constructor(public registerservice :RegisterService ,public router : Router , public nav:NavbarService,private route: ActivatedRoute) { }
BackToLogIn(){
 this.router.navigateByUrl("/login");
 }

SignUp(){
   this.url= window.location.href ;
debugger; 
     if(this.url=="http://localhost:4200/register"){
    this.registerservice.register(this.Data).subscribe(response => {
       const token = (<any>response).token;
       const user = (<any>response).username;
       const CanEdit= (<any>response).canEdit;
       const Strength= (<any>response).strength;

       sessionStorage.setItem("jwt" , token);
       sessionStorage.setItem("user" ,user);
       sessionStorage.setItem("CanEdit" ,CanEdit);
       sessionStorage.setItem("Strength" ,Strength);

       console.log(user)
      this.invalidregister=false;
      this.nav.show();
      this.returnUrl="/user/"+user;
      window.location.href=this.returnUrl;
       //
       } , err => {
       this.invalidregister=true;

    })
  }
  else{
    this.registerservice.registerAdmin(this.Data).subscribe(response => {
      const token = (<any>response).token;
      const user = (<any>response).username;
      const CanEdit= (<any>response).canEdit;
      const Strength= (<any>response).strength;
      const Role = (<any>response).roles;

      sessionStorage.setItem("jwt" , token);
      sessionStorage.setItem("user" ,user);
      sessionStorage.setItem("CanEdit" ,CanEdit);
      sessionStorage.setItem("Strength" ,Strength);
      sessionStorage.setItem("Role" , Role);

      console.log(user)
     this.invalidregister=false;
     this.nav.show();
     this.returnUrl="/user/"+user;
     window.location.href=this.returnUrl;
      //
      } , err => {
      this.invalidregister=true;

   })
  }
  }


  selectChangeHandler (value:any) {

    // console.log(value);
     if (value == 0)
        this.citylist=[];
    else
         this.registerservice.getCities(value).subscribe(data =>
          {
            this.citylist = data
          });
        //console.log(this.citylist);
  }

  ngOnInit(): void {

      this.nav.hide();
      this.registerservice.getAllCountries().subscribe(a=>{
      this.countrylist=a;
   })
   this.Data.countryid=0
   this.Data.cityid=0
  }

}
