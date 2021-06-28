import { Component, OnInit } from '@angular/core';
import { NavbarService } from '../_service/navbarandfooter/navbar&footer.service';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css']
})
export class NotFoundComponent implements OnInit {

  constructor(private nav:NavbarService) { }

  ngOnInit(): void {
    this.nav.hide();
  }

}
