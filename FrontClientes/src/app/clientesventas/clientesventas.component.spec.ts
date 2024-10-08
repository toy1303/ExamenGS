import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientesventasComponent } from './clientesventas.component';

describe('ClientesventasComponent', () => {
  let component: ClientesventasComponent;
  let fixture: ComponentFixture<ClientesventasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientesventasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ClientesventasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
