import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { StateService } from './services/state.service';

import { AppComponent } from './app.component';
import { AuthComponent } from './auth/auth.component';
import { GameWrapperComponent } from './game-wrapper/game-wrapper.component';


@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    GameWrapperComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [StateService],
  bootstrap: [AppComponent]
})
export class AppModule { }
