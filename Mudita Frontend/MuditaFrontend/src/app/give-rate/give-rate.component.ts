import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CompanyService } from '../_service/company/company.service';
import { Rate } from './../_models/company/rate';

@Component({
  selector: 'app-give-rate',
  templateUrl: './give-rate.component.html',
  styleUrls: ['./give-rate.component.css']
})
export class GiveRateComponent implements OnInit {
  rt:Rate=new Rate();
  autoResize: any;
  display:boolean=false;
  test:boolean=false;
  strength:any;
    showDialog() {
    debugger;
      this.rt.user_Name=sessionStorage.getItem("user") as string;
      this.strength=sessionStorage.getItem("Strength") as string;
     if(this.strength>=0.75){
      return  this.display = true;
     }
      else
    return this.test=true;
    }
  constructor(private ser:CompanyService,private ac:ActivatedRoute ) { }

  ngOnInit(): void {
    this.rt.user_Name=sessionStorage.getItem("user") as string;
    this.ac.params.subscribe(a=> this.rt.Company_Id=a.id)
  }


  rate(){

    this.ser.giveArate(this.rt).subscribe(a=>{
        console.log(a);
        this.display=false;
    });

  }
}
