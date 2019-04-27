import { Component, OnInit } from '@angular/core';
import { SeriesService } from '../series.service';
import { AppComponent } from 'src/app/app.component';
import { KeyedCollection } from 'src/app/Collection/keyed-collection';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-view-series',
  templateUrl: './view-series.component.html',
  styleUrls: ['./view-series.component.css']
})
export class ViewSeriesComponent implements OnInit {

  constructor(private seriesService: SeriesService, private appComponent: AppComponent) { }

  seriesList: any[] = [];
  seriesDetails: any[] = [];
  seriesWikiList: any[] = [];
  seriesImageList: any[] = [];
  seasonToggleClicked: any[] = [];
  episodeToggleClicked: any[] = [];
  wikiToggleClicked: any[] = [];
  seriesEpisodeList: KeyedCollection<any[]>;
  seriesSeasonList: any[] = [];
  size: any;
  today = new Date();
  noImage: any = "assets/no_image.png"

  ngOnInit() {
    this.seriesEpisodeList = new KeyedCollection<any[]>();
    this.initialiizeSeriesList();
  }

  initialiizeSeriesList() {
    this.today.setDate(this.today.getDate() - 1);
    this.seriesService.getSeries().subscribe(response => {
      this.seriesList = response;
      for (let index = 0; index < this.seriesList.length; index++) {
        this.seriesService.getShowDetails(this.seriesList[index].apiId).subscribe(response => {
          this.seriesService.getWikis(response["name"]).subscribe(response => {
            this.seriesWikiList.push(response[3]);
          });
          if (response["image"] == null) {
            this.seriesImageList.push(this.noImage);
          }
          else {
            this.seriesImageList.push(response["image"]["medium"]);
          }
          this.seasonToggleClicked.push(false);
          this.wikiToggleClicked.push(false);
          this.seriesDetails.push(response);
          this.size = 0;
          this.seriesService.getSeasons(this.seriesList[index].apiId).subscribe(seasons => {
            this.seriesSeasonList.push(seasons);
            this.episodeToggleClicked.push(false);
            for (let i = 0; i < seasons.length; i++) {
              this.size++;
              if (seasons[i].premiereDate != null) {
                this.seriesService.getEpisodes(seasons[i].id).subscribe(episodes => {
                  this.seriesEpisodeList.Add(seasons[i].id, episodes);
                  for (let j = 0; j < episodes.length; j++) {
                    if (episodes[j]["airdate"] == formatDate(this.today, 'yyyy-MM-dd', 'en')) {
                      console.log(this.seriesList[index].seriesName);
                    }
                  }
                });
              }
              else {
                this.seriesEpisodeList.Add(seasons[i].id, null);
              }

            }
          });

        })
      }
    });
    ;
  }

  toggleSeasonCollapseIcon(index: any) {
    this.seasonToggleClicked[index] = !this.seasonToggleClicked[index];
  }

  toggleEpisodeCollapseIcon(index: any) {
    this.episodeToggleClicked[index] = !this.episodeToggleClicked[index];
  }

  toggleWikiCollapseIcon(index: any) {
    this.wikiToggleClicked[index] = !this.wikiToggleClicked[index];
  }
}
