import { AdminManageUserComponent } from './Admin/admin-manage-user/admin-manage-user.component';
import { InterviewQuesComponent } from './interview-ques/interview-ques.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes, CanActivate, ExtraOptions } from '@angular/router';

import { LoginGuard } from './_Gurad/login.guard';
import { NotFoundComponent } from './not-found/not-found.component';
import { RegisterComponent } from './Account/register/register.component';
import { LoginComponent } from './Account/login/login.component';
import { HomeComponent } from './home/home.component';
import { SearchCompareComponent } from './compare/search-compare/search-compare.component';
import { CompareResultComponent } from './compare/compare-result/compare-result.component';
import { CompanyPRofileComponent } from './Company/company-profile/company-profile.component';
import { PostajobComponent } from './Company/postajob/postajob.component';
import { ManageJobsComponent } from './Company/manage-jobs/manage-jobs.component';
import { ResumeComponent } from './resume/resume.component';
import { AboutUsComponent } from './info/about-us/about-us.component';
import { AllcategoriesComponent } from './allcategories/allcategories.component';
import { UserProfileComponent } from './user/user-profile/user-profile.component';
import { UserAppliedVacancyComponent } from './user/user-applied-vacancy/user-applied-vacancy.component';
import { UserResumeComponent } from './user/user-resume/user-resume.component';
import { ChangePasswordComponent } from './user/change-password/change-password.component';
import{ViewJobsComponent} from './Vacancy/view-jobs/view-jobs.component';
import { AllCompaniesComponent } from './all-companies/all-companies.component';
import { CompanyDetailsComponent } from './Company/company-details/company-details.component';
import { GiveRateComponent } from './give-rate/give-rate.component';

import { PublicUserProfileComponent } from './user/public-user-profile/public-user-profile.component';
import { AdminDashboardComponent } from './Admin/admin-dashboard/admin-dashboard.component';
import { AdminSidebarComponent } from './Admin/admin-sidebar/admin-sidebar.component';
import { DetailedCompanyComponent } from './Company/DetailedCompany/detailed-company/detailed-company.component';
import { AdminManageCityComponent } from './Admin/admin-manage-city/admin-manage-city.component';
import { AdminManageCountryComponent } from './Admin/admin-manage-country/admin-manage-country.component';
import { AdminManageCompanyComponent } from './Admin/admin-manage-company/admin-manage-company.component';
import { AdminManageCategoryComponent } from './Admin/admin-manage-category/admin-manage-category.component';
import { AdminManageVacancyComponent } from './Admin/admin-manage-vacancy/admin-manage-vacancy.component';
import { UserQuestionComponent } from './user/user-question/user-question/user-question.component';
import { UserSlidebarComponent } from './user/user-slidebar/user-slidebar.component';
// import { UserCreatecompanyComponent } from './user/user-createcompany/user-createcompany.component';
import { CreateCompanyProfileComponent } from './user/create-company-profile/create-company-profile.component';
import { PublicProfileComponent } from './Company/public-profile/public-profile.component';
import { ReviewComponent } from './Company/review/review.component';
import { ShowCopanyGuard } from './_Gurad/show-copany.guard';


