import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { CompanyService } from './company.service';
import { Company } from '../shared/Models/company.model';
import { of } from 'rxjs/internal/observable/of';

describe('CompanyService', () => {
  let service: CompanyService;
  let httpMock: HttpTestingController;
  let comp: Company;
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    service = TestBed.inject(CompanyService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should have a service instance', () => {
    expect(service).toBeDefined();
  });

  it('getCompany should send a GET request and return a single item', (done) => {

    // Arrange
    comp = new Company();
    comp.id = "43";

    // Act
    service.getCompany(comp).subscribe(
      (item: Company) => { expect(item).toBeDefined(); done(); },
      (error) => { fail(error.message) }
    );

    //Assert
    const testRequest = httpMock.expectOne('http://localhost:3000/companies/43');
    expect(testRequest.request.method).toBe('GET');
    testRequest.flush({
      id: "43",
      email: "test@gmail.com",
      name: "gdg",
      totalEmployee: 3,
      address: "34 t4veywu5jyyjyjyfu",
      isCompanyActive: "No",
      totalBranch: null,
      companyBranch: [
        {
          branchId: "g",
          branchName: "434",
          address: "454"
        }

      ]
    });
  });

  it('addNewCompany should send a POST request and return the newly created item', (done) => {

    // Arrange
    const item: Company = {
      id: "8888",
      email: "test@gmail.com",
      name: "gdg",
      totalEmployee: 3,
      address: "34 t4veywu5jyyjyjyfu",
      isCompanyActive: false,
      totalBranch: null,
      companyBranch: [
        {
          branchId: 545454,
          branchName: "434",
          address: "454"
        }
      ]
    }

    // Act
    service.addNewCompany(item).subscribe(
      (data: Company) => {
        expect(data).toBeDefined();
        expect(data).toEqual(item);
        done()
      },
      (error) => {
        fail(error.message)
      }
    );

    // Assert
    const testRequest = httpMock.expectOne('http://localhost:3000/companies');
    expect(testRequest.request.method).toBe('POST');
    testRequest.flush(item);

  });


  it('should not invoke the error throwing function since we mocked it', () => {
    // Arrange
    const emptyFn = () => { };
    const spy = spyOn(service, 'throwingError').and.callFake(emptyFn);

    // Act
    service.throwingError();

    // Assert
    expect(spy).toHaveBeenCalled();
  });

  const company: Company =

  {
    id: "43",
    email: "aarsh@gmail.com",
    name: "aarsh",
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



  it('should return the mocked data in the subscribe', () => {
    // Assert
    const spy = spyOn(service, 'getAllCompany').and.returnValue(
      of(company)
    );

    // Act
    service.getAllCompany().subscribe(data => {
      expect(data).toBe(company);
    });

    // Assert
    expect(spy).toHaveBeenCalled();
  });


  it('should update the company data', (done) => {

     // Arrange
     const item: Company = {
      id: "43",
      email: "test@gmail.com",
      name: "aarsh",
      totalEmployee: 3,
      address: "34 t4veywu5jyyjyjyfu",
      isCompanyActive: false,
      totalBranch: null,
      companyBranch: [
        {
          branchId: 545454,
          branchName: "434",
          address: "454"
        }
      ]
    }
    const changes: Partial<Company> =
      { name: "aarsh" };

    const spy = spyOn(service, 'editCompanyDetails').and.returnValue(of(company));

    service.editCompanyDetails("43", changes).subscribe(
      (comp:Company)  => {
        expect(comp).toBeDefined();
        expect(comp.id).toBe("43");
        expect(comp.name).toBe("aarsh");

      },
        (error) => {
          fail(error.message)
        });



      // Assert
      const testRequest = httpMock.expectOne('http://localhost:3000/companies/43');
      expect(testRequest.request.method).toBe('PUT');
      testRequest.flush(item);
  })

});

