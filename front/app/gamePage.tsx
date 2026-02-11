"use client"
import { useGames } from "../hooks/useGames";
import { useGameRemoval } from "../hooks/useGameRemoval";
import { useModifyGame } from "../hooks/useModifyGame";
import GameForms from "../components/forms/gameForms";
import GameCards from "../components/card/gameCards";
import ConfirmModel from "../components/ui/ConfirmModal";

export default function GamePage()
{
    const gameRemoval = useGameRemoval();
    const gameModifier = useModifyGame();


    const {data: games, isError} = useGames();

    if (isError)
    {
        return <div>Deu pau!</div>
    }

    function closeModals()
    {
        if (gameRemoval.isRemovingAGame)
        {
            gameRemoval.resetRemoval();
        }
        else if (gameModifier.isChanging)
        {
            gameModifier.resetModify();
        }
    }

    return <div onClick={() => closeModals()}>
            <GameCards  games = {games} 
                        onDelete = {gameRemoval.requestGameRemoval}
                        onEdit={gameModifier.startEditingGame}/>

            {gameModifier.isChanging &&
            
                <GameForms title = {gameModifier.title}
                            description = {gameModifier.description}
                            confirmText = {gameModifier.modifyConfirmText}
                            onConfirm ={gameModifier.confirmModify}
                            onCancel ={gameModifier.resetModify}/>
            }

            <ConfirmModel 
            title = "Excluir Jogo"
            description="Tem certeza que deseja excluir esse jogo?"
            isOpen = {gameRemoval.isRemovingAGame}
            onConfirm={gameRemoval.confirmGameRemoval}
            onCancel={gameRemoval.resetRemoval}/>

            <button onClick={gameModifier.startCreatingGame}>
                Criar Jogo!!!!
            </button>
        </div>
}