import { Component, OnInit, ViewChild } from '@angular/core';
import { SeriesService } from '../series.service';
import { AppComponent } from 'src/app/app.component';
import { KeyedCollection } from 'src/app/Collection/keyed-collection';
import { formatDate } from '@angular/common';
import { ModalDirective } from 'ngx-bootstrap';
import { ConfirmModalComponent } from 'src/app/commonPage/confirm-modal/confirm-modal.component';

@Component({
  selector: 'app-view-series',
  templateUrl: './view-series.component.html',
  styleUrls: ['./view-series.component.css']
})
export class ViewSeriesComponent implements OnInit {

  constructor(private seriesService: SeriesService, private appComponent: AppComponent) { }

  @ViewChild("confirmModalComponent") deleteConfirmationModal: ConfirmModalComponent;
  seriesList: any[] = [];
  seriesDetails: any[] = [];
  seriesWikiList: any[] = [];
  seriesImageList: any[] = [];
  seasonToggleClicked: any[] = [];
  episodeToggleClicked: any[] = [];
  wikiToggleClicked: any[] = [];
  seriesEpisodeList: any[] = [];
  seriesSeasonList: any[] = [];
  onDownloadTodayList: any[] = [];
  nextEpisodeDetails: any[] = [];
  previousEpisodeDetails: any[] = [];
  nullEpisode = {
    name: "",
    airdate: ""
  }
  size: any;
  today = new Date();
  noImage: any = "assets/no_image.png"

  ngOnInit() {
    this.initialiizeSeriesList();
  }

  initialiizeSeriesList() {
    this.today.setDate(this.today.getDate() - 1);
    this.seriesService.getSeries().subscribe(series => {
      this.seriesList = series;
      for (let index = 0; index < this.seriesList.length; index++) {
        this.nextEpisodeDetails[this.seriesList[index].apiId] = this.nullEpisode;
        this.seriesService.getShowDetails(this.seriesList[index].apiId).subscribe(response => {

          if (response["_links"]["nextepisode"] != null) {
            this.seriesService.getEpisodeDetails(response["_links"]["nextepisode"]["href"]).subscribe(episode => {
              episode["seriesId"] = this.seriesList[index].apiId;
              this.nextEpisodeDetails[this.seriesList[index].apiId] = episode;
            });
          }
          if (response["image"] == null) {
            this.seriesImageList[this.seriesList[index].apiId] = this.noImage;
          }
          else {
            this.seriesImageList[this.seriesList[index].apiId] = response["image"]["medium"];
          }
          if (response["_links"]["previousepisode"] != null) {
            this.seriesService.getEpisodeDetails(response["_links"]["previousepisode"]["href"]).subscribe(episode => {
              if (episode["airdate"] == formatDate(this.today, 'yyyy-MM-dd', 'en')) {
                this.onDownloadTodayList.push(this.seriesList[index].apiId);
                this.previousEpisodeDetails[this.seriesList[index].apiId] = episode;
              }
              else {
                this.previousEpisodeDetails[this.seriesList[index].apiId] = this.nullEpisode;
              }
            });
          }
          else {
            this.previousEpisodeDetails[this.seriesList[index].apiId] = this.nullEpisode;
          }
          this.seasonToggleClicked[series["id"]] = false;
          this.wikiToggleClicked[series["id"]] = false;
          this.seriesDetails.push(response);
        })
      }
    });
    ;
  }

  toggleSeasonCollapseIcon(seriesId: any) {
    this.seasonToggleClicked[seriesId] = !this.seasonToggleClicked[seriesId];
    if (this.seriesSeasonList[seriesId] == undefined) {
      this.seriesService.getSeasons(seriesId).subscribe(seasons => {
        this.seriesSeasonList[seriesId] = seasons;
        this.episodeToggleClicked[seasons["id"]] = false;
      });
    }
  }

  toggleEpisodeCollapseIcon(seriesId: any, seasonId: any) {
    this.episodeToggleClicked[seasonId] = !this.episodeToggleClicked[seasonId];
    if (this.seriesEpisodeList[seasonId] == undefined) {
      if (this.seriesSeasonList[seriesId].filter(x => x.id == seasonId)[0]["premiereDate"] != null) {
        this.seriesService.getEpisodes(seasonId).subscribe(episodes => {
          this.seriesEpisodeList[seasonId] = episodes;
        });
      }
      else {
        this.seriesEpisodeList[seasonId] = [];
      }
    }
  }

  toggleWikiCollapseIcon(seriesId: any, seriesName: any) {
    this.wikiToggleClicked[seriesId] = !this.wikiToggleClicked[seriesId];

    if (this.seriesWikiList[seriesId] == undefined) {
      this.seriesService.getWikis(seriesName).subscribe(wiki => {
        this.seriesWikiList[seriesId] = wiki[3];
      });
    }
  }

  open() {
    this.deleteConfirmationModal.show(null);
  }
}
