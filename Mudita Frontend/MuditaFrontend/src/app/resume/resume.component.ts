import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GETAplicantVacany } from '../_models/jobs/jobs';
import { FileService } from '../_service/file/file.service';
import { JobsService } from '../_service/jobs/jobs.service';

@Component({
  selector: 'app-resume',
  templateUrl: './resume.component.html',
  styleUrls: ['./resume.component.css']
})
export class ResumeComponent implements OnInit {

  cp:number=1;
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

  }

  constructor(
    private ac:ActivatedRoute,
    private jobser:JobsService,
    private route:Router,
    private fileser:FileService,
  ) { }

  data: GETAplicantVacany[] =[]
  show:boolean=true;
  resumeflag:boolean=false;
  ngOnInit(): void {
    this.ac.params.subscribe(res=>{
      var folder = window.location.pathname;
      let URl = folder.split('/');
      var ComID = parseInt(URl[3]); 
      this.jobser.GetResumes(ComID,res.id).subscribe(a=>{
        this.data = a;
        this.jobs = a;//? for search 
      })
    })    
  }

  ChangeStatus(id:number,data:GETAplicantVacany){debugger;
    if(data.status< id){
      data.status = id;
      if(data.status == 4){
        this.jobser.changeStatus(data).subscribe(a=>{
          console.log(id);
          this.jobs = this.jobs.filter(a=>a.status != 4)
        })
      }else{
        this.jobser.changeStatus(data).subscribe(a=>{
          console.log(id);
        });
      }
      
    }
    if(id == 2){
      this.route.navigateByUrl(`/publicuser/${data.userName}`)
    }
  }

  cv: string
  downloadCV(value: string){
    console.log(value);
    this.cv = value;
    if(value){
      this.fileser.DownloadResume(value).subscribe(event=>{
        if (event.type === HttpEventType.Response) {
          //console.log(event)
          this.downloadFile(event);
        }
         
      })
    }
  }
  private downloadFile(data: HttpResponse<Blob>) {
    const downloadedFile = new Blob([data.body], { type: data.body.type });
    const a = document.createElement('a');
    a.setAttribute('style', 'display:none;');
    document.body.appendChild(a);
    a.download = this.cv;
    a.href = URL.createObjectURL(downloadedFile);
    a.target = '_blank';
    a.click();
    document.body.removeChild(a);
  }

  jobs: GETAplicantVacany[];
  searchVal!:string;
  sorttype(value:any){ 
    // if(value == 2 ){
    //   this.data.sort((a) =>(a.status == 2? -1 : 1));
    // }
    // else if(value == 3){
    //   this.data.sort((a) => (a.status > 2 ? 1 : -1));
    // }
    this.jobs = this.data.slice();
    let filteredUsers: any[] = [];
    if (value == 2) {
    /*  FOR OF */
    for (let selectedUser of this.jobs) {
        if (selectedUser.status.toLocaleString().search(value) != -1) {
          filteredUsers.push(selectedUser);
        }
    }
     this.jobs = filteredUsers.slice();
    }
    else if (value == 3) {
      /*  FOR OF */
      for (let selectedUser of this.jobs) {
          if (selectedUser.status.toLocaleString().search(value) != -1) {
            filteredUsers.push(selectedUser);
          }
      }
       this.jobs = filteredUsers.slice();
      }
    console.log(this.jobs);
    
  }

}
