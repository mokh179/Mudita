import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NavbarService {
  isLoggedIn:boolean=false;
  visible: boolean=false;

  constructor() {  }


  check(){
    const token = sessionStorage.getItem("jwt");

    if(token ==null){
      return this.isLoggedIn=false;
    }
    else
    return this.isLoggedIn=true;
  }
  hide() {
    setTimeout(()=>{
    this.visible = false
  });
}

  show() {
    setTimeout(()=>{
    this.visible = true
  });
  }


}
