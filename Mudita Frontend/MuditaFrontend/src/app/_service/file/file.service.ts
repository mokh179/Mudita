import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor(private http:HttpClient) { }
  
  uploadProfile(username: string, formData: FormData) {
    return this.http.post(`https://localhost:44352/api/File/uploadUserProfile/${username}`, formData);
  }
  uploadcompanyProfile(username: number, formData: FormData) {
    return this.http.post(`https://localhost:44352/api/File/uploadCompanyProfile/${username}`, formData);
  }

  GetFiles(path: string) {
    return this.http.get('https://localhost:44352/api/File/getfile/'+path);
  }
  GetProfileCompany(path:string){
    return this.http.get('https://localhost:44352/api/File/getCompanyProfile/'+path);
  }
  
  DownloadResume(cv:string){
    return this.http.get('https://localhost:44352/api/File/download/'+cv,{
      observe: 'events',
      responseType: 'blob',
    });
  }
  
}
