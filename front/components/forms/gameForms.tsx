import { useState } from "react"
import { useCreateGame } from "../../hooks/useGames";

export default function GameForms()
{
    const createGame = useCreateGame();

    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [logoPath, setLogoPath] = useState("");

    function onSubmit(event)
    {
        event.preventDefault();

        let payload = {
            name: name,
            description: description,
            logoPath: logoPath,
        }
        createGame.mutate(payload, {
            onSuccess: () =>
            {
                setName("");
                setDescription("");
            }
        })
    }

    return <form onSubmit={onSubmit}>
                <label>
                    Name: 
                </label>
                <input type = "text" 
                value = {name}
                onChange={(e) => setName(e.target.value)}
                placeholder = "Digite o nome do jogo"
                required></input>

                <label>Description: </label>
                <textarea
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                required>
                </textarea>

                
                <label>Imagem: </label>
                <input type = "text"
                value={logoPath}
                onChange={(e) => setLogoPath(e.target.value)}
                required>
                </input>

                <button type = "submit" disabled = {createGame.isPending}>
                    {createGame.isPending ? "Carregando..." : "Criar jogo"} 
                </button>   
            </form>
}