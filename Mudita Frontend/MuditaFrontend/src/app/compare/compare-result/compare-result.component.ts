import { CompareCompany } from './../../_models/CompareCompany/compare-company';
import { Component, Input, OnInit } from '@angular/core';
import { CompareCompanyService } from 'src/app/_service/CompareCompany/compare-company.service';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-compare-result',
  templateUrl: './compare-result.component.html',
  styleUrls: ['./compare-result.component.css']
})
export class CompareResultComponent implements OnInit {
  val:number=3;
  chk1:number=0;
  chk2:number=0;
  recommended:string=""
  CompData: CompareCompany[] = [];
constructor(private CompareCompanyService:CompareCompanyService ,private activatedRoute :ActivatedRoute) { }


  ngOnInit(): void {
    this.activatedRoute.params.subscribe(p=>{
      console.log(p.firstselect);
      console.log(p.secondselect);
      this.CompareCompanyService.getResult(p.firstselect , p.secondselect).subscribe(a=>{
        this.CompData=a;
        console.log( this.CompData[1].overAllRate );
        this.chk1=this.CompData[0].overAllRate
        this.chk2=this.CompData[1].overAllRate
        this.recommend()
      });
    })
  }


  test(a,b){
    this.chk1=a;
    this.chk2=b;
  }
  recommend()
  {
    debugger;
    if(this.chk1>this.chk2)
    {
      this.recommended=this.CompData[0].companyName
    }
    else this.recommended=this.CompData[1].companyName

  }
}
