import { NgModule } from '@angular/core';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';
import { PruebatesComponent } from './pruebates/pruebates.component';

export const routes: Routes = [
    {
        path:'',
        component : PruebatesComponent,
    },
];
@NgModule({
    imports: [RouterModule.forRoot(routes, { useHash: true })],
    exports: [RouterModule]
  })

  export class AppRoutingModule { }