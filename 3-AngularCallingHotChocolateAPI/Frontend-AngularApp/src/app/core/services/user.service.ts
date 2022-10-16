import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { allData } from '../graphql/queries/todo.query';
import { allusers } from '../graphql/queries/user.query';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  private baseUrl;

  constructor(private httpClient: HttpClient) {
    this.baseUrl = `${environment.baseUrl}/user`;
  }

  allUsersQuery() {
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    
    return this.httpClient.post(this.baseUrl, allusers, httpOptions);
  }

  allDataQuery() {
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    
    return this.httpClient.post(this.baseUrl, allData, httpOptions);
  }
}
