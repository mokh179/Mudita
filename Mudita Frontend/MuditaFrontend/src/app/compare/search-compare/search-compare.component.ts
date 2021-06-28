import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { CompareCompany } from 'src/app/_models/CompareCompany/compare-company';
import { CompareCompanyService } from 'src/app/_service/CompareCompany/compare-company.service';

@Component({
  selector: 'app-search-compare',
  templateUrl:'./search-compare.component.html',
  styleUrls: ['./search-compare.component.css']
})
export class SearchCompareComponent implements OnInit {

  companiesfirst:CompareCompany[]=[];
  companiessecond:CompareCompany[]=[];
  id1:number[]=[];
  id2:number[]=[];


  Data:CompareCompany= new CompareCompany();
  constructor(public CompareCompanyService:CompareCompanyService , public router:Router) { }


  ngOnInit(): void {
    this.CompareCompanyService.getAllCompanies().subscribe(a=>{
      this.companiesfirst=a;
      console.log(a);
    })
  }

  categorytextbox(value:any){

    console.log(value);
    //debugger;
     this.CompareCompanyService.getAllCompare(value).subscribe(b=>{
       this.companiessecond=b
      this.companiessecond=this.companiessecond.filter(a=>a.companyName!=value);
    console.log(b);
    })  
  }
  GoToCompare(){
        this.router.navigate(['/compareresult',this.id1,this.id2]);
  }
}
