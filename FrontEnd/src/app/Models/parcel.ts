import { Post } from "./post";

export interface Parcel {
    id?: number,
    weight: number,
    phoneNumber: number,
    text: string,
    postId?: number,
    post?: Post
}
