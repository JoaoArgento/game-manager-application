import { useState } from "react";
import { useDeleteGame } from "./useGames";

export function useGameRemoval()
{
    const [isRemovingAGame, setIsRemovingAGame] = useState(false);
    const [removingGameId, setRemovingGameId] = useState("")
    const deleteGame = useDeleteGame();

    function confirmGameRemoval()
    {
        deleteGame.mutate(removingGameId, {
            onSuccess: resetRemoval,
        });

    }
    
    function resetRemoval()
    {
        setRemovingGameId("");
        setIsRemovingAGame(false);
    }

    function requestGameRemoval(gameId : string)
    {
        setRemovingGameId(gameId);
        setIsRemovingAGame(true);
    }

    return {
        removingGameId,
        isRemovingAGame,
        requestGameRemoval,
        confirmGameRemoval,
        resetRemoval,
    }
}

