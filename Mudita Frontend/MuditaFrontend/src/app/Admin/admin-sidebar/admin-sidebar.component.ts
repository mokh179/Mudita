import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-sidebar',
  templateUrl: './admin-sidebar.component.html',
  styleUrls: ['./admin-sidebar.component.css']
})
export class AdminSidebarComponent implements OnInit {
 userName:any; 

  constructor(private route:Router) { }

  ngOnInit(): void {
    this.userName=sessionStorage.getItem('user')
  }
  
  logout(){
    sessionStorage.clear(); 
    this.route.navigateByUrl("/login")
  }
}
