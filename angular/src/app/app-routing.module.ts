import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AnalysisComponent } from './analysis/analysis.component';
import { ReadPathComponent } from './entry/read-path/read-path.component';
import { ShowFilesComponent } from './entry/show-files/show-files.component';

const routes: Routes = [
  {path:'upload', component:ReadPathComponent},
  {path:'analyse', component:AnalysisComponent},
  {path:'files', component:ShowFilesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
