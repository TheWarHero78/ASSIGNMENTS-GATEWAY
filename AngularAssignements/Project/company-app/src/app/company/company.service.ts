import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Company } from '../shared/Models/company.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private REST_API_SERVER = "http://localhost:3000";

  constructor(private http: HttpClient) {}



  getAllCompany(){
    return this.http.get<Company>(this.REST_API_SERVER+'/companies');
  }

  getCompany(companies:Company){
    return this.http.get<Company>(this.REST_API_SERVER+'/companies/'+companies.id);
  }

  removeCompany(companies:Company){
    return this.http.delete<Company>(this.REST_API_SERVER+'/companies/'+companies.id);
  }


  addNewCompany(companies:Company){
    console.log(companies);
    return this.http.post<Company>(this.REST_API_SERVER+'/companies',companies);
  }
  editCompanyDetails(companies:Company){
    console.log(companies);
    return this.http.put<Company>(this.REST_API_SERVER+'/companies/'+companies.id,companies);
  }

}
