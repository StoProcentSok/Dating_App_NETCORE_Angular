import { Component, OnInit, Pipe, PipeTransform } from '@angular/core';
import { UrlSegmentGroup } from '@angular/router';
import { Observable, pipe } from 'rxjs';
import { Member } from 'src/app/_models/member';
import { Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { UserParams } from 'src/app/_models/userParams';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-scoreboard',
  templateUrl: './scoreboard.component.html',
  styleUrls: ['./scoreboard.component.css'],
  
})
export class ScoreboardComponent implements OnInit {
  members: Member[];
  userParams: UserParams;
  user: User;
  
  constructor(private memberService : MembersService) { 
    this.userParams = this.memberService.getUserParams();
  }

  ngOnInit(): void {
    this.loadMembers();
    this.members = this.members.sort(e => e.score);
  }

  loadMembers(){
     this.memberService.getAllMembers().subscribe(response => {
      this.members = response;
    })
    this.members.sort(e => e.age);
  }
}


