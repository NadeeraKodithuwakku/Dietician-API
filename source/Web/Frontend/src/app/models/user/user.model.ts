import { SignInModel } from "../auth/signIn.model";

export class UserModel {
    id!: number;
    name!: string;
    surname!: string;
    email!: string;
    signIn!: SignInModel;
}
