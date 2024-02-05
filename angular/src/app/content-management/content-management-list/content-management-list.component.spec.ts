import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentManagementListComponent } from './component-management-list.component';

describe('ComponentManagementListComponent', () => {
  let component: ComponentManagementListComponent;
  let fixture: ComponentFixture<ComponentManagementListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ComponentManagementListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ComponentManagementListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
