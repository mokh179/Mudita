import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Adminmodel } from 'src/app/_models/Admin/adminmodel';
import { AdminServiceService } from 'src/app/_service/Admin/admin-service.service';

@Component({
  selector: 'app-admin-manage-user',
  templateUrl: './admin-manage-user.component.html',
  styleUrls: ['./admin-manage-user.component.css'],
})
export class AdminManageUserComponent implements OnInit {
  cp: number = 1;
  editField!: string;
  show: any;
  allUsers: any;

  changeValue(string, event: any) {
    this.editField = event.target.textContent;
  }

  values1!: string[];
  date1!: Date;
  x: boolean = true;
  HideEditBtn: boolean = false;
  HideSaveBtn: boolean = true;

  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private adminService: AdminServiceService
  ) {}
  confirm(event: Event, username: string) {
    this.confirmationService.confirm({
      target: event.target,
      message: 'Are you sure that you want to Delete this Data ?',
      icon: 'pi pi-exclamation-triangle',

      accept: () => {
        this.adminService.deleteUser(username).subscribe((a) => {
          location.reload();
        });
      },
      reject: () => {
        //reject action
      },
    });
  }

  ngOnInit(): void {
    this.adminService.getAllUsers().subscribe((a) => {
      this.allUsers = a;
    });
  }
}
