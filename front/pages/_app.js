import APIClient from "../services/APIClient.js";
import { useState, useEffect} from "react";
function Home()
{
    const [games, setGames] = useState([])

    useEffect(() =>
    {
        getGames();

        async function getGames()
        {
            const games = await APIClient.get("/games");
            console.log(games);
            setGames(games.data);
        }
        
    }, []);

    return <div>
        <h1 className = "text-3xl font-bold underline white">Games</h1>

        {games.length > 0 &&
            games.map((game, index) =>
            {
                return <div key = {index}>
                    <p>Game name: {game.name}</p>
                    <p>{game.description}</p>
                </div>
            })
        }
    </div>
}

export default Home;