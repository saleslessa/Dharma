import { MapModule } from './map-module/map.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import {ItemsComponent} from './items/items.component';
import {LogsComponent} from './logs/logs.component';

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NgModule } from '@angular/core';
import { MapComponent } from './map-module/map.component';

@NgModule({
   declarations: [
      AppComponent,
      NavMenuComponent,
      HomeComponent,
      CounterComponent,
      FetchDataComponent,
      ItemsComponent,
      LogsComponent
   ],
   imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'items', component: ItemsComponent },
      { path: 'logs', component: LogsComponent },
      { path: 'map', component: MapComponent },
    ]),
    MapModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
