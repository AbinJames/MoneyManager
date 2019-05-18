import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MoneyManagerAngular';
  searchString: string;

  constructor() { }
  filterEnabled: boolean = false;

  //function to toggle filtering
  toggleFilter(): void {
    this.filterEnabled = !this.filterEnabled;
  }

  getDownloadLink(name: any, season: number, episode: any): string {
    this.searchString = name + " s" + ((Math.floor(season / 10) > 0) ? String(season) : "0" + String(season)) + "e" + ((Math.floor(episode / 10) > 0) ? String(episode) : "0" + String(episode));
    return `${'https://1337x.to/search/'}/${this.searchString}/${'/1/'}`;
  }
}
