import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditComponent } from './add-edit/add-edit.component';
import { DetailsComponent } from './details/details.component';
import { ListComponent } from './list/list.component';
const routes: Routes = [{
  path: '',
   component:ListComponent},
   { path: 'add-edit', component: AddEditComponent },
   { path: 'details', component: DetailsComponent },
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
