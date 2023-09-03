import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { EstacionamentoService } from '../entidades/estacionamento.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-marcar-entrada-dialog',
  templateUrl: './marcar-entrada-dialog.component.html',
  styleUrls: ['./marcar-entrada-dialog.component.css'],
})
export class MarcarEntradaDialogComponent implements OnInit {
  public placa = '';
  public fg!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private estacionamentoService: EstacionamentoService,
    public dialogRef: MatDialogRef<MarcarEntradaDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
  ngOnInit() {
    this.fg = this.fb.group({
      dataEntrada: new Date(Date.now()),
      placa: [''],
    });
  }

  public adicionar() {
    this.dialogRef.close(this.fg.value);
  }
  public cancelar() {
    this.dialogRef.close();
  }
}
export interface DialogData {
  dataEntrada: Date;
  placa: string;
}
