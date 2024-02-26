import { HttpClient } from "@angular/common/http";
import { Observable, map } from "rxjs";
import { Injectable } from "@angular/core";
import { Service } from "./service";

@Injectable()
export abstract class CrudService<TEntity> extends Service<TEntity> {
  public constructor(baseUrl: string, http: HttpClient) {
    super(baseUrl, http);
  }

  public find(id: number): Observable<TEntity | undefined> {
    return this.getOne('find', id);
  }

  public filter(filter?: Partial<TEntity>): Observable<TEntity[]> {
    return this.getMany('filter', filter);
  }

  public create(entity: TEntity): Observable<TEntity | undefined> {
    return this.postOne('', entity);
  }

  public update(entity: TEntity): Observable<TEntity | undefined> {
    return this.putOne('', entity);
  }

  public delete(id: number): Observable<boolean> {
    return this.deleteOne('', id);
  }
}
