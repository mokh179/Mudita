import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { Category } from 'src/app/_models/Category/category';
import { CategoryService } from 'src/app/_service/Category/category.service';

@Component({
  selector: 'app-admin-manage-category',
  templateUrl: './admin-manage-category.component.html',
  styleUrls: ['./admin-manage-category.component.css']
})
export class AdminManageCategoryComponent implements OnInit {
  cp:number=1;
  allcategories:Category[]=[];
  AddCategory:Category= new Category();
  EditCategory:Category= new Category();
  DeleteCategory:Category= new Category();
  catId:any;
  date1!: Date;
  x:boolean=true;
  HideEditBtn:boolean=false;
  HideSaveBtn:boolean=true;
  editField!: string;
  show:any;


  constructor(
    private confirmationService : ConfirmationService ,
    private categoryService:CategoryService) { }

    add() {
      this.categoryService.AddCategory(this.AddCategory).subscribe(a=>{
        location.reload();
       });
    }

  changeValue( event: any) {
    this.editField = event.target.textContent;
  }



onEdit(){
  this.x=false;
  this.HideEditBtn=true;
  this.HideSaveBtn=false;
}
Onclick(value:any){

  this.catId=value;
  return this.catId
}
onSave(){
  this.EditCategory.cat_Id=this.catId;
  this.categoryService.EditCategory(this.EditCategory).subscribe(a=>{
      this.x=true;
      this.HideEditBtn=false;
      this.HideSaveBtn=true;
      location.reload();
    });
}


  confirm(event: Event,id:number) {
    this.confirmationService.confirm({
      target: event.target,
        message: 'Are you sure that you want to Delete this Data ?',
        icon: 'pi pi-exclamation-triangle',

        accept: () => {
            //confirm action
            this.categoryService.DeleteCategory(id).subscribe(a=>{
              //console.log(a);
              location.reload()
            });
        },
        reject: () => {
            //reject action
        }
    });
}
  ngOnInit(): void {
    this.categoryService.GetAllCategories().subscribe(a=>{
      this.allcategories=a;
    })

  }

}
