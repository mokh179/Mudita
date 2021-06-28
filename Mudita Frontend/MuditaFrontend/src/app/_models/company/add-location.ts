export class AddLocation {
  constructor(
    public companyID?:number,
    public cityID?:number,
    public countryID?:number,
  ){}
}

export class EditLocation{
  constructor(
    public companyID?:number,
    public cityID?:number,
    public countryID?:number,
    public oldCity?:number,
    public oldCountry?:number,
    public user?:string){}
}
