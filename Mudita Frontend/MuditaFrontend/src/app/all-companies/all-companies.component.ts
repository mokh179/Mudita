import { Component, OnInit } from '@angular/core';
import { AllCompanyDataModel, companyModel } from '../_models/company/all-company-data-model';
import { CompanyService } from 'src/app/_service/company/company.service';
import { ActivatedRoute } from '@angular/router';
import { SearchService } from '../_service/Search/search.service';

@Component({
  selector: 'app-all-companies',
  templateUrl: './all-companies.component.html',
  styleUrls: ['./all-companies.component.css']
})
export class AllCompaniesComponent implements OnInit {
  cp:number=1;
  searchVal!:string;
 CompanyFiltration!:AllCompanyDataModel[];
  companies:AllCompanyDataModel[]=[]

  constructor(private ser:CompanyService,private ac:ActivatedRoute , private searchService:SearchService) { }


  ngOnInit(): void {
       this.ac.params.subscribe(a=>{
            this.searchService.getCompanies(a.id  , a.id2 , a.id3  ).subscribe(result => {
            this.companies=result;
            this.CompanyFiltration=result;
            console.log(this.companies)
       });
    })
  }

  checkSearchVal() {
    this.CompanyFiltration = this.companies.slice();
    let filteredCompany: AllCompanyDataModel[] = [];
    if (this.searchVal && this.searchVal != '') {
    /*  FOR OF */
    for (let selectedCompany of this.CompanyFiltration) {
        if (selectedCompany.companyName.toLowerCase().search(this.searchVal.toLowerCase()) != -1 ) {
            console.log(selectedCompany)
            filteredCompany.push(selectedCompany);
        }
    }
     this.CompanyFiltration = filteredCompany.slice();
    }
  }
}
