import { AnimationQueryMetadata } from '@angular/animations';
import { prepareEventListenerParameters } from '@angular/compiler/src/render3/view/template';
import { conditionallyCreateMapObjectLiteral } from '@angular/compiler/src/render3/view/util';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Company } from 'src/app/shared/Models/company.model';
import { Companybranch } from 'src/app/shared/Models/companybranch.model';
import { CompanyService } from '../company.service';

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css']
})
export class AddEditComponent implements OnInit {
  defaults: Company = new Company();
  company: Company;
  fbranch: FormArray;
  companyForm: FormGroup;
  addingFailed: boolean = false;
  message: string;
  loading: boolean = false;

  comp : any;
  operationType: number;
  constructor(private router: Router, private companyService: CompanyService, private fb: FormBuilder) {
    if (!this.router.getCurrentNavigation().extras.state) {
      this.operationType = 0;
    } else {
      this.operationType = 1;
      console.log(this.router.getCurrentNavigation().extras.state.comp);
      this.defaults = this.router.getCurrentNavigation().extras.state.comp;
      console.log(this.defaults);
    }
  }

  ngOnInit(): void {
    this.loadScript('../assets/js/datatables-demo.js');
    this.loadScript('../assets/js/scripts.js');
    this.fbranch
    this.companyForm = this.fb.group({

      CID: [this.defaults.id, [Validators.required, Validators.minLength(1)]],
      Email: [this.defaults.email, [Validators.required, Validators.email]],
      Name: [this.defaults.name, [Validators.required, Validators.minLength(3)]],
      TotalEmp: [this.defaults.totalEmployee, Validators.required],
      Address: [this.defaults.address, [Validators.required, Validators.minLength(15)]],
      isCompanyActive: [this.defaults.isCompanyActive, Validators.required],
      TotalBranch: [this.defaults.totalBranch],
      branches: this.fb.array([this.createBranch()])
    });
    this.fbranch = this.companyForm.get('branches') as FormArray;
    this.setBranch();
  }

  setBranch(): void {
    if (this.operationType == 1) {
      console.log("hello");
      this.defaults.companyBranch.forEach((element, index) => {
        let z = this.fb.group({
          branchId: [element.branchId, Validators.compose([Validators.required])],
          branchName: [element.branchName, Validators.compose([Validators.required])],
          address: [element.address, Validators.compose([Validators.required])]
        });
        this.fbranch.setControl(index, z);

      });
      this.fbranch = this.companyForm.get('branches') as FormArray;
    }
  }
  createBranch(): FormGroup {
    return this.fb.group({
      branchId: ['', Validators.compose([Validators.required])],
      branchName: ['', Validators.compose([Validators.required])],
      address: ['', Validators.compose([Validators.required])]
    });
  }
  get contactFormGroup() {
    return this.companyForm.get('branches') as FormArray;
  }

  addBranch(): void {
    let cb = new Companybranch();
    this.fbranch.push(this.createBranch());
  }

  removeBranch(index) {
    this.fbranch.removeAt(index);
  }
  getContactsFormGroup(index): FormGroup {
    this.fbranch = this.companyForm.get('branches') as FormArray;
    const formGroup = this.fbranch.controls[index] as FormGroup;
    return formGroup;
  }
  getadd(): void {
    console.log(this.companyForm.value);
  }

  get f() {
    return this.companyForm.controls;
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
  save() {


    this.company={
      id:this.f.CID.value,
      email:this.f.Email.value,
      name:this.f.Name.value,
      totalEmployee:this.f.TotalEmp.value,
      address:this.f.Address.value,
      isCompanyActive:this.f.isCompanyActive.value,
      totalBranch:this.f.TotalBranch.value,
      companyBranch:this.f.branches.value
    }
    if(this.operationType==0){
    this.companyService.addNewCompany(this.company).subscribe({
      next: (data) => {
        console.log(data);
        this.router.navigate(['']);
      },
      error: (error) => {
        console.log(error);
      },
    });
    }else{
      this.companyService.editCompanyDetails(this.company).subscribe({
        next: (data) => {
          console.log(data);
          this.router.navigate(['']);
        },
        error: (error) => {
          console.log(error);
        },
      });
    }
  }
}




