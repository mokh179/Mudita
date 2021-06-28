import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { AllCompanyDataModel } from 'src/app/_models/company/all-company-data-model';
import { City } from 'src/app/_models/City/city';
import { Country } from 'src/app/_models/Country/country';
import { Category } from 'src/app/_models/Category/category';
import { JobCategory } from 'src/app/_models/JobCategory/job-category';
import {
  BasicInfoModel,
  UserResumeModel,
  SkillsModel,
  UserEducationModel,
  SocialMedia,
} from 'src/app/_models/user/user';
import { typeOfEducation } from 'src/app/_models/Education/education';
import { UserService } from 'src/app/_service/user/user.service';
import { LocationService } from 'src/app/_service/location/location.service';
import { UtilitiesService } from 'src/app/_service/utilites/utilities';
import { CompanyService } from 'src/app/_service/company/company.service';
import { CategoryService } from 'src/app/_service/Category/category.service';
import { EducationService } from 'src/app/_service/Education/education.service';
import { KeySkills } from 'src/app/_models/Skills/key-skills';
import { FileService } from 'src/app/_service/file/file.service';

@Component({
  selector: 'app-user-resume',
  templateUrl: './user-resume.component.html',
  styleUrls: ['./user-resume.component.css'],
})
export class UserResumeComponent implements OnInit {
  displayBasic: boolean = false;
  displaySummary: boolean = false;
  displaykeyskills: boolean = false;
  displayEmployment: boolean = false;
  displayEducation: boolean = false;
  displaySocialMedia: boolean = false;

  category: Category[] = [];
  JobCategory: JobCategory[] = [];
  selectcategory: string | undefined;
  showBasicDialog() {
    this.displayBasic = true;
    this.categoryser.GetAllCategories().subscribe((a) => {
      this.category = a;
    });
    this.locationser.getAllCountries().subscribe((a) => {
      this.countries = a;
    });
  }

  selectChangeCategory(id: any) {
    if (id == 0) this.JobCategory = [];
    else {
      this.utilitesser.GetJobCategory(id).subscribe((data) => {
        this.JobCategory = data;
        //console.log(this.JobCategory);
      });
    }
  }

  selectChangeCity(id: any) {
    if (id == 0) this.cities = [];
    else {
      this.locationser.getCitiesBYCountry(id).subscribe((data) => {
        this.cities = data;
        //console.log(this.cities);
      });
    }
  }

  showSummaryDialog() {
    this.displaySummary = true;
  }
  showkeyskillsDialog() {
    this.displaykeyskills = true;
    this.utilitesser.GetAllSkills().subscribe((p) => {
      this.keySkills = p;
    });
    this.saveSkills = this.skillsModel.skills;
  }

  resultsskill: string[] = [];
  keySkills: KeySkills[] = [];
  saveSkills: [] = [];
  searchskill(event: { query: string }) {
    this.resultsskill = [];

    var searchKeyskills = this.keySkills.filter((c) =>
      c.name?.toLocaleLowerCase().startsWith(event.query.toLocaleLowerCase())
    );
    for (let i = 0; i < searchKeyskills.length; i++) {
      this.resultsskill.push(searchKeyskills[i].name as string);
    }
    //console.log(this.resultsskill);
  }

  AllJobCategory: JobCategory[] = [];
  AllCompanies: AllCompanyDataModel[] = [];
  showEmploymentDialog() {
    this.displayEmployment = true;
    this.utilitesser.GetAllJobCatefory().subscribe((a) => {
      this.AllJobCategory = a;
    });
    this.companyser.GetAllCompanies().subscribe((a) => {
      this.AllCompanies = a;
    });
  }
  radio: boolean = true;
  chackRadio(value: boolean) {
    this.radio = this.UserEmp.status as boolean;
    console.log(this.radio);
    if (this.radio) {
      //this.UserEmp.To = new Date().toLocaleDateString('en-GB')
      this.UserEmp.to = undefined;
    }
  }

  typeEdu: typeOfEducation[] = [];
  resultstypeEdu: string[] = [];
  resultsuniversity: string[] = [];

  showEducationDialog() {
    this.displayEducation = true;
    this.Educationser.GetTypeOfEducation().subscribe((p) => {
      this.typeEdu = p;
    });
    this.companyser.GetAllCompanies().subscribe((p) => {
      this.AllCompanies = p;
      this.AllCompanies = this.AllCompanies.filter(a=>a.categoryName =='Education')
    });
  }

  searchtypeofEdu(event: { query: string }) {
    this.resultstypeEdu = [];
    var searchtypeEdu = this.typeEdu.filter((c) =>
      c.name?.startsWith(event.query)
    );
    for (let i = 0; i < searchtypeEdu.length; i++) {
      this.resultstypeEdu.push(searchtypeEdu[i].name as string);
    }
    //console.log(this.resultstypeEdu);
  }

