import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, timer } from 'rxjs';
import { BaseService } from '../base.service';
import { tap, retryWhen, delayWhen } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class SeriesService {

  constructor(private httpClient: HttpClient, private baseService: BaseService) { }
  baseUrl: String = "Series/";

  getShowDetails(apiId: any): Observable<any[]> {
    return this.httpClient.get<any>(`${'http://api.tvmaze.com/shows'}/${apiId}`).pipe(
      retryWhen(errors =>
        errors.pipe(
          //log error message
          tap(val => console.log(`Value ${val} was too high!`)),
          //restart in 5 seconds
          delayWhen(val => timer(val * 1000))
        )
      ));
  }

  getEpisodes(apiId: any): Observable<any[]> {
    return this.httpClient.get<any>(`${'http://api.tvmaze.com/seasons'}/${apiId}/episodes`).pipe(
      retryWhen(errors =>
        errors.pipe(
          //log error message
          tap(val => console.log(`Value ${val} was too high!`)),
          //restart in 5 seconds
          delayWhen(val => timer(val * 1000))
        )
      ));
  }

  getSeasons(apiId: any): Observable<any[]> {
    return this.httpClient.get<any>(`${'http://api.tvmaze.com/shows'}/${apiId}/seasons`).pipe(
      retryWhen(errors =>
        errors.pipe(
          //log error message
          tap(val => console.log(`Value ${val} was too high!`)),
          //restart in 5 seconds
          delayWhen(val => timer(val * 1000))
        )
      ));
  }

  getSeries(): Observable<any[]> {
    //returns list of expense details from api
    return this.baseService.getData(this.baseUrl + 'GetSeries');
    // return this.http.get<SeriesFull>(`${'http://api.tvmaze.com/singlesearch/shows'}/?q=${name}`);
    //return this.http.get<Episode[]>('http://api.tvmaze.com/shows/'+id+'/episodes');
  }

  getWikis(searchString: any): Observable<any[]> {
    var options = {
      headers: this.baseService.getCommonHeaders()
};
    return this.httpClient.get<any>(`${'https://en.wikipedia.org/w/api.php?action=opensearch&format=json&origin=*&search='}${searchString}`).pipe(
      retryWhen(errors =>
        errors.pipe(
          //log error message
          tap(val => console.log(`Value ${val} was too high!`)),
          //restart in 5 seconds
          delayWhen(val => timer(val * 1000))
        )
      ));
  }
}
