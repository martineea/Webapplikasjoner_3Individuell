import { Component, OnInit, NgModule, ViewChild, ViewChildren } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, FormsModule } from '@angular/forms';
import { NgbModal, NgbPanelChangeEvent, NgbPanel, NgbRatingConfig, NgbAccordion } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { FAQ } from './FAQ';
import { kontakt } from '../kontakt/kontakt';
import { Kategori } from './Kategori';

@Component({
  selector: 'app-root',
  templateUrl: './FAQ.component.html'
})
export class FAQComponent {
  laster: boolean;
  alleFAQ: Array<FAQ>;
  alleKontakter: Array<kontakt>;
  alleKategorier: Array<Kategori>;

  /* Disabler rating-knappen når en av de trykkes på */
  klikket = Array(2).fill(false);

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.laster = true;
    this.hentAlleFAQ();
    this.hentAlleKontakter();
    this.hentAlleKategorier(); 
  }

  hentAlleFAQ() {
    this.laster = true;
    this.http.get<FAQ[]>("api/FAQ/hentFAQ")
      .subscribe(FAQ => {
        FAQ.sort((a, b) => {
          return a.jaStemme > b.jaStemme ? -1 : 1;
        }),
          this.alleFAQ = FAQ;
      }),
      error => console.log(error),
      () => console.log("FAQ lastet ferdig")
  };

  hentAlleKontakter() {
    this.laster = true;
    this.http.get<kontakt[]>("api/FAQ/hentKontakter")
      .subscribe(Kontakt => {
        this.alleKontakter = Kontakt;
        this.laster = false;
      },
        error => console.log(error),
        () => console.log("Nye spørsmål lastet ferdig")
      );
  };

  hentAlleKategorier() { 
    this.laster = true;
    this.http.get<Kategori[]>("api/FAQ/kategorier")
      .subscribe(Kategori => {
        this.alleKategorier = Kategori;
        this.laster = false;
      },
        error => console.log(error),
        () => console.log("Kategorier lastet")
      );
  };

  stemmerJa(id: number) {
    let stemmer = this.alleFAQ.find(s => s.id === id);
    stemmer.jaStemme++;

    this.http.post("api/FAQ/ja", id)
      .subscribe(retur => {
        this.router.navigate(['/FAQ']);
        this.laster = false;
      },
        error => console.log(error),
        () => console.log("Stemme: ja")
      );
  };

  stemmerNei(id: number) {
    let stemmer = this.alleFAQ.find(s => s.id === id);
    stemmer.neiStemme++;

    this.http.post("api/FAQ/nei", id)
      .subscribe(retur => {
        this.router.navigate(['FAQ']);
        this.laster = false;
      },
        error => console.log(error),
        () => console.log("Stemme: nei")
      );
  };
}