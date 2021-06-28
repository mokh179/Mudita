import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { City } from 'src/app/_models/City/city';
import { Country } from 'src/app/_models/Country/country';

@Injectable({
  providedIn: 'root',
})
export class LocationService {
  constructor(private http: HttpClient) {}
  getAllCountries() {
    return this.http.get<Country[]>('https://localhost:44352/api/Location/Country');
  }
  getCountry(id: number) {
    return this.http.get<Country>(
      'https://localhost:44352/api/Location/Country/' + id
    );
  }

  getCitiesBYCountry(countryid: number) {
    return this.http.get<City[]>(
      'https://localhost:44352/api/Location/cityBYcounty/' + countryid
    );
  }
  getCity(id: number) {
    return this.http.get<City>(
      'https://localhost:44352/api/Location/city/' + id
    );
  }
}
