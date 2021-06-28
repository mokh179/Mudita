import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { BasicInfoModel } from 'src/app/_models/user/user';
import { FileService } from 'src/app/_service/file/file.service';
import { UserService } from 'src/app/_service/user/user.service';
import { CompanyService } from './../../_service/company/company.service';

@Component({
  selector: 'app-user-slidebar',
  templateUrl: './user-slidebar.component.html',
  styleUrls: ['./user-slidebar.component.css']
})
export class UserSlidebarComponent implements OnInit {

  constructor(
    private confirmationService:ConfirmationService,
    private userser: UserService,
    private Filesser: FileService,
    private router: Router,
    private messageService: MessageService,
    private com:CompanyService
  ) {}

  //* Upload Image
  public uploadFile(files: any) {
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

    this.Filesser.uploadProfile(
      this.UserBasicInfo.userID as string,
      formData
    ).subscribe(
      (p) => {
        console.log(p);
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
          detail: 'Please Try to add item again',
        });
      }
    );
  }
  UserBasicInfo: BasicInfoModel = new BasicInfoModel();
  photos!: string;
  CanEdit:string;
  Editable:boolean=false;
  companyId: any;
  ngOnInit(): void {
    var userID = sessionStorage.getItem("user")
    this.CanEdit = sessionStorage.getItem('CanEdit') as string;
    this.companyId = sessionStorage.getItem('companyId') as string;
    this.CheckCompanyOrUser();

    this.userser.GetInfo(userID as string).subscribe(res =>{
      this.UserBasicInfo = res;
      //console.log(this.UserBasicInfo);
      if(this.UserBasicInfo.image != null){
        this.Filesser.GetFiles(userID).subscribe( data =>{
          this.photos = `https://localhost:44352\\${data.toString()}`;
        });
      }else{
        this.photos = `https://bootdey.com/img/Content/avatar/avatar7.png`
      }
    });
  }
  CheckCompanyOrUser(){
    this.CanEdit = sessionStorage.getItem('CanEdit') as string;
    if(this.CanEdit==="true"){
      this.Editable= true;
      return this.Editable
    }
    else  return this.Editable;
  }
  logout() {
    sessionStorage.clear();
    this.router.navigateByUrl('/login');
  }

   //deactivate

 deleteProduct(event: Event) {
    debugger;
    var userID = sessionStorage.getItem("user")
    this.confirmationService.confirm({
      target: event.target,
      message: 'Are you sure that you want to de-activate your account?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        debugger;
        this.userser.DeleteUsr(userID as string).subscribe(a=>{
          console.log(userID);
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Account is de-activated',
            life: 3000,
          });
          this.logout();
        })
      },
      reject: () => {
        //reject action
      },
    });
  }
  removeCompany(event: Event) {   
    this.confirmationService.confirm({
      target: event.target,
      message: 'Are you sure that you want to proceed?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.com.deactivate(this.companyId).subscribe(a=>{
         
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'DeActivate Successfully',
            life: 3000,
          });
          this.logout();
        })       
      },
      reject: () => {
        //reject action
      },
    });
  }

  // deleteAcc(){
  //   debugger;
  //   var userID = sessionStorage.getItem("user");
  //   this.userser.DeleteUsr(userID as string).subscribe(a=>{
  //     console.log(userID);});
  //     // this.logout();
  // }


  // end of  delete



}
