import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DocDistributionDocBase, DocDistributionRowBase } from 'src/app/distribution/doc-distribution-list-base';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-ku-detail-entity',
  templateUrl: './ku-detail-entity.component.html',
})
export class KuDetailEntityComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient) { 
    this.year = 2022
  }

  entityId!: number;

  year: number

  entity!: DocDistributionDocBase
  entityRows!: DocDistributionRowBase[]

  ngOnInit(): void {
    this.entityId = this.activatedRoute.snapshot.params["id"]
    this.http.get(environment.mainEndpoint + "DocGrbs/KuDetail/Entity", {params: {id: this.entityId, withMeta: false}})
      .subscribe((e: any) => {
        this.entity = e
        this.entityRows = e.rows
//        console.log("get doc ", e)
      })
  }

}
