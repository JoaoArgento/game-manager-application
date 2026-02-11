import { useState } from "react";
import { useCreateGame } from "./useGames";
import { CreateGameDTO } from "../types/GameDTO";
export function useModifyGame()
{
    const createGameMutation = useCreateGame();
    const [gameId, setGameId] = useState("");
    const [isChanging, setIsChanging] = useState(false);
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [modifyConfirmText, setModifyConfirmText] = useState("");

    function startCreatingGame()
    {
        updateModifyType("Criar novo jogo", "Preencha os dados", "Criar");
    }

    function confirmModify(gameInfo : CreateGameDTO, onSuccess: () => void)
    {
        if (isUpdatingAGame())
        {   
                // atualiza o jogo
        }
        else
        {
            createGameMutation.mutate(gameInfo);
            
        }
        onSuccess();
        resetModify();
    }

    function startEditingGame(gameId)
    {
        updateModifyType("Editar jogo", "Preencha os dados", "Editar");
        setGameId(gameId);
    }

    function updateModifyType(title: string, description: string, modifyConfirmText: string)
    {
        setIsChanging(true);

        setTitle(title);
        setDescription(description);
        setModifyConfirmText(modifyConfirmText);
    }

    function resetModify()
    {
        setTitle("");
        setDescription("")
        setModifyConfirmText("")
        setIsChanging(false);
        setGameId("");
    }

    function isUpdatingAGame(){
        return gameId != "";
    }

    return {
        isChanging,
        title,
        description,
        modifyConfirmText, 
        startCreatingGame,
        startEditingGame,
        confirmModify,
        resetModify,
    }
}