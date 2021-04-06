import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const CompanyModule = () => import('./company/company.module').then((x) => x.CompanyModule);
const routes: Routes = [ { path: '',loadChildren: CompanyModule }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
