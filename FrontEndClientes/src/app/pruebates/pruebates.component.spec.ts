import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PruebatesComponent } from './pruebates.component';

describe('PruebatesComponent', () => {
  let component: PruebatesComponent;
  let fixture: ComponentFixture<PruebatesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PruebatesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PruebatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
