import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppEvent } from 'src/app/_models/appEvent';
import { EventsService } from 'src/app/_services/events.service';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.css']
})
export class EventDetailComponent implements OnInit {
appEvent: AppEvent;
participantsCount: number;
  constructor(private eventService: EventsService ,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadEvent();
    this.getCount();
  }

  loadEvent(){
    this.eventService.getEvent(this.route.snapshot.paramMap.get('id'))
      .subscribe(appevent => {
      this.appEvent = appevent;
    })
    
  }

  getCount(){
    this.eventService.getParticipantsCount(this.appEvent).subscribe(r => {
      this.participantsCount = r
    })
  }



}
