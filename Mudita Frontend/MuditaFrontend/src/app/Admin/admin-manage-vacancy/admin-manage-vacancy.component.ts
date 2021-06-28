import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { AdminServiceService } from 'src/app/_service/Admin/admin-service.service';
import { JobsService } from 'src/app/_service/jobs/jobs.service';

@Component({
  selector: 'app-admin-manage-vacancy',
  templateUrl: './admin-manage-vacancy.component.html',
  styleUrls: ['./admin-manage-vacancy.component.css']
})
export class AdminManageVacancyComponent implements OnInit {
  cp:number=1;

  constructor(private confirmationService : ConfirmationService, private adminService:AdminServiceService, private jobService:JobsService) { }
  editField!: string;
  show:any;
  allVacancies:any;



  changeValue(id: number, property: string, event: any) {
    this.editField = event.target.textContent;
  }

values1!: string[];

date1!: Date;
x:boolean=true;
HideEditBtn:boolean=false;
HideSaveBtn:boolean=true;



  confirm(event: Event,id:number) {
    this.confirmationService.confirm({
      target: event.target,
        message: 'Are you sure that you want to Delete this Data ?',
        icon: 'pi pi-exclamation-triangle',

        accept: () => {
            //confirm action
           this.adminService.deletVacancy(id).subscribe(res=>{
             location.reload();
           })
        },
        reject: () => {
            //reject action
        }
    });
}
  ngOnInit(): void {
    //GETVacancyViewModel
    this.adminService.GetCloseVacancy().subscribe(a=>{
      this.allVacancies=a;
      console.log(a)

    });

  }
}
