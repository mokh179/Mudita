import { AllCompanyDataModel } from './../../_models/company/all-company-data-model';
import { AdminServiceService } from 'src/app/_service/Admin/admin-service.service';
import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
@Component({
  selector: 'app-admin-manage-company',
  templateUrl: './admin-manage-company.component.html',
  styleUrls: ['./admin-manage-company.component.css']
})
export class AdminManageCompanyComponent implements OnInit {
  cp:number=1;
  editField!: string;
  show:any;
  values1!: string[];
  date1!: Date;
  x:boolean=true;
  HideEditBtn:boolean=false;
  HideSaveBtn:boolean=true;
  allCompanies:AllCompanyDataModel[]=[];


  changeValue(id: number, property: string, event: any) {
    this.editField = event.target.textContent;
  }

onSave(){
  this.x=true;
  this.HideEditBtn=false;
  this.HideSaveBtn=true;
  location.reload();

}
  constructor(
    private confirmationService : ConfirmationService,
    private adminService:AdminServiceService,
    ) { }
  confirm(event: Event,id:number) {
    this.confirmationService.confirm({
      target: event.target,
        message: 'Are you sure that you want to Delete this Data ?',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
            //confirm action
            this.adminService.DeleteCompany(id).subscribe(a=>{
              location.reload();
            });
        },
        reject: () => {
            //reject action
        }
    });
}
  ngOnInit(): void {
    this.adminService.getAllCompanies().subscribe(a=>{
      this.allCompanies=a;
    });
  }

}
