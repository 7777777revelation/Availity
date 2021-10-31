import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrationFormComponentComponent } from './registration-form-component.component';

describe('RegistrationFormComponentComponent', () => {
  let component: RegistrationFormComponentComponent;
  let fixture: ComponentFixture<RegistrationFormComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistrationFormComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrationFormComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
