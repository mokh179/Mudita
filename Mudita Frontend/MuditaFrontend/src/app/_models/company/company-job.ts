export class CompanyJob {
    constructor(public vacancyID?:number
        ,public jobTitle?:number,
        public company?:number,
        public description?:string,
        public jobTypes?:number[],
        public jobTags?:number[]){}
}
