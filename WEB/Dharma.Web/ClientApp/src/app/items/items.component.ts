import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html'
})
export class ItemsComponent {
  public itemsModel: ItemsModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ItemsModel[]>(baseUrl + 'api/Items').subscribe(result => {
      this.itemsModel = result;
    }, error => console.error("    ERROR: " + error));
  }
}

interface ItemsModel {
  Name: string;
  Type: string;
  Amount: number;
}
