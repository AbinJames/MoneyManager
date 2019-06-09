import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyNavComponent } from './my-nav/my-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule } from '@angular/material';
import { AppRoutingModule } from '../app-routing.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { ConfirmModalComponent } from './confirm-modal/confirm-modal.component';

@NgModule({
  declarations: [MyNavComponent, ConfirmModalComponent],
  imports: [
    CommonModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    AppRoutingModule,
    AngularFontAwesomeModule
  ],
  exports: [MyNavComponent]
})
export class CommonPageModule { }
