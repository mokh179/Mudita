import { Category } from 'src/app/_models/Category/category';

export class AllCompanyDataModel {
    constructor(
        public companyID?:number,
        public overAllRate?:number,
        public companyName?:string,
        public categoryName?:string,
        public img?:string,
        public city_Name?:string,
    ){}
}

export class companyModel{
    constructor(
        public managerID?:string,
        public companyName?:string,
        public phone?:number,
        public email?:string,
        public fax?: number,
        public website?: string,
        public description?: string,
        public category?:string,
        public categoryID?:string,
        public foundedDate?:Date,
        public manager?:string,
        public citis?:string[],
        public linkedProfile?:string,
        public faceProfile?:string,
        public citisID?:number[],
        public countries?:string[],
        public countriesID?:number[],
        public Reiews?:string[],
        public overAllRate?:number,
        public img?:string
    ){}
}


