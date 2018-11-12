import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-logs',
  templateUrl: './logs.component.html'
})
export class LogsComponent {
  private httpClient: HttpClient;
  private apiUrl: string;

  public logs: Log[];
  public blockName: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl = baseUrl;
    this.httpClient = http;
  }


  public findLogs() {
    if (this.blockName != null) {
        this.httpClient.get<Log[]>(this.apiUrl + 'api/Logging/' + this.blockName).subscribe(result => {
        this.logs = result;
      }, error => alert('    ERROR: ' + error));
    } else {
      alert('invalid block name');
    }
  }

}

interface Log {
  id: string;
  message: string;
  timeStamp: Date;
  type: string;
  blockOrigin: string;
}
