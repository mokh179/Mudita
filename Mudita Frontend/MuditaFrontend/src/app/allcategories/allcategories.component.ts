import { Component, OnInit } from '@angular/core';
import { Category } from '../_models/Category/category';
import { CategoryService } from '../_service/Category/category.service';

@Component({
  selector: 'app-allcategories',
  templateUrl: './allcategories.component.html',
  styleUrls: ['./allcategories.component.css']
})
export class AllcategoriesComponent implements OnInit {
  cp:number=1;
categoryList : Category[] =[];
  constructor(public categoryservice:CategoryService) { }

  ngOnInit(): void {
    this.categoryservice.GetAllCategories().subscribe(a=>{
      this.categoryList=a;
    })
  }
}
