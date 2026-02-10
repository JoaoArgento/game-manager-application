"use client"
import { useGames } from "../hooks/useGames";
import GameForms from "../components/forms/gameForms";
import GameCards from "../components/card/gameCards";
export default function GamePage()
{
    const {data: games, isError} = useGames();
    if (isError)
    {
        return <div>Deu pau!</div>
    }

    return <div>
            <GameCards games = {games}/>
            <GameForms/>
        </div>
}