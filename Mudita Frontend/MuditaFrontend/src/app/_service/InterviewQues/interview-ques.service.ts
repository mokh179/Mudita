import { React } from './../../_models/InterviewQues/react';
import { InterviewQues } from './../../_models/InterviewQues/interview-ques';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JobCategory } from 'src/app/_models/JobCategory/job-category';

@Injectable({
  providedIn: 'root',
})
export class InterviewQuesService {
  constructor(private http: HttpClient) {}

  getAllJobCategory() {
    return this.http.get<JobCategory[]>(
      'https://localhost:44352/api/Utilities/AllJobCategory'
    );
  }

  getAllQuestion() {
    return this.http.get<InterviewQues[]>(
      'https://localhost:44352/api/InterviewQues/interviewques'
    );
  }
  getQuesbyCat(Jobcat: any) {
    return this.http.get<InterviewQues[]>(
      'https://localhost:44352/api/InterviewQues/GetAllJobCategoy?' +
        'JCName=' +
        Jobcat
    );
  }

  postQues(InterviewQues: InterviewQues) {
    return this.http.post(
      'https://localhost:44352/api/InterviewQues',
      InterviewQues
    );
  }

  likeQues(qId: any) {
    return this.http.get(
      'https://localhost:44352/api/InterviewQues/likeQues?' + 'id=' + qId
    );
  }
  //  https://localhost:44352/api/InterviewQues/likeQues?id=1
  dislikeQues(qId: any) {
    return this.http.get(
      'https://localhost:44352/api/InterviewQues/ReportQues?' + 'id=' + qId
    );
  }

  GetQuestionBYusername(id: string) {
    return this.http.get<InterviewQues[]>(
      'https://localhost:44352/api/InterviewQues/GetAllUsrId?UsrName=' + id
    );
  }

  DeleteQuetion(id: number) {
    return this.http.delete<InterviewQues>(
      'https://localhost:44352/api/InterviewQues/DelQues?id=' + id
    );
  }

  EditQuestion(Ques: InterviewQues) {
    return this.http.put<InterviewQues>(
      'https://localhost:44352/api/InterviewQues/EditQues',
      Ques
    );
  }
  React(react: React) {
    return this.http.post(
      'https://localhost:44352/api/InterviewQues/React',
      react
    );
  }
 
}
