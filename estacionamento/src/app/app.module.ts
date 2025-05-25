import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MarcarEntradaDialogComponent } from './marcar-entrada-dialog/marcar-entrada-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MarcarEntradaDialogModule } from './marcar-entrada-dialog/marcar-entrada-dialog.module';
import { MatInputModule } from '@angular/material/input';
import { MarcarSaidaDialogComponent } from './marcar-saida-dialog/marcar-saida-dialog.component';
import { MarcarSaidaDialogModule } from './marcar-saida-dialog/marcar-saida-dialog.module';
import { ToastrModule } from 'ngx-toastr';
import { PrecoListagemComponent } from './preco-listagem-dialog/preco-listagem.component';
import { PrecoListagemModule } from './preco-listagem-dialog/preco-listagem.module';
import { PrecoCadastroDialogComponent } from './preco-cadastro-dialog/preco-cadastro-dialog.component';

@NgModule({
  declarations: [AppComponent, PrecoCadastroDialogComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    CommonModule,
    MatTableModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MarcarEntradaDialogModule,
    MatInputModule,
    MarcarSaidaDialogModule,
    PrecoListagemModule,
    ToastrModule.forRoot({
      timeOut: 5000, // 5 seconds
      closeButton: false,
      progressBar: true,
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
