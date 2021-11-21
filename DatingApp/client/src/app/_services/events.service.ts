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

getEvent(id: string): Observable<AppEvent>{
  return this.http.get<AppEvent>(this.baseUrl + 'events/getevent/' + id, {});
}

getEvents(): Observable<AppEvent[]>{
  return this.http.get<AppEvent[]>(this.baseUrl + 'events/getevents');
}

registerToEvent(appEvent: AppEvent){
  return this.http.post(this.baseUrl + 'events/register/' + appEvent.id, {});
} 

//TODO refactor: Get all participants earlier and just return collection count, we will need participants to
//show who already joined event
getParticipantsCount(appEvent: AppEvent){
  
  return this.http.get<number>(this.baseUrl + 'events/' + appEvent.id + '/participantsCount', {});
}

}