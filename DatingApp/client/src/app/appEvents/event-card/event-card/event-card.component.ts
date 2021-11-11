import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AppEvent } from 'src/app/_models/appEvent';
import { EventsService } from 'src/app/_services/events.service';

@Component({
  selector: 'app-event-card',
  templateUrl: './event-card.component.html',
  styleUrls: ['./event-card.component.css']
})
export class EventCardComponent implements OnInit {
  @Input() appevent: AppEvent;

  constructor(private eventService: EventsService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  registerToEvent(appEvent: AppEvent){
    this.eventService.registerToEvent(appEvent).subscribe(() => {
      this.toastr.success('You joined event: ' + this.appevent.eventName);
    })
  }

}
