import { PrecoListagemComponent } from './../preco-listagem-dialog/preco-listagem.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BrowserModule } from '@angular/platform-browser';
import { MatTableModule } from '@angular/material/table';




@NgModule({
  declarations: [PrecoListagemComponent],
  imports: [
    CommonModule,
    BrowserModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule

  ]
})
export class PrecoListagemModule { }
