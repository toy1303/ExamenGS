import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routes';
import { HttpClientModule, HttpClient } from "@angular/common/http";

@NgModule({
    declarations: [
      AppComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule
    ],
    providers: [
    ],
    bootstrap: [AppComponent]
  })
export class AppModule { }