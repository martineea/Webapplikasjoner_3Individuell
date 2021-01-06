import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { KundeserviceComponent } from './kundeservice/kundeservice.component';
import { OmComponent } from './om/om.component';
import { KontaktComponent } from './kontakt/kontakt.component';
import { FAQComponent } from './FAQ/FAQ.component';

const appRoots: Routes = [
  { path: 'kundeservice', component: KundeserviceComponent },
  { path: 'om', component: OmComponent },
  { path: 'kontakt', component: KontaktComponent },
  { path: 'FAQ', component: FAQComponent },
  { path: '', redirectTo: 'kundeservice', pathMatch: 'full' }
]

@NgModule({
  imports: [
    RouterModule.forRoot(appRoots)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }