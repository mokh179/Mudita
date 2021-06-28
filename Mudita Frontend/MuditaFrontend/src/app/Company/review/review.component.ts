import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/_service/company/company.service';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {
  cp:number=1;
  data: any 
  

  constructor(private com:CompanyService) { }
   cid:number=0;
  
  ngOnInit(): void {
    var folder = window.location.pathname;
    let URl = folder.split('/')
    this.cid= parseInt(URl[3])
    this.com.getreviews(this.cid).subscribe(a=>{
      this.data=a
      console.log(this.data)
    });
  }
  
}
