import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from 'src/app/_models/Category/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  GetAllCategories(){
      return this.http.get<Category[]>('https://localhost:44352/api/Utilities/Category');
  }

  AddCategory(CategoryList:Category){

    return this.http.post('https://localhost:44352/api/Admin/AddCategory',CategoryList);

  }
  EditCategory(CategoryList:Category){

    return this.http.put('https://localhost:44352/api/Admin/EditCategory',CategoryList);

  }
  DeleteCategory(id:any){
   return this.http.delete('https://localhost:44352/api/Admin/DeleteCategory?'+'id='+id);
  }
 constructor(private http:HttpClient) { }
}
