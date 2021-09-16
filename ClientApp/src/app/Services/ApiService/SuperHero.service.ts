import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class SuperHeroService {
  private baseUrl: string;

  constructor(
    private http: HttpClient,) {
    this.baseUrl = 'superhero/getAllHeros';
  }
  GetAllHeros() {
    return this.http.get<any>(this.baseUrl);
  }
  
  
}
