import { ComponentFixture, TestBed } from '@angular/core/testing';
import {HttpClientTestingModule, HttpTestingController}
       from '@angular/common/http/testing';
import { ListComponent } from './list.component';
import { Company } from 'src/app/shared/Models/company.model';
import { CompanyService } from '../company.service';
import { Observable, of } from 'rxjs';
import { MockCompany } from '../mock-company';
import { HttpClientModule } from '@angular/common/http';
import { RouterTestingModule } from '@angular/router/testing';
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

describe('ListComponent', () => {
  let component: ListComponent;
  let fixture: ComponentFixture<ListComponent>;
  let companyService: CompanyService;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListComponent ],
      imports : [HttpClientModule,RouterTestingModule],
      providers: [
        CompanyService
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    companyService = TestBed.get(CompanyService);

    spyOn(companyService, 'getAllCompany').and.returnValue(of(COMPANY_OBJECT));
  });

  it('should create', () => {
    expect(component).toBeTruthy();
    component.ngOnInit();
    expect(component.comp).toBe(COMPANY_OBJECT);
    //spyOn(companyService, 'getAllCompany').and.callThrough();
  });






});


