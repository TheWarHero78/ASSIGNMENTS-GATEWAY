import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyRoutingModule } from './company-routing.module';
import { AddEditComponent } from './add-edit/add-edit.component';
import { DetailsComponent } from './details/details.component';
import { ListComponent } from './list/list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { DataTablesModule } from 'angular-datatables';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'
@NgModule({
  declarations: [AddEditComponent, DetailsComponent, ListComponent],
  imports: [
    CommonModule,
    CompanyRoutingModule,FormsModule,
    ReactiveFormsModule,

    FontAwesomeModule,
    FontAwesomeModule
  ]
})
export class CompanyModule { }
