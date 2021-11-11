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

  participants : number = 0;

  constructor(private eventService: EventsService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getNumber();
  }

  registerToEvent(appEvent: AppEvent){
    this.eventService.registerToEvent(appEvent).subscribe(() => {
      this.toastr.success('You joined event: ' + this.appevent.eventName);
    })
  }

  getParticipantsCount(appEvent: AppEvent){
    this.eventService.getParticipantsCount(appEvent).subscribe(data => 
      this.participants = data)
    }

  getNumber(){
    this.participants =  Math.floor(Math.random() * (15 - 0)) + 0;
  }

}