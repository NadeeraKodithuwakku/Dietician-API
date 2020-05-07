import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UserModel } from "../models/user/user.model";

@Injectable({ providedIn: "root" })
export class AppUserService {
    constructor(private readonly http: HttpClient) { }

    add(model: UserModel) {
        return this.http.post<number>("Users", model);
    }

    delete(id: number) {
        return this.http.delete(`Users/${id}`);
    }

    get(id: number) {
        return this.http.get<UserModel>(`Users/${id}`);
    }

    list() {
        return this.http.get<UserModel[]>("Users");
    }

    update(model: UserModel) {
        return this.http.put(`Users/${model.id}`, model);
    }
}
