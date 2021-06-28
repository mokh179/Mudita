import { AddLocation } from '../../_models/company/add-location';
import { CreateCompany } from '../../_models/company/create-company';
import { City } from 'src/app/_models/City/city';
import { Country } from 'src/app/_models/Country/country';
import { SearchService } from '../../_service/Search/search.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../_service/Category/category.service';
import { CompanyService } from '../../_service/company/company.service';
import { Category } from '../../_models/Category/category';
import { Search } from '../../_models/Search/search';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-create-company-profile',
  templateUrl: './create-company-profile.component.html',
  styleUrls: ['./create-company-profile.component.css']
})
export class CreateCompanyProfileComponent implements OnInit {
  partcategories:Category[]=[] ;
  Data:Search=new Search();
  countrysearchlist:Country[]=[];
  citysearchlist:City[]=[];
  idcat:Category[]=[];
  idcountry:Country[]=[];

  categoryname:any;
  companyAdded: CreateCompany=new CreateCompany();




  constructor( private router : Router , private categoryService:CategoryService , private searchService:SearchService, private companyService:CompanyService,private messageService: MessageService,private confirmationService: ConfirmationService) { }

 searchCat(valuee: any) {
  console.log(valuee);
  this.categoryService.GetAllCategories().subscribe((a) => {
    this.partcategories = a;
  });
}



  addCompany(){
    debugger;
    this.companyAdded.manager_Id=sessionStorage.getItem("user") as string;
   this.companyService.addCompany(this.companyAdded).subscribe(a=>{
   console.log(this.companyAdded);
   });
   
}

confirm1() {
  this.confirmationService.confirm({
      message: 'You have to logout to save changes',
      header: 'Confirmation',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        debugger;
        this.addCompany();
          this.messageService.add({severity:'info', summary:'Confirmed', detail:'Added Succesfully'});
         setTimeout(()=>this.logout(),1000)
      },
      reject: (type) => {
        this.messageService.add({severity:'info', summary:'Danger', detail:'An error Occured'});      }
  });
}
logout() {
  debugger;
  sessionStorage.clear();
  this.router.navigateByUrl('/login');
}

  ngOnInit(): void {
    this.categoryService.GetAllCategories().subscribe(a=>{
      this.partcategories=a;
    })

    this.searchService.getAllCountries().subscribe(a=>{
      this.countrysearchlist=a;
    });

  }

}
