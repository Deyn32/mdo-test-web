import { Injectable, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ConnectionInfos } from '../models/connection.infos';
import { Observable } from 'rxjs';

@Injectable()
export class SessionService {

  private apiUrl = 'api/sql/server';

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }


  getDbVersion(): Observable<string> {
    return this.http.get(`${this.apiUrl}/version`, { responseType: 'text' });
  }

  openConnection(): Observable<ConnectionInfos> {
    return this.http.get<ConnectionInfos>(`${this.apiUrl}/open`);
  }

  closeConnection(): Observable<ConnectionInfos> {
    return this.http.get<ConnectionInfos>(`${this.apiUrl}/close`);
  }
}
