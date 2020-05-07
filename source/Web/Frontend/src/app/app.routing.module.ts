import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppRouteGuard } from "./core/guards/route.guard";
import { AppLayoutMainComponent } from "./layouts/layout-main/layout-main.component";
import { AppLayoutComponent } from "./layouts/layout/layout.component";

const routes: Routes = [
    {
        path: "",
        component: AppLayoutComponent,
        children: [
            {
                path: "",
                loadChildren: () => import("./views/signin/signin.module").then((x) => x.AppSignInModule)
            }
        ]
    },
    {
        path: "main",
        component: AppLayoutMainComponent,
        canActivate: [AppRouteGuard],
        children: [
            {
                path: "files",
                loadChildren: () => import("./views/main/files/files.module").then((x) => x.AppFilesModule)
            },
            {
                path: "form",
                loadChildren: () => import("./views/main/form/form.module").then((x) => x.AppFormModule)
            },
            {
                path: "home",
                loadChildren: () => import("./views/main/home/home.module").then((x) => x.AppHomeModule)
            },
            {
                path: "list",
                loadChildren: () => import("./views/main/list/list.module").then((x) => x.AppListModule)
            }
        ]
    },
    { path: "**", redirectTo: "" }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
