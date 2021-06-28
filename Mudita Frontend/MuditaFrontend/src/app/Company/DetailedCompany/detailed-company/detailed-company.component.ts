import { Component, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyService } from 'src/app/_service/company/company.service';
import { companyModel } from 'src/app/_models/company/all-company-data-model';
import { RegisterService } from '../../../_service/register/register.service';
import { Country } from 'src/app/_models/Country/country';
import { City } from '../../../_models/City/city';
import { CategoryService } from '../../../_service/Category/category.service';
import { MessageService } from 'primeng/api';
import { AddLocation, EditLocation } from 'src/app/_models/company/add-location';

@Component({
  selector: 'app-detailed-company',
  templateUrl: './detailed-company.component.html',
  styleUrls: ['./detailed-company.component.css']
})
export class DetailedCompanyComponent implements OnInit {
  editField!: string;
  show:any;
  @Output() email:string
    changeValue(id: number, property: string, event: any) {
      this.editField = event.target.textContent;
    }


  onEdit(){
    this.x=false;
    this.HideEditBtn=true;
    this.HideSaveBtn=false;
  }

  onSave(){
    this.x=true;
    this.HideEditBtn=false;
    this.HideSaveBtn=true;
     console.log(this.companyId,this.companyProf)
     debugger;
     if(this.companyProf.managerID==sessionStorage.getItem("user") as string)
     {
      this.ser.EditCompany(this.companyId,this.companyProf).subscribe(
        (a)=> {
          // this.router.navigateByUrl('/')
          location.reload();
        },
      (err)=>{
         alert('An Error Occured')
      })
     }
     else
     {
      console.log('Error')
     }
  }

 Editcountry(){
this.Econ=false;
console.log(this.companyId)
 }
 EditedLocation:EditLocation= new EditLocation();

Save(countryId:number,cityId:number,OcountryId:number,OcityId:number){
 this.EditedLocation.countryID=countryId
 this.EditedLocation.cityID=cityId
 this.EditedLocation.companyID=this.companyId
 this.EditedLocation.oldCity=OcityId
 this.EditedLocation.oldCountry=OcountryId
 this.EditedLocation.user=sessionStorage.getItem("user") as string
 console.log(cityId,countryId,OcountryId,OcityId)
 console.log(this.EditedLocation);  
 this.companyService.EditCompanyLocation(this.EditedLocation).subscribe(a=>{
  this.messageService.add({
   severity: 'success',
   summary: 'Successful',
   detail: 'Location is Updated successfully',
   life: 3000,
 });
 location.reload();
 this.Econ=true;
 });




}



  constructor(private ser:CompanyService,private ac:ActivatedRoute,private router:Router,
    private registerservice:RegisterService,private cat:CategoryService,private companyService:CompanyService,
    private messageService:MessageService
    ) { }
  companyProf:companyModel=new companyModel();
  countrylist:Country[]=[];
  countryNames:any[]=[];
  cont?:any|[]=[]
  citis?:any|[]=[]
  citisName?:any|[]=[]
  categories?:any|[]=[]
  companyId:number=0;
  suc:boolean=false;
  values1!: string[];

  date1!: Date;
  x:boolean=true;
  Econ:boolean=true;
  HideEditBtn:boolean=false;
  HideSaveBtn:boolean=true;
  ocitis:any[]=[]
  ocountries:any[]=[]
  SelectedCountry :Country = new Country();
  citylist:City[]=[];
  ngOnInit(): void {
    this.registerservice.getAllCountries().subscribe(a=>{
      this.countrylist=a;
   })
   this.cat.GetAllCategories().subscribe(a=>{
    this.categories=a;
 })
   
    this.ac.params.subscribe(a=>{
      this.companyId=a.id;
      this.ser.GetCompanyByID(a.id).subscribe(com=>{
        this.companyProf=com
        console.log(this.companyProf)
        this.ocitis=this.companyProf.citisID
        this.email=this.companyProf.email;
        this.cont=this.companyProf.countriesID
        this.citis=this.companyProf.citisID
        this.citisName=this.companyProf.citis
        this.countryNames=this.companyProf.countries
        this.ocountries=this.companyProf.countriesID
      })
    })
    
  }

  selectChangeHandler (value:any) {
    this.Econ=false;
     if (value == 0)
        this.citylist=[];
    else
    {
      this.registerservice.getCities(value).subscribe(data =>
        {
          this.citylist = data
        });
      }
          this.citis=this.companyProf.citisID
  }

}

