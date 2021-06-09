import { Car } from "./car";

export interface Client {

    id: number;
    username: string;
    city: string;
    cars: Car;

}
