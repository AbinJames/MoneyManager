import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'SeriesFilterPipe' })

export class SeriesFilterPipe implements PipeTransform {
    transform(seriesDetails: any[], seriesName:any, seriesStartDate: Date, seriesEndDate: Date, isDownloadableToday: number, filterEnabled: boolean,onDownloadTodayList:any[], nextEpisodeList:any[]) {
        //return original list if filtered button is not clicked

        if (!filterEnabled ) {
            return seriesDetails;
        }

        if (isDownloadableToday && isDownloadableToday == -1) {
            return seriesDetails;
        }

        //if series date is not empty, select value satisfying date range filter
        if (seriesStartDate || seriesEndDate && (seriesStartDate <= seriesEndDate)) {
            nextEpisodeList = nextEpisodeList.filter(
                item =>
                    new Date(seriesEndDate).getDate() >= new Date(item.airdate).getDate()
                    && new Date(item.airdate).getDate() >= new Date(seriesStartDate).getDate()
            );
            
            seriesDetails = seriesDetails.filter(series => {
                return nextEpisodeList.filter(episode => episode.seriesId == series.id).length != 0
            });
        }

        //if seriesDetails is not empty the filter series by seriesDetails
        if (seriesName) {
            seriesDetails = seriesDetails.filter(
                item =>
                    item.name.toLowerCase().includes(
                        seriesName.toLowerCase()
                    )
            );
        }

        //if seriesDetails is not empty the filter series by seriesDetails
        if (isDownloadableToday && isDownloadableToday == 1) {
            seriesDetails = seriesDetails.filter(
                item =>onDownloadTodayList.includes(item.id)
            );
        }

        //if seriesDetails is not empty the filter series by seriesDetails
        if (isDownloadableToday && isDownloadableToday == 0) {
            seriesDetails = seriesDetails.filter(
                item => !onDownloadTodayList.includes(item.id)
            );
        }

        //return filtered list
        return seriesDetails;
    }
}