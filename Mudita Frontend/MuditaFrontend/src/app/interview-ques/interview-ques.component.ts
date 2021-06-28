import { InterviewQuesService } from './../_service/InterviewQues/interview-ques.service';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { InterviewQues } from 'src/app/_models/InterviewQues/interview-ques';
import { JobCategory } from '../_models/JobCategory/job-category';
import { React } from '../_models/InterviewQues/react';

@Component({
  selector: 'app-interview-ques',
  templateUrl: './interview-ques.component.html',
  styleUrls: ['./interview-ques.component.css'],
})
export class InterviewQuesComponent implements OnInit {
  cp:number=1;
  allJobCat:JobCategory[]=[];
  addQues: InterviewQues =new InterviewQues();
  allQues:any;
  jobname:any;
  sorting:any;
  asc:any;
  desc:any;
  state:any;
  disabled:boolean=true;
  reaction:React =new React();
  stateval:string="";


  constructor(public interviewQuesService: InterviewQuesService,  public router:Router) { }

  searchJobCat(valuee: any) {
    console.log(valuee);
    this.interviewQuesService.getQuesbyCat(valuee).subscribe((a) => {
      this.allQues = a;
    });
  }


 sortData(value:any) {
    debugger;
    if (value == 'asc') {
      return this.allQues.sort((a: { createOn: any }, b: { createOn: any }) => {
        return <any>new Date(a.createOn) - <any>new Date(b.createOn);
      });
    } else
      return this.allQues.sort(
        (
          a: { createOn: string | number | Date },
          b: { createOn: string | number | Date }
        ) => {
          return <any>new Date(b.createOn) - <any>new Date(a.createOn);
        }
      );
  }

 addNewQues(){
  debugger;
    this.addQues.username=sessionStorage.getItem("user") as string;
    this.interviewQuesService.postQues(this.addQues).subscribe(a=>{
      window.location.reload();
     console.log(this.addQues)
    })

 }

React(value:any,status:any ){
  debugger;
  this.stateval=status
  console.log(typeof(this.stateval))
   if(this.stateval=="true")
    {
      this.reaction.like=true
      this.reaction.dislike=false

    }
    else{
      this.reaction.like=false
      this.reaction.dislike=true
    
    }
  this.reaction.ques_Id =value;
  this.reaction.username=sessionStorage.getItem("user") as string;
  this.interviewQuesService.React(this.reaction).subscribe(a=>{
    window.location.reload();
  })
  console.log(status)
  console.log(this.reaction)
  console.log(value)

}


  ngOnInit(): void {

    this.interviewQuesService.getAllJobCategory().subscribe(a=>{
      this.allJobCat=a;
    })
    this.interviewQuesService.getAllQuestion().subscribe(a=>{
      this.allQues=a;
      console.log(this.allQues);
    });
  }
}
