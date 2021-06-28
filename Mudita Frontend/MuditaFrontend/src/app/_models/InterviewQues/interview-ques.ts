export class InterviewQues {
  constructor(
    public ques_Id?:number,
    public jobCat_Desc?:string,
    public jobCat_Id?:number,
    public ques_Desc?:string,
    public username?:string,
    public numOfVote?:number,
    public reports?:number,
    public isActive?:boolean,
    public createOn?:Date,
    public like?:boolean,
    public dislike?:boolean,
    public general?:boolean,

  ){}
}
