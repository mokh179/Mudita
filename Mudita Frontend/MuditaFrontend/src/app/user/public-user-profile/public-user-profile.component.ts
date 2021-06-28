import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { City } from 'src/app/_models/City/city';
import { Country } from 'src/app/_models/Country/country';
import { BasicInfoModel, SkillsModel, SocialMedia, UserEducationModel, UserResumeModel } from 'src/app/_models/user/user';
import { FileService } from 'src/app/_service/file/file.service';
import { LocationService } from 'src/app/_service/location/location.service';
import { UserService } from 'src/app/_service/user/user.service';
import { UtilitiesService } from 'src/app/_service/utilites/utilities';

@Component({
  selector: 'app-public-user-profile',
  templateUrl: './public-user-profile.component.html',
  styleUrls: ['./public-user-profile.component.css']
})
export class PublicUserProfileComponent implements OnInit {

  UserBasicInfo: BasicInfoModel = new BasicInfoModel();
  photos!: string;
  Country: Country = new Country();
  City: City = new City();
  
  sampleEmpSC: any[] = [];
  UserEduArr: UserEducationModel[] = [];
  UserEmpArr: UserResumeModel[] = [];
  skillsModel: SkillsModel = new SkillsModel();

  constructor(
    private userser: UserService,
    private locationser: LocationService,
    private utilitesser: UtilitiesService,
    private Filesser: FileService,
    private ac: ActivatedRoute,
    private router : Router,
    private messageService: MessageService
  ) {}


  ngOnInit(): void {
    var folder = window.location.pathname;
      let URl = folder.split('/')
      var userID= URl[2]
    //console.log(userID);
    this.userser.GetInfo(userID as string).subscribe(res =>{
      this.UserBasicInfo = res;
      //console.log(this.UserBasicInfo);
      if(this.UserBasicInfo.image != null){
        this.Filesser.GetFiles(userID).subscribe( data =>{
          this.photos = `https://localhost:44352\\${data.toString()}`;
        });
      }else{
        this.photos = `https://bootdey.com/img/Content/avatar/avatar7.png`
      }
    });
    //*load skills front end with username
    this.userser.GetSkillsModel(userID as string).subscribe((a) => {
      this.skillsModel = a as SkillsModel;
    });
    //* load Employee histroy with username
    this.userser.GetResume(userID as string).subscribe((a) => {
      this.UserEmpArr = a;
    });
    //*load Education histroy with username
    this.userser.GetEducation(userID as string).subscribe((a) => {
      this.UserEduArr = a;
    });
     //* load soicalMedia Link with username
    this.userser.GetSocialMedia(userID as string).subscribe(a=>{
      a.forEach((e) => {
        var selectusersc = { type: '', url: '' };
        selectusersc.url = e.url as string;
        selectusersc.type = e.url?.split('.')[1] as string;
        this.sampleEmpSC.push(selectusersc);
      });
    })
  }

  logout(){
    sessionStorage.clear();
    this.router.navigateByUrl("/login");
  }

}
