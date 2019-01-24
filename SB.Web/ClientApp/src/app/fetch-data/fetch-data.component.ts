import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public renderModels: RenderModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<RenderModel[]>(baseUrl + 'api/Renders/1/20').subscribe(result => {
      this.renderModels = result;
    }, error => console.error(error));
  }
}
interface RenderModel {
  renderRawId: number;
  identity: number;
  junk1: number;
  offset: number;
  unCompressedSize: number;
  compressedSize: number;
  order: number;
  name: string;
  data: string;
}
