import { City } from 'src/app/_models/City/city';
import { Country } from 'src/app/_models/Country/country';
import { SearchService } from './../_service/Search/search.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../_service/Category/category.service';
import { Category } from '../_models/Category/category';
import { Search } from '../_models/Search/search';

@Component({
  selector: 'app-home',
  templateUrl:'./home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  partcategories:Category[]=[] ;
  Data:Search=new Search();
  countrysearchlist:Country[]=[];
  citysearchlist:City[]=[];
  idcat:Category[]=[];
  idcountry:Country[]=[];
  idcity:City[]=[];
  test:any[]=['a' ,'b','c' , 'd' , 'd' ,'e'  ];


  constructor( private router : Router , private categoryService:CategoryService , private searchService:SearchService) { }

 searchResult(){
  console.log(this.idcountry , this.idcity , this.idcat);
    this.searchService.getCompanies(this.idcountry , this.idcity , this.idcat).subscribe(result => {
       console.log(result);
 });

 }
 GoToCompanies(){
   debugger
  if(  this.idcity.length==0 &&this.idcat.length==0  &&this.idcountry.length!=0){
        this.router.navigate(['/companiesCountry',this.idcountry]);
   }
   else if(this.idcat.length== 0&& this.idcity.length!=0&& this.idcountry.length!=0){
  this.router.navigate(['/companiesCoutCity',this.idcountry, this.idcity ]);
   }
   else if(this.idcity.length==0 &&this.idcountry.length!=0 &&this.idcat.length!=0){
    this.router.navigate(['/companiesCoutCat',this.idcountry,  this.idcat ]);
   }
   else if(this.idcity.length==0 &&this.idcountry.length==0  &&this.idcat.length!=0){
    this.router.navigate(['/companiesCategory', this.idcat ]);
   }
   else if(this.idcity.length!==0 &&this.idcountry.length!=0  &&this.idcat.length!=0){
  this.router.navigate(['/companies',this.idcountry, this.idcity , this.idcat ]);
   }
   else
  this.router.navigate(['/companies']);
}
  selectcountry(value :any){
    if (value == 0)
    this.citysearchlist=[];
else
     this.searchService.getCities(value).subscribe(data =>
      {
        this.citysearchlist = data
      });
  }
  show(a:any){
    alert(a);
   }



  ngOnInit(): void {
    this.categoryService.GetAllCategories().subscribe(a=>{
      this.partcategories=a;
    })

    this.searchService.getAllCountries().subscribe(a=>{
      this.countrysearchlist=a;
    });

  }

  logout(){
    sessionStorage.clear();
    this.router.navigateByUrl("/login");
  }

  allCategories(){
   this.router.navigateByUrl("/allCategories");
  }
}
