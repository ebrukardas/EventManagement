import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReadPathComponent } from './entry/read-path/read-path.component';
import { ShowFilesComponent } from './entry/show-files/show-files.component';

const routes: Routes = [
  {path:'upload', component:ReadPathComponent},
  {path:'files', component:ShowFilesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
