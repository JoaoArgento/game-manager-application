"use client"
import { useGames, useCreateGame } from "../hooks/useGames";
import { useGameRemoval } from "../hooks/useGameRemoval";
import GameForms from "../components/forms/gameForms";
import GameCards from "../components/card/gameCards";
import ConfirmModel from "../components/ui/ConfirmModal";
export default function GamePage()
{
    const gameRemoval = useGameRemoval();

    const {data: games, isError} = useGames();

    if (isError)
    {
        return <div>Deu pau!</div>
    }


    return <div>
            <GameCards  games = {games} 
                        onDelete = {gameRemoval.requestGameRemoval}
                        onEdit={null}/>
            <GameForms createGame = {useCreateGame()}/>

            <ConfirmModel isOpen = {gameRemoval.isRemovingAGame}
            onConfirm={gameRemoval.confirmGameRemoval}
            onCancel={gameRemoval.resetRemoval}/>
        </div>
}