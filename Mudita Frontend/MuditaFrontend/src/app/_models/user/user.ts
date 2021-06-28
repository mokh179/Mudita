export class BasicInfoModel {
    constructor(
        public userID?: string,
        public fname?: string,
        public lname?: string,
        public title?: any,
        public city?: any,
        public country?: any,
        public summary?: string,
        public email?: string,
        public birthdate?: Date,
        public phone?: any,
        public image?:string,
        public strength?: any,
        public address?: string,
        public message?: string,
        public categoryId?:number,
        public titleId?:number,
        public countryId?:number,
        public cityId?:number
    ){};
}

export class PassModel {
    constructor(
        public userID?: string,
        public CurrentPassword?: string,
        public NewPassword?: string,
        public ConfirmPassword?: string
    ){};
}

export class SkillsModel {
    constructor(
        public userID?: string,
        public skills?: [],
        public Message?: string
    ){};
}

export class UserEducationModel {
    constructor(
        public userID?: string,
        public typeOfEducation?: any,
        public university?: any,
        public message?: string,
        public eduuserID?: number
    ){};
}

export class UserResumeModel {
    constructor(
        public userID?: string,
        public title?: any,
        public company?: any,
        public description?: string,
        public status?: boolean,
        public from?: Date,
        public to?: Date,
        public Message?: string,
        public empuserID?: number,
        public strength?: number
    ){};
}

export class SocialMedia{
    constructor(
        public url?:string,
        public userID?: string,
        public message?: string,
        public onlineID?: number
    ){}
}
