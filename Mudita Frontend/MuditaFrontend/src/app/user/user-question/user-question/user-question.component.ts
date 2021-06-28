import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { InterviewQues } from 'src/app/_models/InterviewQues/interview-ques';
import { BasicInfoModel } from 'src/app/_models/user/user';
import { FileService } from 'src/app/_service/file/file.service';
import { InterviewQuesService } from 'src/app/_service/InterviewQues/interview-ques.service';
import { UserService } from 'src/app/_service/user/user.service';

@Component({
  selector: 'app-user-question',
  templateUrl: './user-question.component.html',
  styleUrls: ['./user-question.component.css'],
})
export class UserQuestionComponent implements OnInit {
  constructor(
    private userser: UserService,
    private Filesser: FileService,
    private interviewser: InterviewQuesService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {}

  Questions: InterviewQues[] = [];
  QuestionsDialog: boolean = false;
  Question: InterviewQues = new InterviewQues();
  allJobCat: any[];

  ngOnInit(): void {
    var userID = sessionStorage.getItem('user');
    this.interviewser.GetQuestionBYusername(userID as string).subscribe((a) => {
      //console.log(a);
      this.Questions = a
    });
    this.interviewser.getAllJobCategory().subscribe((a) => {
      this.allJobCat = a;
    });
  }

  editProduct(Ques: InterviewQues) {
    this.Question = {...Ques}
    console.log(this.Question)
    this.QuestionsDialog = true;
  }

  deleteProduct(event: Event, Ques: InterviewQues) {   
    this.confirmationService.confirm({
      target: event.target,
      message: 'Are you sure that you want to proceed?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.Questions = this.Questions.filter(
          (val) => val.ques_Id !== Ques.ques_Id
        );
        this.interviewser.DeleteQuetion(Ques.ques_Id).subscribe(a=>{
          this.Question = {};
          this.messageService.add({
            severity: 'success',
            summary: 'Successful',
            detail: 'Question Deleted',
            life: 3000,
          });
        })       
      },
      reject: () => {
        //reject action
      },
    });
  }

  hideDialog() {
    this.QuestionsDialog = false;
  }

  saveProduct(Ques:InterviewQues) {
    //console.log(Ques);
    this.interviewser.EditQuestion(Ques).subscribe(a=>{
      this.QuestionsDialog = false;
      location.reload();
      this.messageService.add({
        severity: 'success',
        summary: 'Successful',
        detail: 'Question Updated',
        life: 3000,
      });
    })
  }
}
