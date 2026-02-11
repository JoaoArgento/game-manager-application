import { GameDTO } from "./GameDTO"

export type Props =  
{
    games: GameDTO[]
    onDelete: (id:string) => void;
    onEdit: (id:string) => void,
}