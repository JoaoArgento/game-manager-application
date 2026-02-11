import { CreateGameDTO } from "../types/GameDTO";
import APIClient from "./APIClient";

async function getAll()
{
    const response = await APIClient.get("/games");
    return response.data;
}
async function getById(id : string)
{
    const response = await APIClient.get(`/games/${id}`);
    return response.data;
}
async function updateById(id: string)
{
    const response = await APIClient.patch(``)
}

async function createGame(payload : CreateGameDTO)
{
    const newGame = await APIClient.post("/games", payload);
}
async function deleteGame(id :string)
{
    const response = await APIClient.delete(`/games/${id}`);
}

const gameService = {
    getAll,
    getById,
    createGame,
    deleteGame,
}

export default gameService;