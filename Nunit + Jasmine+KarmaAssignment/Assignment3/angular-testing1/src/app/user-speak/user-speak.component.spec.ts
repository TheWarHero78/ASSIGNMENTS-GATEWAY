import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserSpeakComponent } from './user-speak.component';

describe('UserSpeakComponent', () => {
  let component: UserSpeakComponent;
  let fixture: ComponentFixture<UserSpeakComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserSpeakComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserSpeakComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });


  it('should say hello', () => {
    // Arrange
    const sayHelloSpy = spyOn(component.speak, 'emit');
    // Act
    component.sayHello();
    // Assert
    expect(sayHelloSpy).toHaveBeenCalled();
    expect(sayHelloSpy).toHaveBeenCalledWith('Hello');
});

it('should say goodbye', () => {
    // Arrange
    const sayGoodbyeSpy = spyOn(component.speak, 'emit');
    // Act
    component.sayGoodbye();
    // Assert
    expect(sayGoodbyeSpy).toHaveBeenCalled();
    expect(sayGoodbyeSpy).toHaveBeenCalledWith('Goodbye hello');
});
});
