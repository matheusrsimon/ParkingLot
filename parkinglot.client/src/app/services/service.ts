import { HttpClient } from "@angular/common/http";
import { Observable, map } from "rxjs";
import { Injectable } from "@angular/core";
import { StringHelper } from "../helpers/string.helper";

@Injectable()
export abstract class Service<TEntity> {
  protected readonly baseUrl: string;
  protected readonly http: HttpClient;

  public constructor(baseUrl: string, http: HttpClient) {
    this.baseUrl = baseUrl;
    this.http = http;
  }

  public abstract toEntity(apiDto: any): TEntity;
  public abstract toApiDto(entity: TEntity): any;

  protected getOne(action: string, id: number): Observable<TEntity | undefined> {
    const url = `${this.concatUrl(this.baseUrl, action)}?id=${id}`;
    return this.http.get<any>(url).pipe(
      map(this.toEntity)
    );
  }

  protected getMany(action: string, filter?: Partial<TEntity>): Observable<TEntity[]> {
    let url = this.concatUrl(this.baseUrl, action);
    if (filter) {
      url = `${url}?${Object.keys(filter).map(k => `${k}=${filter[k as keyof TEntity]}`).join('&')}`;
    }
    return this.http.get<any[]>(url).pipe(
      map(result => result.map<TEntity>(this.toEntity))
    );
  }

  protected postOne(action: string, entity: TEntity): Observable<TEntity | undefined> {
    const url = this.concatUrl(this.baseUrl, action);
    return this.http.post<number | null>(url, entity).pipe(map(result => result ? { ...entity, id: result } : undefined));
  }

  protected putOne(action: string, entity: TEntity): Observable<TEntity | undefined> {
    const url = this.concatUrl(this.baseUrl, action);
    return this.http.put<boolean>(url, entity).pipe(map(result => result ? entity : undefined));
  }

  protected deleteOne(action: string, id: number): Observable<boolean> {
    const url = `${this.concatUrl(this.baseUrl, action)}?id=${id}`;
    return this.http.delete<boolean>(url);
  }

  protected concatUrl(...parts: any[]): string {
    let url: string = parts.map(part => StringHelper.trim(part, '/')).join('/');
    return url.startsWith('http') ? url : `/${url}`;
  }
}
