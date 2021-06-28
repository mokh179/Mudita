import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { BasicInfoModel, PassModel } from '../../_models/user/user';
import { FileService } from '../../_service/file/file.service';
import { UserService } from '../../_service/user/user.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {


  userPass: PassModel = new PassModel();

  constructor(private userser:UserService,
              private messageService:MessageService) { }

  ngOnInit(): void {

  }

  Save(){
    var userID = sessionStorage.getItem("user")
    this.userPass.userID = userID as string;
    if(this.userPass.NewPassword === this.userPass.ConfirmPassword && this.userPass.NewPassword !== this.userPass.CurrentPassword ){
      this.userser.ResetPass(this.userPass).subscribe(abc=>{
        this.messageService.add({severity: 'success', summary: 'Password Changed', detail: 'Password has been Successfully Changed'});
      })
    }
    else{
      this.messageService.add({severity: 'error', summary: 'Password Error', detail: 'Pasword been typed wrong or equal to current one'});
    }

  }

}
