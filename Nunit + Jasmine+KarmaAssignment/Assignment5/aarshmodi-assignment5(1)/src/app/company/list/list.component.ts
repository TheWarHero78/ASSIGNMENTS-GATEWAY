import { Component, OnInit } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { Company } from 'src/app/shared/Models/company.model';
import { CompanyService } from '../company.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  comp: any=[];

  constructor(http: HttpClient,
    private router: Router,
    private companyService: CompanyService) {
  }

  ngOnInit(): void {

    this.loadScript('../assets/js/datatables-demo.js');
    this.loadScript('../assets/js/scripts.js');

    this.companyService.getAllCompany().subscribe({
      next: (data) => {
        console.log('data',data);
        this.comp = data;

        console.log(this.comp);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }


  addCompanyDetails(){
    this.router.navigateByUrl('add-edit');
  }

  editCompany(comp: Company) {
   // console.log("data from table "+comp);
    //console.log(comp);
    this.router.navigateByUrl('add-edit', { state: { comp } });
  }

  showCompanyDetails(comp: Company) {
    console.log(comp);
    this.router.navigateByUrl('details', { state: { comp } });
  }

  removeCompanyDetails(comp: Company) {
    console.log(comp);
    this.companyService.removeCompany(comp).subscribe({
      next: (data) => {
        console.log(data);
        this.router.navigate(['']);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  private loadScript(url: string) {
    const body = <HTMLDivElement> document.body;
    const script = document.createElement('script');
    script.innerHTML = '';
    script.src = url;
    script.async = false;
    script.defer = true;
    body.appendChild(script);
    }

}









