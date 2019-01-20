import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MoneyManagerAngular';

  constructor() { }
  filterEnabled: boolean = false;

  //function to toggle filtering
  toggleFilter(): void {
    this.filterEnabled = !this.filterEnabled;
  }
}
