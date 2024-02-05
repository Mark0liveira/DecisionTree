import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { ActionResult } from '../../microsoft/asp-net-core/mvc/models';
import type { ContentManagementDto } from '../services/dtos/models';

@Injectable({
  providedIn: 'root',
})
export class ContentManagementService {
  apiName = 'Default';
  

  getAll = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, ActionResult>({
      method: 'GET',
      url: '/api/content-manager',
    },
    { apiName: this.apiName,...config });
  

  getCMSContentById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ActionResult>({
      method: 'GET',
      url: `/api/content-manager/${id}`,
    },
    { apiName: this.apiName,...config });
  

  insertOrUpdateCMSContentByModel = (model: ContentManagementDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ActionResult>({
      method: 'POST',
      url: '/api/content-manager',
      body: model,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
