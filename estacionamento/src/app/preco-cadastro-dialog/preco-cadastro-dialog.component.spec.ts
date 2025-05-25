import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrecoCadastroDialogComponent } from './preco-cadastro-dialog.component';

describe('PrecoCadastroDialogComponent', () => {
  let component: PrecoCadastroDialogComponent;
  let fixture: ComponentFixture<PrecoCadastroDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PrecoCadastroDialogComponent]
    });
    fixture = TestBed.createComponent(PrecoCadastroDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
