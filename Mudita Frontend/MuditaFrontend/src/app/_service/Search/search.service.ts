import { Search } from './../../_models/Search/search';
import { City } from 'src/app/_models/City/city';
import { Country } from 'src/app/_models/Country/country';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from 'src/app/_models/Category/category';
import { AllCompanyDataModel } from 'src/app/_models/company/all-company-data-model';
@Injectable({
  providedIn: 'root',
})
export class SearchService {
  constructor(private http: HttpClient) {}
  getAllCountries() {

    return this.http.get<Country[]>(
      'https://localhost:44352/api/Location/Country'
    );
  }
  getAllCategory() {
    return this.http.get<Category[]>(
      'https://localhost:44352/api/Utilities/Category'
    );
  }
  getCities(countryid: number) {
    return this.http.get<City[]>(
      'https://localhost:44352/api/Location/cityBYcounty/' + countryid
    );
  }
  getCompanies(countryid?: any, cityid?: any, categoryid?: any) {
    if (categoryid == null && cityid != null && countryid != null) {
      return this.http.get<AllCompanyDataModel[]>(
        'https://localhost:44352/api/Company/Search?' +
          'countryid=' +
           countryid +
          '&cityid=' +
           cityid
      );
    } else if (countryid == null && cityid == null && categoryid != null) {
      return this.http.get<AllCompanyDataModel[]>(
        'https://localhost:44352/api/Company/Search?' +
          '&categoryid=' +
          categoryid
      );
    } else if (cityid == null && countryid != null && categoryid != null) {
      return this.http.get<AllCompanyDataModel[]>(
        'https://localhost:44352/api/Company/Search?' +
          'countryid=' +
          countryid +
          '&categoryid=' +
          categoryid
      );
    } else if (cityid == null && countryid != null && categoryid == null) {
      return this.http.get<AllCompanyDataModel[]>(
        'https://localhost:44352/api/Company/Search?' +
         'countryid=' +
          countryid
      );
    } else if(cityid != null && countryid != null && categoryid != null) {
      return this.http.get<AllCompanyDataModel[]>(
        'https://localhost:44352/api/Company/Search?' +
          'countryid=' +
          countryid +
          '&categoryid=' +
          categoryid +
          '&cityid=' +
          cityid
      );
    }
    else{
      return this.http.get<AllCompanyDataModel[]>
      ('https://localhost:44352/api/Company/Search' );
    }
  }
}
