import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [new WeatherForecast("asdsa", 13, 15, "lol")];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  }
}

class WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
  constructor(date: string, temperatureC: number, temperatureF: number, summary: string)
  {
	  this.date=date;
	  this.temperatureC=temperatureC;
	  this.temperatureF=temperatureF;
	  this.summary=summary;
  }
}

