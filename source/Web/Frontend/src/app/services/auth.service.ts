import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AppTokenService } from "../core/services/token.service";
import { SignInModel } from "../models/auth/signIn.model";
import { TokenModel } from "../models/auth/token.model";

@Injectable({ providedIn: "root" })
export class AppAuthService {
    constructor(
        private readonly http: HttpClient,
        private readonly router: Router,
        private readonly appTokenService: AppTokenService) { }

    signIn(model: SignInModel): void {
        this.http
            .post<TokenModel>("Auths", model)
            .subscribe((result) => {
                if (!result || !result.token) { return; }
                this.appTokenService.set(result.token);
                this.router.navigate(["/main/home"]);
            });
    }

    signOut() {
        this.appTokenService.clear();
        this.router.navigate(["/login"]);
    }
}
