import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Company } from 'src/app/shared/Models/company.model';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  company: Company = new Company();
  constructor(private router: Router) {
    console.log(this.router.getCurrentNavigation().extras.state.comp);
    this.company = this.router.getCurrentNavigation().extras.state.comp;
   }

  ngOnInit(): void {

  }

}
