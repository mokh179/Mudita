import { AdminServiceService } from 'src/app/_service/Admin/admin-service.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  allUser:any;
  allCompany:any;
  allVacancy:any;
  allJobCat:any;
  allJobTitle:any;
  allActiveUser:any;
  allDeactiveUser:any;
  allActiveCompany:any;
  allDeactiveCompany:any;
  allActiveVacancy:any;
  allDeactiveVacancy:any;

  constructor(

    private adminService:AdminServiceService ,private router:Router) { }

  ngOnInit(): void {
    
    var role=sessionStorage.getItem('Role');
    if(role!="Admin"){
      this.router.navigateByUrl("/");
    }
  
    this.adminService.getAllUser().subscribe(a=>{
      this.allUser=a;
    })
    this.adminService.getAllCompany().subscribe(a=>{
      this.allCompany=a;
    })
    this.adminService.getAllVacancy().subscribe(a=>{
      this.allVacancy=a;
    })
    this.adminService.getAllJobCat().subscribe(a=>{
      this.allJobCat=a;
    })
    this.adminService.getAllJobTitle().subscribe(a=>{
      this.allJobTitle=a;
    })
    this.adminService.getAllActiveUser().subscribe(a=>{
      this.allActiveUser=a;
    })
    this.adminService.getAllActiveCompany().subscribe(a=>{
      this.allActiveCompany=a;
    })
     this.adminService.getAllActiveVacancy().subscribe(a=>{
      this.allActiveVacancy=a;
    })
    this.adminService.getAllDeactiveUser().subscribe(a=>{
      this.allDeactiveUser=a;
    })
    this.adminService.getAllDeactiveCompany().subscribe(a=>{
      this.allDeactiveCompany=a;
    })
     this.adminService.getAllDeactiveVacancy().subscribe(a=>{
      this.allDeactiveVacancy=a;
    })
  }





}
