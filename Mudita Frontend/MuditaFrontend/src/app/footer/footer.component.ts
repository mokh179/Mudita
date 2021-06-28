import { Component, OnInit } from '@angular/core';
import { NavbarService } from '../_service/navbarandfooter/navbar&footer.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  constructor(public nav : NavbarService) { }

  ngOnInit(): void {
    this.nav.show();
  }

}
