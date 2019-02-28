import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {HttpModule} from '@angular/http';
import {AppService} from './app.service';
import { ValueComponent } from './value/value.component';



@NgModule({
   declarations: [
      AppComponent,
      ValueComponent
   ],
   imports: [
      BrowserModule,
      HttpModule
   ],
   providers: [
      AppService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { 


  
}
