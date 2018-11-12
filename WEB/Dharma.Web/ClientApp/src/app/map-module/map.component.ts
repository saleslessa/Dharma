import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Marker } from './Marker';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {

  private httpClient: HttpClient;
  private apiUrl: string;
  // google maps zoom level
  private zoom = 13;

  // initial center position for the map
  public lat = 51.426760;
  public lng = 5.478174;
  public radius = 2;

  public markers: Marker[];
  public selectedItem: Marker;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl = baseUrl;
    this.httpClient = http;
    this.findLocation();
  }

  ngOnInit(): void {
    if (window.navigator.geolocation) {
      window.navigator.geolocation.getCurrentPosition(position => {
        this.lat = position.coords.latitude;
        this.lng = position.coords.longitude;
      });
      }
  }

  public clickedMarker(index: number) {
    this.selectedItem = this.markers[index];
  }

  public findLocation() {
      this.httpClient.get<Marker[]>(this.apiUrl + 'api/Organization/ListFromArea/'
      + this.lat + '/' + this.lng + '/' + this.radius)
      .subscribe(result => {
      this.markers = result;
    }, error => alert('    ERROR: ' + error));

  }
}

