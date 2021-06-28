export class GETVacancyViewModel {
  constructor(
    public vacancyID?: number,
    public jobTitle?: any,
    public company?: any,
    public description?: string,
    public jobTypes?: any[],
    public jobTags?: any[],
    public publishdate?: Date,
    public email?:string,
    public companyId?:number,
    public appliedState?:boolean
  ) {}
}
export class VacancyViewModel {
  constructor(
    public vacancyID?: number,
    public jobTitle?: any,
    public description?: string,
    public jobTypes?: any[],
    public jobTags?: any[],
    public email?:string,
    public companyId?:number
  ) {}
}

export class Apply{
  constructor(public vacancyID?:number,
    public userName?:string,
    public companyId?:number
    ){}
}

export class AppliedVacancy{
  constructor(
    public vacancyId?: number,
    public state?: string,
    public title?: string,
    public companyName?: string,
    public description?: string,
    public appliedDate?: Date,
    public publishDate?: Date,
    public noApplicants?: number,
    public noViewed?: number,
    public noselected?: number,
    public noRejected?: number,
    public companyImage?: string,
    public vacancyState?: boolean,
    ){}
}

export class getAllAppliedVacancyModel{
  constructor(
    public publishDate?: Date,
    public noApplicants?: number,
    public noViewed?: number,
    public noselected?: number,
    public noRejected?: number,
    public title?: string,
    public vacancyState?:boolean,
    public vacancyId?:number
  ){}
}


export class GETAplicantVacany{
  constructor(
    public name?: string,
    public userName?: string,
    public title?: string,
    public city?: string,
    public country?: string,
    public cv?: string,
    public status?: number,
    public vacancyID?: number,
    
  ){}
}