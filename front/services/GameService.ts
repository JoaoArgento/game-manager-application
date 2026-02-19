import { describe } from "node:test";
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
async function updateById(id: string, payload : CreateGameDTO)
{
    const response = await APIClient.patch(`/games`, {
        id: id,
        name: payload.name,
        description: payload.description,
        logoPath: payload.logoPath,
    });
    return response.data;
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
    updateById,
    createGame,
    deleteGame,
}

export default gameService;