import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EventsService } from '../_services/events.service';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.css']
})
export class CreateEventComponent implements OnInit {
  @Output() cancelCreation = new EventEmitter();
  createEventForm: FormGroup;
  constructor(private eventsService: EventsService, private fb: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.createEventForm = this.fb.group({
      eventName: ['', Validators.required],
      eventDescription: ['', Validators.required],
    })
  }

  createEvent(){
    this.eventsService.createEvent(this.createEventForm.value).subscribe(response => {
       this.router.navigateByUrl('/events');
    })
  }

  Cancel(){
    this.cancelCreation.emit(false);
  }
}