const routes: Routes = [
  {path : "login" , component:LoginComponent },
  {path :"home" , component:HomeComponent },
  {path:"" , component:HomeComponent},
  {path:"companiesCategory/:id3",component:AllCompaniesComponent  ,canActivate:[LoginGuard]},
  {path:"companiesCountry/:id",component:AllCompaniesComponent ,canActivate:[LoginGuard]},
  {path:"companiesCoutCat/:id/:id3",component:AllCompaniesComponent ,canActivate:[LoginGuard]},
  {path:"companiesCoutCity/:id/:id2",component:AllCompaniesComponent,canActivate:[LoginGuard]},
  {path:"company/companydetails/:id",component:CompanyDetailsComponent,canActivate:[LoginGuard],children:[
    {path:"",component:PublicProfileComponent},
    {path:"Review",component:ReviewComponent}
  ]},
  {path:"companies",component:AllCompaniesComponent,canActivate:[LoginGuard]},
  {path:"companies/:id/:id2/:id3",component:AllCompaniesComponent,canActivate:[LoginGuard]},
  {path:"register" , component:RegisterComponent},
  {path:"searchcompare",component:SearchCompareComponent,canActivate:[LoginGuard]},
  {path:"compareresult/:firstselect/:secondselect",component:CompareResultComponent,canActivate:[LoginGuard]},
  {path:"company/companyprofile/:id" , component:CompanyPRofileComponent,canActivate:[LoginGuard],children:[
    {path:"",component:DetailedCompanyComponent},
    {path:"postJob",component:PostajobComponent},
    {path:"manageJob",component:ManageJobsComponent,children:[
      {path:"resume/:id" , component:ResumeComponent}
    ]},
  ]},
  {path:"register/admin" , component:RegisterComponent },
  {path:"register" , component:RegisterComponent },
  {path:"searchcompare",component:SearchCompareComponent , canActivate:[LoginGuard]},
  {path:"compareresult/:id1/:id2",component:CompareResultComponent,canActivate:[LoginGuard] },
  {path:"aboutus",component:AboutUsComponent },
  {path:"interviewques" , component:InterviewQuesComponent,canActivate:[LoginGuard]},
  {path:"allCategories",component:AllcategoriesComponent ,canActivate:[LoginGuard]},
  {path : "user/:id" , component:UserSlidebarComponent ,canActivate:[LoginGuard] ,children:[
    {path:"profile", component:UserProfileComponent},
    {path:"", component:UserProfileComponent},
    {path:"vacancy", component:UserAppliedVacancyComponent},
    {path:"question", component:UserQuestionComponent},
    {path:"ChangePassword", component:ChangePasswordComponent},
    {path : "CreateCompany" , component:CreateCompanyProfileComponent ,canActivate:[LoginGuard]},
    ]},
  {path : "userresume/:id" , component:UserResumeComponent ,canActivate:[LoginGuard]},
  {path : "publicuser/:id" , component:PublicUserProfileComponent,canActivate:[LoginGuard]},
  {path : "viewjobs" , component:ViewJobsComponent ,canActivate:[LoginGuard] },
  {path : "Dashboard" , component:AdminSidebarComponent ,canActivate:[LoginGuard], children:[
    {path:"",component:AdminDashboardComponent},
    {path : "adminuser" , component:AdminManageUserComponent },
    {path : "admincity" , component:AdminManageCityComponent },
    {path : "admincountry" , component:AdminManageCountryComponent },
    {path : "admincompany" , component:AdminManageCompanyComponent },
    {path : "admincategory" , component:AdminManageCategoryComponent },
    {path : "adminvacancy" , component:AdminManageVacancyComponent },


  ] },
  
  {path :"**" , component:NotFoundComponent}
];

export const RoutingComponents = [
  LoginComponent,
  HomeComponent,
  RegisterComponent,
  SearchCompareComponent,
  CompareResultComponent,
  CompanyPRofileComponent,
  PostajobComponent,
  ManageJobsComponent,
  ResumeComponent,
  AboutUsComponent,
  AllcategoriesComponent,
  UserProfileComponent,
  UserAppliedVacancyComponent,
  UserResumeComponent,
  ChangePasswordComponent,
  NotFoundComponent,
  UserQuestionComponent,


  CompanyDetailsComponent,
  PublicUserProfileComponent,
  ViewJobsComponent,
  AllCompaniesComponent,
  GiveRateComponent,
  AdminDashboardComponent,
  AdminSidebarComponent,
  AdminManageUserComponent,
  AdminManageCityComponent,
  AdminManageCountryComponent,
  AdminManageCategoryComponent,
  AdminManageCompanyComponent,
  AdminManageVacancyComponent,


]

const routerOptions: ExtraOptions = {
  useHash: false,
  anchorScrolling: 'enabled',
  // ...any other options you'd like to use
};

@NgModule({
  imports: [RouterModule.forRoot(routes,routerOptions)],
exports: [RouterModule]
})
export class AppRoutingModule { }
