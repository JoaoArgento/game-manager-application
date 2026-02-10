import APIClient from "./APIClient";

async function getAll()
{
    const response = await APIClient.get("/games");
    return response.data;
}
async function getById(id)
{
    const response = await APIClient.get(`/games/${id}`);
    return response.data;
}

async function createGame(payload)
{
    const newGame = await APIClient.post("/games", payload);
}

const gameService = {
    getAll,
    getById,
    createGame,
}

export default gameService;