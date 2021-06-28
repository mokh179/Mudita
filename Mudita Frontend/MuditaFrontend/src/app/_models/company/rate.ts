export class Rate {
 constructor(public salrate?:number,public WorkEnvironmentRate?:number,public ServiceRate?:number,public SafetyRate?:number,public Rate_Desc?:string,public user_Name?:string,public Company_Id?:number){}
}
export class Status{
    constructor(public noReviwers?:number,public comments?:number,public overAllRate?:number){}
}