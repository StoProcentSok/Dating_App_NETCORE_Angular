import { Component, Input, OnInit } from '@angular/core';
import { AppEvent } from 'src/app/_models/appEvent';

@Component({
  selector: 'app-event-card',
  templateUrl: './event-card.component.html',
  styleUrls: ['./event-card.component.css']
})
export class EventCardComponent implements OnInit {
  @Input() appevent: AppEvent;
  constructor() { }

  ngOnInit(): void {
  }

}
