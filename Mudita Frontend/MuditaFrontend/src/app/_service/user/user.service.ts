import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BasicInfoModel, PassModel, SkillsModel, SocialMedia, UserEducationModel, UserResumeModel } from 'src/app/_models/user/user';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  GetInfo(id: string){
    return this.http.get<BasicInfoModel>("https://localhost:44352/api/User/EditBasicInfo/"+id);
  }
  EditBasicInfo(BasicInfo : BasicInfoModel){
    return this.http.post<BasicInfoModel>("https://localhost:44352/api/User/EditBasicInfo",BasicInfo);
  }
  GetResume(id: string){
    return this.http.get<UserResumeModel[]>("https://localhost:44352/api/User/EditResume/"+id);
  }
  EditResume(resume : UserResumeModel){
    debugger; 
    // console.log("https://localhost:44352/api/User/EditResume",resume)
    return this.http.post("https://localhost:44352/api/User/EditResume",resume);
  }
  GetSkillsModel(id: string){
    return this.http.get<SkillsModel[]>("https://localhost:44352/api/User/EditSkills/"+id)
  }
  EditSkills(skills : SkillsModel){
    return this.http.put<SkillsModel>("https://localhost:44352/api/User/EditSkills",skills);
  }
  GetEducation(id: string){
    return this.http.get<UserEducationModel[]>("https://localhost:44352/api/User/EditEducation/"+id);
  }
  EditEducation(Education : UserEducationModel){
    return this.http.post<UserEducationModel>("https://localhost:44352/api/User/EditEducation",Education);
  }
  ResetPass(Pass : PassModel){
    return this.http.put<PassModel>("https://localhost:44352/api/User/ResetPass",Pass);
  }
  GetSocialMedia(id: string){
    return this.http.get<SocialMedia[]>("https://localhost:44352/api/User/SocialMedia/"+id);
  }
  EditSocialMedia(sc: SocialMedia){
    return this.http.post<SocialMedia>("https://localhost:44352/api/User/SocialMedia",sc);
  }

  DeleteUsr(usrname:string){
    return this.http.delete<BasicInfoModel>("https://localhost:44352/api/User/DelUser?usrname="+usrname);
  }
  DeleteEduHistroy(usrname:number){
    return this.http.delete<number>("https://localhost:44352/api/User/DeleteEduHistroy/"+usrname);
  }
  DeleteEmpHistroy(usrname:number){
    return this.http.delete<number>("https://localhost:44352/api/User/DeleteEmpHistroy/"+usrname);
  }
  DeleteonlineProfile(usrname:number){
    return this.http.delete<number>("https://localhost:44352/api/User/Deleteonlineprofile/"+usrname);
  }

}
