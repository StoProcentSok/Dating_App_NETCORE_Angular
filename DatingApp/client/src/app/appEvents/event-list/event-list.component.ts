import { Component, OnInit } from '@angular/core';
import { AppEvent } from 'src/app/_models/appEvent';
import { EventsService } from 'src/app/_services/events.service';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
appEvents: AppEvent[];
  constructor(private eventService: EventsService) { }

  ngOnInit(): void {
    this.loadEvents();
  }

  loadEvents()
  {
    this.eventService.getEvents().subscribe(response => {
      this.appEvents = (response);
    })
  }

}
