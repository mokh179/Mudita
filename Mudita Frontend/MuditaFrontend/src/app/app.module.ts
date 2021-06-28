import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { PrimengComponentsModule } from './_primeng-components/primeng-components.module';
import { AppRoutingModule, RoutingComponents } from './app-routing.module';
import { MessageService, ConfirmationService } from 'primeng/api';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';

import {CalendarModule} from 'primeng/calendar';
import {ChartModule} from 'primeng/chart';



import { AdminDashboardComponent } from './Admin/admin-dashboard/admin-dashboard.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { ConfirmPopupModule } from 'primeng/confirmpopup';

import { InterviewQuesComponent } from './interview-ques/interview-ques.component';
import { CreateCompanyProfileComponent } from './user/create-company-profile/create-company-profile.component';
import { UserSlidebarComponent } from './user/user-slidebar/user-slidebar.component';
import { DetailedCompanyComponent } from './Company/DetailedCompany/detailed-company/detailed-company.component';
import { ReviewComponent } from './Company/review/review.component';
import { PublicProfileComponent } from './Company/public-profile/public-profile.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    RoutingComponents,
    InterviewQuesComponent,
    CreateCompanyProfileComponent,
    UserSlidebarComponent,
    AdminDashboardComponent,

    DetailedCompanyComponent,
      ReviewComponent,
      PublicProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    NgxPaginationModule,
    ConfirmPopupModule,
    CalendarModule,
    ChartModule,
    PrimengComponentsModule // ?PrimeNG compenets implimnation

  ],
  providers: [MessageService,ConfirmationService],//* for the toast tool in primeng lib.
  bootstrap: [AppComponent]
})
export class AppModule { }
