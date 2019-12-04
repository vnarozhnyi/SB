import { Component, OnInit } from '@angular/core';
import { StateService } from '../services/state.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  nickName = '';

  constructor(private stateService: StateService) { }

  ngOnInit() {
  }

  onAuthClick() {
    this.stateService.logInUser();
  }
}
