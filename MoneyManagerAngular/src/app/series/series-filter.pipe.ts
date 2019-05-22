import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'SeriesFilterPipe' })

export class SeriesFilterPipe implements PipeTransform {
    transform(seriesDetails: any[], seriesName:any, previousSeriesStartDate: Date, previousSeriesEndDate: Date, nextSeriesStartDate: Date, nextSeriesEndDate: Date, isDownloadableToday: number, filterEnabled: boolean) {
        //return original list if filtered button is not clicked

        if (!filterEnabled ) {
            return seriesDetails;
        }

        if (isDownloadableToday && isDownloadableToday == -1) {
            seriesDetails =  seriesDetails;
        }

        //if series date is not empty, select value satisfying date range filter
        if (previousSeriesStartDate || previousSeriesEndDate && (previousSeriesStartDate <= previousSeriesEndDate)) {
            seriesDetails = seriesDetails.filter(
                item =>
                    new Date(previousSeriesEndDate).getDate() >= new Date(item.previousEpisodeAirdate).getDate()
                    && new Date(item.previousEpisodeAirdate).getDate() >= new Date(previousSeriesStartDate).getDate()
            );
        }

        //if series date is not empty, select value satisfying date range filter
        if (nextSeriesStartDate || nextSeriesEndDate && (nextSeriesStartDate <= nextSeriesEndDate)) {
            seriesDetails = seriesDetails.filter(
                item =>
                    new Date(nextSeriesEndDate).getDate() >= new Date(item.nextEpisodeAirdate).getDate()
                    && new Date(item.nextEpisodeAirdate).getDate() >= new Date(nextSeriesStartDate).getDate()
            );
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
                item => item.onDownloadToday
            );
        }

        //if seriesDetails is not empty the filter series by seriesDetails
        if (isDownloadableToday && isDownloadableToday == 0) {
            seriesDetails = seriesDetails.filter(
                item => !item.onDownloadToday
            );
        }

        //return filtered list
        return seriesDetails;
    }
}