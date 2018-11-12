import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapComponent } from './map.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AgmCoreModule } from '@agm/core';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAn1ZkN_JGLIu1d-zS7lde-xQDN4xzR-Q4'
    }),
  ],
  declarations: [MapComponent],
  exports: [MapComponent]
})
export class MapModule { }
