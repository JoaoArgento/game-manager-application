"use client"
import { useGames, useDeleteGame, useCreateGame } from "../hooks/useGames";
import GameForms from "../components/forms/gameForms";
import GameCards from "../components/card/gameCards";

export default function GamePage()
{
    const {data: games, isError} = useGames();
    const deleteGame = useDeleteGame();
    
    if (isError)
    {
        return <div>Deu pau!</div>
    }


    return <div>
            <GameCards  games = {games} 
                        onDelete = {(id: string) => {deleteGame.mutate(id)}} 
                        onEdit={null}/>

            <GameForms createGame = {useCreateGame()}/>
        </div>
}