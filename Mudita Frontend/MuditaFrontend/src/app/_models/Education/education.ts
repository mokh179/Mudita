export class typeOfEducation {
  constructor(public id?: number, public name?: string) {}
}

export class userEducation {
  constructor(
    public id?: number,
    public userID?: string,
    public companyID?: number,
    public type?: number
  ) {}
}
