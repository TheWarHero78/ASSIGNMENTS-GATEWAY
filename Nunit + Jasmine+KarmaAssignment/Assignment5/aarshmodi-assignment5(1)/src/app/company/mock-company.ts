import { Observable } from 'rxjs';
import { of } from "rxjs";
import { Company } from '../shared/Models/company.model';
const COMPANY_OBJECT: Company = {
  id: "43",
  email: "aarsh@gmail.com",
  name: "gdg",
  totalEmployee: 3,
  address: "34 t4veywu5jyyjyjyfu",
  isCompanyActive: false,
  totalBranch: null,
  companyBranch: [
    {
      branchId: 55,
      branchName: "434",
      address: "454"
    },
    {
      branchId: 6565,
      branchName: "hghg",
      address: "hgfh"
    }
  ]
}
export class MockCompany {

  public getAllCompany(): Observable<Company> {
    return of(COMPANY_OBJECT);
  }
}
