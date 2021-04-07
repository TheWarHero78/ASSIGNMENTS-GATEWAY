import { TestBed, async, flush, tick } from '@angular/core/testing';
import { Component } from '@angular/core';
import { ComponentFixture, fakeAsync } from '@angular/core/testing';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { UserLoginComponent } from './user-login.component';
;

describe('UserLoginComponent', () => {
  let component: UserLoginComponent;
  let fixture: ComponentFixture<UserLoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
      ],
      declarations: [UserLoginComponent],
      providers: [
        HttpClient,
      ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should demonstrate isolated testing behavior for async with promises', fakeAsync(() => {
    component.authenticateUser().then(() => {
      expect(component.userLoginAttemptCount).toBe(3);
    });

    component.authenticateUser();

    component.authenticateUser();
  }));

  it('should demonstrate isolated testing behavior for fakeAsync with promises', fakeAsync(() => {

    // Simulate a few user login
    component.authenticateUser();
    component.authenticateUser();
    component.authenticateUser();
    component.authenticateUser();
    component.authenticateUser();
    expect(component.userLoginAttemptCount).toBe(0);
    flush();

    expect(component.userLoginAttemptCount).toBe(5);
    expect(component.isMaxAttempt).toBe(false);

    component.authenticateUser();
    flush();
    expect(component.userLoginAttemptCount).toBe(5);
    expect(component.isMaxAttempt).toBe(true);
  }));

  it('should demonstrate shallow testing behavior with a failing test for fakeAsync with promises', fakeAsync(() => {
    component.authenticateUser();

    // Trigger resolution for the promise
    flush();

    // Component should have correct value
    expect(component.userLoginAttemptCount).toBe(1);

    const htmlPreBinding = fixture.nativeElement.querySelector('h1');

    expect(htmlPreBinding.textContent).toBe('0');

    const htmlPostBonding = fixture.nativeElement.querySelector('h1');

    expect(htmlPostBonding.textContent).toBe('1');
  }));

  it('should demonstrate shallow testing behavior for fakeAsync with promises', fakeAsync(() => {
    component.authenticateUser();

    // Trigger resolution for the promise
    flush();

    // Component should have correct value
    expect(component.userLoginAttemptCount).toBe(1);

    const htmlPreBinding = fixture.nativeElement.querySelector('h1');

    expect(htmlPreBinding.textContent).toBe('0', 'data bindings not updated to to manual change detection');

    fixture.detectChanges();

    const htmlPostBonding = fixture.nativeElement.querySelector('h1');

    expect(htmlPostBonding.textContent).toBe('1', 'data bindings now up to date after manual change detection');
  }));

  it('should raise an exception for an HTTP request inside a fakeAsync method', fakeAsync(() => {
    component.checkStatus();
    flush();
  }));

  it('h1  via fakeAsync() and tick()', fakeAsync(() => {
    expect(fixture.nativeElement.querySelector('h1').textContent).toBe('0');

    fixture.detectChanges();

    expect(fixture.nativeElement.querySelector('h1').textContent).toBe('0');

    component.ngOnInit();

    component.authenticateUser();

    tick();

    fixture.detectChanges();

    expect(fixture.nativeElement.querySelector('h1').textContent).toBe('1');
  }));

});
