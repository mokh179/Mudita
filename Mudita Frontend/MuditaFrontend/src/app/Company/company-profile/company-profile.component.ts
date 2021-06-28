import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyService } from 'src/app/_service/company/company.service';
import { companyModel } from 'src/app/_models/company/all-company-data-model';
import { RegisterService } from '../../_service/register/register.service';
import { Country } from 'src/app/_models/Country/country';
import { City } from '../../_models/City/city';
import { CategoryService } from '../../_service/Category/category.service';
import { MessageService } from 'primeng/api';
import { FileService } from 'src/app/_service/file/file.service';
import { AddLocation } from 'src/app/_models/company/add-location';
import { Status } from 'src/app/_models/company/rate';


@Component({
  selector: 'app-company-profile',
  templateUrl: './company-profile.component.html',
  styleUrls: ['./company-profile.component.css']
})
export class CompanyPRofileComponent implements OnInit {

  addedLocation:AddLocation= new AddLocation();
  addlocation($event){
   this.companyService.addCompanyLocation(this.addedLocation).subscribe(a=>{
   console.log(this.addedLocation);
   this.messageService.add({
    severity: 'success',
    summary: 'Successful',
    detail: 'Location is added successfully',
    life: 3000,
  });
  });
   }



  editField!: string;
  show:any;

    updateList(id: number, property: string, event: any) {
      // const editField = event.target.textContent;
      // this.personList[id][property] = editField;
    }

    remove(id?: any) {
      // this.awaitingPersonList.push(this.personList[id]);
      // this.personList.splice(id, 1);
    }

    add() {
      // if (this.awaitingPersonList.length > 0) {
      //   const person = this.awaitingPersonList[0];
      //   this.personList.push(person);
      //   this.awaitingPersonList.splice(0, 1);
      // }
    }

    changeValue(id: number, property: string, event: any) {
      this.editField = event.target.textContent;
    }

  values1!: string[];

  date1!: Date;
  x:boolean=true;
  HideEditBtn:boolean=false;
  HideSaveBtn:boolean=true;
  onEdit(){
    this.x=false;
    this.HideEditBtn=true;
    this.HideSaveBtn=false;
  }

  onSave(){
    this.x=true;
    this.HideEditBtn=false;
    this.HideSaveBtn=true;
     //console.log(this.companyId,this.companyProf)
     debugger;
     if(this.companyProf.managerID==sessionStorage.getItem("user") as string)
     {
      this.ser.EditCompany(this.companyId,this.companyProf).subscribe(
        (a)=> {
          this.router.navigateByUrl('/')
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

  photos!: string;
  constructor(private ser:CompanyService,private ac:ActivatedRoute,private router:Router,
    private registerservice:RegisterService,private cat:CategoryService,
    private messageService: MessageService,private fileser:FileService,
    private companyService:CompanyService
    ) { }
  companyProf:companyModel=new companyModel();
  status:Status=new Status();
  countrylist:Country[]=[];
  cont?:any|[]=[]
  citis?:any|[]=[]
  categories?:any|[]=[]
  companyId:number=0;
  suc:boolean=false;
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
        this.cont=this.companyProf.countriesID
        this.citis=this.companyProf.citisID
        if(this.companyProf.img != null){
          this.fileser.GetProfileCompany(a.id).subscribe( data =>{
            this.photos = `https://localhost:44352\\${data.toString()}`;
          });
        }else{
          this.photos = `https://bootdey.com/img/Content/avatar/avatar7.png`
        }
      })

      this.ser.getstatus(this.companyId).subscribe(d=>{
        this.status=d
      })
  
    })
    var folder = window.location.pathname;
    let URl = folder.split('/')
    this.addedLocation.companyID= parseInt(URl[3])
   let fl= parseInt(URl[3]).toString();
   var usercompany=sessionStorage.getItem('companyId') as string
   if(fl!=usercompany){
     this.router.navigateByUrl('/company/companydetails/fl')
   }
  //  else if{
         
  //  }


  }


  selectcountry(value :any){
    if (value == 0)
    this.citylist=[];
else
     this.registerservice.getCities(value).subscribe(data =>
      {
        this.citylist = data
      });
  }

//* upload Image
  public uploadFile(files: any) {
    debugger
    if (files.length === 0) {
      this.messageService.add({
        severity: 'error',
        summary: 'file Error',
        detail: 'No file selected',
      });
    }

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    //console.log(this.companyId);

    this.fileser.uploadcompanyProfile(this.companyId as number,formData).subscribe(
      (p) => {
        //console.log(p);
        location.reload();
        this.messageService.add({
          severity: 'success',
          summary: 'Sccussfully upload',
          detail: '',
        });
      },
      (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Server Error',
          detail: 'Please Try to add item again with jpgor png format',
        });
      }
    );
  }

  selectChangeHandler (value:any) {
    //console.log("hello")
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
