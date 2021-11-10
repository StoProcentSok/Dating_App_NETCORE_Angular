import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AppEvent } from '../_models/appEvent';
import { User } from '../_models/user';
import { UserParams } from '../_models/userParams';

@Injectable({
  providedIn: 'root'
})
export class EventsService {
  baseUrl = environment.apiUrl;


  constructor(private http: HttpClient) { }


getEvents(): Observable<AppEvent[]>{
  return this.http.get<AppEvent[]>(this.baseUrl + 'events/getevents');
}



}