  searchuniversity(event: { query: string }) {
    this.resultsuniversity = [];
    var searchuniversityk = this.AllCompanies.filter((c) =>
      c.companyName?.startsWith(event.query)
    );
    for (let i = 0; i < searchuniversityk.length; i++) {
      this.resultsuniversity.push(searchuniversityk[i].companyName as string);
    }
    //console.log(this.resultsuniversity)
  }

  showSocialMedia() {
    this.displaySocialMedia = true;
  }

  //* Upload Image
  public uploadFile(files: any) {
    if (files.length === 0) {
      this.messageService.add({
        severity: 'error',
        summary: 'file Error',
        detail: 'No file selected',
      });
    }

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.Filesser.uploadProfile(
      this.UserBasicInfo.userID as string,
      formData
    ).subscribe(
      (p) => {
        this.displayBasic = false;
        this.displaySummary = false;
        this.messageService.add({
          severity: 'success',
          summary: 'Sccussfully upload',
          detail: '',
        });
        location.reload();
      },
      (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Server Error',
          detail: 'Please Try to add item again',
        });
      }
    );
  }

  UserBasicInfo: BasicInfoModel = new BasicInfoModel();
  photos!: string;
  strength!: number;

  cities: City[] = [];
  countries: Country[] = [];

  skillsModel: SkillsModel = new SkillsModel();

  UserEmp: UserResumeModel = new UserResumeModel();
  UserEmpArr: UserResumeModel[] = [];
  sampleEmp: any[] = [];

  UserEduArr: UserEducationModel[] = [];
  UserEdu: UserEducationModel = new UserEducationModel();

  UserSocialMedia: SocialMedia = new SocialMedia();
  sampleEmpSC: any[] = [];

  test: any;
  constructor(
    private userser: UserService,
    private locationser: LocationService,
    private utilitesser: UtilitiesService,
    private companyser: CompanyService,
    private categoryser: CategoryService,
    private Educationser: EducationService,
    private Filesser: FileService,
    private ac: ActivatedRoute,
    private messageService: MessageService,
    private router: Router,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit(): void {
    var userID = sessionStorage.getItem('user');
    //console.log(userID);
    this.userser.GetInfo(userID as string).subscribe((res) => {
      this.UserBasicInfo = res;
      if (this.UserBasicInfo.image != null) {
        this.Filesser.GetFiles(userID).subscribe((data) => {
          this.photos = `https://localhost:44352\\${data.toString()}`;
        });
      } else {
        this.photos = `https://bootdey.com/img/Content/avatar/avatar7.png`;
      }
    });
    //*load skills front end with username
    this.userser.GetSkillsModel(userID as string).subscribe((a) => {
      this.skillsModel = a as SkillsModel;
    });
    //* load Employee histroy with username
    this.userser.GetResume(userID as string).subscribe((a) => {
      this.UserEmpArr = a;
      console.log(a);
    });
    //*load Education histroy with username
    this.userser.GetEducation(userID as string).subscribe((a) => {
      this.UserEduArr = a;
      //console.log(a);
    });
    //* load soicalMedia Link with username
    this.userser.GetSocialMedia(userID as string).subscribe((a) => {
      //let sc: any[] = [];
      a.forEach((e) => {
        var selectusersc = {id:'', type: '', url: '' };
        selectusersc.url = e.url as string;
        selectusersc.type = e.url?.split('.')[1] as string;
        selectusersc.id = e.onlineID.toString();       
         this.sampleEmpSC.push(selectusersc);
        console.log(this.sampleEmpSC);
      });
    });

    if (this.UserBasicInfo.strength == 0.75) {
      sessionStorage.clear();
      this.router.navigateByUrl('/login');
    }
  }

  //*? BasicInform call server to save data
  SaveBasicInfo() {
    console.log(this.UserBasicInfo);
    this.userser.EditBasicInfo(this.UserBasicInfo).subscribe(
      (p) => {
        this.displayBasic = false;
        this.displaySummary = false;
        location.reload();
        this.messageService.add({
          severity: 'success',
          summary: 'Sccussfully Saved',
          detail: p.message,
        });
      },
      (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Server Error',
          detail: 'Please Fill All Data.',
        });
      }
    );
  }

  //*? skills call server to save data
  SaveSkills() {
    this.skillsModel.userID = this.UserBasicInfo.userID;
    let gg: any[] = [];
    this.skillsModel.skills?.forEach((e) => {
      gg.push(this.keySkills.find((c) => c.name == e)?.id);
      this.skillsModel.skills = [];
      this.skillsModel.skills = gg as [];
    });
    console.log(this.skillsModel.skills);
    this.userser.EditSkills(this.skillsModel).subscribe(
      (p) => {
        this.displaykeyskills = false;
        location.reload();
        this.messageService.add({
          severity: 'success',
          summary: 'Sccussfully skill upload',
          detail: p.Message,
        });
      },
      (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Server Error',
          detail: 'Please Try to add item again',
        });
      }
    );
  }

  //*? Employment Histroy call server to save data
  SaveEmployement() {
    if (this.UserEmpArr.length == 0) {
      this.confirm1();
    }
    else{
      this.confirm2();
    }
  }

  private confirm1() {
    this.displayEmployment = false;
    this.confirmationService.confirm({
      message: 'You have to logout to save changes',
      header: 'Confirmation',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        console.log(sessionStorage.getItem('Strength'));
        debugger;
        this.UserEmp.userID = this.UserBasicInfo.userID;
        console.log(this.UserEmp);
        this.userser.EditResume(this.UserEmp).subscribe((a) => {
          //location.reload();
          this.logout();
        });
        this.messageService.add({
          severity: 'info',
          summary: 'Confirmed',
          detail: 'Added succesfully',
        });
      },
      reject: (type) => {
        ////
      },
    });
  }
  private confirm2() {
    this.displayEmployment = false;
    this.UserEmp.userID = this.UserBasicInfo.userID;
    console.log(this.UserEmp);
    this.userser.EditResume(this.UserEmp).subscribe((a) => {
      location.reload();
      //this.logout();
    });
    this.messageService.add({
      severity: 'info',
      summary: 'Confirmed',
      detail: 'Added succesfully',
    });
  }
  logout() {
    debugger;
    sessionStorage.clear();
    this.router.navigateByUrl('/login');
  }

  DeleteEmp(value: number) {
    this.userser.DeleteEmpHistroy(value).subscribe(
      (p) => {
        this.displayEducation = false;
        this.messageService.add({
          severity: 'success',
          summary: 'Deleted',
        });
        this.UserEmpArr= this.UserEmpArr.filter(a=>a.empuserID != value )
      },
      (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Server Error',
          detail: 'Please Try to add item again',
        });
      }
    );
  }

  //*? EducationHistory call server to save data
  SaveEducation() {
    console.log(this.UserEdu.typeOfEducation)
    this.UserEdu.userID = this.UserBasicInfo.userID;
    this.UserEdu.typeOfEducation = this.typeEdu.find(
      (c) => c.name == this.UserEdu.typeOfEducation
    )?.id;
    this.UserEdu.university = this.AllCompanies.find(
      (c) => c.companyName == this.UserEdu.university
    )?.companyID;
    this.userser.EditEducation(this.UserEdu).subscribe(
      (p) => {
        this.displayEducation = false;
        this.messageService.add({
          severity: 'success',
          summary: 'Sccussfully Saved',
          detail: p.message,
        });
        location.reload();
      },
      (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Server Error',
          detail: 'Please Try to add item again',
        });
      }
    );
  }
  DeleteEdu(value: number) {
    this.userser.DeleteEduHistroy(value).subscribe(
      (p) => {
        this.displayEducation = false;
        this.messageService.add({
          severity: 'success',
          summary: 'Sccussfully Education De;eted',
        });
        this.UserEduArr= this.UserEduArr.filter(a=>a.eduuserID != value )
      },
      (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Server Error',
          detail: 'Please Try to add item again',
        });
      }
    );
  }
  //? social Media
  SaveSocialMedia() {
    this.UserSocialMedia.userID = this.UserBasicInfo.userID;
    this.userser.EditSocialMedia(this.UserSocialMedia).subscribe(
      (p) => {
        this.displaySocialMedia = false;
        this.messageService.add({
          severity: 'success',
          summary: 'Sccussfully skill upload',
          detail: p.message,
        });
        // location.reload();
        var selectusersc = { type: '', url: '' };
        selectusersc.url = this.UserSocialMedia.url as string;
        selectusersc.type = this.UserSocialMedia.url?.split('.')[1] as string;
        this.sampleEmpSC.push(selectusersc)
      },
      (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Server Error',
          detail: 'URL Type is incorrect',
        });
      }
    );
  }
  Deleteprofile(value:any){
    console.log(value,typeof(value));
    
    this.userser.DeleteonlineProfile(parseInt(value)).subscribe(
      (p) => {
        this.displayEducation = false;
        this.messageService.add({
          severity: 'success',
          summary: 'Sccussfully Deleted',
        });
        location.reload();
      },
      (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Server Error',
          detail: 'Please Try to add item again',
        });
      }
    );
  }
}
