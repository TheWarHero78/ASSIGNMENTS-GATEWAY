import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HostComponentComponent } from './host-component.component';

describe('HostComponentComponent', () => {
  let component: HostComponentComponent;
  let fixture: ComponentFixture<HostComponentComponent>;
  let element: HTMLElement;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HostComponentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HostComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    element=fixture.nativeElement.querySelector('p');
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });


  it("paragraph should contain default message", () => {
    expect(element.innerText).toContain("not specified");
  });

  it("paragraph should contain phone number", () => {
    component.phone = "0021000111";

    fixture.detectChanges();

    expect(element.innerText).toContain("0021007760111");
  });


});
