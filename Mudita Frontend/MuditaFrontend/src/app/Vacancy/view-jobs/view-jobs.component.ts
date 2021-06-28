import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import { Apply, GETVacancyViewModel } from 'src/app/_models/jobs/jobs';
import { JobsService } from 'src/app/_service/jobs/jobs.service';

@Component({
  selector: 'app-view-jobs',
  templateUrl: './view-jobs.component.html',
  styleUrls: ['./view-jobs.component.css'],
})
export class ViewJobsComponent implements OnInit {
  constructor(private jobser: JobsService,private messageService: MessageService) {}
  obj:Apply=new Apply();
  jobsArr : GETVacancyViewModel[] = [];
  searchVal!:string;
  jobs!:GETVacancyViewModel[]
  onejob: GETVacancyViewModel = new GETVacancyViewModel();

  cp: number = 1;//*for paginator

  ngOnInit(): void {
    let ID = sessionStorage.getItem("user")
    this.jobser.GetAllJobForuser(ID).subscribe((res) => {
      this.jobsArr = res;
      this.jobs = this.jobsArr
      console.log(this.jobsArr);
      this.obj.userName=sessionStorage.getItem("user")
    });
  }

  sorttype(value:any){
    if(value == 1 ){
      this.jobsArr.sort((a,b) => 0 - (a.publishdate > b.publishdate ? -1 : 1));
    }
    else if(value == 2){
      this.jobsArr.sort((a,b) => 0 - (a.publishdate > b.publishdate ? 1 : -1));
    }
    console.log(this.jobsArr);
  }

checkSearchVal() {

    this.jobs = this.jobsArr.slice();
    let filteredUsers: GETVacancyViewModel[] = [];
    if (this.searchVal && this.searchVal != '') {
    /*  FOR OF */
    for (let selectedUser of this.jobs) {
        if (selectedUser.jobTitle.toLowerCase().search(this.searchVal.toLowerCase()) != -1 ||
          selectedUser.company.toLowerCase().search(this.searchVal.toLowerCase()) != -1) {
          filteredUsers.push(selectedUser);
        }
    }
     this.jobs = filteredUsers.slice();
    }
  }
  Apply(vacId:number,comId:number){
    this.obj.vacancyID=vacId;
    this.obj.companyId=comId;
    console.log(this.obj)
    this.jobser.Apply(this.obj).subscribe(a=>{
      this.messageService.add({
        severity: 'success',
        summary: 'Sccussfully Applied',
      });
      setTimeout(()=>{location.reload(); },500)
    })
  }
  displayjob: Boolean = false;
  viewjobs(value:number){
    this.onejob = this.jobsArr.find(x=>x.vacancyID == value)
    this.displayjob = true;
    console.log(this.onejob);
    
  }

}

