import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UserModel } from "../models/user/user.model";
import { environment } from "../../environments/environment";

@Injectable({ providedIn: "root" })
export class AppUserService {
    constructor(private readonly http: HttpClient) { }

    add(model: UserModel) {
        return this.http.post<number>(environment.userAPI, model);
    }

    delete(id: number) {
        return this.http.delete(`${environment.userAPI}/${id}`);
    }

    get(id: number) {
        return this.http.get<UserModel>(`${environment.userAPI}/${id}`);
    }

    list() {
        return this.http.get<UserModel[]>(environment.userAPI);
    }

    update(model: UserModel) {
        return this.http.put(`${environment.userAPI}/${model.id}`, model);
    }
}
