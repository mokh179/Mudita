import { AdminServiceService } from './../../_service/Admin/admin-service.service';
import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { Country } from 'src/app/_models/Country/country';
import { SearchService } from 'src/app/_service/Search/search.service';

@Component({
  selector: 'app-admin-manage-country',
  templateUrl: './admin-manage-country.component.html',
  styleUrls: ['./admin-manage-country.component.css'],
})
export class AdminManageCountryComponent implements OnInit {
  cp: number = 1;
  allCountries: Country[] = [];
  AddCountry: Country = new Country();
  EditCountry: Country = new Country();
  DeleteCountry: Country = new Country();
  countaryId: any;
  x: boolean = true;
  HideEditBtn: boolean = false;
  HideSaveBtn: boolean = true;
  editField!: string;
  show: any;

  constructor(
    private confirmationService: ConfirmationService,
    private searchservice: SearchService,
    private adminService: AdminServiceService
  ) {}

  changeValue(event: any) {
    this.editField = event.target.textContent;
  }
  //flages
  onEdit() {
    this.x = false;
    this.HideEditBtn = true;
    this.HideSaveBtn = false;
  }
  //add new
  add() {
    this.adminService.AddCountry(this.AddCountry).subscribe((a) => {
      location.reload();
    });
  }
  //to get id
  Onclick(value: any) {
    this.countaryId = value;
    return this.countaryId;
  }
  //edit save
  onSave() {
    this.EditCountry.country_id = this.countaryId;
    this.adminService.EditCountry(this.EditCountry).subscribe((a) => {
      this.x = true;
      this.HideEditBtn = false;
      this.HideSaveBtn = true;
      location.reload();
    });
  }

  //delete confirm
  confirm(event: Event, id: number) {
    this.confirmationService.confirm({
      target: event.target,
      message: 'Are you sure that you want to Delete this Data ?',
      icon: 'pi pi-exclamation-triangle',

      accept: () => {
        //confirm action
        this.adminService.DeleteCountry(id).subscribe((a) => {
          location.reload();
        });
      },
      reject: () => {
        //reject action
      },
    });
  }
  //getall
  ngOnInit(): void {
    this.searchservice.getAllCountries().subscribe((a) => {
      this.allCountries = a;
    });
  }
}
