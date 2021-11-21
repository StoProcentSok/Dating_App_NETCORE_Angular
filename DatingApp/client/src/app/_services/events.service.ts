import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
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

getParticipantsCount(appEvent: AppEvent){

  return this.http.get<number>(this.baseUrl + 'events/' + appEvent.id + '/participantsCount', {});
}

createEvent(model: any){
  return this.http.post<AppEvent>(this.baseUrl + 'events/AddEventFromForm', model).pipe(
    
  )
}

}