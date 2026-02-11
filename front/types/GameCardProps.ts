import { GameDTO } from "./GameDTO"

export type GameCardProps =  
{
    games: GameDTO[]
    onDelete: (id:string) => void;
    onEdit: (id:string) => void,
}