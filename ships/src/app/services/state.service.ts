import { Injectable } from '@angular/core';

@Injectable()
export class StateService {
  isAuth = false;

  constructor() {}

  logInUser() {
    this.isAuth = true;
  }

  logOutUser() {
    this.isAuth = false;
  }
}
