import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/_service/company/company.service';
import { ActivatedRoute } from '@angular/router';
import { Rate } from './../_models/company/rate';

@Component({
  selector: 'app-rate',
  templateUrl: './rate.component.html',
  styleUrls: ['./rate.component.css']
})
export class RateComponent implements OnInit {

  constructor(private ser:CompanyService,private ac:ActivatedRoute) { }
   ratingModel:Rate=new Rate();
  ngOnInit(): void {
    // this.ac.params.subscribe(a=>{this.ratingModel.Company_Id=a.id})
  }

}
