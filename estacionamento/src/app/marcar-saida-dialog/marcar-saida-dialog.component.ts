import { EstacionamentoAtualizar } from './../entidades/estacionamento.service';
import { DialogData } from './../marcar-entrada-dialog/marcar-entrada-dialog.component';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import {
  EstacionamentoLista,
  EstacionamentoService,
} from '../entidades/estacionamento.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-marcar-saida-dialog',
  templateUrl: './marcar-saida-dialog.component.html',
  styleUrls: ['./marcar-saida-dialog.component.css'],
})
export class MarcarSaidaDialogComponent {
  public placa = '';
  public fg!: FormGroup;
  estacionamento!: EstacionamentoLista;

  constructor(
    private fb: FormBuilder,
    private estacionamentoService: EstacionamentoService,
    public dialogRef: MatDialogRef<MarcarSaidaDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}
  ngOnInit() {
    this.fg = this.fb.group({
      dataSaida: new Date(Date.now()),
      placa: '',
    });
  }

  atualizar() {
    this.dialogRef.close(this.fg.value);
  }

  cancelar() {
    this.dialogRef.close();
  }
}
