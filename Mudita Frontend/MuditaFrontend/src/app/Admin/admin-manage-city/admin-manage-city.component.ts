import { AdminServiceService } from 'src/app/_service/Admin/admin-service.service';
import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { City } from 'src/app/_models/City/city';
import { Country } from 'src/app/_models/Country/country';
import { SearchService } from 'src/app/_service/Search/search.service';

@Component({
  selector: 'app-admin-manage-city',
  templateUrl: './admin-manage-city.component.html',
  styleUrls: ['./admin-manage-city.component.css']
})
export class AdminManageCityComponent implements OnInit {
  cp:number=1;
  allCities:City[]=[];
  allCountries:Country[]=[];
  AddCity:City= new City();
  EditCity:City= new City();
  DeleteCity:City= new City();
  cityId:any;
  countryId:any;
  values1!: string[];
  date1!: Date;
  x:boolean=true;
  HideEditBtn:boolean=false;
  HideSaveBtn:boolean=true;
  editField!: string;
  show:any;

  constructor(
    private confirmationService : ConfirmationService,
    private adminService:AdminServiceService,
    private searchservice:SearchService,
    ) { }
//get countryId

//add new
add() {
  this.adminService.AddCity(this.AddCity).subscribe(a=>{
    location.reload();
 });
}

changeValue(id: number, property: string, event: any) {
    this.editField = event.target.textContent;
}

//flgs edits
onEdit(){
  this.x=false;
  this.HideEditBtn=true;
  this.HideSaveBtn=false;
}
//to get id
Onclick(value:any){
  this.cityId=value;
  return this.cityId
  
}
//save edits
onSave(){ 
  this.EditCity.city_Id=this.cityId;
   this.adminService.EditCity(this.EditCity).subscribe(a=>{
     location.reload();
     this.x=true;
     this.HideEditBtn=false;
     this.HideSaveBtn=true;
    });
}
//delete city
confirm(event: Event,id:number) {
    this.confirmationService.confirm({
      target: event.target,
        message: 'Are you sure that you want to Delete this Data ?',
        icon: 'pi pi-exclamation-triangle',

        accept: () => {
            //confirm action
           this.adminService.DeleteCity(id).subscribe(a=>{
             location.reload();
            
          });
        },
        reject: () => {
            //reject action
        }
    });
}
//getall
  ngOnInit(): void {
    this.adminService.getallCities().subscribe(data =>
      {
        this.allCities = data
      });
      this.searchservice.getAllCountries().subscribe(a=>{
        this.allCountries=a;
    });
  }

}
